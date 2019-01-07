#ifndef __NA7600_USART_H
#define __NA7600_USART_H
#include "stdio.h"	
#include "sys.h" 

#define FLASH_SAVE_CODE_SIZE 2048
#define USART_RECEIVE_CODE_DATA_SIZE  (2048 + 6)  //实际的数据大小是2K，再加上协议 55 AA 01 code 包号 校验位 6个字节
#define USART_RECEIVE_SIZE  16
#define USART_SEND_SIZE  16
#define USART_CODE_LEN   0X10


enum ADJUSTCODENUM
{
    ADJUST_POINT_1 = 1,
    ADJUST_POINT_2,
    ADJUST_POINT_3,
    ADJUST_POINT_4,
    ADJUST_TOUCH_FAILED,
    ADJUST_TOUCH_SUCCESSFUL,
};


extern u8 USART_Receive[USART_RECEIVE_SIZE];
void uart_init(int Baud);
void ReceiveUsartData(void);
void USARTxSendRespondToServer(USART_TypeDef* USARTx, u8 CodeFlg);
u8 CompareBuffer(u8* pBuf1, u8* pBuf2, int nCount);
#endif


