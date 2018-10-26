/**
  ******************************************************************************
  * @file    usb_desc.c
  * @author  MCD Application Team
  * @version V4.0.0
  * @date    21-January-2013
  * @brief   Descriptors for Joystick Mouse Demo
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
#include "usb_lib.h"
#include "usb_desc.h"

/* Private typedef -----------------------------------------------------------*/
/* Private define ------------------------------------------------------------*/
/* Private macro -------------------------------------------------------------*/
/* Private variables ---------------------------------------------------------*/
/* Extern variables ----------------------------------------------------------*/
/* Private function prototypes -----------------------------------------------*/
/* Private functions ---------------------------------------------------------*/

/* USB Standard Device Descriptor */
const uint8_t Joystick_DeviceDescriptor[JOYSTICK_SIZ_DEVICE_DESC] =
  {
    0x12,                       /*bLength 整个descriptor的长度 18字节*/
    USB_DEVICE_DESCRIPTOR_TYPE, /*bDescriptor Type*/
    0x00,                       /*bcdUSB 设备遵循的USB协议版本号 2.00*/
    0x02,
    0x00,                       /*bDeviceClass     设备所实现的类 0表示类型在接口描述符中定义*/
    0x00,                       /*bDeviceSubClass  设备所实现的子类 上面一项为0时，本项也要设置为0*/
    0x00,                       /*bDeviceProtocol  设备所遵循的协议累类别 上面一项为0时，本项也要设置为0*/
    0x40,                       /*bMaxPacketSize0   端点0的最大数据包长度 64字节*/
    0x34,                       /*idVendor (0x1234)  VID*/
    0x12,
    0x77,                       /*idProduct = 0x5677 PID*/
    0x56,
    0x00,                       /*bcdDevice rel. 2.00*/
    0x02,
    1,                          /*Index of string descriptor describing manufacturer  描述生产厂商的字符描述符的索引号*/
    2,                          /*Index of string descriptor describing product  描述产品的字符描述符的索引号 */
    3,                          /*Index of string descriptor describing the device serial number  描述产品系列号的字符描述符的索引号 */
    0x01                        /*bNumConfigurations   设备所支持的配置数目*/
  }
  ; /* Joystick_DeviceDescriptor */


/* USB Configuration Descriptor */
/*   All Descriptors (Configuration, Interface, Endpoint, Class, Vendor */
const uint8_t Joystick_ConfigDescriptor[JOYSTICK_SIZ_CONFIG_DESC] =
  {
    0x09, /* bLength: Configuration Descriptor size 描述符的长度*/
    USB_CONFIGURATION_DESCRIPTOR_TYPE, /* bDescriptorType: Configuration  描述符的类型*/
    JOYSTICK_SIZ_CONFIG_DESC,  //这个长度是指整个Joystick_ConfigDescriptor中的字节数，此长度一定要和实际元素的个数相同，否则会出现错误
    /* wTotalLength: Bytes returned */
    0x00,
    0x01,         /*bNumInterfaces: 1 interface  配置所支持的接口数目*/
    0x01,         /*bConfigurationValue: Configuration value  用SetConofiguration()选择此配置，所指定的配置号： 1*/
    0x00,         /*iConfiguration: Index of string descriptor describing the configuration 用于描述此配置的字符描述符的索引号： 0 */
    0xE0,         /*bmAttributes: Self powered 供电配置： B7(1 保留), B6(自供电), B5(远程唤醒),B4-B0(0 保留)*/
    			  /*Bus powered: 7th bit, Self Powered: 6th bit, Remote wakeup: 5th bit, reserved: 4..0 bits */
    0x32,         /*MaxPower 100 mA: this current is used for detecting Vbus*/

    /**************接口描述符 Descriptor of Joystick Mouse interface ****************/
    /* 09 */
    0x09,         /*bLength: Interface Descriptor size*/
    USB_INTERFACE_DESCRIPTOR_TYPE,/*bDescriptorType: Interface descriptor type*/
    0x00,         /*bInterfaceNumber: Number of Interface 选择此接口的索引号 从0开始 */
    0x00,         /*bAlternateSetting: Alternate setting*/
    0x02,         /*bNumEndpoints  实现此接口需要的端点数,不包括端点0*/
    0x08,         /*bInterfaceClass: 接口所遵循的类  MASS STORAGE Class USB大容量存储设备*/
    0x06,         /*bInterfaceSubClass : SCSI transparent 简化块命令*/
    0x50,         /*nInterfaceProtocol :  接口所支持的协议，使用单批量传输协议 */
    0,            /*iInterface: Index of string descriptor 用于描述此接口的字符描述符的索引号*/
    /**************类描述符 Descriptor of Joystick Mouse HID ********************/
    /* 18 */
    //0x09,         /*bLength: HID Descriptor size*/
    //HID_DESCRIPTOR_TYPE, /*bDescriptorType: HID*/
    //0x10,0x01,         /*bcdHID: HID Class Spec release number 所遵循的HID协议版本 1.0.0*/    
    //0x00,         /*bCountryCode: Hardware target country*/
    //0x01,         /*bNumDescriptors: Number of HID class descriptors to follow 按照类定义，后续所需要的描述符的数目 */
    //0x22,         /*bDescriptorType  后续的描述符的类型：报告描述符*/
    //JOYSTICK_SIZ_REPORT_DESC,/*wItemLength: Total length of Report descriptor 后续的描述符的长度： */
    //0x00,
    /**************端点描述符 Descriptor of Joystick Mouse endpoint ********************/
    //端点1 IN
    0x07,          /*bLength: Endpoint Descriptor size*/
    USB_ENDPOINT_DESCRIPTOR_TYPE, /*bDescriptorType:*/

    0x01,          /*bEndpointAddress: Endpoint Address (OUT) 端点的特性：B3-B0(端点号), B6-B4(0), B7(1=IN, 0=OUT): 0x81： Endpoint1/ IN*/
    0x02,		   /*bmAttributes: Bulk endpoint*/	
    USB_DATA_SIZE,     /*wMaxPacketSize: 64 Bytes max 此端点的最大有效数据长度： 64 字节*/   
    0x00,
    0x10,          /*bInterval: Polling Interval (32 ms)主机查询此端点数据的间隔时间： (1ms或125us单位): 0x20： 32 ms */

    //端点2 OUT
    0x07,          /* bLength: Endpoint Descriptor size */
    USB_ENDPOINT_DESCRIPTOR_TYPE, /* bDescriptorType: */

    0x82,          /* 0x82 端点2为IN bEndpointAddress: Endpoint Address (IN) */               
                   // bit 3...0 : the endpoint number
                   // bit 6...4 : reserved
                   // bit 7     : 0(OUT), 1(IN)
    0x02,		   /*bmAttributes: Bulk endpoint*/
    USB_DATA_SIZE,    /* wMaxPacketSize: 64 Bytes max */
    0x00, 
    0x20,          /* bInterval: Polling Interval (32 ms) */
  }
  ; /* MOUSE_ConfigDescriptor */


  //ReportDescriptor 是HID专用的
