using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZLERP.Licensing.Client;
using License.Base;
namespace License.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Security security = new Security();
            //a a = new a();
            //Computer c = new Computer();
            //HWHelper h = new HWHelper();
            //string xx = h.GetHWInfo();
            //System.Console.WriteLine(xx);
            //System.Console.WriteLine(xx);
            //xx = security.DecodeString(xx);
            //xx = security.DecodeString(xx);
            //System.Console.WriteLine(xx);
            //var hsmc = h.GetMachineHash();
            //if (hsmc != a.e())
            //{
            //    System.Console.WriteLine("许可无效, HWInfo Error!");
            //}
            //else
            //{
            //    System.Console.WriteLine(hsmc);
            //    System.Console.WriteLine("HWInfo 验证成功!");
            //}
            //RSACryption rc = new RSACryption();
            //string str_priv = ""; string str_public = "";
            //rc.RSAKey(out str_priv, out str_public);
            //System.Console.WriteLine(str_priv);
            //System.Console.WriteLine(str_public);
            string pub = "<RSAKeyValue><Modulus>lBe/+Eaw6Dh0DFIlfSu/2pVPwa4mCg8PC4eIgKwPmoiY0BrHDUCh9fXyAot+vCfWmt08C8IXiEja3r79WamIVnFjIFNgh/yII8apZGrSOMgunPTiwwRbi8MKu1j6bQJHdg54q6o1OGZJpDD1hHvmjAFZzrY6hgUXN/JkgAxrzDM=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
            string pri = "<RSAKeyValue><Modulus>lBe/+Eaw6Dh0DFIlfSu/2pVPwa4mCg8PC4eIgKwPmoiY0BrHDUCh9fXyAot+vCfWmt08C8IXiEja3r79WamIVnFjIFNgh/yII8apZGrSOMgunPTiwwRbi8MKu1j6bQJHdg54q6o1OGZJpDD1hHvmjAFZzrY6hgUXN/JkgAxrzDM=</Modulus><Exponent>AQAB</Exponent><P>zIsXilFsf3yT6q2QsE1zT27biC/2tlGv30YOjGhKM+uAdJSoAPZqg5yqYo0CMHqClRiPOLN17LoNWmSSPan24w==</P><Q>uVknjVwS/D8jY2hN79bWwXrrtItZ4b3+ukF8YAFRIV8PoBRmH+fiFuscVC6Ko4H5gT8HoQ5Dik9O9tBdCxmGcQ==</Q><DP>AEvnUdUCYkDs+fcccZT7KM9RVCY1plgB+EHivYNdMCwUOJcKk03II76zZIctzKIw1ER/2KYx8pDmeg4RRDOd3w==</DP><DQ>PdQ103wRgT/2qCSVSxqZzTUaB8Ism5drr+pEeSo3TDCP39CuOJp72zVW3+YerWigOLMz8k/1y9+k8cSUJS3AoQ==</DQ><InverseQ>yUl8J8AuxtvD0ol3a/DsIpGvvIYiQJACNkmCOyIn+RKzv6bT7rTf7OfI+ZW3mtXaWRuR3eRqo4oLIu5+qWfpdQ==</InverseQ><D>Lduk4HbTdTV2ChKt9TLE+CTgS7NnqBm9qO5RQLcHJe1ClL6WAO6QuJ9uT4duuUkE1XPIkkOKEfOtguhVf5xV0SYTZh+ccvefVb+IvxdiANfTgvLBlFcgrt2Z+DbGKYeN0JEozzmmJuIzqCefJ6dhfYhiaXXmGkGq3OXu2r8bsUE=</D></RSAKeyValue>";
            //System.Console.WriteLine(security.EncodeString(pub));
            //System.Console.WriteLine(security.EncodeString(pri));
            string _key = "PFJTQUtleVZhbHVlPjxNb2R1bHVzPmxCZS8rRWF3NkRoMERGSWxmU3UvMnBWUHdhNG1DZzhQQzRlSWdLd1Btb2lZMEJySERVQ2g5Zlh5QW90K3ZDZldtdDA4QzhJWGlFamEzcjc5V2FtSVZuRmpJRk5naC95SUk4YXBaR3JTT01ndW5QVGl3d1JiaThNS3UxajZiUUpIZGc1NHE2bzFPR1pKcEREMWhIdm1qQUZaenJZNmhnVVhOL0prZ0F4cnpETT08L01vZHVsdXM+PEV4cG9uZW50PkFRQUI8L0V4cG9uZW50PjwvUlNBS2V5VmFsdWU+";
            System.Console.WriteLine(security.DecodeString(_key));
            System.Console.ReadKey();
        }
    }
}
