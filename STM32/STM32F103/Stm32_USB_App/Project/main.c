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

    SPI2_Init();  //SPI2 ����w25x40
    NVIC_Configuration();  

    USB_Interrupts_Config();    
    Set_USBClock();   
    USB_Init();	
	
    USB_ConCtrIoInit();  //B9 �����õ� ʹ��USB D+�ź����ϵ��������赼ͨ
    while(1)
    {	
      USB_Communication();  
    }
}








