#include "stm32f10x.h"
#include "ConstValue.h"

__asm void MSR_MSP(u32 addr) 
{
//   asm("MSR MSP, r0");                         //set Main Stack value
//   asm("BX r14");
    MSR MSP, r0 			//set Main Stack value
    BX r14
}

//void MSR_MSP(u32 addr) 
//{
    //__ASM("MSR MSP, r0");  //使用Keil内嵌汇编时使用这两句
   // __ASM("BX r14");
  //__ASM("msr msp, r0");  //set Main Stack value 将主堆栈地址保存到MSP寄存器(R13)中
  //__ASM("bx lr"); //跳转到lr中存放的地址处。bx是强制跳转指令 lr是连接寄存器，是STM32单片机的R14
//}

typedef  void (*IapFun)(void);				//定义一个函数类型的参数
IapFun JumpToApp; 

//跳转到应用程序 AppAddr:用户代码起始地址.
void Iap_Load_App(u32 AppAddr)
{
	if(((*(vu32*)AppAddr)&0x2FFE0000)==0x20000000)	//检查栈顶地址是否合法.
	{ 
		JumpToApp = (IapFun)*(vu32*)(AppAddr+4); //用户代码区第二个字为程序开始地址(新程序复位地址)		
		MSR_MSP(*(vu32*)AppAddr);		 //初始化APP堆栈指针(用户代码区的第一个字用于存放栈顶地址)
		JumpToApp();	//设置PC指针为新程序复位中断函数的地址，往下执行
	}
}

