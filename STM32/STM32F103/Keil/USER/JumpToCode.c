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
    //__ASM("MSR MSP, r0");  //ʹ��Keil��Ƕ���ʱʹ��������
   // __ASM("BX r14");
  //__ASM("msr msp, r0");  //set Main Stack value ������ջ��ַ���浽MSP�Ĵ���(R13)��
  //__ASM("bx lr"); //��ת��lr�д�ŵĵ�ַ����bx��ǿ����תָ�� lr�����ӼĴ�������STM32��Ƭ����R14
//}

typedef  void (*IapFun)(void);				//����һ���������͵Ĳ���
IapFun JumpToApp; 

//��ת��Ӧ�ó��� AppAddr:�û�������ʼ��ַ.
void Iap_Load_App(u32 AppAddr)
{
	if(((*(vu32*)AppAddr)&0x2FFE0000)==0x20000000)	//���ջ����ַ�Ƿ�Ϸ�.
	{ 
		JumpToApp = (IapFun)*(vu32*)(AppAddr+4); //�û��������ڶ�����Ϊ����ʼ��ַ(�³���λ��ַ)		
		MSR_MSP(*(vu32*)AppAddr);		 //��ʼ��APP��ջָ��(�û��������ĵ�һ�������ڴ��ջ����ַ)
		JumpToApp();	//����PCָ��Ϊ�³���λ�жϺ����ĵ�ַ������ִ��
	}
}

