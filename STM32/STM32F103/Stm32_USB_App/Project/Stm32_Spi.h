
#ifndef __STM32_W25X40_H__
#define __STM32_W25X40_H__
#include "stm32f10x.h"
#include "ConstValue.h"

extern u8 uFlashWrite[SPI_FLASH_SECTOR_SIZE];
extern u8 uFlashRead[SPI_FLASH_SECTOR_SIZE];

//根据手册设置下面的值
#define WRITE      0x02  /* Write to Memory instruction PP */
#define WRSR       0x01  /* Write Status Register instruction */
#define WREN       0x06  /* Write enable instruction */

#define READ       0x03  /* Read from Memory instruction */
#define RDSR       0x05  /* Read Status Register instruction  */
#define RDID       0x9F  /* Read identification */
#define SE         0x20  /* Sector Erase instruction */
#define CE         0xC7  /* Chip Erase instruction */
#define WIP_Flag   0x01  /* Write In Progress (WIP) flag */
#define Dummy_Byte 0xA5


void SPI2_Init();
u8 SPI_ReadWriteByte(SPI_TypeDef* nSpix, u8 uWriteByte);
u32 SPI_FlashReadID(void);
void SPI_FlashBufferRead(u8* pBuffer, u32 ReadAddr, u16 NumByteToRead);
void SPI_FlashWriteEnable(void);
void SPI_FlashWaitForWriteEnd(void);
void SPI_FlashPageWrite(u8* pBuffer, u32 WriteAddr, u16 NumByteToWrite);
void SPI_FlashBufferWrite(u8* pBuffer, u32 WriteAddr, u16 NumByteToWrite);
void SPI_FlashSectorErase(u32 uSectorAddr);
void SPI_FlashBulkErase(void);
						   
#endif
