/*************************************************************************/
//工程: BootLoaderV1.0
/************************************************************************/

#include "stm32f10x.h"
#include "stm32f10x_usart.h"
#include "NA7600_Usart.h"
#include "NA7600_Timer.h"
#include "NA7600_STM32_INFLASH.h"
#include "delay.h"
#include "led.h"
#include "ConstValue.h"
#include "JumpToCode.h"


extern u8 Flag10MS;

int main(void)
{ 
  int flag = 3;
  int nCount = 0;
	int i = 0;
  delay_init();  
  uart_init(115200);
  LED_Init();
  TIM3_Init(99, 719);  //10ms定时
  flag = STMFLASH_ReadHalfWord(FLASH_ADDR_UPDATE_FLAG);
  while(1)
  {	
    //FLASH_EraseAllPages();  //仅在擦除所有FLASH时打开
    /*if(flag == FLAG_TO_APP)
    {
        for(; i < 10; i++)
        {
            LED1 = !LED1;
            delay_ms(300);
        }
        Iap_Load_App(FLASH_ADDR_APP);
    }        
    else
		*/
    {      
        ReceiveUsartData();	
        if(Flag10MS == 1)  
        {          
            Flag10MS = 0; 
            nCount++;
            if(nCount == 10)  //100ms
            {
                nCount = 0;
                USARTxSendRespondToServer(USART1, SERIAL_CODE_STM32_UPDATE_PREPAR_BOOT_OK);  //不能发送过快否则会有脏数据
                LED1 = !LED1;
            }                            
        }
    }
  }    
}




