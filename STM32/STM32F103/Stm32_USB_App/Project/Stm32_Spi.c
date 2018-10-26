/********************************************************************
//对于STM32中SPI外设的进一步封装
//创建于2018.6.20 by wen

*********************************************************************/
#include "stm32f10x_spi.h"
#include "Stm32_Spi.h"

u8 uFlashWrite[SPI_FLASH_SECTOR_SIZE] = {0}; //这个数组定义的大一点，就是为了多接受整包数据要拆分组合
u8 uFlashRead[SPI_FLASH_SECTOR_SIZE] = {0};

#define SPI2_Flash_CS_Low()   GPIO_ResetBits(GPIOB, GPIO_Pin_12)  //选中flash
#define SPI2_Flash_CS_High()  GPIO_SetBits(GPIOB, GPIO_Pin_12)    //释放flash


/*******************************************************************************
* 函数名称: SPI2_Init()
* 函数描述: SPI2初始化
* 输入参数: 
* 输出参数: 
* 返回值  : flash的ID
*******************************************************************************/
void SPI2_Init()
{
    SPI_InitTypeDef  SPI_InitStructure;
	GPIO_InitTypeDef GPIO_InitStructure;

	/* Enable SPI2 and GPIO clocks */
    RCC_APB2PeriphClockCmd(RCC_APB2Periph_GPIOB, ENABLE);
	RCC_APB1PeriphClockCmd(RCC_APB1Periph_SPI2, ENABLE);

	/* Configure SPI2 pins: SCK, MISO and MOSI */
	GPIO_InitStructure.GPIO_Pin = GPIO_Pin_13 |GPIO_Pin_14 |GPIO_Pin_15;
	GPIO_InitStructure.GPIO_Mode = GPIO_Mode_AF_PP;
	GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;
	GPIO_Init(GPIOB, &GPIO_InitStructure);

	/*  Configure I/O for Flash Chip select */
	GPIO_InitStructure.GPIO_Pin =  GPIO_Pin_12;
	GPIO_InitStructure.GPIO_Mode = GPIO_Mode_Out_PP;
	GPIO_Init(GPIOB, &GPIO_InitStructure);

	/* Deselect the FLASH: Chip Select high */
	GPIO_SetBits(GPIOB, GPIO_Pin_12);

	/* SPI2 configuration */
	SPI_InitStructure.SPI_Direction = SPI_Direction_2Lines_FullDuplex;
	SPI_InitStructure.SPI_Mode = SPI_Mode_Master;  //主机
	SPI_InitStructure.SPI_DataSize = SPI_DataSize_8b;
	SPI_InitStructure.SPI_CPOL = SPI_CPOL_High;
	SPI_InitStructure.SPI_CPHA = SPI_CPHA_2Edge;
	SPI_InitStructure.SPI_NSS = SPI_NSS_Soft;  //NSS配置为软件模式
	SPI_InitStructure.SPI_BaudRatePrescaler = SPI_BaudRatePrescaler_4;  //4分频 9M
	SPI_InitStructure.SPI_FirstBit = SPI_FirstBit_MSB;  //先传高字节
	SPI_InitStructure.SPI_CRCPolynomial = 7;
	SPI_Init(SPI2, &SPI_InitStructure);

	/* Enable SPI2 */
	SPI_Cmd(SPI2, ENABLE);
}

/*******************************************************************************
* 函数名称: SPI_FlashReadID()
* 函数描述: 读取flash的ID
* 输入参数: 
* 输出参数: 
* 返回值  : flash的ID
*******************************************************************************/
u32 SPI_FlashReadID(void)
{
  u32 Temp = 0, Temp0 = 0, Temp1 = 0, Temp2 = 0;

  /* Select the FLASH: Chip Select low */
  SPI2_Flash_CS_Low();

  /* Send "RDID " instruction */
  SPI_ReadWriteByte(SPI2, RDID);

  /* Read a byte from the FLASH */
  Temp0 = SPI_ReadWriteByte(SPI2, Dummy_Byte);

  /* Read a byte from the FLASH */
  Temp1 = SPI_ReadWriteByte(SPI2, Dummy_Byte);

  /* Read a byte from the FLASH */
  Temp2 = SPI_ReadWriteByte(SPI2, Dummy_Byte);

  /* Deselect the FLASH: Chip Select high */
  SPI2_Flash_CS_High();

  Temp = (Temp0 << 16) | (Temp1 << 8) | Temp2;

  return Temp;
}

