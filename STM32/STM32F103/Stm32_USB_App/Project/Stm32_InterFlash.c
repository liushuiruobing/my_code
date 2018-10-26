/***********************************************************************************
��������: NA7600_STM32_INFLASH.c
����ʱ��: 2015-7-28
��������: ��Ҫʵ�� ��STM32���ڲ�FLASH�д洢����
ע������: ������ѡ��оƬ���޸���ѡ�� STM32_FLASH_SIZE��STM_SECTOR_SIZE��FLASH_SAVE_ADDR

************************************************************************************/
#include "Stm32_InterFlash.h"


 

#if STM32_FLASH_WREN	//���ʹ����д   

/*
	��������: 	������д��
  	�������:	WriteAddr: ��ʼ��ַ
				pBuffer: ����ָ��
				NumToWrite: ����(16λ)��  
*/
void STMFLASH_Write_NoCheck(u32 WriteAddr, u16 *pBuffer, u16 NumToWrite)   
{ 			 		 
	u16 i;
	
	for(i = 0; i < NumToWrite; i++)
	{
		FLASH_ProgramHalfWord(WriteAddr, pBuffer[i]);  //��ָ���ĵ�ַд�����
	    WriteAddr += 2;  //��ַ����2.
	}  
} 

//���ֲ��֪������оƬ��ÿ��������2K��С����С������Ʒÿ��������1K��С
#if STM32_FLASH_SIZE < 256

	#define STM_SECTOR_SIZE 1024  //�ֽ�
	
#else 

	#define STM_SECTOR_SIZE	2048

#endif		 

u16 STMFLASH_BUF[STM_SECTOR_SIZE / 2];  //�����������Ϊ2K�ֽ�

/*
	��������: 	��ָ����ַ��ʼд��ָ�����ȵ�����
  	�������:	WriteAddr: ��ʼ��ַ(�˵�ַ����Ϊ2�ı���!!)
				pBuffer: ����ָ��
				NumToWrite:����(16λ)�� (����Ҫд���16λ���ݵĸ���.) 
*/
void STMFLASH_Write(u32 WriteAddr, u16 *pBuffer, u16 NumToWrite)	
{
	u16 i;
	u32 secpos;	   //������ַ
	u16 secoff;	   //������ƫ�Ƶ�ַ(16λ�ּ���)
	u16 secremain; //������ʣ���ַ(16λ�ּ���)	       
	u32 offaddr;   //ȥ��0X08000000��ĵ�ַ

	//���жϵ�ַ�Ƿ�Ϸ�
	if(WriteAddr < STM32_FLASH_BASE || (WriteAddr >= (STM32_FLASH_BASE + 1024 * STM32_FLASH_SIZE)))
	{
		return;  
	}
	
	FLASH_Unlock();	 //����
	
	offaddr = WriteAddr - STM32_FLASH_BASE;		//ʵ��ƫ�Ƶ�ַ.
	secpos = offaddr / STM_SECTOR_SIZE;			//������ַ  0~127 for STM32F103RBT6
	secoff = (offaddr % STM_SECTOR_SIZE) / 2;   //�������ڵ�ƫ��(u16ռ�����ֽڣ�����2���ֽ�Ϊ������λ.)
	secremain = STM_SECTOR_SIZE / 2 -secoff;	//����ʣ��ռ��С(u16 ռ2���ֽ�)  
	
	if(NumToWrite <= secremain)
	{
		secremain = NumToWrite;  //�����ڸ�������Χ
	}
	
	while(1) 
	{	
		STMFLASH_Read(secpos*STM_SECTOR_SIZE + STM32_FLASH_BASE, STMFLASH_BUF, STM_SECTOR_SIZE / 2);  //������������������
		
		for(i = 0; i < secremain; i++)  //У�������Ƿ�Ϊ0xffff,STM32�ڲ�FLASH��д����ǰҲҪ��֤��д��������������ֵΪ0xffff
		{
			if(STMFLASH_BUF[secoff + i] != 0XFFFF)
			{
				break;  //��Ҫ����  	 
			} 
		}
		
		if(i < secremain)  //��Ҫ����
		{
			FLASH_ErasePage(secpos*STM_SECTOR_SIZE + STM32_FLASH_BASE);  //�����������
			
			for(i = 0; i < secremain; i++)  //����
			{
				STMFLASH_BUF[i+secoff] = pBuffer[i];	  
			}
			
			STMFLASH_Write_NoCheck(secpos*STM_SECTOR_SIZE + STM32_FLASH_BASE, STMFLASH_BUF, STM_SECTOR_SIZE / 2);  //д����������  
		}
		else 
		{
			STMFLASH_Write_NoCheck(WriteAddr, pBuffer, secremain);  //�����Ѿ������˵�,ֱ��д������ʣ������. 	
		}
		
		if(NumToWrite == secremain)
		{
			break;  //д�������
		}
		else  //д��δ����
		{
			secpos++;	//������ַ��1
			secoff = 0;  //ƫ��λ��Ϊ0 	 
		   	pBuffer += secremain;  	//ָ��ƫ��
			WriteAddr += secremain;	 //д��ַƫ��	   
		   	NumToWrite -= secremain;  //�ֽ�(16λ)���ݼ�
			
			if(NumToWrite > (STM_SECTOR_SIZE / 2))
			{
				secremain = STM_SECTOR_SIZE / 2;  //��һ����������д����
			}
			else 
			{
				secremain = NumToWrite;  //��һ����������д����
			}
		}	 
	}	
	
	FLASH_Lock();  //����
}
#endif

/*
	��������:	��ȡָ����ַ�İ���(16λ����)
  	�������:	faddr:����ַ(�˵�ַ����Ϊ2�ı���!!)
	����ֵ: 	��Ӧ����
*/
u16 STMFLASH_ReadHalfWord(u32 faddr)
{
	return *(vu16*)faddr; 
}

/*
	��������: 	��ָ����ַ��ʼ����ָ�����ȵ�����
  	�������:	ReadAddr: ��ʼ��ַ
				pBuffer: ����ָ��
				NumToWrite:����(16λ)�� 
*/
void STMFLASH_Read(u32 ReadAddr, u16 *pBuffer, u16 NumToRead)   	
{
	u16 i;
	
	for(i = 0; i < NumToRead; i++)
	{
		pBuffer[i] = STMFLASH_ReadHalfWord(ReadAddr);  //��ȡ2���ֽ�.
		ReadAddr += 2;  //ƫ��2���ֽ�.	
	}
}

/*
	��������: 	���Ժ���
  	�������:	WriteAddr:��ʼ��ַ
				WriteData:Ҫд�������
*/
void STMFLASH_WtiteU16DataToFlash(u32 WriteAddr, u16 WriteData)   	
{
	STMFLASH_Write(WriteAddr,&WriteData, 1);  //д��һ���� 
}






