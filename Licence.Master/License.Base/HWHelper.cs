using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace License.Base
{
    public class HWHelper
    {
        public string GetMachineHash()
        {
            Security security = new Security();
            return security.MD5(this.GetHWInfo());
        }
        public string GetHWInfo()
        {
            Security security = new Security();
            string cpuid = this.GetCpuID();
            string hddin = this.GetHddSerial();
            string macin = this.GetMacAddress();
            string plainString = string.Format("{0}\r\n{1}\r\n{2}", cpuid, hddin, macin);
            //return plainString;
            //plainString = security.EncodeString(plainString);
            //return security.EncodeString(plainString);
            //string plainString = "UWtaRlFrWkNSa1l3TURBeU1EWkJOdzBLTWpBeU1ESXdNakExTnpJd01tUTBORFF6TlRjek1qUXpOREUwTlRNMU16SXpNRE0yTXpjek53MEtSVU02UVRnNk5rSTZRelE2T1RRNlJFRT0=";
            plainString = security.EncodeString(plainString);
            plainString = security.EncodeString(plainString);
            return plainString;
            //a a = new a();
            //string xx = a.d();
            //xx = security.DecodeString(xx);
            
        }
        private string GetMacAddress()
        {
            string result;
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                ManagementClass managementClass = new ManagementClass("Win32_NetworkAdapter");
                ManagementObjectCollection instances = managementClass.GetInstances();
                using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = instances.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        ManagementObject managementObject = (ManagementObject)enumerator.Current;
                        if (managementObject["PNPDeviceID"] != null&&managementObject["PNPDeviceID"].ToString().StartsWith("PCI"))
                        {
                            if (stringBuilder.Length > 0)
                            {
                                stringBuilder.Append(";");
                            }
                            //string xx = managementObject["MacAddress"].ToString();
                            //string xx2 = managementObject.Properties["MacAddress"].Value.ToString();
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
        private string GetHddSerial()
        {
            //return this.GetWMIProperties("Win32_DiskDrive", "Caption", "Model");
            string result;
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                ManagementClass managementClass = new ManagementClass("Win32_DiskDrive");
                ManagementObjectCollection instances = managementClass.GetInstances();
                using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = instances.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        ManagementObject managementObject = (ManagementObject)enumerator.Current;
                        //PropertyData propertyData = managementObject.Properties["InterfaceType"];
                        //if (propertyData != null && propertyData.Value != null)
                        if (managementObject.Properties["InterfaceType"].Value.ToString() != "USB")
                        {
                            //if (stringBuilder.Length > 0)
                            //{
                            //    stringBuilder.Append(";");
                            //}
                            //stringBuilder.AppendFormat("{0}:{1}", managementObject[caption], propertyData.Value.ToString().Trim());
                            stringBuilder.AppendFormat("{0}", managementObject.Properties["SerialNumber"].Value.ToString().Trim());
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
                            string xx = propertyData.Value.ToString().Trim();
                            //stringBuilder.AppendFormat(propertyData.Value.ToString().Trim());
                            //stringBuilder.AppendFormat("{0}:{1}", managementObject[caption], propertyData.Value.ToString().Trim());
                            //stringBuilder.AppendFormat("{0}", propertyData.Value.ToString().Trim());
                            stringBuilder.AppendFormat(propertyData.Value.ToString().Trim(), new object[0]);
                            break;
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
