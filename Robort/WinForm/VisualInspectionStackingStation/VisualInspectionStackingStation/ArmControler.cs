using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RobotWorkstation
{
    public enum ArmCommandCode:byte  //单片机控制板
    {
        SetOutput = 0x10,               //设置输出口
        GetOutput,                      //读取输出口缓冲区数据
        SetOutputDefault,               //设置输出口开机默认状态（需要存储到SPI-Flash）

        GetInput = 0x18,                //读取输入口

        GetAxisParameters = 0x20,       //读取电机轴运动参数
        SetAxisParametersDefault,       //设置电机轴默认运动参数（需要存储到SPI-Flash）
        SetAxisParameters,              //设置电机轴当前运动参数

        GetAxisStepsAbs = 0x28,         //读取电机轴当前步数
        SetAxisStepsAbs,                //设置电机轴步数(绝对值)
        SetAxisStepsRef,                //设置电机轴步数(相对值)
        SetAxisMoveContinuous,          //设置电机连续运动
        SetAxisStepsMax,                //设置电机轴最大步数
        StopAxis,                       //停止电机轴

        GetAxisState = 0x30,            //读取电机轴状态
        ResetAxisError,                 //复位电机轴错误状态

        AxisGoHome = 0x38,             //设置电机轴回原点

        SetIp = 0x40,                   //设置板卡IP地址（需要存储到SPI-Flash）
        SetVersionHardware,            //设置板卡硬件版本（需要存储到SPI-Flash）

        ResetFactory = 0x48,           //恢复出厂设置（恢复除IP地址外的所有SPI-FLASH数据）

        GetBoardInformation = 0x50,    //读取板卡信息

        SendControlerUpdateFileLength = 0x60,   //系统升级--发送升级文件长度数据
        SendControlerUpdateFileData             //系统升级--发送升级文件

    }

    //单片机板卡定义
    public enum Board
    {
        Conveyor_Empty = 0,     //空盘传输线（8个轴）
        Conveyor_Full,          //满盘传输线（8个轴）
        Module_Basket,          //筐模组（4个角各1个， 4个轴）
        Module_Reject,          //不良品模组 （1个轴）
        IO_Backup,              //备用板接IO            
        Max             
    }

    #region   //电机轴相关
    public enum Axis      //电机轴定义，如果调整了板子的顺序，最好也调整此顺序
    {
        Conveyor_EmptyOuterBasket = 0 + Board.Conveyor_Empty * ArmControler.MAX_AXIS_CHANNEL,   //空盘外框传输线轴
        Conveyor_EmptyBottom_1 = 1 + Board.Conveyor_Empty * ArmControler.MAX_AXIS_CHANNEL,
        Conveyor_EmptyBottom_2 = 2 + Board.Conveyor_Empty * ArmControler.MAX_AXIS_CHANNEL,
        Conveyor_EmptyBottom_3 = 3 + Board.Conveyor_Empty * ArmControler.MAX_AXIS_CHANNEL,
        Conveyor_EmptyInnerBasket = 4 + Board.Conveyor_Empty * ArmControler.MAX_AXIS_CHANNEL,    //空盘内框传输线轴
        Conveyor_EmptyTop_1 = 5 + Board.Conveyor_Empty * ArmControler.MAX_AXIS_CHANNEL,
        Conveyor_EmptyTop_2 = 6 + Board.Conveyor_Empty * ArmControler.MAX_AXIS_CHANNEL,
        Conveyor_EmptyTop_3 = 7 + Board.Conveyor_Empty * ArmControler.MAX_AXIS_CHANNEL,

        Conveyor_FullOuterBasket = 0 + Board.Conveyor_Full * ArmControler.MAX_AXIS_CHANNEL,      //满盘外框传输线轴
        Conveyor_FullBottom_1 = 1 + Board.Conveyor_Full * ArmControler.MAX_AXIS_CHANNEL,
        Conveyor_FullBottom_2 = 2 + Board.Conveyor_Full * ArmControler.MAX_AXIS_CHANNEL,
        Conveyor_FullBottom_3 = 3 + Board.Conveyor_Full * ArmControler.MAX_AXIS_CHANNEL,
        Conveyor_FullInnerBasket = 4 + Board.Conveyor_Full * ArmControler.MAX_AXIS_CHANNEL,      //满盘内框传输线轴
        Conveyor_FullTop_1 = 5 + Board.Conveyor_Full * ArmControler.MAX_AXIS_CHANNEL,
        Conveyor_FullTop_2 = 6 + Board.Conveyor_Full * ArmControler.MAX_AXIS_CHANNEL,
        Conveyor_FullTop_3 = 7 + Board.Conveyor_Full * ArmControler.MAX_AXIS_CHANNEL,

        Module_EmptyOuterBasket = 0 + Board.Module_Basket * ArmControler.MAX_AXIS_CHANNEL,        //筐模组
        Module_EmptyInnerBasket = 1 + Board.Module_Basket * ArmControler.MAX_AXIS_CHANNEL,
        Module_FullOuterBasket = 2 + Board.Module_Basket * ArmControler.MAX_AXIS_CHANNEL,
        Module_FullInnerBasket = 3 + Board.Module_Basket * ArmControler.MAX_AXIS_CHANNEL,

        Module_Reject = 0 + Board.Module_Reject * ArmControler.MAX_AXIS_CHANNEL,                  //不良品模组
        Modul_LinkChain = 1 + Board.Module_Reject * ArmControler.MAX_AXIS_CHANNEL,                //链板线

        Max = 14             //总轴数,此值要根据上表的变化修改
    }

    //电机轴运动方向
    public enum AxisDir
    {
        Forward = 0,  //正转
        Reverse = 1,  //反转
    }

    //电机驱动状态
    public enum MotorAxisState
    {
        Ready = 0,      //轴已准备就绪
        ErrorStop = 1,  //出现错误，轴停止
        Motion = 2,     //轴正在执行运动
    }
    #endregion

    #region  //IO相关

    public enum ARM_InputPoint  //具体编号要等电气连接图出来之后与之相对应，机械臂的IO由机械臂的脚本处理，上位机只查询标志
    {
        //Key
        IO_IN_KeyRun = 0 + Board.IO_Backup * ArmControler.MAX_IO_CHANNEL,
        IO_IN_KeyPause = 1 + Board.IO_Backup * ArmControler.MAX_IO_CHANNEL,
        IO_IN_KeyStop = 2 + Board.IO_Backup * ArmControler.MAX_IO_CHANNEL,
        IO_IN_KeyReset = 3 + Board.IO_Backup * ArmControler.MAX_IO_CHANNEL,
        IO_IN_KeyScram = 4 + Board.IO_Backup * ArmControler.MAX_IO_CHANNEL,
        IO_IN_KeyAddEmptySalver = 5 + Board.IO_Backup * ArmControler.MAX_IO_CHANNEL,    //上空盘
        IO_IN_KeyTackFullSalver = 6 + Board.IO_Backup * ArmControler.MAX_IO_CHANNEL,    //拿走满盘

        //空盘最外部(筐)传输线
        IO_IN_Conveyor_EmptyOuter_StopAirCylGoArrive = 0 + Board.Conveyor_Empty * ArmControler.MAX_IO_CHANNEL,       //阻挡气缸进到位
        IO_IN_Conveyor_EmptyOuter_StopAirCylBackArrive = 1 + Board.Conveyor_Empty * ArmControler.MAX_IO_CHANNEL,     //阻挡气缸退到位
        IO_IN_Conveyor_EmptyOuter_BoltAirCylGoArrive = 2 + Board.Conveyor_Empty * ArmControler.MAX_IO_CHANNEL,       //插销气缸进到位
        IO_IN_Conveyor_EmptyOuter_BoltAirCylBackArrive = 3 + Board.Conveyor_Empty * ArmControler.MAX_IO_CHANNEL,     //插销气缸退到位

        //空盘底层传输线1
        IO_IN_Conveyor_EmptyBottom_1_StopAirCylGoArrive = 4 + Board.Conveyor_Empty * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Conveyor_EmptyBottom_1_StopAirCylBackArrive = 5 + Board.Conveyor_Empty * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Conveyor_EmptyBottom_1_BoltAirCylGoArrive = 6 +Board.Conveyor_Empty * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Conveyor_EmptyBottom_1_BoltAirCylBackArrive = 7 + Board.Conveyor_Empty * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Conveyor_EmptyBottom_1_InSensor = 8 + Board.Conveyor_Empty * ArmControler.MAX_IO_CHANNEL,              //入口传感器

        //空盘底层传输线2
        IO_IN_Conveyor_EmptyBottom_2_StopAirCylGoArrive = 9 + Board.Conveyor_Empty * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Conveyor_EmptyBottom_2_StopAirCylBackArrive = 10 + Board.Conveyor_Empty * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Conveyor_EmptyBottom_2_BoltAirCylGoArrive = 11 + Board.Conveyor_Empty * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Conveyor_EmptyBottom_2_BoltAirCylBackArrive = 12 + Board.Conveyor_Empty * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Conveyor_EmptyBottom_2_InSensor = 13 + Board.Conveyor_Empty * ArmControler.MAX_IO_CHANNEL,

        //空盘底层传输线3
        IO_IN_Conveyor_EmptyBottom_3_StopAirCylGoArrive = 14 + Board.Conveyor_Empty * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Conveyor_EmptyBottom_3_StopAirCylBackArrive = 15 + Board.Conveyor_Empty * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Conveyor_EmptyBottom_3_BoltAirCylGoArrive = 16 + Board.Conveyor_Empty * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Conveyor_EmptyBottom_3_BoltAirCylBackArrive = 17 + Board.Conveyor_Empty * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Conveyor_EmptyBottom_3_InSensor = 18 + Board.Conveyor_Empty * ArmControler.MAX_IO_CHANNEL,

        //空盘最内部(筐)传输线
        IO_IN_Conveyor_EmptyInner_StopAirCylGoArrive = 19 + Board.Conveyor_Empty * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Conveyor_EmptyInner_StopAirCylBackArrive = 20 + Board.Conveyor_Empty * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Conveyor_EmptyInner_BoltAirCylGoArrive = 21 + Board.Conveyor_Empty * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Conveyor_EmptyInner_BoltAirCylBackArrive = 22 + Board.Conveyor_Empty * ArmControler.MAX_IO_CHANNEL,

        //空盘顶层传输线1
        IO_IN_Conveyor_EmptyTop_1_StopAirCylGoArrive = 23 + Board.Conveyor_Empty * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Conveyor_EmptyTop_1_StopAirCylBackArrive = 24 + Board.Conveyor_Empty * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Conveyor_EmptyTop_1_BoltAirCylGoArrive = 25 + Board.Conveyor_Empty * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Conveyor_EmptyTop_1_BoltAirCylBackArrive = 26 + Board.Conveyor_Empty * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Conveyor_EmptyTop_1_InSensor = 27 + Board.Conveyor_Empty * ArmControler.MAX_IO_CHANNEL,

        //空盘底层传输线2
        IO_IN_Conveyor_EmptyTop_2_StopAirCylGoArrive = 28 + Board.Conveyor_Empty * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Conveyor_EmptyTop_2_StopAirCylBackArrive = 29 + Board.Conveyor_Empty * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Conveyor_EmptyTop_2_BoltAirCylGoArrive = 30 + Board.Conveyor_Empty * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Conveyor_EmptyTop_2_BoltAirCylBackArrive = 31 + Board.Conveyor_Empty * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Conveyor_EmptyTop_2_InSensor = 7 + Board.IO_Backup * ArmControler.MAX_IO_CHANNEL,

        //空盘底层传输线3
        IO_IN_Conveyor_EmptyTop_3_StopAirCylGoArrive = 8 + Board.IO_Backup * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Conveyor_EmptyTop_3_StopAirCylBackArrive = 9 + Board.IO_Backup * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Conveyor_EmptyTop_3_BoltAirCylGoArrive = 10 + Board.IO_Backup * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Conveyor_EmptyTop_3_BoltAirCylBackArrive = 11 + Board.IO_Backup * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Conveyor_EmptyTop_3_InSensor = 12 + Board.IO_Backup * ArmControler.MAX_IO_CHANNEL,

        //满盘最外部(筐)传输线
        IO_IN_Conveyor_FullOuter_StopAirCylGoArrive = 0 + Board.Conveyor_Full * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Conveyor_FullOuter_StopAirCylBackArrive = 1 + Board.Conveyor_Full * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Conveyor_FullOuter_BoltAirCylGoArrive = 2 + Board.Conveyor_Full * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Conveyor_FullOuter_BoltAirCylBackArrive = 3 + Board.Conveyor_Full * ArmControler.MAX_IO_CHANNEL,

        //满盘底层传输线1
        IO_IN_Conveyor_FullBottom_1_StopAirCylGoArrive = 4 + Board.Conveyor_Full * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Conveyor_FullBottom_1_StopAirCylBackArrive = 5 + Board.Conveyor_Full * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Conveyor_FullBottom_1_BoltAirCylGoArrive = 6 + Board.Conveyor_Full * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Conveyor_FullBottom_1_BoltAirCylBackArrive = 7 + Board.Conveyor_Full * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Conveyor_FullBottom_1_InSensor = 8 + Board.Conveyor_Full * ArmControler.MAX_IO_CHANNEL,

        //满盘底层传输线2
        IO_IN_Conveyor_FullBottom_2_StopAirCylGoArrive = 9 + Board.Conveyor_Full * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Conveyor_FullBottom_2_StopAirCylBackArrive = 10 + Board.Conveyor_Full * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Conveyor_FullBottom_2_BoltAirCylGoArrive = 11 + Board.Conveyor_Full * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Conveyor_FullBottom_2_BoltAirCylBackArrive = 12 + Board.Conveyor_Full * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Conveyor_FullBottom_2_InSensor = 13 + Board.Conveyor_Full * ArmControler.MAX_IO_CHANNEL,

        //满盘底层传输线3
        IO_IN_Conveyor_FullBottom_3_StopAirCylGoArrive = 14 + Board.Conveyor_Full * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Conveyor_FullBottom_3_StopAirCylBackArrive = 15 + Board.Conveyor_Full * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Conveyor_FullBottom_3_BoltAirCylGoArrive = 16 + Board.Conveyor_Full * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Conveyor_FullBottom_3_BoltAirCylBackArrive = 17 + Board.Conveyor_Full * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Conveyor_FullBottom_3_InSensor = 18 + Board.Conveyor_Full * ArmControler.MAX_IO_CHANNEL,

        //满盘最内部(筐)传输线
        IO_IN_Conveyor_FullInner_StopAirCylGoArrive = 19 + Board.Conveyor_Full * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Conveyor_FullInner_StopAirCylBackArrive = 20 + Board.Conveyor_Full * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Conveyor_FullInner_BoltAirCylGoArrive = 21 + Board.Conveyor_Full * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Conveyor_FullInner_BoltAirCylBackArrive = 22 + Board.Conveyor_Full * ArmControler.MAX_IO_CHANNEL,

        //满盘顶层传输线1
        IO_IN_Conveyor_FullTop_1_StopAirCylGoArrive = 23 + Board.Conveyor_Full * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Conveyor_FullTop_1_StopAirCylBackArrive = 24 + Board.Conveyor_Full * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Conveyor_FullTop_1_BoltAirCylGoArrive = 25 + Board.Conveyor_Full * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Conveyor_FullTop_1_BoltAirCylBackArrive = 26 + Board.Conveyor_Full * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Conveyor_FullTop_1_InSensor = 27 + Board.Conveyor_Full * ArmControler.MAX_IO_CHANNEL,

        //满盘顶层传输线2
        IO_IN_Conveyor_FullTop_2_StopAirCylGoArrive = 28 + Board.Conveyor_Full * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Conveyor_FullTop_2_StopAirCylBackArrive = 29 + Board.Conveyor_Full * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Conveyor_FullTop_2_BoltAirCylGoArrive = 30 + Board.Conveyor_Full * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Conveyor_FullTop_2_BoltAirCylBackArrive = 31 + Board.Conveyor_Full * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Conveyor_FullTop_2_InSensor = 13 + Board.IO_Backup * ArmControler.MAX_IO_CHANNEL,

        //满盘顶层传输线3
        IO_IN_Conveyor_FullTop_3_StopAirCylGoArrive = 14 + Board.IO_Backup * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Conveyor_FullTop_3_StopAirCylBackArrive = 15 + Board.IO_Backup * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Conveyor_FullTop_3_BoltAirCylGoArrive = 16 + Board.IO_Backup * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Conveyor_FullTop_3_BoltAirCylBackArrive = 17 + Board.IO_Backup * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Conveyor_FullTop_3_InSensor = 18 + Board.IO_Backup * ArmControler.MAX_IO_CHANNEL,

        //空盘(筐)最外部模组
        IO_IN_Module_EmptyOuter_BoltAirCylGoArrive = 0 + Board.Module_Basket * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Module_EmptyOuter_BoltAirCylBackArrive = 1 + Board.Module_Basket * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Module_EmptyOuter_BottomLimitSensor = 2 + Board.Module_Basket * ArmControler.MAX_IO_CHANNEL,       //底部限位传感器
        IO_IN_Module_EmptyOuter_TopLimitSensor = 3 + Board.Module_Basket * ArmControler.MAX_IO_CHANNEL,          //顶部限位传感器
        IO_IN_Module_EmptyOuter_HomeLimitSensor = 4 + Board.Module_Basket * ArmControler.MAX_IO_CHANNEL,         //原点传感器

        //空盘(筐)最内部模组
        IO_IN_Module_EmptyInner_BoltAirCylGoArrive = 5 + Board.Module_Basket * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Module_EmptyInner_BoltAirCylBackArrive = 6 + Board.Module_Basket * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Module_EmptyInner_BottomLimitSensor = 7 + Board.Module_Basket * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Module_EmptyInner_TopLimitSensor = 8 + Board.Module_Basket * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Module_EmptyInner_HomeLimitSensor = 9 + Board.Module_Basket * ArmControler.MAX_IO_CHANNEL,

        //满盘(筐)最外部模组
        IO_IN_Module_FullOuter_BoltAirCylGoArrive = 10 + Board.Module_Basket * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Module_FullOuter_BoltAirCylBackArrive = 11 + Board.Module_Basket * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Module_FullOuter_BottomLimitSensor = 12 + Board.Module_Basket * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Module_FullOuter_TopLimitSensor = 13 + Board.Module_Basket * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Module_FullOuter_HomeLimitSensor = 14 + Board.Module_Basket * ArmControler.MAX_IO_CHANNEL,

        //满盘(筐)最内部模组
        IO_IN_Module_FullInner_BoltAirCylGoArrive = 15 + Board.Module_Basket * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Module_FullInner_BoltAirCylBackArrive = 16 + Board.Module_Basket * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Module_FullInner_BottomLimitSensor = 17 + Board.Module_Basket * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Module_FullInner_TopLimitSensor = 18 + Board.Module_Basket * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Module_FullInner_HomeLimitSensor = 19 + Board.Module_Basket * ArmControler.MAX_IO_CHANNEL,

        //不良品模组
        IO_IN_Module_Reject_LiftAirCylGoArrive = 0 + Board.Module_Reject * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Module_Reject_LiftAirCylBackArrive = 1 + Board.Module_Reject * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Module_Reject_LeftClipAirCylGoArrive = 2 + Board.Module_Reject * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Module_Reject_LeftClipAirCylBackArrive = 3 + Board.Module_Reject * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Module_Reject_RightClipAirCylGoArrive = 4 + Board.Module_Reject * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Module_Reject_RightClipAirCylBackArrive = 5 + Board.Module_Reject * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Module_Reject_UpperLimitSensor = 6 + Board.Module_Reject * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Module_Reject_LowerLimitSensor = 7 + Board.Module_Reject * ArmControler.MAX_IO_CHANNEL,
        IO_IN_Module_Reject_HomeLimitSensor = 8 + Board.Module_Reject * ArmControler.MAX_IO_CHANNEL,

        //链板线
        IO_IN_Module_LinkChain_HorizontalSensor = 9 + Board.Module_Reject * ArmControler.MAX_IO_CHANNEL,          //水平对射传感器
        IO_IN_Module_LinkChain_VerticalSensor = 10 + Board.Module_Reject * ArmControler.MAX_IO_CHANNEL,           //垂直对射传感器

        //型材结构上要安装的传感器
        IO_IN_Frame_EmptyOuterBasket_CenterSensor = 19 + Board.IO_Backup * ArmControler.MAX_IO_CHANNEL,           //上空盘处型材中间，检测筐中是否有盘
        IO_IN_Frame_EmptyOuterBasket_TopSensor = 20 + Board.IO_Backup * ArmControler.MAX_IO_CHANNEL,              //上空盘处型材顶部，检测筐中是否满盘
        IO_IN_Frame_FullOuterBasket_CenterSensor = 21 + Board.IO_Backup * ArmControler.MAX_IO_CHANNEL,            //下满盘处型材中间，检测筐中是否有盘
        IO_IN_Frame_FullOuterBasket_TopSensor = 22 + Board.IO_Backup * ArmControler.MAX_IO_CHANNEL,               //下满盘处型材顶部，检测筐中是否满盘
        IO_IN_Frame_EmptyCoveyoner_BottomCenterSensor_1 = 23 + Board.IO_Backup * ArmControler.MAX_IO_CHANNEL,     //空盘传底层输线型材中间处传感器1, 检测空盘传输线中间处是否有空筐
        IO_IN_Frame_EmptyCoveyoner_BottomCenterSensor_2 = 24 + Board.IO_Backup * ArmControler.MAX_IO_CHANNEL,     //空盘传底层输线型材中间处传感器2, 检测空盘传输线中间处是否有空筐
        IO_IN_Frame_FullCoveyoner_BottomCenterSensor_1 = 25 + Board.IO_Backup * ArmControler.MAX_IO_CHANNEL,      //满盘传上层输线型材中间处传感器1, 检测满盘传输线中间处是否有空筐
        IO_IN_Frame_FullCoveyoner_BottomCenterSensor_2 = 26 + Board.IO_Backup * ArmControler.MAX_IO_CHANNEL,      //满盘传上层输线型材中间处传感器2, 检测满盘传输线中间处是否有空筐

        IO_IN_MAX = 122   //所有IO_IN的总点数
    }

    public enum ARM_OutputPoint   //具体编号要等电气连接图出来之后与之相对应，
    {
        //Led
        IO_OUT_LedRed = 0 + Board.IO_Backup * ArmControler.MAX_IO_CHANNEL,
        IO_OUT_LedOriange = 1 + Board.IO_Backup * ArmControler.MAX_IO_CHANNEL,
        IO_OUT_LedGreen = 2 + Board.IO_Backup * ArmControler.MAX_IO_CHANNEL,
        IO_OUT_LedBlue = 3 + Board.IO_Backup * ArmControler.MAX_IO_CHANNEL,
        IO_OUT_LedKeyRun = 4 + Board.IO_Backup * ArmControler.MAX_IO_CHANNEL,
        IO_OUT_LedKeyPause = 5 + Board.IO_Backup * ArmControler.MAX_IO_CHANNEL,
        IO_OUT_LedKeyStop = 6 + Board.IO_Backup * ArmControler.MAX_IO_CHANNEL,
        IO_OUT_LedKeyReset = 7 + Board.IO_Backup * ArmControler.MAX_IO_CHANNEL,
        IO_OUT_Beep = 8 + Board.IO_Backup * ArmControler.MAX_IO_CHANNEL,

        //空盘传输线
        IO_OUT_Conveyor_EmptyOuter_StopAirCyl = 0 + Board.Conveyor_Empty * ArmControler.MAX_IO_CHANNEL,       //阻挡气缸
        IO_OUT_Conveyor_EmptyOuter_BoltAirCyl = 1 + Board.Conveyor_Empty * ArmControler.MAX_IO_CHANNEL,       //插销锁定气缸
        IO_OUT_Conveyor_EmptyBottom_1_StopAirCyl = 2 + Board.Conveyor_Empty * ArmControler.MAX_IO_CHANNEL,      
        IO_OUT_Conveyor_EmptyBottom_1_BoltAirCyl = 3 + Board.Conveyor_Empty * ArmControler.MAX_IO_CHANNEL,
        IO_OUT_Conveyor_EmptyBottom_2_StopAirCyl = 4 + Board.Conveyor_Empty * ArmControler.MAX_IO_CHANNEL,
        IO_OUT_Conveyor_EmptyBottom_2_BoltAirCyl = 5 + Board.Conveyor_Empty * ArmControler.MAX_IO_CHANNEL,
        IO_OUT_Conveyor_EmptyBottom_3_StopAirCyl = 6 + Board.Conveyor_Empty * ArmControler.MAX_IO_CHANNEL,
        IO_OUT_Conveyor_EmptyBottom_3_BoltAirCyl = 7 + Board.Conveyor_Empty * ArmControler.MAX_IO_CHANNEL,
        IO_OUT_Conveyor_EmptyInner_StopAirCyl = 8 + Board.Conveyor_Empty * ArmControler.MAX_IO_CHANNEL,       //阻挡气缸
        IO_OUT_Conveyor_EmptyInner_BoltAirCyl = 9 + Board.Conveyor_Empty * ArmControler.MAX_IO_CHANNEL,       //插销锁定气缸
        IO_OUT_Conveyor_EmptyTop_1_StopAirCyl = 10 + Board.Conveyor_Empty * ArmControler.MAX_IO_CHANNEL,
        IO_OUT_Conveyor_EmptyTop_1_BoltAirCyl = 11 + Board.Conveyor_Empty * ArmControler.MAX_IO_CHANNEL,
        IO_OUT_Conveyor_EmptyTop_2_StopAirCyl = 12 + Board.Conveyor_Empty * ArmControler.MAX_IO_CHANNEL,
        IO_OUT_Conveyor_EmptyTop_2_BoltAirCyl = 13 + Board.Conveyor_Empty * ArmControler.MAX_IO_CHANNEL,
        IO_OUT_Conveyor_EmptyTop_3_StopAirCyl = 14 + Board.Conveyor_Empty * ArmControler.MAX_IO_CHANNEL,
        IO_OUT_Conveyor_EmptyTop_3_BoltAirCyl = 15 + Board.Conveyor_Empty * ArmControler.MAX_IO_CHANNEL,

        //满盘传输线
        IO_OUT_Conveyor_FullOuter_StopAirCyl = 0 + Board.Conveyor_Full * ArmControler.MAX_IO_CHANNEL,       //阻挡气缸
        IO_OUT_Conveyor_FullOuter_BoltAirCyl = 1 + Board.Conveyor_Full * ArmControler.MAX_IO_CHANNEL,       //插销锁定气缸
        IO_OUT_Conveyor_FullBottom_1_StopAirCyl = 2 + Board.Conveyor_Full * ArmControler.MAX_IO_CHANNEL,
        IO_OUT_Conveyor_FullBottom_1_BoltAirCyl = 3 + Board.Conveyor_Full * ArmControler.MAX_IO_CHANNEL,
        IO_OUT_Conveyor_FullBottom_2_StopAirCyl = 4 + Board.Conveyor_Full * ArmControler.MAX_IO_CHANNEL,
        IO_OUT_Conveyor_FullBottom_2_BoltAirCyl = 5 + Board.Conveyor_Full * ArmControler.MAX_IO_CHANNEL,
        IO_OUT_Conveyor_FullBottom_3_StopAirCyl = 6 + Board.Conveyor_Full * ArmControler.MAX_IO_CHANNEL,
        IO_OUT_Conveyor_FullBottom_3_BoltAirCyl = 7 + Board.Conveyor_Full * ArmControler.MAX_IO_CHANNEL,
        IO_OUT_Conveyor_FullInner_StopAirCyl = 8 + Board.Conveyor_Full * ArmControler.MAX_IO_CHANNEL,       //阻挡气缸
        IO_OUT_Conveyor_FullInner_BoltAirCyl = 9 + Board.Conveyor_Full * ArmControler.MAX_IO_CHANNEL,       //插销锁定气缸
        IO_OUT_Conveyor_FullTop_1_StopAirCyl = 10 + Board.Conveyor_Full * ArmControler.MAX_IO_CHANNEL,
        IO_OUT_Conveyor_FullTop_1_BoltAirCyl = 11 + Board.Conveyor_Full * ArmControler.MAX_IO_CHANNEL,
        IO_OUT_Conveyor_FullTop_2_StopAirCyl = 12 + Board.Conveyor_Full * ArmControler.MAX_IO_CHANNEL,
        IO_OUT_Conveyor_FullTop_2_BoltAirCyl = 13 + Board.Conveyor_Full * ArmControler.MAX_IO_CHANNEL,
        IO_OUT_Conveyor_FullTop_3_StopAirCyl = 14 + Board.Conveyor_Full * ArmControler.MAX_IO_CHANNEL,
        IO_OUT_Conveyor_FullTop_3_BoltAirCyl = 15 + Board.Conveyor_Full * ArmControler.MAX_IO_CHANNEL,

        //(筐) 模组
        IO_OUT_Module_EmptyOuter_BoltAirCyl = 0 + Board.Module_Basket * ArmControler.MAX_IO_CHANNEL,     //空盘(筐)最外部模组
        IO_OUT_Module_EmptyInner_BoltAirCyl = 1 + Board.Module_Basket * ArmControler.MAX_IO_CHANNEL,     //空盘(筐)最内部模组
        IO_OUT_Module_FullOuter_BoltAirCyl = 2 + Board.Module_Basket * ArmControler.MAX_IO_CHANNEL,      //满盘(筐)最外部模组
        IO_OUT_Module_FullInner_BoltAirCyl = 3 + Board.Module_Basket * ArmControler.MAX_IO_CHANNEL,     //满盘(筐)最内部模组

        //不良品模组
        IO_OUT_Module_Reject_LiftAirCyl = 0 + Board.Module_Reject * ArmControler.MAX_IO_CHANNEL,        //顶升气缸
        IO_IN_Module_Reject_LeftClipAirCyl = 1 + Board.Module_Reject * ArmControler.MAX_IO_CHANNEL,     //左加紧气缸
        IO_IN_Module_Reject_RightClipAirCyl = 2 + Board.Module_Reject * ArmControler.MAX_IO_CHANNEL,    //右夹紧气缸

        IO_OUT_MAX = 48
    }

    public enum IOValue
    {
        IOValueLow = 0,
        IOValueHigh
    }

    public enum LED_State
    {
        LED_OFF = 0,
        LED_ON
    }

    #endregion

    public class ArmControler
    {
        private static ArmControler m_UniqueIo = null;
        private static readonly object m_Locker = new object();
        private byte[] m_SendMeas = new byte[Message.MessageLength];
        public MyTcpClient[] m_MyTcpClientArm = new MyTcpClient[(int)Board.Max];

        public const int MAX_IO_CHANNEL = 4 * 8;  //一块板卡包括32/32个隔离数字量输入/输出通道 
        public const int MAX_AXIS_CHANNEL = 8;    //一块板卡包括8个电机轴

        private uint[] m_InputValue = new uint[(int)Board.Max];  //ARM控制板IO输入的缓存 4个byte，每位代表1个IO，共32个,从而用uint来表示，32位每个位代表1个IO  
        private bool[] m_InputPointStateBackups = new bool[(int)ARM_InputPoint.IO_IN_MAX];  //输入点状态备份
        private int[,] m_AxisState = new int[(int)Board.Max, MAX_AXIS_CHANNEL];
        private int[,] m_AxisPostion = new int[(int)Board.Max, MAX_AXIS_CHANNEL];

        public static int m_ConveyorAxisMaxStep = 1000;   //传输线电机把盘送到位，所要运行的步数
        public static int m_OverturnAxisMaxStep = 1000;   //翻转电机,翻转所需的步数

        private ArmControler()
        { 
            for (int i = 0; i < (int)ARM_InputPoint.IO_IN_MAX; i++)
            {
                m_InputPointStateBackups[i] = false;
            }
        }

        /// <summary>
        /// 定义公有方法提供一个全局访问点,同时你也可以定义公有属性来提供全局访问点
        /// </summary>
        /// <returns></returns>
        public static ArmControler GetInstance()
        {
            if (m_UniqueIo == null)
            {
                lock (m_Locker)
                {
                    if (m_UniqueIo == null)
                        m_UniqueIo = new ArmControler();
                }
            }
            return m_UniqueIo;
        }

        /// <summary>
        /// 打开ARM卡
        /// </summary>
        public void Open()
        {
            //传输线上的Arm控制板
            m_MyTcpClientArm[(int)Board.Conveyor_Empty] = new MyTcpClient();
            IPAddress ControlIp = IPAddress.Parse(Profile.m_Config.ControlerArmIp);
            int ControlPort = Profile.m_Config.ControlerArmPort;
            m_MyTcpClientArm[(int)Board.Conveyor_Empty].CreateConnect(ControlIp, ControlPort);

            //其他Arm控制板

        }

        /// <summary>
        /// 关闭ARM卡
        /// </summary>
        public void Close()
        {
            for (int i = 0; i < (int)Board.Max; i++)
            {
                if (IsBoardConnected((Board)i))
                {
                    m_MyTcpClientArm[i].Close();
                }
            }
        }

        public bool IsBoardConnected(Board board)
        {
            if (m_MyTcpClientArm[(int)board] != null)
                return m_MyTcpClientArm[(int)board].IsConnected;
            else
                return false;
        }

        //给单片机发送非电机轴的指令，仅指令，无参数
        public void SendCommandToArm(Board board, ArmCommandCode Code)
        {
            if (!IsBoardConnected(board))
                return;

            Message.MakeSendArrayByCode((byte)Code, ref m_SendMeas);
            m_MyTcpClientArm[(int)board].ClientWrite(m_SendMeas);
        }

        //给单片机发送电机轴相关的指令，axis 轴号， code命令
        public bool SendCommandToArmWithAxis(Axis axis, ArmCommandCode Code)
        {
            int indexBoard = (int)axis / MAX_AXIS_CHANNEL;  //板卡索引
            int indexAxis = (int)axis % MAX_AXIS_CHANNEL;  //板卡内轴号索引

            if (!IsBoardConnected((Board)indexBoard))
                return false;

            Message.MakeSendArrayByCode((byte)Code, ref m_SendMeas);
            m_SendMeas[Message.MessageCommandIndex + 1] = (byte)indexAxis;
            m_SendMeas[Message.MessageSumCheck] = MyMath.CalculateSum(m_SendMeas, Message.MessageLength);

            m_MyTcpClientArm[indexBoard].ClientWrite(m_SendMeas);

            return true;
        }

        /// <summary>
        /// 发送读取输入点指令
        /// </summary>
        /// <param name="board">板卡类型</param>
        public void SendReadInputPoint(Board board)
        {
            SendCommandToArm(board, ArmCommandCode.GetInput);
        }

        /// <summary>
        /// 设置输入口
        /// </summary>
        /// <param name="board">板卡号/param>
        /// <param name="InputData">输入点位数据</param>
        /// <returns></returns>
        public void SetInputPoint(Board board, uint InputData)
        {
            m_InputValue[(int)board] = InputData;
        }

        /// <summary>
        /// 读取输入口
        /// </summary>
        /// <param name="point">输入点位</param>
        /// <returns></returns>
        public bool ReadInputPoint(ARM_InputPoint point)
        {
            int indexBoard = (int)point / MAX_IO_CHANNEL;  //板卡索引
            int indexPoint = (int)point % MAX_IO_CHANNEL;  //板卡内端口号索引
            uint mask = (uint)1 << indexPoint;

            return (m_InputValue[indexBoard] & mask) > 0;
        }

        /// <summary>
        /// 设置IO输入点的状态备份
        /// </summary>
        /// <param name="Point">输入点位</param>
        /// <param name="State">点位状态</param>
        public void SetInputPointStateBackups(ARM_InputPoint Point, bool State)
        {
            m_InputPointStateBackups[(int)Point] = State;
        }

        /// <summary>
        /// 读取IO输入点的状态备份
        /// </summary>
        /// <param name="Point">输入点位</param>
        /// <returns></returns>
        public bool ReadInputPointStateBackups(ARM_InputPoint Point)
        {
           return m_InputPointStateBackups[(int)Point];
        }

        /// <summary>
        /// 发送读取轴当前位置命令
        /// </summary>
        /// <param name="axis">轴号</param>
        public void SendReadAxisPostion(Axis axis)
        {
            SendCommandToArmWithAxis(axis, ArmCommandCode.GetAxisStepsAbs);
        }

        /// <summary>
        /// 设置当前位置
        /// </summary>
        /// <param name="axis">轴号</param>
        /// <param name="steps">步数</param>
        public void SetAxisPostion(Axis axis, uint steps)
        {
            int indexBoard = (int)axis / MAX_AXIS_CHANNEL;  //板卡索引
            int indexAxis = (int)axis % MAX_AXIS_CHANNEL;  //板卡内轴号索引

            m_AxisPostion[indexBoard, indexAxis] = (int)steps;  //有负值
        }

        /// <summary>
        /// 读取轴当前位置
        /// </summary>
        /// <param name="axis">轴号</param>
        /// <returns></returns>
        public int ReadAxisPostion(Axis axis)
        {
            int indexBoard = (int)axis / MAX_AXIS_CHANNEL;  //板卡索引
            int indexAxis = (int)axis % MAX_AXIS_CHANNEL;  //板卡内轴号索引

            if (!IsBoardConnected((Board)indexBoard))
                return 0;

            return m_AxisPostion[indexBoard, indexAxis];
        }

        /// <summary>
        /// 发送读取轴状态命令
        /// </summary>
        /// <param name="axis">轴号</param>
        public void SendReadAxisState(Axis axis)
        {
            SendCommandToArmWithAxis(axis, ArmCommandCode.GetAxisState);
        }

        /// <summary>
        /// 设置轴状态
        /// </summary>
        /// <param name="axis">轴号</param>
        /// <param name="State">状态</param>
        public void SetAxisState(Axis axis, int State)
        {
            int indexBoard = (int)axis / MAX_AXIS_CHANNEL;  //板卡索引
            int indexAxis = (int)axis % MAX_AXIS_CHANNEL;  //板卡内轴号索引

            m_AxisState[(int)indexBoard, (int)indexAxis] = State;  //m_AxisState 中轴的索引为DataIndex - 1
        }

        /// <summary>
        /// 读取轴状态
        /// </summary>
        /// <param name="axis">轴号</param>
        /// <returns>状态</returns>
        public MotorAxisState ReadAxisState(Axis axis)
        {
            int indexBoard = (int)axis / MAX_AXIS_CHANNEL;  //板卡索引
            int indexAxis = (int)axis % MAX_AXIS_CHANNEL;  //板卡内轴号索引

            return (MotorAxisState)m_AxisState[indexBoard, indexAxis]; //m_AxisState 中轴的索引为DataIndex - 1
        }

        /// <summary>
        /// 读取轴状态
        /// </summary>
        /// <param name="axis">轴号</param>
        /// <returns>状态字符串</returns>
        public string ReadAxisStateString(Axis axis)
        {
            int indexBoard = (int)axis / MAX_AXIS_CHANNEL;  //板卡索引
            int indexAxis = (int)axis % MAX_AXIS_CHANNEL;  //板卡内轴号索引

            if (!IsBoardConnected((Board)indexBoard))
                return " ";

            string retStr = " ";
            MotorAxisState State = (MotorAxisState)m_AxisState[indexBoard, indexAxis];
            switch (State)
            {
                case MotorAxisState.Ready:
                    retStr = "轴已准备就绪";
                    break;
                case MotorAxisState.ErrorStop:
                    retStr = "出现错误，轴停止";
                    break;
                case MotorAxisState.Motion:
                    retStr = "轴正在执行运动...";
                    break;
            }

            return retStr;
        }

        /// <summary>
        /// 设置电机轴速度参数
        /// </summary>
        /// <param name="axis">轴号</param>
        /// <param name="velLow">初速度</param>
        /// <param name="velHigh">运行速度</param>
        /// <param name="acc">加速度</param>
        /// <param name="dec">减速度</param>
        /// <param name="Default">是否为默认值</param>
        public bool SetSpeedParam(Axis axis, int velLow, int velHigh, int acc, int dec, bool Default)
        {
            int indexBoard = (int)axis / MAX_AXIS_CHANNEL;  //板卡索引
            int indexAxis = (int)axis % MAX_AXIS_CHANNEL;  //板卡内轴号索引

            if (!IsBoardConnected((Board)indexBoard))
                return false;

            ArmCommandCode Code = Default ? ArmCommandCode.SetAxisParametersDefault : ArmCommandCode.SetAxisParameters;
            Message.MakeSendArrayByCode((byte)Code, ref m_SendMeas);

            int DataIndex = Message.MessageCommandIndex + 1;
            m_SendMeas[DataIndex] = (byte)indexAxis;

            m_SendMeas[DataIndex + 1] = (byte)(velLow & 0xffU);
            m_SendMeas[DataIndex + 2] = (byte)((velLow >> 8) & 0xffU);
            m_SendMeas[DataIndex + 3] = (byte)((velLow >> 16) & 0xffU);
            m_SendMeas[DataIndex + 4] = (byte)((velLow >> 24) & 0xffU);
            m_SendMeas[DataIndex + 5] = (byte)(velHigh & 0xffU);
            m_SendMeas[DataIndex + 6] = (byte)((velHigh >> 8) & 0xffU);
            m_SendMeas[DataIndex + 7] = (byte)((velHigh >> 16) & 0xffU);
            m_SendMeas[DataIndex + 8] = (byte)((velHigh >> 24) & 0xffU);
            m_SendMeas[DataIndex + 9] = (byte)(acc & 0xffU);
            m_SendMeas[DataIndex + 10] = (byte)((acc >> 8) & 0xffU);
            m_SendMeas[DataIndex + 11] = (byte)((acc >> 16) & 0xffU);
            m_SendMeas[DataIndex + 12] = (byte)((acc >> 24) & 0xffU);
            m_SendMeas[DataIndex + 13] = (byte)(dec & 0xffU);
            m_SendMeas[DataIndex + 14] = (byte)((dec >> 8) & 0xffU);
            m_SendMeas[DataIndex + 15] = (byte)((dec >> 16) & 0xffU);
            m_SendMeas[DataIndex + 16] = (byte)((dec >> 24) & 0xffU);

            m_SendMeas[Message.MessageSumCheck] = MyMath.CalculateSum(m_SendMeas, Message.MessageLength);

            m_MyTcpClientArm[indexBoard].ClientWrite(m_SendMeas);

            return true;
        }

        /// <summary>
        /// 移动 -- 绝对位置  （以原点为参照）
        /// </summary>
        /// <param name="axis">电机轴</param>
        /// <param name="steps">步数</param>
        /// <returns></returns>
        public bool MoveAbs(Axis axis, int steps)
        {
            int indexBoard = (int)axis / MAX_AXIS_CHANNEL;  //板卡索引
            int indexAxis = (int)axis % MAX_AXIS_CHANNEL;   //板卡内轴号索引

            if (!IsBoardConnected((Board)indexBoard))
                return false;

            Message.MakeSendArrayByCode((byte)ArmCommandCode.SetAxisStepsAbs, ref m_SendMeas);

            int DataIndex = Message.MessageCommandIndex + 1;

            m_SendMeas[DataIndex] = (byte)indexAxis;
            m_SendMeas[DataIndex + 1] = (byte)(steps & 0xffU);
            m_SendMeas[DataIndex + 2] = (byte)((steps >> 8) & 0xffU);
            m_SendMeas[DataIndex + 3] = (byte)((steps >> 16) & 0xffU);
            m_SendMeas[DataIndex + 4] = (byte)((steps >> 24) & 0xffU);

            m_SendMeas[Message.MessageSumCheck] = MyMath.CalculateSum(m_SendMeas, Message.MessageLength);

            m_MyTcpClientArm[indexBoard].ClientWrite(m_SendMeas);

            return true;
        }

        /// <summary>
        /// 移动 -- 相对位置 （以当前步数为基础）
        /// </summary>
        /// <param name="axis">电机轴</param>
        /// <param name="steps">步数</param>
        /// <returns></returns>
        public bool MoveRef(Axis axis, int steps)
        {
            int indexBoard = (int)axis / MAX_AXIS_CHANNEL;  //板卡索引
            int indexAxis = (int)axis % MAX_AXIS_CHANNEL;  //板卡内轴号索引

            if (!IsBoardConnected((Board)indexBoard))
                return false;

            Message.MakeSendArrayByCode((byte)ArmCommandCode.SetAxisStepsRef, ref m_SendMeas);

            int DataIndex = Message.MessageCommandIndex + 1;

            m_SendMeas[DataIndex] = (byte)indexAxis;
            m_SendMeas[DataIndex + 1] = (byte)(steps & 0xffU);
            m_SendMeas[DataIndex + 2] = (byte)((steps >> 8) & 0xffU);
            m_SendMeas[DataIndex + 3] = (byte)((steps >> 16) & 0xffU);
            m_SendMeas[DataIndex + 4] = (byte)((steps >> 24) & 0xffU);

            m_SendMeas[Message.MessageSumCheck] = MyMath.CalculateSum(m_SendMeas, Message.MessageLength);

            m_MyTcpClientArm[indexBoard].ClientWrite(m_SendMeas);

            return true;
        }

        /// <summary>
        /// 电机轴连续运动
        /// </summary>
        /// <param name="axis">电机轴</param>
        /// <param name="dir">运行方向</param>
        /// <returns></returns>
        public bool MoveContinuous(Axis axis, AxisDir dir)
        {
            bool Re = SendCommandToArmWithAxis(axis, ArmCommandCode.SetAxisMoveContinuous);
            return Re;
        }

        /// <summary>
        /// 回原点
        /// </summary>
        /// <param name="axis">电机轴</param>
        /// <param name="dir">回原点方向</param>
        /// <returns></returns>
        public bool BackHome(Axis axis, AxisDir dir)
        {
            bool Re = SendCommandToArmWithAxis(axis, ArmCommandCode.AxisGoHome);
            return Re;
        }

        /// <summary>
        /// 停止
        /// </summary>
        /// <param name="axis">电机轴</param>
        /// <returns></returns>
        public bool Stop(Axis axis)
        {
            bool Re = SendCommandToArmWithAxis(axis, ArmCommandCode.StopAxis);
            return Re;
        }

        //复位轴错误状态，如果轴处于ErrorStop状态，则在调用此函数后状态将更改为Ready。
        public bool ResetError(Axis axis)
        {
            bool Re = SendCommandToArmWithAxis(axis, ArmCommandCode.ResetAxisError);
            return Re;
        }

        //设置单片机控制板的IO
        public bool SetArmControlBoardIo(Board board, ARM_OutputPoint Io, IOValue Value)
        {
            if (!IsBoardConnected(board))
                return false;

            int data1 = 8;  //1~8输出口使能控制字节, 最大是0x80
            int data2 = 16;
            int data3 = 24;
            int data4 = 32;

            const int CommandIndex = Message.MessageCommandIndex;
            Message.MakeSendArrayByCode((byte)ArmCommandCode.SetOutput, ref m_SendMeas);

            //根据Type， Value 设置使能位和数据
            int TempIo = (int)Io;
            int ControlIndex = CommandIndex + 1;
            byte ControlValue = 0;
            byte IoData = 0;

            if (TempIo <= data1)
            {
                ControlIndex = CommandIndex + 1;
                ControlValue = (byte)(0x01 << (TempIo - 1));
                IoData = (byte)(((byte)Value) << (TempIo - 1));
            }
            else if (TempIo > data1 && TempIo <= data2)
            {
                ControlIndex = CommandIndex + 2;
                ControlValue = (byte)(0x01 << (TempIo - data1 - 1));
                IoData = (byte)(((byte)Value) << (TempIo - data1 - 1));
            }
            else if (TempIo > data2 && TempIo <= data3)
            {
                ControlIndex = CommandIndex + 3;
                ControlValue = (byte)(0x01 << (TempIo - data2 - 1));
                IoData = (byte)(((byte)Value) << (TempIo - data2 - 1));
            }
            else if (TempIo > data3 && TempIo <= data4)
            {
                ControlIndex = CommandIndex + 4;
                ControlValue = (byte)(0x01 << (TempIo - data3 - 1));
                IoData = (byte)(((byte)Value) << (TempIo - data3 - 1));
            }

            m_SendMeas[ControlIndex] = ControlValue;
            m_SendMeas[ControlIndex + 4] = IoData;
            m_SendMeas[Message.MessageSumCheck] = MyMath.CalculateSum(m_SendMeas, Message.MessageLength);

            m_MyTcpClientArm[(int)board].ClientWrite(m_SendMeas);

            return true;
        }

        //设置单片机控制板控制的按键灯
        public void SetKeyLedByKey(Board board, ARM_InputPoint Key, LED_State LedState)
        {
            IOValue Value = LedState == (LED_State.LED_ON) ? IOValue.IOValueHigh : IOValue.IOValueLow;
            ARM_OutputPoint KeyLed = ARM_OutputPoint.IO_OUT_LedKeyRun;

            switch (Key)
            {
                case ARM_InputPoint.IO_IN_KeyRun:
                    KeyLed = ARM_OutputPoint.IO_OUT_LedKeyRun;
                    break;
                case ARM_InputPoint.IO_IN_KeyPause:
                    KeyLed = ARM_OutputPoint.IO_OUT_LedKeyPause;
                    break;
                case ARM_InputPoint.IO_IN_KeyStop:
                    KeyLed = ARM_OutputPoint.IO_OUT_LedKeyStop;
                    break;
                case ARM_InputPoint.IO_IN_KeyReset:
                    KeyLed = ARM_OutputPoint.IO_OUT_LedKeyReset;
                    break;
                default:
                    break;
            }

            SetArmControlBoardIo(board, KeyLed, Value);
        }

        //轮询单片机的各个状态
        public void SendCommandToReadAllArmController()
        {
            for (int i = 0; i < (int)Board.Max; i++)
            {
                if (IsBoardConnected((Board)i))
                {
                    SendReadInputPoint((Board)i);   //读取IO输入点的状态

                    for (int j = 0; j < (int)Axis.Max; j++)
                    {
                        SendReadAxisPostion((Axis)j);   //读取传输线各电机的当前位置
                        SendReadAxisState((Axis)j);
                    }
                }
            }
        }
    }
}