/*******************************************************************************
* 函数名称: SPI_ReadWriteByte()
* 函数描述: SPI读写一个字节
* 输入参数: nSpix: 要操作的SPI,如SPI2
  	        uWriteByte: 要写入的字节
* 输出参数: 
* 返回值  : 读取的字节
*******************************************************************************/
u8 SPI_ReadWriteByte(SPI_TypeDef* nSpix, u8 uWriteByte)
{
  /* Loop while DR register in not emplty */                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        
  while (SPI_I2S_GetFlagStatus(nSpix, SPI_I2S_FLAG_TXE) == RESET);

  /* Send byte through the SPI1 peripheral */
  SPI_I2S_SendData(nSpix, uWriteByte);

  /* Wait to receive a byte */
  while (SPI_I2S_GetFlagStatus(nSpix, SPI_I2S_FLAG_RXNE) == RESET);
	
  /* Return the byte read from the SPI bus */
  return SPI_I2S_ReceiveData(nSpix);
}

/*******************************************************************************
* 函数名称: SPI_FlashBufferRead()
* 函数描述: 从指定地址中读取flash数据
* 输入参数: pBuffer: 存放数据的缓存
  	        ReadAddr: 要读取的地址
  	        NumByteToRead: 读取的字节数
* 输出参数: 
* 返回值  : 
*******************************************************************************/
void SPI_FlashBufferRead(u8* pBuffer, u32 ReadAddr, u16 NumByteToRead)
{
  /* Select the FLASH: Chip Select low */
  SPI2_Flash_CS_Low();

  /* Send "Read from Memory " instruction */
  SPI_ReadWriteByte(SPI2, READ);

  /* Send ReadAddr high nibble address byte to read from */
  SPI_ReadWriteByte(SPI2, (ReadAddr & 0xFF0000) >> 16);
  /* Send ReadAddr medium nibble address byte to read from */
  SPI_ReadWriteByte(SPI2, (ReadAddr& 0xFF00) >> 8);
  /* Send ReadAddr low nibble address byte to read from */
  SPI_ReadWriteByte(SPI2, ReadAddr & 0xFF);

  while (NumByteToRead--) /* while there is data to be read */
  {
    /* Read a byte from the FLASH */
    *pBuffer = SPI_ReadWriteByte(SPI2, Dummy_Byte);  //发送哑巴字节为了产生时钟
    /* Point to the next location where the byte read will be saved */
    pBuffer++;
  }

  /* Deselect the FLASH: Chip Select high */
  SPI2_Flash_CS_High();
}

/*******************************************************************************
* 函数名称: SPI_FlashWriteEnable()
* 函数描述: 写使能
* 输入参数: 
* 输出参数: 
* 返回值  : 
*******************************************************************************/
void SPI_FlashWriteEnable(void)
{
  /* Select the FLASH: Chip Select low */
  SPI2_Flash_CS_Low();

  /* Send "Write Enable" instruction */
  SPI_ReadWriteByte(SPI2, WREN);

  /* Deselect the FLASH: Chip Select high */
  SPI2_Flash_CS_High();
}

