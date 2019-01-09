#ifndef __CONSTVALUE_H
#define __CONSTVALUE_H


#define FLASH_APP_ADDR_OFFSET 2048

#define FLAG_TO_BOOT 0
#define FLAG_TO_APP 1
#define FLASH_ADDR_UPDATE_FLAG 0x08030000  //��ű�־λ
#define FLASH_ADDR_APP 	0x08010000  //App�����ŵ�ַ
#define LED_ON 1
#define LED_OFF 0

enum ServerToStm32
{
    SERIAL_CODE_SET_STM32_TO_BOOT = 0,
    SERIAL_CODE_SET_STM32_TO_UPDATE,
    SERIAL_CODE_SET_STM32_UPDATE_PACKEG

};
enum Stm32ToServer
{
    SERIAL_CODE_STM32_UPDATE_PREPAR_BOOT_OK,
    SERIAL_CODE_STM32_UPDATE_PREPAR_OK,
    SERIAL_CODE_STM32_UPDATE_NEXT_PACKEG,
    SERIAL_CODE_STM32_UPDATE_CURRENT_PACKEG,
    SERIAL_CODE_STM32_UPDATE_SUCCESS
};

#endif
