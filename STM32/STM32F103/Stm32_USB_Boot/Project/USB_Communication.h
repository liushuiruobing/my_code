#ifndef __USB_COMMUNICATION_H
#define __USB_COMMUNICATION_H	

void USB_ConCtrIoInit();
void USB_Communication();
void USB_SendString(u8 *str, int len);
void USB_SendCommand(u8 nCommand, u8* pParam, u8 nParamLen);
u8 CompareBuffer(u8* pBuf1, u8* pBuf2, int nCount);
u16 CheckCRC(u8 *CheckData, int CheckNum, u16 nLastCrc);

#endif