/*******************************************************************************
* 函数名称: SPI_FlashWaitForWriteEnd()
* 函数描述: 等待写结束
* 输入参数: 
* 输出参数: 
* 返回值  : 
*******************************************************************************/
void SPI_FlashWaitForWriteEnd(void)
{
  u8 FLASH_Status = 0;

  /* Select the FLASH: Chip Select low */
  SPI2_Flash_CS_Low();

  /* Send "Read Status Register" instruction */
  SPI_ReadWriteByte(SPI2, RDSR);

  /* Loop as long as the memory is busy with a write cycle */
  do
  {
    /* Send a dummy byte to generate the clock needed by the FLASH
    and put the value of the status register in FLASH_Status variable */
    FLASH_Status = SPI_ReadWriteByte(SPI2, Dummy_Byte);

  }
  while ((FLASH_Status & WIP_Flag) == SET); /* Write in progress */

  /* Deselect the FLASH: Chip Select high */
  SPI2_Flash_CS_High();
}

/*******************************************************************************
* 函数名称: SPI_FlashPageWrite()
* 函数描述: 往指定页的地址里写数据，写一页
* 输入参数: pBuffer: 要写的数据
  	        WriteAddr: 要写的地址
  	        NumByteToWrite: 要写入的字节数
* 输出参数: 
* 返回值  : 
*******************************************************************************/
void SPI_FlashPageWrite(u8* pBuffer, u32 WriteAddr, u16 NumByteToWrite)
{
  /* Enable the write access to the FLASH */
  SPI_FlashWriteEnable();

  /* Select the FLASH: Chip Select low */
  SPI2_Flash_CS_Low();
  /* Send "Write to Memory " instruction */
  SPI_ReadWriteByte(SPI2, WRITE);
  /* Send WriteAddr high nibble address byte to write to */
  SPI_ReadWriteByte(SPI2, (WriteAddr & 0xFF0000) >> 16);
  /* Send WriteAddr medium nibble address byte to write to */
  SPI_ReadWriteByte(SPI2, (WriteAddr & 0xFF00) >> 8);
  /* Send WriteAddr low nibble address byte to write to */
  SPI_ReadWriteByte(SPI2, WriteAddr & 0xFF);

  /* while there is data to be written on the FLASH */
  while (NumByteToWrite--)
  {
    /* Send the current byte */
    SPI_ReadWriteByte(SPI2, *pBuffer);
    /* Point on the next byte to be written */
    pBuffer++;
  }

  /* Deselect the FLASH: Chip Select high */
  SPI2_Flash_CS_High();

  /* Wait the end of Flash writing */
  SPI_FlashWaitForWriteEnd();
}

