/******************** (C) COPYRIGHT 2008 Deviser *******************************
* File Name          : SPIFLASH.c
* Author             : renping wang
* Version            : V1.0
* Date               : 12/09/2008
* Description        : SPI_FLASH API
********************************************************************************
* Function list:
* void SPI2_FLASH_Init(void);
* u8 SPI_FLASH_ReadByte(void);
* u8 SPI_FLASH_SendByte(u8 byte);
* u16 SPI_FLASH_SendHalfWord(u16 HalfWord);
* void SPI_FLASH_WriteEnable(void);
* void SPI_FLASH_WaitForWriteEnd(void);
* void SPI_FLASH_SectorErase(u32 SectorAddr);
* void SPI_FLASH_BulkErase(void);
* void SPI_FLASH_PageWrite(u8* pBuffer, u32 WriteAddr, u16 NumByteToWrite);
* void SPI_FLASH_BufferWrite(u8* pBuffer, u32 WriteAddr, u16 NumByteToWrite);
* void SPI_FLASH_BufferRead(u8* pBuffer, u32 ReadAddr, u16 NumByteToRead);
* void SPI_FLASH_StartReadSequence(u32 ReadAddr);
* void SPI_FLASH_WaitForWriteEnd(void);
********************************************************************************
* Modified History:
* 1)
* By	: renping wang
* Date	:
* Modification:
*******************************************************************************/

/* Includes ------------------------------------------------------------------*/

#include "stm32f10x.h"
#include "SPI_FLASH.h"


/* Private typedef -----------------------------------------------------------*/
/* Private define ------------------------------------------------------------*/

#define SPI_FLASH_PageSize    0x100

//根据手册设置下面的值

#define WRITE      0x02  /* Write to Memory instruction PP */
#define WRSR       0x01  /* Write Status Register instruction */
#define WREN       0x06  /* Write enable instruction */

#define READ       0x03  /* Read from Memory instruction */
#define RDSR       0x05  /* Read Status Register instruction  */
#define RDID       0x9F  /* Read identification */
#define SE         0x20// 0xD8 /* Sector Erase instruction */
#define BE         0xC7  /* Bulk Erase instruction */
#define WIP_Flag   0x01  /* Write In Progress (WIP) flag */
#define Dummy_Byte 0xA5
#define FLASH_WriteAddress    0x001000 //0x700000
#define FLASH_ReadAddress      FLASH_WriteAddress
#define FLASH_SectorToErase    FLASH_WriteAddress

/* Private macro -------------------------------------------------------------*/
/* Exported macro ------------------------------------------------------------*/

/* Private variables ---------------------------------------------------------*/
u32 SPI_FLASH_Read_ID(void);
/* Private macro -------------------------------------------------------------*/
u8 Tx_Buffer[] = " STM32F10x SPI Firmware Library Example: communication STM32F10x SPI Firmware Library Example: communication STM32F10x SPI Firmware Library Example: communication STM32F10x SPI Firmware Library Example: communication STM32F10x SPI Firmware Library Example: communication STM32F10x SPI Firmware Library Example: communication STM32F10x SPI Firmware Library Example: communication STM32F10x SPI Firmware Library Example: communication STM32F10x SPI Firmware Library Example: communication STM32F10x SPI Firmware Library Example: communication STM32F10x SPI Firmware Library Example: communication001021.01.32.32.32.3.32.31.3232.32.2.132.321.132.312.312.02101202102asadsadsadsadsadsadsadadsa010210210222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222224555555555555555555555555555777777777777777788888888888888888888888833333333333333333333333999999999999999999988777777777777777777777777777777777777783221111111111111111111131212122222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222224444444444444444444444888888888888888888888888888888811111111111111111111111111999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999";
#define countof(a) (sizeof(a) / sizeof(*(a)))
#define  BufferSize (countof(Tx_Buffer)-1)
u8 Rx_Buffer[BufferSize];


