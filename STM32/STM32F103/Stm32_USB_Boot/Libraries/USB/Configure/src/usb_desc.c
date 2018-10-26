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
    0x12,                       /*bLength ����descriptor�ĳ��� 18�ֽ�*/
    USB_DEVICE_DESCRIPTOR_TYPE, /*bDescriptor Type*/
    0x00,                       /*bcdUSB �豸��ѭ��USBЭ��汾�� 2.00*/
    0x02,
    0x00,                       /*bDeviceClass     �豸��ʵ�ֵ��� 0��ʾ�����ڽӿ��������ж���*/
    0x00,                       /*bDeviceSubClass  �豸��ʵ�ֵ����� ����һ��Ϊ0ʱ������ҲҪ����Ϊ0*/
    0x00,                       /*bDeviceProtocol  �豸����ѭ��Э������� ����һ��Ϊ0ʱ������ҲҪ����Ϊ0*/
    0x40,                       /*bMaxPacketSize0   �˵�0��������ݰ����� 64�ֽ�*/
    0x34,                       /*idVendor (0x1234)  VID*/
    0x12,
    0x77,                       /*idProduct = 0x5677 PID*/
    0x56,
    0x00,                       /*bcdDevice rel. 2.00*/
    0x02,
    1,                          /*Index of string descriptor describing manufacturer  �����������̵��ַ���������������*/
    2,                          /*Index of string descriptor describing product  ������Ʒ���ַ��������������� */
    3,                          /*Index of string descriptor describing the device serial number  ������Ʒϵ�кŵ��ַ��������������� */
    0x01                        /*bNumConfigurations   �豸��֧�ֵ�������Ŀ*/
  }
  ; /* Joystick_DeviceDescriptor */


/* USB Configuration Descriptor */
/*   All Descriptors (Configuration, Interface, Endpoint, Class, Vendor */
const uint8_t Joystick_ConfigDescriptor[JOYSTICK_SIZ_CONFIG_DESC] =
  {
    0x09, /* bLength: Configuration Descriptor size �������ĳ���*/
    USB_CONFIGURATION_DESCRIPTOR_TYPE, /* bDescriptorType: Configuration  ������������*/
    JOYSTICK_SIZ_CONFIG_DESC,  //���������ָ����Joystick_ConfigDescriptor�е��ֽ������˳���һ��Ҫ��ʵ��Ԫ�صĸ�����ͬ���������ִ���
    /* wTotalLength: Bytes returned */
    0x00,
    0x01,         /*bNumInterfaces: 1 interface  ������֧�ֵĽӿ���Ŀ*/
    0x01,         /*bConfigurationValue: Configuration value  ��SetConofiguration()ѡ������ã���ָ�������úţ� 1*/
    0x00,         /*iConfiguration: Index of string descriptor describing the configuration �������������õ��ַ��������������ţ� 0 */
    0xE0,         /*bmAttributes: Self powered �������ã� B7(1 ����), B6(�Թ���), B5(Զ�̻���),B4-B0(0 ����)*/
    			  /*Bus powered: 7th bit, Self Powered: 6th bit, Remote wakeup: 5th bit, reserved: 4..0 bits */
    0x32,         /*MaxPower 100 mA: this current is used for detecting Vbus*/

    /**************�ӿ������� Descriptor of Joystick Mouse interface ****************/
    /* 09 */
    0x09,         /*bLength: Interface Descriptor size*/
    USB_INTERFACE_DESCRIPTOR_TYPE,/*bDescriptorType: Interface descriptor type*/
    0x00,         /*bInterfaceNumber: Number of Interface ѡ��˽ӿڵ������� ��0��ʼ */
    0x00,         /*bAlternateSetting: Alternate setting*/
    0x02,         /*bNumEndpoints  ʵ�ִ˽ӿ���Ҫ�Ķ˵���,�������˵�0*/
    0x08,         /*bInterfaceClass: �ӿ�����ѭ����  MASS STORAGE Class USB�������洢�豸*/
    0x06,         /*bInterfaceSubClass : SCSI transparent �򻯿�����*/
    0x50,         /*nInterfaceProtocol :  �ӿ���֧�ֵ�Э�飬ʹ�õ���������Э�� */
    0,            /*iInterface: Index of string descriptor ���������˽ӿڵ��ַ���������������*/
    /**************�������� Descriptor of Joystick Mouse HID ********************/
    /* 18 */
    //0x09,         /*bLength: HID Descriptor size*/
    //HID_DESCRIPTOR_TYPE, /*bDescriptorType: HID*/
    //0x10,0x01,         /*bcdHID: HID Class Spec release number ����ѭ��HIDЭ��汾 1.0.0*/    
    //0x00,         /*bCountryCode: Hardware target country*/
    //0x01,         /*bNumDescriptors: Number of HID class descriptors to follow �����ඨ�壬��������Ҫ������������Ŀ */
    //0x22,         /*bDescriptorType  �����������������ͣ�����������*/
    //JOYSTICK_SIZ_REPORT_DESC,/*wItemLength: Total length of Report descriptor �������������ĳ��ȣ� */
    //0x00,
    /**************�˵������� Descriptor of Joystick Mouse endpoint ********************/
    //�˵�1 IN
    0x07,          /*bLength: Endpoint Descriptor size*/
    USB_ENDPOINT_DESCRIPTOR_TYPE, /*bDescriptorType:*/

    0x01,          /*bEndpointAddress: Endpoint Address (OUT) �˵�����ԣ�B3-B0(�˵��), B6-B4(0), B7(1=IN, 0=OUT): 0x81�� Endpoint1/ IN*/
    0x02,		   /*bmAttributes: Bulk endpoint*/	
    USB_DATA_SIZE,     /*wMaxPacketSize: 64 Bytes max �˶˵�������Ч���ݳ��ȣ� 64 �ֽ�*/   
    0x00,
    0x10,          /*bInterval: Polling Interval (32 ms)������ѯ�˶˵����ݵļ��ʱ�䣺 (1ms��125us��λ): 0x20�� 32 ms */

    //�˵�2 OUT
    0x07,          /* bLength: Endpoint Descriptor size */
    USB_ENDPOINT_DESCRIPTOR_TYPE, /* bDescriptorType: */

    0x82,          /* 0x82 �˵�2ΪIN bEndpointAddress: Endpoint Address (IN) */               
                   // bit 3...0 : the endpoint number
                   // bit 6...4 : reserved
                   // bit 7     : 0(OUT), 1(IN)
    0x02,		   /*bmAttributes: Bulk endpoint*/
    USB_DATA_SIZE,    /* wMaxPacketSize: 64 Bytes max */
    0x00, 
    0x20,          /* bInterval: Polling Interval (32 ms) */
  }
  ; /* MOUSE_ConfigDescriptor */


  //ReportDescriptor ��HIDר�õ�
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
    JOYSTICK_SIZ_STRING_LANGID,  //�������ĳ���
    USB_STRING_DESCRIPTOR_TYPE,  //������������
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


