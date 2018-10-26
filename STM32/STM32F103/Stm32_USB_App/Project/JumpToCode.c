#include "stm32f10x.h"
#include "ConstValue.h"


void MSR_MSP(u32 addr) 
{
    //asm("MSR MSP, r0"); 			//set Main Stack value
    //asm("BX r14");
  __ASM("msr msp, r0");
  __ASM("bx lr");
}


typedef  void (*iapfun)(void);				//����һ���������͵Ĳ���
iapfun jump2app; 


//��ת��Ӧ�ó����
//appxaddr:�û�������ʼ��ַ.
void iap_load_app(u32 appxaddr)
{
	if(((*(vu32*)appxaddr)&0x2FFE0000)==0x20000000)	//���ջ����ַ�Ƿ�Ϸ�.
	{ 
		jump2app=(iapfun)*(vu32*)(appxaddr + 4);	//�û��������ڶ�����Ϊ����ʼ��ַ(��λ��ַ)		
		MSR_MSP(*(vu32*)appxaddr);					//��ʼ��APP��ջָ��(�û��������ĵ�һ�������ڴ��ջ����ַ)
		jump2app();									//��ת��APP.
	}
}