#define SPI_FLASH_HELP_DISABLE() GPIO_SetBits(GPIOB, GPIO_Pin_11)
#define SPI_FLASH_HOLD_DISABLE() GPIO_SetBits(GPIOB, GPIO_Pin_10)
/* Private function prototypes -----------------------------------------------*/
/* Exported functions ------------------------------------------------------- */
void SPI2_FLASH_Init(void);
void SPI1EachInit(void);
u8 SPI_FLASH_ReadByte(void);
u8 SPI_FLASH_SendByte(u8 byte);
u16 SPI_FLASH_SendHalfWord(u16 HalfWord);
void SPIDirectSend(u8* pBuffer, u16 NumByteToWrite);
void SPIDMASend(u8* pBuffer,  int DMANum);
void DMARXInit(void);
void DMATXInit(void);
void SpiNumSet (u8 *InNum, int n, u8 *OutNum);
void mDelayDMA(u16 *CurrCounter, u32 Time);
void SPI_Ecah_Buffer_Send(u8* pBuffer, u16 NumByteToRead);
void SPI_FLASH_WriteEnable(void);
void SPI_FLASH_WaitForWriteEnd(void);
void SPI_FLASH_SectorErase(u32 SectorAddr);
void SPI_FLASH_BulkErase(void);
void SPI_FLASH_PageWrite(u8* pBuffer, u32 WriteAddr, u16 NumByteToWrite);
void SPI_FLASH_BufferWrite(u8* pBuffer, u32 WriteAddr, u16 NumByteToWrite);
void SPI_Buffer_Send(u8* pBuffer,  u16 NumByteToWrite);
u8 SPI_Conmunication_SendByte(u8 byte);
void SPI_Buffer_Receive(u8* pBuffer, u16 NumByteToRead);
void SPI_FLASH_BufferRead(u8* pBuffer, u32 ReadAddr, u16 NumByteToRead);
void SPI_FLASH_StartReadSequence(u32 ReadAddr);
void SPI_FLASH_WaitForWriteEnd(void);
u32 SPI_FLASH_ID;
void SPIDMARespond(u8 TransferState, u8 CommNum);
void ClearBuffer(u8* pBuffer, u16 NumByteToRead);





/*
	Description: spi2通信发送数组数据
	Input:
	Output:
	Return:
*/
void SPI_Buffer_Send(u8* pBuffer,  u16 NumByteToWrite)
{
  /* while there is data to be written on the FLASH */
  while (NumByteToWrite--)
  {
    /* Send the current byte */
    SPI_FLASH_SendByte(*pBuffer);
    /* Point on the next byte to be written */
    pBuffer++;
  }
}


/*
	Description:spi1通信发送数组数据
	Input:
	Output:
	Return:
*/
void SPI_Ecah_Buffer_Send(u8* pBuffer, u16 NumByteToRead)
{
	int i = 0;
	for(; i < NumByteToRead; i++)
	{
		SPI_Conmunication_SendByte(*pBuffer);
		pBuffer++;
	}
}
/*
	Description:spi2通信接收收据
	Input:
	Output:
	Return:
*/
void SPI_Buffer_Receive(u8* pBuffer, u16 NumByteToRead)
{
	while (NumByteToRead--) /* while there is data to be read */
	{
		/* Read a byte from the FLASH */
		*pBuffer = SPI_FLASH_SendByte(Dummy_Byte);
		/* Point to the next location where the byte read will be saved */
		pBuffer++;
	}
}
 
