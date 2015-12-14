using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Serialization;
using License.Lang;
namespace License.Base
{
    [Serializable]
    public class License
    {
        private static string licFile = License.GetLicenseFilePath();
        public string Copyright { get; set; }
        public string LicenceTo { get; set; }
        public string ProductName { get; set; }
        public string MachineHash
        {
            get
            {
                string result;
                if (!string.IsNullOrEmpty(this.MachineDesc))
                {
                    Security security = new Security();
                    result = security.MD5(this.MachineDesc);
                }
                else
                {
                    result = string.Empty;
                }
                return result;
            }
        }
        public string MachineDesc { get; set; }
        public int MajorVersion { get; set; }
        public int MinorVersion { get; set; }
        public string Edition { get; set; }
        public string SerialNumber { get; set; }
        public int DaysLeftInTrial
        {
            get
            {
                int num = (this.ExpireTo - DateTime.Today).Days;
                if (num < 0)
                {
                    num = 0;
                }
                return num;
            }
        }
        public DateTime ExpireTo { get; set; }
        public string UserData { get; set; }
        public string Signature { get; set; }
        private static string GetLicenseFilePath()
        {
            string result;
            if (HttpContext.Current != null)
            {
                result = HttpContext.Current.Server.MapPath("~/license.lic");
            }
            else
            {
                result = "license.lic";
            }
            return result;
        }
        public static License GetLicense(string licenseFile)
        {
            License result;
            try
            {
                if (!File.Exists(licenseFile))
                {
                    throw new LicenseInvalidException(string.Format(Resource.FileNotExist, Resource.Company));
                }
                Security security = new Security();
                string encodedString = File.ReadAllText(licenseFile);
                string s = security.DecodeString(encodedString);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(License));
                License license = (License)xmlSerializer.Deserialize(new StringReader(s));
                if (!License.VerifyLicense(license))
                {
                    throw new LicenseInvalidException(Resource.LicenseInvalid);
                }
                result = license;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public static License GetLicense()
        {
            return License.GetLicense(License.licFile);
        }
        private static bool VerifyLicense(License lic)
        {
            Security security = new Security();
            string hash = security.GetHash(lic.GetHashString());
            bool flag = security.SignatureDeformatter(hash, lic.Signature);
            bool result;
            if (flag)
            {
                if (lic.DaysLeftInTrial == 0)
                {
                    throw new LicenseInvalidException(Resource.LicenseExpired);
                }
                if (!string.IsNullOrEmpty(lic.MachineHash))
                {
                    Computer hWHelper = new Computer();
                    if (hWHelper.GetMachineHash() != lic.MachineHash)
                    {
                        throw new LicenseInvalidException(Resource.LicenseHardwardError);
                    }
                }
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }
        public bool Save()
        {
            return this.Save(License.licFile);
        }
        public bool Save(string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(License));
            using (StringWriter stringWriter = new StringWriter())
            {
                xmlSerializer.Serialize(stringWriter, this);
                Security security = new Security();
                string contents = security.EncodeString(stringWriter.ToString());
                File.WriteAllText(path, contents);
            }
            return true;
        }
        public string GetHashString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(this.Copyright);
            stringBuilder.Append(this.LicenceTo);
            stringBuilder.Append(this.ProductName);
            stringBuilder.Append(this.MachineHash);
            stringBuilder.Append(this.MajorVersion);
            stringBuilder.Append(this.MinorVersion);
            stringBuilder.Append(this.Edition);
            stringBuilder.Append(this.SerialNumber);
            stringBuilder.Append(this.ExpireTo.ToString("yyyy-MM-dd"));
            stringBuilder.Append(this.UserData);
            return stringBuilder.ToString();
        }
        public override string ToString()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(base.GetType());
            string result;
            using (StringWriter stringWriter = new StringWriter())
            {
                xmlSerializer.Serialize(stringWriter, this);
                result = stringWriter.ToString();
            }
            return result;
        }
    }
}
