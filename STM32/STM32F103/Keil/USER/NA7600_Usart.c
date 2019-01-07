#include "sys.h"
#include "NA7600_Usart.h"
#include <stdio.h>
#include "string.h"
#include "ConstValue.h"
#include "JumpToCode.h"
#include "NA7600_STM32_INFLASH.h"



volatile int UsartRxCount = 0;
volatile int UsartRxCodeCount = 0;
u8 UsartReceiveFlag = 0;
u8 USART_Receive[USART_RECEIVE_SIZE] = {0};
u8 USART_ReCodeData[USART_RECEIVE_CODE_DATA_SIZE] = {0};


void uart_init(int Baud)
{
    USART_InitTypeDef USART_InitStructure;
    GPIO_InitTypeDef GPIO_InitStructure;
    NVIC_InitTypeDef NVIC_InitStructure;
	
    //配置USART1的时钟
    RCC_APB2PeriphClockCmd(RCC_APB2Periph_USART1 | RCC_APB2Periph_GPIOA, ENABLE);
 
    GPIO_InitStructure.GPIO_Pin = GPIO_Pin_9;  //USART1 发送
    GPIO_InitStructure.GPIO_Mode = GPIO_Mode_AF_PP;
    GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;
    GPIO_Init(GPIOA, &GPIO_InitStructure);

    GPIO_InitStructure.GPIO_Pin = GPIO_Pin_10;  //USART1 接收
    GPIO_InitStructure.GPIO_Mode = GPIO_Mode_IN_FLOATING;
    GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;
    GPIO_Init(GPIOA, &GPIO_InitStructure);
		
    USART_DeInit(USART1);  //
    USART_InitStructure.USART_BaudRate = Baud;
    USART_InitStructure.USART_WordLength = USART_WordLength_8b;
    USART_InitStructure.USART_StopBits = USART_StopBits_1;
    USART_InitStructure.USART_Parity = USART_Parity_No;
    USART_InitStructure.USART_HardwareFlowControl = USART_HardwareFlowControl_None;
    USART_InitStructure.USART_Mode = USART_Mode_Rx|USART_Mode_Tx;
    USART_Init(USART1,&USART_InitStructure);
	
    USART_ITConfig(USART1, USART_IT_RXNE, ENABLE);  //使能接收中断
    // USART_ITConfig(USART1, USART_IT_TC, ENABLE); 
    USART_Cmd(USART1,ENABLE);
    
    /* Enable the USART1 Interrupt */
    NVIC_InitStructure.NVIC_IRQChannel = USART1_IRQn;
    NVIC_InitStructure.NVIC_IRQChannelPreemptionPriority = 2;
    NVIC_InitStructure.NVIC_IRQChannelSubPriority = 0;
    NVIC_InitStructure.NVIC_IRQChannelCmd = ENABLE;
    
    NVIC_Init(&NVIC_InitStructure);

}

//重定义fputc函数 
int fputc(int ch, FILE *f)
{      
    while((USART1->SR&0X40)==0);//循环发送,直到发送完毕   
    USART1->DR = (u8) ch;      
    return ch;
}


extern u8 UsartReceiveFlag;

volatile u8 UpdateFlag = 0;
u8 NextPageFlag = 0;
u8 nPageCount = 0;
u8 nPageTotal = 0;
u8 TempReadTest[FLASH_SAVE_CODE_SIZE] = {0};

