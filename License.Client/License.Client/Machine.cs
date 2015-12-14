using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace License.Client
{
    public class Machine
    {
        public string CpuID;
        public string MacAddress;
        public string DiskID;
        public string IpAddress;
        public string LoginUserName;
        public string ComputerName;
        public string SystemType;
        public string TotalPhysicalMemory; //单位：M
        private static Machine _instance;
        public static Machine Instance()
        {
            if (_instance == null)
                _instance = new Machine();
            return _instance;
        }
        protected Machine()
        {
            CpuID=GetCpuID();
            MacAddress=GetMacAddress();
            DiskID=GetDiskID();
            IpAddress=GetIPAddress();
            LoginUserName=GetUserName();
            SystemType=GetSystemType();
            TotalPhysicalMemory=GetTotalPhysicalMemory();
            ComputerName=GetComputerName();
        }
        string  GetCpuID()
        {
            try
            {
                //获取CPU序列号代码
                string cpuInfo = "";//cpu序列号
                ManagementClass mc = new ManagementClass("Win32_Processor");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach(ManagementObject mo in moc)
                {
                    cpuInfo = mo.Properties["ProcessorId"].Value.ToString();
                }
                moc=null;
                mc=null;
                return cpuInfo;
            }
            catch
            {
                return "unknow";
            }
            finally
            {
            }
            
        }
        string  GetMacAddress()
        {
            try
            {
                //获取网卡硬件地址
                string mac="";
                ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach(ManagementObject mo in moc)
                {
                    if((bool)mo["IPEnabled"] == true)
                    {
                        mac=mo["MacAddress"].ToString();
                        break;
                    }
                }
                moc=null;
                mc=null;
                return mac;
            }
            catch
            {
                return "unknow";
            }
            finally
            {
            }
            
        }
        string  GetIPAddress()
        {
            try
            {
                //获取IP地址
                string st="";
                ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach(ManagementObject mo in moc)
                {
                    if((bool)mo["IPEnabled"] == true)
                    {
                        //st=mo["IpAddress"].ToString();
                        System.Array ar;
                        ar=(System.Array)(mo.Properties["IpAddress"].Value);
                        st=ar.GetValue(0).ToString();
                        break;
                    }
                }
                moc=null;
                mc=null;
                return st;
            }
            catch
            {
                return "unknow";
            }
            finally
            {
            }
            
        }
         
        string  GetDiskID()
        {
            try
            {
                //获取硬盘ID
                String HDid="";
                ManagementClass mc = new ManagementClass("Win32_DiskDrive");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach(ManagementObject mo in moc)
                {
                    HDid = (string)mo.Properties["Model"].Value;
                }
                moc=null;
                mc=null;
                return HDid;
            }
            catch
            {
                return "unknow";
            }
            finally
            {
            }
                
        }

        /// <summary>
        /// 操作系统的登录用户名
        /// </summary>
        /// <returns></returns>
        string  GetUserName()
        {
            try
            {
                string st="";
                ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach(ManagementObject mo in moc)
                {
                    
                    st=mo["UserName"].ToString();
                    
                }
                moc=null;
                mc=null;
                return st;
            }
            catch
            {
                return "unknow";
            }
            finally
            {
            }
            
        }


        /// <summary>
        /// PC类型
        /// </summary>
        /// <returns></returns>
        string  GetSystemType()
        {
            try
            {
                string st="";
                ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach(ManagementObject mo in moc)
                {
                    st=mo["SystemType"].ToString();
                }
                moc=null;
                mc=null;
                return st;
            }
            catch
            {
                return "unknow";
            }
            finally
            {
            }
            
        }

        /// <summary>
        /// 物理内存
        /// </summary>
        /// <returns></returns>
        string  GetTotalPhysicalMemory()
        {
            try
            {
                
                string st="";
                ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach(ManagementObject mo in moc)
                {
                    st=mo["TotalPhysicalMemory"].ToString();
                }
                moc=null;
                mc=null;
                return st;
            }
            catch
            {
                return "unknow";
            }
            finally
            {
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        string  GetComputerName()
        {
            try
            {                
                return System.Environment.GetEnvironmentVariable("ComputerName");
            }
            catch
            {
                return "unknow";
            }
            finally
            {
            }
        }
    }
}