const uint8_t Joystick_ReportDescriptor[JOYSTICK_SIZ_REPORT_DESC] =
  {
	0x05, 0x8c, /* USAGE_PAGE (ST Page) */ 
	0x09, 0x01, /* USAGE (Demo Kit) */ 
	0xa1, 0x01, /* COLLECTION (Application) */ 

	// The Input report 
	0x09,0x03, // USAGE ID - Vendor defined 
	0x15,0x00, // LOGICAL_MINIMUM (0) 
	0x26,0x00, 0xFF, // LOGICAL_MAXIMUM (255) 
	0x75,0x08, // REPORT_SIZE (8) 
	0x95,0x16, // REPORT_COUNT (20) 
	0x81,0x02, // INPUT (Data,Var,Abs) 
	//19
	// The Output report 
	0x09,0x04, // USAGE ID - Vendor defined 
	0x15,0x00, // LOGICAL_MINIMUM (0) 
	0x26,0x00,0xFF, // LOGICAL_MAXIMUM (255) 
	0x75,0x08, // REPORT_SIZE (8) 
	0x95,0x16, // REPORT_COUNT (20) 
	0x91,0x02, // OUTPUT (Data,Var,Abs) 
	//32
	// The Feature report
	/*
	0x09, 0x05, // USAGE ID - Vendor defined 
	0x15,0x00, // LOGICAL_MINIMUM (0) 
	0x26,0x00,0xFF, // LOGICAL_MAXIMUM (255) 
	0x75,0x08, // REPORT_SIZE (8) 
	0x95,0x02, // REPORT_COUNT (2) 
	0xB1,0x02, 
	*/
	/* 45 */ 
	0xc0 /* END_COLLECTION */ 
  }; /* Joystick_ReportDescriptor */

/* USB String Descriptors (optional) */
const uint8_t Joystick_StringLangID[JOYSTICK_SIZ_STRING_LANGID] =
  {
    JOYSTICK_SIZ_STRING_LANGID,  //描述符的长度
    USB_STRING_DESCRIPTOR_TYPE,  //描述符的类型
    0x09,
    0x04
  }
  ; /* LangID = 0x0409: U.S. English */

const uint8_t Joystick_StringVendor[JOYSTICK_SIZ_STRING_VENDOR] =
  {
    JOYSTICK_SIZ_STRING_VENDOR, /* Size of Vendor string */
    USB_STRING_DESCRIPTOR_TYPE,  /* bDescriptorType*/
    /* Manufacturer: "STMicroelectronics" */
	'M', 0, 'y', 0, 'U', 0,'S', 0,'B', 0, '_', 0, 'H', 0,'I',0,'D',0
  };

const uint8_t Joystick_StringProduct[JOYSTICK_SIZ_STRING_PRODUCT] =
  {
    JOYSTICK_SIZ_STRING_PRODUCT,          /* bLength */
    USB_STRING_DESCRIPTOR_TYPE,        /* bDescriptorType */
    'S', 0, 'T', 0, 'M', 0, '3', 0, '2', 0, '_', 0, 'U', 0,
    'S', 0, 'B', 0
  };
uint8_t Joystick_StringSerial[JOYSTICK_SIZ_STRING_SERIAL] =
  {
    JOYSTICK_SIZ_STRING_SERIAL,           /* bLength */
    USB_STRING_DESCRIPTOR_TYPE,        /* bDescriptorType */
    'S', 0, 'T', 0, 'M', 0, '3', 0, '2', 0
  };

/************************ (C) COPYRIGHT STMicroelectronics *****END OF FILE****/