void ReceiveUsartData(void)
{
  u8 CompareFlag = 0;
  u8 CheckSum = 0;
  u8 CodeData = 0;
	int i = 0;
  u32 tempAddr = FLASH_ADDR_APP;

  
  if(UsartReceiveFlag == 1) 
  {
    UsartReceiveFlag = 0; 	
    CodeData = USART_Receive[4];		
    for(; i < USART_RECEIVE_SIZE; ++i)
    {
      CheckSum = CheckSum + USART_Receive[i];
    }
    if((CheckSum == 0) && (USART_Receive[0] == 0x55) && (USART_Receive[1] == 0xaa) && (USART_Receive[2] == 0x01))
    {
      switch(CodeData)
      {
        case SERIAL_CODE_SET_STM32_TO_UPDATE:
        {
            UpdateFlag = 1;
            nPageTotal = USART_Receive[5]; //获取总包数
            USARTxSendRespondToServer(USART1, SERIAL_CODE_STM32_UPDATE_PREPAR_OK);
            while(1)
            {
                 if(UpdateFlag == 1 && NextPageFlag == 1)
                 {
                    if((USART_ReCodeData[0] == 0x55) && (USART_ReCodeData[1] == 0xaa) && (USART_ReCodeData[2] == 0x01))
                    {                                
                        //把u8数组转换成u16的数组写入FLASH
                        STMFLASH_Write(tempAddr, (u16*)(USART_ReCodeData + 5), (sizeof(USART_ReCodeData)/sizeof(USART_ReCodeData[0]) - 6) / 2); //-6是去掉协议数据仅2048个字节的程序数据
                        STMFLASH_Read(tempAddr, (u16*)TempReadTest, sizeof(TempReadTest)/ sizeof(TempReadTest[0])/2);
                        CompareFlag = CompareBuffer(&USART_ReCodeData[5], TempReadTest, sizeof(TempReadTest)/sizeof(TempReadTest[0]));
                        if(CompareFlag != 1)
                            continue;  //注意coutinue之后会在此执行一次读写                          
                        nPageCount++;  
                        tempAddr += FLASH_APP_ADDR_OFFSET;
                        USARTxSendRespondToServer(USART1, SERIAL_CODE_STM32_UPDATE_NEXT_PACKEG);
                        if(nPageCount == nPageTotal)
                        {
                            UpdateFlag = 0;  //只能升级完成后置此标志
                            nPageCount = 0;
                            tempAddr = FLASH_ADDR_APP;
                            STMFLASH_WtiteU16DataToFlash(FLASH_ADDR_UPDATE_FLAG, FLAG_TO_APP);
                            USARTxSendRespondToServer(USART1, SERIAL_CODE_STM32_UPDATE_SUCCESS);  
                            
                            if(((*(vu32*)(FLASH_ADDR_APP + 4)) & 0xFF000000) == 0x08000000)//判断是否为0X08XXXXXX.
                            {	 
                                Iap_Load_App(FLASH_ADDR_APP);//执行FLASH APP代码
                            }
                        }
                    }
                    else
                    {
                        USARTxSendRespondToServer(USART1, SERIAL_CODE_STM32_UPDATE_CURRENT_PACKEG);
                    }
                    NextPageFlag = 0;
                    UsartRxCodeCount = 0;
                    memset(USART_ReCodeData, 0, sizeof(USART_ReCodeData)/sizeof(USART_ReCodeData[0]));
                }
            }           
        }break;
      	default: break;
      }				
    }
    UsartRxCount = 0;
    memset(USART_Receive, 0, sizeof(USART_Receive)/sizeof(USART_Receive[0]));
  }
}

//使用串口向Server发消息
void USARTxSendRespondToServer(USART_TypeDef* USARTx, u8 CodeFlg)
{
    u8 SendBuf[USART_CODE_LEN] = {0};
    u8 CheckSum = 0;
		int i = 0;
		
    SendBuf[0] = 0x55;
    SendBuf[1] = 0xaa;
    SendBuf[2] = 0x01;
    SendBuf[3] = USART_CODE_LEN;
    SendBuf[4] = CodeFlg;  //命令码 
   
    for(; i < (USART_CODE_LEN -1); ++i)
    {
      CheckSum = CheckSum + SendBuf[i];
    }
    
    SendBuf[USART_CODE_LEN - 1] = 0 - CheckSum;    
    USART_SendString(USARTx, SendBuf, sizeof(SendBuf)/sizeof(SendBuf[0]));
}

//比较两个数组的前nCount字节是否相等
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