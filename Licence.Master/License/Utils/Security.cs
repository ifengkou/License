using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace License.Utils
{
    public class Security
    {
        //erp keys
        //erp key : "<RSAKeyValue><Modulus>txMgnP8yFVV6sXtmFs2W3qcy2Xr+7Z4XdtKZ3HfYqEFpexnwLszrCtvVrVcRcB2BoOa/sO+sm/qRKkCe9EHbBfCw/MROng8xFOcr6o5iX+TDr3f169a57GugSZ0brIM7u+VCpBnirfVq+AED573xojaEM/C+gqY/3BDws9Hqesc=</Modulus><Exponent>AQAB</Exponent><P>9Y3Dv15FWslJ0jE8R4rb7fKkG7PRqqx+qvUd9MQO6sgSEWlHbCMI4+M/iCq54fLpHlyPzQDTSecuBq9024d5/Q==</P><Q>vtztLmU1gm9zcFhWDSHYVS2qq0Ai+dafzefBQjcfm3LqVhC7j0Vi+IOnPP8xmGRSbcGw0IJOMmKDh6ZzpH8xEw==</Q><DP>05ELgQymUOxxUErflvyLNV8ECmJKWfU5Re7fmo56E8vB1YKR6Rfehwq7KIU3lvgF5wT1WTpG0bv/qf7ufl8huQ==</DP><DQ>JB5GvArnD2Hr5Iyy7BVFjQjxTSr782+MGjkLN26bCp26fsL322r0CbdQRJi+V+pUNvT6ctrV1W8TGO6E39I6BQ==</DQ><InverseQ>QYYF71c6BVr9gIkXbzQ1aP5uU1e4GZtY1iQ9U/sa3jwaCCtPROsgekXvo+0RaeANqgfkn+zMszsdOqH96cfHUg==</InverseQ><D>Z39evqLe84ShmljCvD15/2HSs3R/TmJDrZ8d8K+oQmbIdRmS2UJr1nW1dQt2BkYIFKie0i6NDJk5HAPwWPIqGVjh/NnLSxhi51lhljL564+zx2QKUm+G4CNQKoSV9ePkWl2H4N5UC64MyJlngN/PGB9ZB5iURzfrvNidHjira7E=</D></RSAKeyValue>";
        //erp pub :"<RSAKeyValue><Modulus>txMgnP8yFVV6sXtmFs2W3qcy2Xr+7Z4XdtKZ3HfYqEFpexnwLszrCtvVrVcRcB2BoOa/sO+sm/qRKkCe9EHbBfCw/MROng8xFOcr6o5iX+TDr3f169a57GugSZ0brIM7u+VCpBnirfVq+AED573xojaEM/C+gqY/3BDws9Hqesc=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
        //zoomlion keys
        //private string p_strKeyPublic = "<RSAKeyValue><Modulus>lBe/+Eaw6Dh0DFIlfSu/2pVPwa4mCg8PC4eIgKwPmoiY0BrHDUCh9fXyAot+vCfWmt08C8IXiEja3r79WamIVnFjIFNgh/yII8apZGrSOMgunPTiwwRbi8MKu1j6bQJHdg54q6o1OGZJpDD1hHvmjAFZzrY6hgUXN/JkgAxrzDM=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
        //private string p_strKeyPrivate = "<RSAKeyValue><Modulus>lBe/+Eaw6Dh0DFIlfSu/2pVPwa4mCg8PC4eIgKwPmoiY0BrHDUCh9fXyAot+vCfWmt08C8IXiEja3r79WamIVnFjIFNgh/yII8apZGrSOMgunPTiwwRbi8MKu1j6bQJHdg54q6o1OGZJpDD1hHvmjAFZzrY6hgUXN/JkgAxrzDM=</Modulus><Exponent>AQAB</Exponent><P>zIsXilFsf3yT6q2QsE1zT27biC/2tlGv30YOjGhKM+uAdJSoAPZqg5yqYo0CMHqClRiPOLN17LoNWmSSPan24w==</P><Q>uVknjVwS/D8jY2hN79bWwXrrtItZ4b3+ukF8YAFRIV8PoBRmH+fiFuscVC6Ko4H5gT8HoQ5Dik9O9tBdCxmGcQ==</Q><DP>AEvnUdUCYkDs+fcccZT7KM9RVCY1plgB+EHivYNdMCwUOJcKk03II76zZIctzKIw1ER/2KYx8pDmeg4RRDOd3w==</DP><DQ>PdQ103wRgT/2qCSVSxqZzTUaB8Ism5drr+pEeSo3TDCP39CuOJp72zVW3+YerWigOLMz8k/1y9+k8cSUJS3AoQ==</DQ><InverseQ>yUl8J8AuxtvD0ol3a/DsIpGvvIYiQJACNkmCOyIn+RKzv6bT7rTf7OfI+ZW3mtXaWRuR3eRqo4oLIu5+qWfpdQ==</InverseQ><D>Lduk4HbTdTV2ChKt9TLE+CTgS7NnqBm9qO5RQLcHJe1ClL6WAO6QuJ9uT4duuUkE1XPIkkOKEfOtguhVf5xV0SYTZh+ccvefVb+IvxdiANfTgvLBlFcgrt2Z+DbGKYeN0JEozzmmJuIzqCefJ6dhfYhiaXXmGkGq3OXu2r8bsUE=</D></RSAKeyValue>";
        private string p_strKeyPublic = "<RSAKeyValue><Modulus>txMgnP8yFVV6sXtmFs2W3qcy2Xr+7Z4XdtKZ3HfYqEFpexnwLszrCtvVrVcRcB2BoOa/sO+sm/qRKkCe9EHbBfCw/MROng8xFOcr6o5iX+TDr3f169a57GugSZ0brIM7u+VCpBnirfVq+AED573xojaEM/C+gqY/3BDws9Hqesc=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
        private string p_strKeyPrivate = "<RSAKeyValue><Modulus>txMgnP8yFVV6sXtmFs2W3qcy2Xr+7Z4XdtKZ3HfYqEFpexnwLszrCtvVrVcRcB2BoOa/sO+sm/qRKkCe9EHbBfCw/MROng8xFOcr6o5iX+TDr3f169a57GugSZ0brIM7u+VCpBnirfVq+AED573xojaEM/C+gqY/3BDws9Hqesc=</Modulus><Exponent>AQAB</Exponent><P>9Y3Dv15FWslJ0jE8R4rb7fKkG7PRqqx+qvUd9MQO6sgSEWlHbCMI4+M/iCq54fLpHlyPzQDTSecuBq9024d5/Q==</P><Q>vtztLmU1gm9zcFhWDSHYVS2qq0Ai+dafzefBQjcfm3LqVhC7j0Vi+IOnPP8xmGRSbcGw0IJOMmKDh6ZzpH8xEw==</Q><DP>05ELgQymUOxxUErflvyLNV8ECmJKWfU5Re7fmo56E8vB1YKR6Rfehwq7KIU3lvgF5wT1WTpG0bv/qf7ufl8huQ==</DP><DQ>JB5GvArnD2Hr5Iyy7BVFjQjxTSr782+MGjkLN26bCp26fsL322r0CbdQRJi+V+pUNvT6ctrV1W8TGO6E39I6BQ==</DQ><InverseQ>QYYF71c6BVr9gIkXbzQ1aP5uU1e4GZtY1iQ9U/sa3jwaCCtPROsgekXvo+0RaeANqgfkn+zMszsdOqH96cfHUg==</InverseQ><D>Z39evqLe84ShmljCvD15/2HSs3R/TmJDrZ8d8K+oQmbIdRmS2UJr1nW1dQt2BkYIFKie0i6NDJk5HAPwWPIqGVjh/NnLSxhi51lhljL564+zx2QKUm+G4CNQKoSV9ePkWl2H4N5UC64MyJlngN/PGB9ZB5iURzfrvNidHjira7E=</D></RSAKeyValue>";
        public string GetHash(string m_strSource)
        {
            System.Security.Cryptography.HashAlgorithm hashAlgorithm = System.Security.Cryptography.HashAlgorithm.Create("MD5");
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(m_strSource);
            byte[] inArray = hashAlgorithm.ComputeHash(bytes);
            return System.Convert.ToBase64String(inArray);
        }
        public string MD5(string source)
        {
            System.Security.Cryptography.HashAlgorithm hashAlgorithm = System.Security.Cryptography.HashAlgorithm.Create("MD5");
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(source);
            byte[] value = hashAlgorithm.ComputeHash(bytes);
            return System.BitConverter.ToString(value);
        }
        public string SignatureFormatter(string m_strHashbyteSignature)
        {
            byte[] rgbHash = System.Convert.FromBase64String(m_strHashbyteSignature);
            System.Security.Cryptography.RSACryptoServiceProvider rSACryptoServiceProvider = new System.Security.Cryptography.RSACryptoServiceProvider();
            rSACryptoServiceProvider.FromXmlString(this.p_strKeyPrivate);
            System.Security.Cryptography.RSAPKCS1SignatureFormatter rSAPKCS1SignatureFormatter = new System.Security.Cryptography.RSAPKCS1SignatureFormatter(rSACryptoServiceProvider);
            rSAPKCS1SignatureFormatter.SetHashAlgorithm("MD5");
            byte[] inArray = rSAPKCS1SignatureFormatter.CreateSignature(rgbHash);
            return System.Convert.ToBase64String(inArray);
        }
        public bool SignatureDeformatter(string p_strHashbyteDeformatter, string p_strDeformatterData)
        {
            bool result;
            try
            {
                byte[] rgbHash = System.Convert.FromBase64String(p_strHashbyteDeformatter);
                System.Security.Cryptography.RSACryptoServiceProvider rSACryptoServiceProvider = new System.Security.Cryptography.RSACryptoServiceProvider();
                rSACryptoServiceProvider.FromXmlString(this.p_strKeyPublic);
                System.Security.Cryptography.RSAPKCS1SignatureDeformatter rSAPKCS1SignatureDeformatter = new System.Security.Cryptography.RSAPKCS1SignatureDeformatter(rSACryptoServiceProvider);
                rSAPKCS1SignatureDeformatter.SetHashAlgorithm("MD5");
                byte[] rgbSignature = System.Convert.FromBase64String(p_strDeformatterData);
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
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(plainString);
            return System.Convert.ToBase64String(bytes);
        }
        public string DecodeString(string encodedString)
        {
            byte[] bytes = System.Convert.FromBase64String(encodedString);
            return System.Text.Encoding.UTF8.GetString(bytes);
        }
    }
}
