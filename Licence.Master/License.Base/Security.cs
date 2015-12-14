using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace License.Base
{
    public class Security
    {
        //private string p_strKeyPublic = "<RSAKeyValue><Modulus>lBe/+Eaw6Dh0DFIlfSu/2pVPwa4mCg8PC4eIgKwPmoiY0BrHDUCh9fXyAot+vCfWmt08C8IXiEja3r79WamIVnFjIFNgh/yII8apZGrSOMgunPTiwwRbi8MKu1j6bQJHdg54q6o1OGZJpDD1hHvmjAFZzrY6hgUXN/JkgAxrzDM=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
        private string p_strKeyPublic = "<RSAKeyValue><Modulus>txMgnP8yFVV6sXtmFs2W3qcy2Xr+7Z4XdtKZ3HfYqEFpexnwLszrCtvVrVcRcB2BoOa/sO+sm/qRKkCe9EHbBfCw/MROng8xFOcr6o5iX+TDr3f169a57GugSZ0brIM7u+VCpBnirfVq+AED573xojaEM/C+gqY/3BDws9Hqesc=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
        public string GetHash(string m_strSource)
        {
            HashAlgorithm hashAlgorithm = HashAlgorithm.Create("MD5");
            byte[] bytes = Encoding.UTF8.GetBytes(m_strSource);
            byte[] inArray = hashAlgorithm.ComputeHash(bytes);
            return Convert.ToBase64String(inArray);
        }
        public string MD5(string source)
        {
            HashAlgorithm hashAlgorithm = HashAlgorithm.Create("MD5");
            byte[] bytes = Encoding.UTF8.GetBytes(source);
            byte[] value = hashAlgorithm.ComputeHash(bytes);
            return BitConverter.ToString(value);
        }
        public bool SignatureDeformatter(string p_strHashbyteDeformatter, string p_strDeformatterData)
        {
            bool result;
            try
            {
                //hash
                byte[] rgbHash = Convert.FromBase64String(p_strHashbyteDeformatter);
                byte[] rgbSignature = Convert.FromBase64String(p_strDeformatterData);

                RSACryptoServiceProvider rSACryptoServiceProvider = new RSACryptoServiceProvider();
                rSACryptoServiceProvider.FromXmlString(this.p_strKeyPublic);
                RSAPKCS1SignatureDeformatter rSAPKCS1SignatureDeformatter = new RSAPKCS1SignatureDeformatter(rSACryptoServiceProvider);
                rSAPKCS1SignatureDeformatter.SetHashAlgorithm("MD5");

                if (rSAPKCS1SignatureDeformatter.VerifySignature(rgbHash, rgbSignature))
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }
        public string EncodeString(string plainString)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(plainString);
            return Convert.ToBase64String(bytes);
        }
        public string DecodeString(string encodedString)
        {
            byte[] bytes = Convert.FromBase64String(encodedString);
            return Encoding.UTF8.GetString(bytes);
        }
    }
}
