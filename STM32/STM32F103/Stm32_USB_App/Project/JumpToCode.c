#include "stm32f10x.h"
#include "ConstValue.h"


void MSR_MSP(u32 addr) 
{
    //asm("MSR MSP, r0"); 			//set Main Stack value
    //asm("BX r14");
  __ASM("msr msp, r0");
  __ASM("bx lr");
}


typedef  void (*iapfun)(void);				//定义一个函数类型的参数
iapfun jump2app; 


//跳转到应用程序段
//appxaddr:用户代码起始地址.
void iap_load_app(u32 appxaddr)
{
	if(((*(vu32*)appxaddr)&0x2FFE0000)==0x20000000)	//检查栈顶地址是否合法.
	{ 
		jump2app=(iapfun)*(vu32*)(appxaddr + 4);	//用户代码区第二个字为程序开始地址(复位地址)		
		MSR_MSP(*(vu32*)appxaddr);					//初始化APP堆栈指针(用户代码区的第一个字用于存放栈顶地址)
		jump2app();									//跳转到APP.
	}
}


