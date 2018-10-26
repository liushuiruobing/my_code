#include "stm32f10x.h"
#include "string.h"
#include "sys.h"
#include "delay.h"
#include "usb_lib.h"
#include "ConstValue.h"
#include "JumpToCode.h"
#include "Stm32_InterFlash.h"
#include "USB_Communication.h"


u8 USB_ReceiveFlg = FALSE;
u8 USB_SendBuffer[USB_ONE_PACKAGE_SEND_SIZE] = {0};
u8 USB_ReceiveBuffer[USB_ONE_PACKAGE_SEND_SIZE] = {2};
u8 saveCodeBuf[FLASH_ADDR_APP_OFFSET] = {0};  //���ݻ������� 2048 ���ֽ�
u32 saveAppAddr = FLASH_ADDR_APP;

extern u8 sendBootPreparFlag;


//����USB ����/����
//enable:0,�Ͽ�
//       1,��������	   
//USB ����������3.3V��Դ��ͨ���Ŀ�������
void USB_ConCtrIoInit()
{
    GPIO_InitTypeDef GPIO_InitStructure;
    RCC_APB2PeriphClockCmd(RCC_APB2Periph_GPIOB, ENABLE);

	GPIO_InitStructure.GPIO_Pin = GPIO_Pin_9;
	GPIO_InitStructure.GPIO_Mode = GPIO_Mode_Out_PP;
	GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;
	GPIO_Init(GPIOB, &GPIO_InitStructure);

    GPIO_ResetBits(GPIOB, GPIO_Pin_9);
}

void USB_SendString(u8 *str, int len)
{
     for(int i = 0; i < len; i++)
     {
        USB_SendBuffer[i] = str[i];
     }
     UserToPMABufferCopy(USB_SendBuffer, ENDP2_TXADDR, USB_ONE_PACKAGE_SEND_SIZE);
     SetEPTxValid(ENDP2);
}

void USB_SendCommand(u8 nCommand, u8* pParam, u8 nParamLen)
{
    u8 sendData[USB_ONE_PACKAGE_SEND_SIZE] = {0};
    const u8 nLen = USB_PROTOCOL_SIZE + nParamLen;

    sendData[0] = 0x55;
    sendData[1] = 0xaa;
    sendData[2] = 0x01;
    sendData[3] = nLen;
    sendData[4] = nCommand;

    for(int i = 0; i < nParamLen; i++)
    {
    	sendData[5 + i] = pParam[i];
    }

    u8 cSum = 0;
    for (int j = 0; j < nLen - 1; j++)
    {
    	cSum += sendData[j];
    }

    sendData[nLen - 1] = 0 - cSum;

    UserToPMABufferCopy(sendData, ENDP2_TXADDR, USB_ONE_PACKAGE_SEND_SIZE);
    SetEPTxValid(ENDP2);
}

