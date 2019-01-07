#ifndef __SPI_FLASH_H
#define __SPI_FLASH_H

#define SPI_FLASH_CS_PORT 			     GPIOB
#define SPI_FLASH_CS1				     GPIO_Pin_12
/* Select SPI FLASH: Chip Select pin low  */
#define SPI_FLASH_CS_LOW()       SPI_FLASH_CS_PORT->BRR = SPI_FLASH_CS1//GPIO_ResetBits(GPIOB, GPIO_Pin_9)

/* Deselect SPI FLASH: Chip Select pin high */
#define SPI_FLASH_CS_HIGH()      SPI_FLASH_CS_PORT->BSRR = SPI_FLASH_CS1//GPIO_SetBits(GPIOB, GPIO_Pin_9)

//====================== SPI     ==============================//
#define SPI1_CS            SPI_FLASH_CS1//SPI_CS  GPIOB 12
#define SPI1_SCK           SPI_FLASH_SCK1//SPI1_SCK  GPIOA 13
#define SPI1_MISO          SPI_FLASH_MISO1//SPI1_MISO GPIOA DO 14
#define SPI1_MOSI          SPI_FLASH_MOSI1//SPI1_MOSI  GPIOA DIO 15
//===============================================================//
/* Select SPI FLASH: Chip Select pin low  */
#define SPI_FLASH_CS_LOW()       SPI_FLASH_CS_PORT->BRR = SPI_FLASH_CS1//GPIO_ResetBits(GPIOB, GPIO_Pin_9)

/* Deselect SPI FLASH: Chip Select pin high */
#define SPI_FLASH_CS_HIGH()      SPI_FLASH_CS_PORT->BSRR = SPI_FLASH_CS1//GPIO_SetBits(GPIOB, GPIO_Pin_9)

#define PC_STAR_TABLE_ADDR    	        						0x000000//用于存放开关机信息 page0

//==========================================================//

void SPI2_FLASH_Init(void);
u32 SPI_FLASH_ReadID(void);
u8 SPI_FLASH_ReadByte(void);
u8 SPI_FLASH_SendByte(u8 byte);
u16 SPI_FLASH_SendHalfWord(u16 HalfWord);
void SPI_FLASH_WriteEnable(void);
void SPI_FLASH_WaitForWriteEnd(void);
void SPI_FLASH_SectorErase(u32 SectorAddr);
void SPI_FLASH_BulkErase(void);
void SPI_FLASH_PageWrite(u8* pBuffer, u32 WriteAddr, u16 NumByteToWrite);
void SPI_FLASH_BufferWrite(u8* pBuffer, u32 WriteAddr, u16 NumByteToWrite);
void SPI_FLASH_BufferRead(u8* pBuffer, u32 ReadAddr, u16 NumByteToRead);
void SPI_FLASH_StartReadSequence(u32 ReadAddr);
void SPI_FLASH_WaitForWriteEnd(void);

void SPI_Buffer_Send(u8* pBuffer,  u16 NumByteToWrite);
void SPIDMARespond(u8 TransferState, u8 CommNum);
#endif
/***********************************************************/


