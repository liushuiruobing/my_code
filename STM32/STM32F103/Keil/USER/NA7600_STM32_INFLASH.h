
#ifndef __NA7600_STM32_INFLASH_H__
#define __NA7600_STM32_INFLASH_H__
#include "sys.h"  


//������ѡ���оƬ������
#define STM32_FLASH_SIZE 256 	 			//RCT6��ѡSTM32��FLASH������С(��λΪK)
//#define STM32_FLASH_SIZE        128 	 	//RBT6 ��ѡSTM32��FLASH������С(��λΪK)
#define STM32_FLASH_WREN        1           //ʹ��FLASHд��(0��������;1��ʹ��)
#define STM32_FLASH_BASE       0x08000000 	//STM32 FLASH����ʼ��ַ
#define STM32_FLASH_SAVE_TOUCH_ADDR  0X08020000 	//����FLASH �����ַ(����Ϊż��������ֵҪ���ڱ�������ռ��FLASH�Ĵ�С+0X08000000)
#define STM32_FLASH_SAVE_RESOLUATION_ADDR  0X08030000 
 
u16 STMFLASH_ReadHalfWord(u32 faddr);  //��������  
void STMFLASH_WriteLenByte(u32 WriteAddr,u32 DataToWrite,u16 Len);	//ָ����ַ��ʼд��ָ�����ȵ�����
u32 STMFLASH_ReadLenByte(u32 ReadAddr,u16 Len);						//ָ����ַ��ʼ��ȡָ����������
void STMFLASH_Write(u32 WriteAddr,u16 *pBuffer,u16 NumToWrite);		//��ָ����ַ��ʼд��ָ�����ȵ�����
void STMFLASH_Read(u32 ReadAddr,u16 *pBuffer,u16 NumToRead);   		//��ָ����ַ��ʼ����ָ�����ȵ�����

//����д��
void STMFLASH_WtiteU16DataToFlash(u32 WriteAddr,u16 WriteData);								   
#endif



