/*******************************************************************************
* Function Name  : SPI_FLASH_SectorErase
* Description    : Erases the specified FLASH sector.
* Input          : SectorAddr: address of the sector to erase.
* Output         : None
* Return         : None
*******************************************************************************/
void SPI_FLASH_SectorErase(u32 SectorAddr)
{
  /* Send write enable instruction */
  SPI_FLASH_WriteEnable();

  /* Sector Erase */
  /* Select the FLASH: Chip Select low */
  SPI_FLASH_CS_LOW();
  /* Send Sector Erase instruction */
  SPI_FLASH_SendByte(SE);
  /* Send SectorAddr high nibble address byte */
  SPI_FLASH_SendByte((SectorAddr & 0xFF0000) >> 16);
  /* Send SectorAddr medium nibble address byte */
  SPI_FLASH_SendByte((SectorAddr & 0xFF00) >> 8);
  /* Send SectorAddr low nibble address byte */
  SPI_FLASH_SendByte(SectorAddr & 0xFF);
  /* Deselect the FLASH: Chip Select high */
  SPI_FLASH_CS_HIGH();

  /* Wait the end of Flash writing */
  SPI_FLASH_WaitForWriteEnd();
}

/*******************************************************************************
* Function Name  : SPI_FLASH_BulkErase
* Description    : Erases the entire FLASH.
* Input          : None
* Output         : None
* Return         : None
*******************************************************************************/
void SPI_FLASH_BulkErase(void)
{
  /* Send write enable instruction */
  SPI_FLASH_WriteEnable();

  /* Bulk Erase */
  /* Select the FLASH: Chip Select low */
  SPI_FLASH_CS_LOW();
  /* Send Bulk Erase instruction  */
  SPI_FLASH_SendByte(BE);
  /* Deselect the FLASH: Chip Select high */
  SPI_FLASH_CS_HIGH();

  /* Wait the end of Flash writing */
  SPI_FLASH_WaitForWriteEnd();
}

/*******************************************************************************
* Function Name  : SPI_FLASH_PageWrite
* Description    : Writes more than one byte to the FLASH with a single WRITE
*                  cycle(Page WRITE sequence). The number of byte can't exceed
*                  the FLASH page size.
* Input          : - pBuffer : pointer to the buffer  containing the data to be
*                    written to the FLASH.
*                  - WriteAddr : FLASH's internal address to write to.
*                  - NumByteToWrite : number of bytes to write to the FLASH,
*                    must be equal or less than "SPI_FLASH_PageSize" value.
* Output         : None
* Return         : None
*******************************************************************************/
void SPI_FLASH_PageWrite(u8* pBuffer, u32 WriteAddr, u16 NumByteToWrite)
{
  /* Enable the write access to the FLASH */
  SPI_FLASH_WriteEnable();

  /* Select the FLASH: Chip Select low */
  SPI_FLASH_CS_LOW();
  /* Send "Write to Memory " instruction */
  SPI_FLASH_SendByte(WRITE);
  /* Send WriteAddr high nibble address byte to write to */
  SPI_FLASH_SendByte((WriteAddr & 0xFF0000) >> 16);
  /* Send WriteAddr medium nibble address byte to write to */
  SPI_FLASH_SendByte((WriteAddr & 0xFF00) >> 8);
  /* Send WriteAddr low nibble address byte to write to */
  SPI_FLASH_SendByte(WriteAddr & 0xFF);

  /* while there is data to be written on the FLASH */
  while (NumByteToWrite--)
  {
    /* Send the current byte */
    SPI_FLASH_SendByte(*pBuffer);
    /* Point on the next byte to be written */
    pBuffer++;
  }

  /* Deselect the FLASH: Chip Select high */
  SPI_FLASH_CS_HIGH();

  /* Wait the end of Flash writing */
  SPI_FLASH_WaitForWriteEnd();
}

