#include "NA7600_Timer.h"
#include "stm32f10x.h"
#include "stm32f10x_it.h"

u8 Flag10MS = 0;  
u8 TouchCheckFlag10MsCount = 0;  //��ⴥ�������²���������Ķ�ʱ��־
u8 TouchAdjustFlag10MsCount = 0;  //У׼ʱ��ȡУ׼��Ķ�ʱ��־


/*
	Description: ��ʱ��TIM3�ĳ�ʼ������
	Input:       arr:�Զ����ؼ�������  
				 psc: ��Ƶϵ��
	Output:        
	Return:        
*/

//TIM3_Init(4999, 7199); //10Khz�ļ���Ƶ�ʼ�����5000Ϊ5000ms
//TIM3_Init(999, 719);   //100Khz�ļ���Ƶ�ʼ�����1000Ϊ100ms(ʾ����������15ms)
//TIM3_Init(99, 719);    //100Khz�ļ���Ƶ�ʼ�����100Ϊ10ms(ʾ����������1.5ms)

void TIM3_Init(u16 arr, u16 psc)
{
    TIM_TimeBaseInitTypeDef  TIM_TimeBaseStructure;
	NVIC_InitTypeDef NVIC_InitStructure;

	RCC_APB1PeriphClockCmd(RCC_APB1Periph_TIM3, ENABLE);  //ʹ�ܶ�ʱ��3��ʱ�� 

	TIM_TimeBaseStructure.TIM_Period = arr;  //�Զ���������
	TIM_TimeBaseStructure.TIM_Prescaler = psc;  //���÷�Ƶϵ��
	TIM_TimeBaseStructure.TIM_ClockDivision = TIM_CKD_DIV1;  //ʱ�ӷ�Ƶ����
	TIM_TimeBaseStructure.TIM_CounterMode = TIM_CounterMode_Up;  //���ϼ��� 
	TIM_TimeBaseInit(TIM3, &TIM_TimeBaseStructure); 
 
	TIM_ITConfig(TIM3, TIM_IT_Update, ENABLE);  //��ʱ�������ж�ʹ��(����TIMx_ DIER DMA/�ж�ʹ�ܼĴ���)
	
	NVIC_InitStructure.NVIC_IRQChannel = TIM3_IRQn;  
	NVIC_InitStructure.NVIC_IRQChannelPreemptionPriority = 0;  
	NVIC_InitStructure.NVIC_IRQChannelSubPriority = 3;  
	NVIC_InitStructure.NVIC_IRQChannelCmd = ENABLE; 
	NVIC_Init(&NVIC_InitStructure);

	TIM_Cmd(TIM3, ENABLE);  //ʹ�ܼ�����  (����TIMx_CR1 ���ƼĴ���1)
        
    Flag10MS = 0;  //��ʱ��־Ϊ0
							 
}


