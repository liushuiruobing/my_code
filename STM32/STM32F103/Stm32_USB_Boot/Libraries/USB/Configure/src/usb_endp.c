/**
  ******************************************************************************
  * @file    usb_endp.c
  * @author  MCD Application Team
  * @version V4.0.0
  * @date    21-January-2013
  * @brief   Endpoint routines
  ******************************************************************************
  * @attention
  *
  * <h2><center>&copy; COPYRIGHT 2013 STMicroelectronics</center></h2>
  *
  * Licensed under MCD-ST Liberty SW License Agreement V2, (the "License");
  * You may not use this file except in compliance with the License.
  * You may obtain a copy of the License at:
  *
  *        http://www.st.com/software_license_agreement_liberty_v2
  *
  * Unless required by applicable law or agreed to in writing, software 
  * distributed under the License is distributed on an "AS IS" BASIS, 
  * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
  * See the License for the specific language governing permissions and
  * limitations under the License.
  *
  ******************************************************************************
  */


/* Includes ------------------------------------------------------------------*/
#include "hw_config.h"
#include "usb_lib.h"
#include "usb_istr.h"

/* Private typedef -----------------------------------------------------------*/
/* Private define ------------------------------------------------------------*/
/* Private macro -------------------------------------------------------------*/
/* Private variables ---------------------------------------------------------*/
extern __IO uint8_t PrevXferComplete;

/* Private function prototypes -----------------------------------------------*/
/* Private functions ---------------------------------------------------------*/
/*******************************************************************************
* Function Name  : EP1_OUT_Callback.
* Description    : EP1 OUT Callback Routine.
* Input          : None.
* Output         : None.
* Return         : None.
*******************************************************************************/


extern u8 USB_ReceiveFlg;
extern u8 USB_ReceiveBuffer[USB_ONE_PACKAGE_SEND_SIZE];

//数据接收
u32 CountOut = 0;
void EP1_OUT_Callback(void)
{
	/*
	USB_ReceiveFlg = TRUE;
	PMAToUserBufferCopy(USB_ReceiveBuffer, ENDP1_RXADDR, nReportCnt);  //把数据从PMA的缓冲区里读出来放到自己的缓冲区中
	MsgCmd = USB_ReceiveBuffer[21];
	SetEPRxStatus(ENDP1, EP_RX_VALID);
	*/
	CountOut = GetEPRxCount(ENDP1);
	PMAToUserBufferCopy(USB_ReceiveBuffer, ENDP1_RXADDR, CountOut);  //把USB接收的数据放在BufferOut[]里
	SetEPRxValid(ENDP1);
	USB_ReceiveFlg = TRUE;
}
//数据发送
void EP2_IN_Callback(void)
{
	
}


/************************ (C) COPYRIGHT STMicroelectronics *****END OF FILE****/