/*******************************************************************************
* Function Name  : SPI_FLASH_BufferWrite
* Description    : Writes block of data to the FLASH. In this function, the
*                  number of WRITE cycles are reduced, using Page WRITE sequence.
* Input          : - pBuffer : pointer to the buffer  containing the data to be
*                    written to the FLASH.
*                  - WriteAddr : FLASH's internal address to write to.
*                  - NumByteToWrite : number of bytes to write to the FLASH.
* Output         : None
* Return         : None
*******************************************************************************/
void SPI_FLASH_BufferWrite(u8* pBuffer, u32 WriteAddr, u16 NumByteToWrite)
{
  u8 NumOfPage = 0, NumOfSingle = 0, Addr = 0, count = 0, temp = 0;

  Addr = WriteAddr % SPI_FLASH_PageSize;
  count = SPI_FLASH_PageSize - Addr;
  NumOfPage =  NumByteToWrite / SPI_FLASH_PageSize;
  NumOfSingle = NumByteToWrite % SPI_FLASH_PageSize;

  if (Addr == 0) /* WriteAddr is SPI_FLASH_PageSize aligned  */
  {
    if (NumOfPage == 0) /* NumByteToWrite < SPI_FLASH_PageSize */
    {
      SPI_FLASH_PageWrite(pBuffer, WriteAddr, NumByteToWrite);
    }
    else /* NumByteToWrite > SPI_FLASH_PageSize */
    {
      while (NumOfPage--)
      {
        SPI_FLASH_PageWrite(pBuffer, WriteAddr, SPI_FLASH_PageSize);
        WriteAddr +=  SPI_FLASH_PageSize;
        pBuffer += SPI_FLASH_PageSize;
      }

      SPI_FLASH_PageWrite(pBuffer, WriteAddr, NumOfSingle);
    }
  }
  else /* WriteAddr is not SPI_FLASH_PageSize aligned  */
  {
    if (NumOfPage == 0) /* NumByteToWrite < SPI_FLASH_PageSize */
    {
      if (NumOfSingle > count) /* (NumByteToWrite + WriteAddr) > SPI_FLASH_PageSize */
      {
        temp = NumOfSingle - count;

        SPI_FLASH_PageWrite(pBuffer, WriteAddr, count);
        WriteAddr +=  count;
        pBuffer += count;

        SPI_FLASH_PageWrite(pBuffer, WriteAddr, temp);
      }
      else
      {
        SPI_FLASH_PageWrite(pBuffer, WriteAddr, NumByteToWrite);
      }
    }
    else /* NumByteToWrite > SPI_FLASH_PageSize */
    {
      NumByteToWrite -= count;
      NumOfPage =  NumByteToWrite / SPI_FLASH_PageSize;
      NumOfSingle = NumByteToWrite % SPI_FLASH_PageSize;

      SPI_FLASH_PageWrite(pBuffer, WriteAddr, count);
      WriteAddr +=  count;
      pBuffer += count;

      while (NumOfPage--)
      {
        SPI_FLASH_PageWrite(pBuffer, WriteAddr, SPI_FLASH_PageSize);
        WriteAddr +=  SPI_FLASH_PageSize;
        pBuffer += SPI_FLASH_PageSize;
      }

      if (NumOfSingle != 0)
      {
        SPI_FLASH_PageWrite(pBuffer, WriteAddr, NumOfSingle);
      }
    }
  }
}

/*******************************************************************************
* Function Name  : SPI_FLASH_BufferRead
* Description    : Reads a block of data from the FLASH.
* Input          : - pBuffer : pointer to the buffer that receives the data read
*                    from the FLASH.
*                  - ReadAddr : FLASH's internal address to read from.
*                  - NumByteToRead : number of bytes to read from the FLASH.
* Output         : None
* Return         : None
*******************************************************************************/
void SPI_FLASH_BufferRead(u8* pBuffer, u32 ReadAddr, u16 NumByteToRead)
{
  /* Select the FLASH: Chip Select low */
  SPI_FLASH_CS_LOW();

  /* Send "Read from Memory " instruction */
  SPI_FLASH_SendByte(READ);

  /* Send ReadAddr high nibble address byte to read from */
  SPI_FLASH_SendByte((ReadAddr & 0xFF0000) >> 16);
  /* Send ReadAddr medium nibble address byte to read from */
  SPI_FLASH_SendByte((ReadAddr& 0xFF00) >> 8);
  /* Send ReadAddr low nibble address byte to read from */
  SPI_FLASH_SendByte(ReadAddr & 0xFF);

  while (NumByteToRead--) /* while there is data to be read */
  {
    /* Read a byte from the FLASH */
    *pBuffer = SPI_FLASH_SendByte(Dummy_Byte);  //发送哑巴字节为了产生时钟
    /* Point to the next location where the byte read will be saved */
    pBuffer++;
  }

  /* Deselect the FLASH: Chip Select high */
  SPI_FLASH_CS_HIGH();
}

