using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace License.Base
{
    public class Computer
    {
        public string GetMachineHash()
        {
            Security security = new Security();
            return security.MD5(this.GetHWInfo());
        }
        public string GetHWInfo()
        {
            Security security = new Security();
            string plainString = string.Format("{0}\r\n{1}\r\n{2}", this.GetCpuID(), this.GetHddSerial(), this.GetMacAddress());
            plainString = security.EncodeString(plainString);
            return security.EncodeString(plainString);
        }
        private string GetMacAddress()
        {
            string result;
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                ManagementClass managementClass = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection instances = managementClass.GetInstances();
                using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = instances.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        ManagementObject managementObject = (ManagementObject)enumerator.Current;
                        if ((bool)managementObject["IPEnabled"])
                        {
                            if (stringBuilder.Length > 0)
                            {
                                stringBuilder.Append(";");
                            }
                            stringBuilder.AppendFormat("{0}", managementObject["MacAddress"]);
                        }
                    }
                }
                result = stringBuilder.ToString();
            }
            catch
            {
                result = string.Empty;
            }
            return result;
        }
        private string GetCpuID()
        {
            return this.GetWMIProperties("Win32_Processor", "Caption", "ProcessorId");
        }
        private string GetHddSerial()
        {
            return this.GetWMIProperties("Win32_DiskDrive", "Caption", "Model");
        }
        private string GetWMIProperties(string className, string caption, string property)
        {
            string result;
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                ManagementClass managementClass = new ManagementClass(className);
                ManagementObjectCollection instances = managementClass.GetInstances();
                using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = instances.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        ManagementObject managementObject = (ManagementObject)enumerator.Current;
                        PropertyData propertyData = managementObject.Properties[property];
                        if (propertyData != null && propertyData.Value != null)
                        {
                            if (stringBuilder.Length > 0)
                            {
                                stringBuilder.Append(";");
                            }
                            stringBuilder.AppendFormat("{0}:{1}", managementObject[caption], propertyData.Value.ToString().Trim());
                        }
                    }
                }
                result = stringBuilder.ToString();
            }
            catch
            {
                result = string.Empty;
            }
            return result;
        }
    }
}