void USB_Communication()
{
	if(USB_ReceiveFlg == TRUE)
	{ 
    	u8 nSum = 0;      
        u8 bCommandState = 0;  
        u16 static nRecvCRC = 0;
        u16 static nCalcCRC = 0;        
        int nByteCounts = 0;
        int nCutPackage = 0;
        int nTotalPackages = 0;
        
        const int nLength = USB_ReceiveBuffer[3];
        const u8 nCommamdValue = USB_ReceiveBuffer[4];
      
        if ((USB_ReceiveBuffer[0] == 0x55) && (USB_ReceiveBuffer[1] == 0xAA) && (USB_ReceiveBuffer[2] == 0x01))
    	{
    		bCommandState = 1;
    	}

        for (int i = 0; i < nLength; i++)
    	{
    		nSum += USB_ReceiveBuffer[i];  //У��λ��֤
    	}

        if(bCommandState == 1 && nSum == 0)
        {         
            switch(nCommamdValue)
            {
                case FIRMWARE_UPDATE_TOTAL_PACKAGES_AND_CRC:
                    {
                        sendBootPreparFlag = 0;
                        
                        nTotalPackages = *(int*)(USB_ReceiveBuffer + 5);
                        nRecvCRC = *(u16*)(USB_ReceiveBuffer + 9);
                        
                        USB_SendCommand(FIRMWARE_UPDATE_TOTAL_PACKAGES_AND_CRC_OK, 0,0);   

                        USB_ReceiveFlg = FALSE;
                        while(1)
                        {
                            if(USB_ReceiveFlg == TRUE)
                            {
                                USB_ReceiveFlg = FALSE;

                                nCalcCRC = CheckCRC(USB_ReceiveBuffer, sizeof(USB_ReceiveBuffer), nCalcCRC);

                                memcpy(saveCodeBuf + nByteCounts, USB_ReceiveBuffer, USB_ONE_PACKAGE_SEND_SIZE);  

                                nByteCounts += USB_ONE_PACKAGE_SEND_SIZE;
                                nCutPackage++;
                                
                                if(nByteCounts == FLASH_ADDR_APP_OFFSET)
                                {
                                    nByteCounts = 0;
                                    STMFLASH_Write(saveAppAddr, (u16*)saveCodeBuf, FLASH_ADDR_APP_OFFSET / 2); 
                                    saveAppAddr += FLASH_ADDR_APP_OFFSET;
                                }
                                
                                USB_SendCommand(FIRMWARE_UPDATE_NEXT_PACKAGE, 0,0);                                                         
                                
                                if(nCutPackage == nTotalPackages && nByteCounts < FLASH_ADDR_APP_OFFSET)
                                {
                                    STMFLASH_Write(saveAppAddr, (u16*)saveCodeBuf, nByteCounts / 2); 
                                    break;
                                }                                 
                            }
                        }                       
                    }break; 
                case FIRMWARE_UPDATE_FINISHED:
                    {
                        if(nCalcCRC == nRecvCRC && nRecvCRC != 0)
                        {                          
                            STMFLASH_Write(FLASH_ADDR_UPDATE_FLAG,(u16*)ToApp, sizeof(ToApp)/sizeof(ToApp[0])/2);

                            USB_SendCommand(FIRMWARE_UPDATE_FINISHED, 0,0);                            
                            delay_ms(300);

                            if(((*(vu32*)(FLASH_ADDR_APP + 4)) & 0xFF000000) == 0x08000000)//�ж��Ƿ�Ϊ0X08XXXXXX.
                            {	 
                                iap_load_app(FLASH_ADDR_APP);//ִ��FLASH APP����
                            } 
                        }       
                        else
                        {
                             USB_SendCommand(FIRMWARE_UPDATE_UNSECUESSED, 0,0);                              
                        }
                    }break;
                default: break;
            }
        }
        else
        {
            USB_SendCommand(USB_CODE_ERROR, 0,0);   
        }

        USB_ReceiveFlg = FALSE; 
		memset(USB_ReceiveBuffer, 0X00, sizeof(USB_ReceiveBuffer) / sizeof(USB_ReceiveBuffer[0]));  //ͷ�ļ���string.h
	}
}



//�Ƚ����������ǰnCount�ֽ��Ƿ����
u8 CompareBuffer(u8* pBuf1, u8* pBuf2, int nCount)
{
    int i;
    for(i = 0; i < nCount; i++)
    {
        if(pBuf1[i] != pBuf2[i])
            return 0;           
    }
    return 1;
}

/*
  Description: 	�ֽڲ���� CRC
  Input:        CheckData  У������
  				CheckNum  ���鳤��
  Output:         
  Return:         	
*/
u16 CheckCRC(u8 *CheckData, int CheckNum, u16 nLastCrc)
{
	u8 da;
	u16 crc = nLastCrc;
  	for (int i=0; i<CheckNum; i++)
	{
		da = (u8)(crc / 256);  //��8 λ���������ݴ�CRC �ĸ� 8 λ  
		crc <<= 8;  //����8 λ
		crc ^= TabCRC[da ^ CheckData[i]];  //���ֽں͵�ǰ���� XOR �ٲ��
	}
	return crc;
}