/*******************************************************************************
* Function Name  : SPI_FLASH_ReadID
* Description    : Reads FLASH identification.
* Input          : None
* Output         : None
* Return         : FLASH identification
*******************************************************************************/
u32 SPI_FLASH_Read_ID(void)
{
  u32 Temp = 0, Temp0 = 0, Temp1 = 0, Temp2 = 0;

  /* Select the FLASH: Chip Select low */
  //SPI_FLASH_CS_LOW();

  /* Send "RDID " instruction */
  SPI_FLASH_SendByte(RDID);

  /* Read a byte from the FLASH */
  Temp0 = SPI_FLASH_SendByte(Dummy_Byte);

  /* Read a byte from the FLASH */
  Temp1 = SPI_FLASH_SendByte(Dummy_Byte);

  /* Read a byte from the FLASH */
  Temp2 = SPI_FLASH_SendByte(Dummy_Byte);

  /* Deselect the FLASH: Chip Select high */
  //SPI_FLASH_CS_HIGH();

  Temp = (Temp0 << 16) | (Temp1 << 8) | Temp2;

  return Temp;
}

/*******************************************************************************
* Function Name  : SPI_FLASH_StartReadSequence
* Description    : Initiates a read data byte (READ) sequence from the Flash.
*                  This is done by driving the /CS line low to select the device,
*                  then the READ instruction is transmitted followed by 3 bytes
*                  address. This function exit and keep the /CS line low, so the
*                  Flash still being selected. With this technique the whole
*                  content of the Flash is read with a single READ instruction.
* Input          : - ReadAddr : FLASH's internal address to read from.
* Output         : None
* Return         : None
*******************************************************************************/
void SPI_FLASH_StartReadSequence(u32 ReadAddr)
{
  /* Select the FLASH: Chip Select low */
  SPI_FLASH_CS_LOW();

  /* Send "Read from Memory " instruction */
  SPI_FLASH_SendByte(READ);

  /* Send the 24-bit address of the address to read from -----------------------*/
  /* Send ReadAddr high nibble address byte */
  SPI_FLASH_SendByte((ReadAddr & 0xFF0000) >> 16);
  /* Send ReadAddr medium nibble address byte */
  SPI_FLASH_SendByte((ReadAddr& 0xFF00) >> 8);
  /* Send ReadAddr low nibble address byte */
  SPI_FLASH_SendByte(ReadAddr & 0xFF);
}

/*******************************************************************************
* Function Name  : SPI_FLASH_ReadByte
* Description    : Reads a byte from the SPI Flash.
*                  This function must be used only if the Start_Read_Sequence
*                  function has been previously called.
* Input          : None
* Output         : None
* Return         : Byte Read from the SPI Flash.
*******************************************************************************/
u8 SPI_FLASH_ReadByte(void)
{
  return (SPI_FLASH_SendByte(Dummy_Byte));
}

/*******************************************************************************
* Function Name  : SPI_FLASH_SendByte
* Description    : Sends a byte through the SPI interface and return the byte
*                  received from the SPI bus.
* Input          : byte : byte to send.
* Output         : None
* Return         : The value of the received byte.
*******************************************************************************/

