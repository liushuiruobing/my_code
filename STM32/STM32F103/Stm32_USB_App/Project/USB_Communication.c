#include "stm32f10x.h"
#include "USB_Communication.h"
#include "string.h"
#include "sys.h"
#include "delay.h"
#include "ConstValue.h"
#include "JumpToCode.h"
#include "Stm32_InterFlash.h"
#include "Stm32_Spi.h"



u8 USB_SendBuf[USB_ONE_PACKAGE_SEND_SIZE] = {0};
u8 USB_RecvBuf[USB_ONE_PACKAGE_SEND_SIZE] = {0};
u8 USB_ReceiveFlg = FALSE;


//USB 上拉电阻与3.3V电源导通与否的控制引脚
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
        USB_SendBuf[i] = str[i];
     }
     UserToPMABufferCopy(USB_SendBuf, ENDP2_TXADDR, USB_ONE_PACKAGE_SEND_SIZE);
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
        bool bCommandCheck = FALSE;
        const u8 nLenth = USB_RecvBuf[3];
        const u8 nCommamdValue = USB_RecvBuf[4];

        bCommandCheck = CheckUsbDataWithProtocol(USB_RecvBuf, nLenth);
        if(bCommandCheck)
        {          
            switch(nCommamdValue)
            {
                case FIRMWARE_UPDATE_BOOT:
                    {                      
                        STMFLASH_Write(FLASH_ADDR_UPDATE_FLAG,(u16*)ToBoot, sizeof(ToBoot)/sizeof(ToBoot[0])/2);
                        mDelay(100);
                        iap_load_app(FLASH_ADDR_BOOT);//执行FLASH APP代码
                    }
                    break;    				
                default: break;
            }
        }
        else
        {
            USB_SendCommand(USB_CODE_ERROR, UsbError, sizeof(UsbError)); 
        }

		USB_ReceiveFlg = FALSE; 
		memset(USB_RecvBuf, 0X00, sizeof(USB_RecvBuf) / sizeof(USB_RecvBuf[0]));
	}
}


bool CompareData(u8* pDataBuf1, u8* pDataBuf2, const u32 nSize)
{
    bool bResult = TRUE;

    for(int i = 0; i < nSize; i++)
    {
        if(pDataBuf1[i] != pDataBuf2[i])
        {
            bResult = FALSE;
            break;
        }
    }

    return bResult;
}


//当复制的字节数少时使用此函数，否则使用memcpy
bool CopySrcBufToDesBuf(u8* uSrcBuf, u8* uDesBuf, const u16 uCopyBytes)
{
    bool bRe = FALSE;
    if(uSrcBuf != NULL && uDesBuf != NULL)
    {
        for(u16 i = 0; i < uCopyBytes; i++)
        {
            uDesBuf[i] = uSrcBuf[i];
        }
        bRe = TRUE;
    }

    return bRe;
}

//检查接收到的USB数据是否满足协议
bool CheckUsbDataWithProtocol(u8* uData, const u8 nLength)
{
    bool bResult = FALSE; 
    bool bCommandState = FALSE;
    u8 nSum = 0;   
    
    if ((uData[0] == 0x55) && (uData[1] == 0xAA) && (uData[2] == 0x01))
    {
        bCommandState = TRUE;
    }

    for (int i = 0; i < nLength; i++)
    {
        nSum += uData[i];  //校验位验证
    }

    if(bCommandState && nSum == 0)
        bResult = TRUE;

    return bResult;
}