/*******************************************************************************
* 函数名称: SPI_FlashBufferWrite()
* 函数描述: 往指定的地址里写数据
* 输入参数: pBuffer: 要写的数据
  	        WriteAddr: 要写的地址
  	        NumByteToWrite: 要写入的字节数
* 输出参数: 
* 返回值  : 
*******************************************************************************/
void SPI_FlashBufferWrite(u8* pBuffer, u32 WriteAddr, u16 NumByteToWrite)
{
  u8 NumOfPage = 0, NumOfSingle = 0, Addr = 0, count = 0, temp = 0;

  Addr = WriteAddr % SPI_FLASH_PAGE_SIZE;
  count = SPI_FLASH_PAGE_SIZE - Addr;
  NumOfPage =  NumByteToWrite / SPI_FLASH_PAGE_SIZE;
  NumOfSingle = NumByteToWrite % SPI_FLASH_PAGE_SIZE;

  if (Addr == 0) /* WriteAddr is SPI_FLASH_PAGE_SIZE aligned  */
  {
    if (NumOfPage == 0) /* NumByteToWrite < SPI_FLASH_PAGE_SIZE */
    {
      SPI_FlashPageWrite(pBuffer, WriteAddr, NumByteToWrite);
    }
    else /* NumByteToWrite > SPI_FLASH_PAGE_SIZE */
    {
      while (NumOfPage--)
      {
        SPI_FlashPageWrite(pBuffer, WriteAddr, SPI_FLASH_PAGE_SIZE);
        WriteAddr +=  SPI_FLASH_PAGE_SIZE;
        pBuffer += SPI_FLASH_PAGE_SIZE;
      }

      SPI_FlashPageWrite(pBuffer, WriteAddr, NumOfSingle);
    }
  }
  else /* WriteAddr is not SPI_FLASH_PAGE_SIZE aligned  */
  {
    if (NumOfPage == 0) /* NumByteToWrite < SPI_FLASH_PAGE_SIZE */
    {
      if (NumOfSingle > count) /* (NumByteToWrite + WriteAddr) > SPI_FLASH_PAGE_SIZE */
      {
        temp = NumOfSingle - count;

        SPI_FlashPageWrite(pBuffer, WriteAddr, count);
        WriteAddr +=  count;
        pBuffer += count;

        SPI_FlashPageWrite(pBuffer, WriteAddr, temp);
      }
      else
      {
        SPI_FlashPageWrite(pBuffer, WriteAddr, NumByteToWrite);
      }
    }
    else /* NumByteToWrite > SPI_FLASH_PAGE_SIZE */
    {
      NumByteToWrite -= count;
      NumOfPage =  NumByteToWrite / SPI_FLASH_PAGE_SIZE;
      NumOfSingle = NumByteToWrite % SPI_FLASH_PAGE_SIZE;

      SPI_FlashPageWrite(pBuffer, WriteAddr, count);
      WriteAddr +=  count;
      pBuffer += count;

      while (NumOfPage--)
      {
        SPI_FlashPageWrite(pBuffer, WriteAddr, SPI_FLASH_PAGE_SIZE);
        WriteAddr +=  SPI_FLASH_PAGE_SIZE;
        pBuffer += SPI_FLASH_PAGE_SIZE;
      }

      if (NumOfSingle != 0)
      {
        SPI_FlashPageWrite(pBuffer, WriteAddr, NumOfSingle);
      }
    }
  }
}

/*******************************************************************************
* 函数名称: SPI_FlashSectorErase()
* 函数描述: 删除指定扇区
* 输入参数: uSectorAddr: 要删除的地址
* 输出参数: 
* 返回值  : 
*******************************************************************************/
void SPI_FlashSectorErase(u32 uSectorAddr)
{
  /* Send write enable instruction */
  SPI_FlashWriteEnable();

  /* Sector Erase */
  /* Select the FLASH: Chip Select low */
  SPI2_Flash_CS_Low();
  /* Send Sector Erase instruction */
  SPI_ReadWriteByte(SPI2, SE);
  /* Send SectorAddr high nibble address byte */
  SPI_ReadWriteByte(SPI2, (uSectorAddr & 0xFF0000) >> 16);
  /* Send SectorAddr medium nibble address byte */
  SPI_ReadWriteByte(SPI2, (uSectorAddr & 0xFF00) >> 8);
  /* Send SectorAddr low nibble address byte */
  SPI_ReadWriteByte(SPI2, uSectorAddr & 0xFF);
  /* Deselect the FLASH: Chip Select high */
  SPI2_Flash_CS_High();

  /* Wait the end of Flash writing */
  SPI_FlashWaitForWriteEnd();
}

/*******************************************************************************
* 函数名称: SPI_FlashBulkErase()
* 函数描述: 删除整个芯片
* 输入参数: 
* 输出参数: 
* 返回值  : 
*******************************************************************************/
void SPI_FlashBulkErase(void)
{
  /* Send write enable instruction */
  SPI_FlashWriteEnable();

  /* Bulk Erase */
  /* Select the FLASH: Chip Select low */
  SPI2_Flash_CS_Low();
  /* Send Chip Erase instruction  */
  SPI_ReadWriteByte(SPI2, CE);
  /* Deselect the FLASH: Chip Select high */
  SPI2_Flash_CS_High();

  /* Wait the end of Flash writing */
  SPI_FlashWaitForWriteEnd();
}