u8 SPI_FLASH_SendByte(u8 byte)
{
  /* Loop while DR register in not emplty */                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        
  while (SPI_I2S_GetFlagStatus(SPI2, SPI_I2S_FLAG_TXE) == RESET);

  /* Send byte through the SPI1 peripheral */
  SPI_I2S_SendData(SPI2, byte);

  /* Wait to receive a byte */
  while (SPI_I2S_GetFlagStatus(SPI2, SPI_I2S_FLAG_RXNE) == RESET);
	
  /* Return the byte read from the SPI bus */
  return SPI_I2S_ReceiveData(SPI2);
}

u8 SPI_Conmunication_SendByte(u8 byte)
{
  /* Loop while DR register in not emplty */                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        
  while (SPI_I2S_GetFlagStatus(SPI1, SPI_I2S_FLAG_TXE) == RESET);

  /* Send byte through the SPI1 peripheral */
  SPI_I2S_SendData(SPI1, byte);

  /* Wait to receive a byte */
  while (SPI_I2S_GetFlagStatus(SPI1, SPI_I2S_FLAG_RXNE) == RESET);
	
  /* Return the byte read from the SPI bus */
  return SPI_I2S_ReceiveData(SPI1);
}

/*******************************************************************************
* Function Name  : SPI_FLASH_SendHalfWord
* Description    : Sends a Half Word through the SPI interface and return the
*                  Half Word received from the SPI bus.
* Input          : Half Word : Half Word to send.
* Output         : None
* Return         : The value of the received Half Word.
*******************************************************************************/
u16 SPI_FLASH_SendHalfWord(u16 HalfWord)
{
  /* Loop while DR register in not emplty */
  while (SPI_I2S_GetFlagStatus(SPI2, SPI_I2S_FLAG_TXE) == RESET);

  /* Send Half Word through the SPI1 peripheral */
  SPI_I2S_SendData(SPI2, HalfWord);

  /* Wait to receive a Half Word */
  while (SPI_I2S_GetFlagStatus(SPI2, SPI_I2S_FLAG_RXNE) == RESET);

  /* Return the Half Word read from the SPI bus */
  return SPI_I2S_ReceiveData(SPI2);
}

/*******************************************************************************
* Function Name  : SPI_FLASH_WriteEnable
* Description    : Enables the write access to the FLASH.
* Input          : None
* Output         : None
* Return         : None
*******************************************************************************/
void SPI_FLASH_WriteEnable(void)
{
  /* Select the FLASH: Chip Select low */
  SPI_FLASH_CS_LOW();

  /* Send "Write Enable" instruction */
  SPI_FLASH_SendByte(WREN);

  /* Deselect the FLASH: Chip Select high */
  SPI_FLASH_CS_HIGH();
}

/*******************************************************************************
* Function Name  : SPI_FLASH_WaitForWriteEnd
* Description    : Polls the status of the Write In Progress (WIP) flag in the
*                  FLASH's status  register  and  loop  until write  opertaion
*                  has completed.
* Input          : None
* Output         : None
* Return         : None
*******************************************************************************/
void SPI_FLASH_WaitForWriteEnd(void)
{
  u8 FLASH_Status = 0;

  /* Select the FLASH: Chip Select low */
  SPI_FLASH_CS_LOW();

  /* Send "Read Status Register" instruction */
  SPI_FLASH_SendByte(RDSR);

  /* Loop as long as the memory is busy with a write cycle */
  do
  {
    /* Send a dummy byte to generate the clock needed by the FLASH
    and put the value of the status register in FLASH_Status variable */
    FLASH_Status = SPI_FLASH_SendByte(Dummy_Byte);

  }
  while ((FLASH_Status & WIP_Flag) == SET); /* Write in progress */

  /* Deselect the FLASH: Chip Select high */
  SPI_FLASH_CS_HIGH();
}

/******************* (C) COPYRIGHT 2008 STMicroelectronics *****END OF FILE****/



