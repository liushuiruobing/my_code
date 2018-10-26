#ifndef __USB_COMMUNICATION_H
#define __USB_COMMUNICATION_H	

#include "usb_lib.h"

void USB_ConCtrIoInit();
void USB_Communication();
void USB_SendString(u8 *str, int len);
void USB_SendCommand(u8 nCommand, u8* pParam, u8 nParamLen);
bool CompareData(u8* pDataBuf1, u8* pDataBuf2, const u32 nSize);
bool CopySrcBufToDesBuf(u8* uSrcBuf, u8* uDesBuf, const u16 uCopyBytes);
bool CheckUsbDataWithProtocol(u8* uData, const u8 nLength);

#endif