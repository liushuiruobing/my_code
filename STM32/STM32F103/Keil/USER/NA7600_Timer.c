#include "NA7600_Timer.h"
#include "stm32f10x.h"
#include "stm32f10x_it.h"

u8 Flag10MS = 0;  
u8 TouchCheckFlag10MsCount = 0;  //检测触摸屏按下并发送坐标的定时标志
u8 TouchAdjustFlag10MsCount = 0;  //校准时读取校准点的定时标志


/*
	Description: 定时器TIM3的初始化函数
	Input:       arr:自动重载计数周期  
				 psc: 分频系数
	Output:        
	Return:        
*/

//TIM3_Init(4999, 7199); //10Khz的计数频率计数到5000为5000ms
//TIM3_Init(999, 719);   //100Khz的计数频率计数到1000为100ms(示波器测试有15ms)
//TIM3_Init(99, 719);    //100Khz的计数频率计数到100为10ms(示波器测试有1.5ms)

void TIM3_Init(u16 arr, u16 psc)
{
    TIM_TimeBaseInitTypeDef  TIM_TimeBaseStructure;
	NVIC_InitTypeDef NVIC_InitStructure;

	RCC_APB1PeriphClockCmd(RCC_APB1Periph_TIM3, ENABLE);  //使能定时器3的时钟 

	TIM_TimeBaseStructure.TIM_Period = arr;  //自动重载周期
	TIM_TimeBaseStructure.TIM_Prescaler = psc;  //设置分频系数
	TIM_TimeBaseStructure.TIM_ClockDivision = TIM_CKD_DIV1;  //时钟分频因子
	TIM_TimeBaseStructure.TIM_CounterMode = TIM_CounterMode_Up;  //向上计数 
	TIM_TimeBaseInit(TIM3, &TIM_TimeBaseStructure); 
 
	TIM_ITConfig(TIM3, TIM_IT_Update, ENABLE);  //定时器更新中断使能(配置TIMx_ DIER DMA/中断使能寄存器)
	
	NVIC_InitStructure.NVIC_IRQChannel = TIM3_IRQn;  
	NVIC_InitStructure.NVIC_IRQChannelPreemptionPriority = 0;  
	NVIC_InitStructure.NVIC_IRQChannelSubPriority = 3;  
	NVIC_InitStructure.NVIC_IRQChannelCmd = ENABLE; 
	NVIC_Init(&NVIC_InitStructure);

	TIM_Cmd(TIM3, ENABLE);  //使能计数器  (配置TIMx_CR1 控制寄存器1)
        
    Flag10MS = 0;  //定时标志为0
							 
}


