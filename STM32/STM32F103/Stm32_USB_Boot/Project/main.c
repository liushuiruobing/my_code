#include "stm32f10x.h"
#include "USB_Communication.h"
#include "delay.h"
#include "usb_lib.h"
#include "JumpToCode.h"
#include "Stm32_InterFlash.h"
#include "led.h"
#include "myusart.h"	

u8 sendBootPreparFlag = 1;
u8 erasure[4] = {0xff, 0xff, 0xff, 0xff};

int main(void)
{	   
    SCB->VTOR = FLASH_BASE;
    
    u8 nCount = 0;
    u8 ReadFlag[4];
      
    delay_init(); 
    LED_Init();
     
    NVIC_Configuration();

    //这段代码在开发板时有效，但是在功率计小班时无效，应为两者的电路不同
	//usb_port_set(0); 	//USB先断开
	//delay_ms(300);
	//usb_port_set(1);	//USB再次连接
    USB_ConCtrIoInit();
    USB_Interrupts_Config();    
    Set_USBClock();  
    USB_Init();	 

    //FLASH_EraseAllPages();  //擦除整个FLASH
    //STMFLASH_Write(FLASH_ADDR_UPDATE_FLAG,(u16*)erasure, sizeof(erasure)/sizeof(erasure[0])/2);
    STMFLASH_Read(FLASH_ADDR_UPDATE_FLAG, (u16*)ReadFlag, sizeof(ReadFlag)/sizeof(ReadFlag[0])/2);
    if(ReadFlag[0] == 0x55 && ReadFlag[1] == 0xAA && ReadFlag[2] == 0x01 && ReadFlag[3] == 0xcc)
    {
        if(((*(vu32*)(FLASH_ADDR_APP + 4)) & 0xFF000000) == 0x08000000)//判断是否为0X08XXXXXX.
        {	 
            iap_load_app(FLASH_ADDR_APP);//执行FLASH APP代码
        }
    }        
    else 
    { 
        while(1)
        {	
            USB_Communication();

            nCount++;
            if(sendBootPreparFlag && nCount > 50)  //50ms
            {
                nCount = 0;   
                LED0 = !LED0; 
                USB_SendCommand(FIRMWARE_UPDATE_BOOT_PREPAR_OK, NULL, 0);  //不能发送过快否则会有脏数据
            } 
            delay_ms(100);
       }
    }
}




















