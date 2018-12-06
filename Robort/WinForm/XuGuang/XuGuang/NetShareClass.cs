using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Management;
using System.Security.AccessControl;
using System.Diagnostics;
using System.Threading;

namespace NetShare
{
    class NetShareClass
    {
        [DllImport("mpr.dll")]
        public static extern int WNetAddConnection2A(NETRESOURCE[] lpNetResource, string lpPassword, string lpUserName, int dwFlags);

        [DllImport("mpr.dll")]
        public static extern int WNetCancelConnection2A(string sharename, int dwFlags, int fForce);

        public enum ERROR_ID
        {
            ERROR_SUCCESS = 0, // Success 
            ERROR_ACCESS_DENIED = 5,
            ERROR_NOT_ENOUGH_MEMORY = 8,
            ERROR_BAD_NETPATH = 53,
            ERROR_NETWORK_BUSY = 54,
            ERROR_BAD_DEV_TYPE = 66,
            ERROR_BAD_NET_NAME = 67,
            ERROR_ALREADY_ASSIGNED = 85, //The local device name is already in use.
            ERROR_INVALID_PASSWORD = 86,
            ERROR_INVALID_PARAMETER = 87,
            ERROR_INVALID_LEVEL = 124,
            ERROR_BUSY = 170,
            ERROR_MORE_DATA = 234,          
            ERROR_DEVICE_ALREADY_REMEMBERED = 1202,
            ERROR_NO_NET_OR_BAD_PATH = 1203,
            ERROR_EXTENDED_ERROR = 1208,
            ERROR_SESSION_CREDENTIAL_CONFLICT = 1219, //Multiple connections to a server or shared resource by the same user, using more than one user name, are not allowed. Disconnect all previous connections to the server or shared resource and try again.
            ERROR_NO_NETWORK = 1222,
            ERROR_INVALID_HANDLE_STATE = 1609,
            ERROR_NO_BROWSER_SERVERS_FOUND = 6118,
        }

        public enum RESOURCE_SCOPE
        {
            RESOURCE_CONNECTED = 1,
            RESOURCE_GLOBALNET = 2,
            RESOURCE_REMEMBERED = 3,
            RESOURCE_RECENT = 4,
            RESOURCE_CONTEXT = 5
        }

        public enum RESOURCE_TYPE
        {
            RESOURCETYPE_ANY = 0,
            RESOURCETYPE_DISK = 1,
            RESOURCETYPE_PRINT = 2,
            RESOURCETYPE_RESERVED = 8,
        }

        public enum RESOURCE_USAGE
        {
            RESOURCEUSAGE_CONNECTABLE = 1,
            RESOURCEUSAGE_CONTAINER = 2,
            RESOURCEUSAGE_NOLOCALDEVICE = 4,
            RESOURCEUSAGE_SIBLING = 8,
            RESOURCEUSAGE_ATTACHED = 16,
            RESOURCEUSAGE_ALL = (RESOURCEUSAGE_CONNECTABLE | RESOURCEUSAGE_CONTAINER | RESOURCEUSAGE_ATTACHED),
        }

        public enum RESOURCE_DISPLAYTYPE
        {
            RESOURCEDISPLAYTYPE_GENERIC = 0,
            RESOURCEDISPLAYTYPE_DOMAIN = 1,
            RESOURCEDISPLAYTYPE_SERVER = 2,
            RESOURCEDISPLAYTYPE_SHARE = 3,
            RESOURCEDISPLAYTYPE_FILE = 4,
            RESOURCEDISPLAYTYPE_GROUP = 5,
            RESOURCEDISPLAYTYPE_NETWORK = 6,
            RESOURCEDISPLAYTYPE_ROOT = 7,
            RESOURCEDISPLAYTYPE_SHAREADMIN = 8,
            RESOURCEDISPLAYTYPE_DIRECTORY = 9,
            RESOURCEDISPLAYTYPE_TREE = 10,
            RESOURCEDISPLAYTYPE_NDSCONTAINER = 11
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct NETRESOURCE
        {
            public RESOURCE_SCOPE dwScope;
            public RESOURCE_TYPE dwType;
            public RESOURCE_DISPLAYTYPE dwDisplayType;
            public RESOURCE_USAGE dwUsage;

            [MarshalAs(UnmanagedType.LPStr)]
            public string lpLocalName;

            [MarshalAs(UnmanagedType.LPStr)]
            public string lpRemoteName;

            [MarshalAs(UnmanagedType.LPStr)]
            public string lpComment;

            [MarshalAs(UnmanagedType.LPStr)]
            public string lpProvider;
        }

        public int Connect(string remotePath, string localPath, string username, string password)
        {
            NETRESOURCE[] share_driver = new NETRESOURCE[1];
            share_driver[0].dwScope = RESOURCE_SCOPE.RESOURCE_GLOBALNET;
            share_driver[0].dwType = RESOURCE_TYPE.RESOURCETYPE_DISK;
            share_driver[0].dwDisplayType = RESOURCE_DISPLAYTYPE.RESOURCEDISPLAYTYPE_SHARE;
            share_driver[0].dwUsage = RESOURCE_USAGE.RESOURCEUSAGE_CONNECTABLE;
            share_driver[0].lpLocalName = localPath;
            share_driver[0].lpRemoteName = remotePath;

            Disconnect(localPath);
            int ret = WNetAddConnection2A(share_driver, password, username, 1);

            return ret;
        }

        public int Disconnect(string localpath)
        {
            return WNetCancelConnection2A(localpath, 1, 1);
        }

        /// 创建文件夹共享  
        public void CallShareBatFile(string ShareFile)
        {
            string targetDir = AppDomain.CurrentDomain.BaseDirectory;//this is where testChange.bat lies

            Process p = new Process();  //创建进程对象
            p.StartInfo.WorkingDirectory = targetDir;
            p.StartInfo.FileName = ShareFile;
            p.StartInfo.Arguments = string.Format("10");//this is argument
            p.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;  //窗口状态为隐藏           
            p.StartInfo.CreateNoWindow = true;  //启动进程不创建窗口
            p.Start();   //启动进程
            p.WaitForExit(100);  //设置100ms等待关联的进程退出
        }

        /// <summary>
        /// 取消文件夹共享
        /// </summary>
        /// <param name="ShareName">文件夹的共享名</param>
        /// <returns></returns>
        public int CancelShareNetFolder(string ShareName)
        {
            try
            {
                SelectQuery selectQuery = new SelectQuery("Select * from Win32_Share Where Name = '" + ShareName + "'");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(selectQuery);
                foreach (ManagementObject mo in searcher.Get())
                {
                    mo.InvokeMethod("Delete", null, null);
                }
            }
            catch
            {
                return -1;
            }
            return 0;
        }

    }
}
