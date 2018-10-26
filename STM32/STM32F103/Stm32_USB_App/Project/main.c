#include "stm32f10x.h"
#include "USB_Communication.h"
#include "Stm32_InterFlash.h"
#include "delay.h"
#include "usb_lib.h"
#include "JumpToCode.h"
#include "led.h"
#include "myusart.h"	
#include "Stm32_Spi.h"

int main(void)
{
    SCB->VTOR = FLASH_BASE | FLASH_VTOR_OFFSET;
    LED_Init();

    SPI2_Init();  //SPI2 连接w25x40
    NVIC_Configuration();  

    USB_Interrupts_Config();    
    Set_USBClock();   
    USB_Init();	
	
    USB_ConCtrIoInit();  //B9 引脚置低 使得USB D+信号线上的上拉电阻导通
    while(1)
    {	
      USB_Communication();  
    }
}








