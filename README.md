# License
C#程序，Web程序 许可文件制作工具


##介绍##
分为Master  和 Client 项目。

Client用于收集服务器电脑相关配置信息（如CPU,磁盘，网卡等等），形成硬件码信息文件。

Master 用于生成授权文件，根据Client生成的硬件码和 带授权程序.dll 生成 授权文件.lic

生成 ![界面](制作授权文件.png)

lic文件为加密内容，通过Master 程序可以进行解密验证。通过引用License.dll，我们可以利用

主版本，副版本，产品类型，序列号，过期日期，用户信息（如权限集合），签名

	<?xml version="1.0" encoding="utf-16"?>
	<License xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
	  <LicenceTo>ifengkou</LicenceTo>
	  <ProductName>cms</ProductName>
	  <MajorVersion>1</MajorVersion>
	  <MinorVersion>0</MinorVersion>
	  <Edition>标准版</Edition>
	  <SerialNumber>A7BFB2EF-7C59-44FB-9A58-6A0252975C54</SerialNumber>
	  <ExpireTo>2015-12-31T00:00:00</ExpireTo>
	  <UserData>01,0101,0102,0103,22,2211,1133,2231,2202,2205,2207,2209,2206,2230</UserData>
	  <Signature>Y3ayAMC7XZAT30eDlHqGybWvTjodlEJqZ+d09ytgNl3PEEd/9MM0OZfg5KIJfyFY1DTA5r99oVsT4Q0umpAfO5Gw4XPymQhxShtiWRLlBB7GME2Z6rxQZoGdJkPWTamG6l2pFUqcS7PAC3Iqee7Lnc6G35ML8s9Uxa++Vt3D7Aw=</Signature>
	</License>


##安装部署##

VS12 直接打开运行

##使用##

 1.项目引用License.dll文件

 2.将生产的.lic 文件拷贝至运行项目根目录下，在Properties目录下，修改AssemblyInfo.cs文件，增加一项：

 	[assembly: DreamLicense.AssemblyDreamLicenseKey()]

 3.在项目关键Controller上加上授权声明：

 	[LicenseProvider(typeof(DreamLicense.DreamLicenseProvider))]
    //public class HomeController

 4.加入验证方法：
	
	private ResultDto License()
        {
		#if DEBUG
            return new ResultDto(true, "");
		#else
          License license;
            string msg = "";
            bool isvalid = false;
            try
            {
                isvalid = LicenseManager.IsValid(typeof(HomeController), this, out license);
                if (license == null)
                {
                    msg = Resource.NoLicenseFile;
                    isvalid = false;
                }
                else if (((DreamLicense.LicenseFile.DreamLicenseFile)license).FailureReason != String.Empty)
                {
                    msg = ((DreamLicense.LicenseFile.DreamLicenseFile)license).FailureReason;
                    isvalid = false;
                }
            }
            catch (Exception ex)
            {
                msg = ex.ToString();
            }
            return new ResultDto(isvalid, msg) ;
		#endif

        }

5.在关键方法中加入上述的验证方法

		public ActionResult Login()
        {
            var rd = License();
            if (!rd.Result)
            {
				//授权不通过
                string retu = "";
                var rdmsg = (string)rd.Message;
                string[] x = rdmsg.Split(new string[] { "\r" }, StringSplitOptions.None);
                if (x.Length > 0) retu = x[0];
                return View("NeedLicense", (object)retu);
            }

            return View("LoginPage");
        }


##贡献##

有任何意见或建议都欢迎提 issue，或者直接提给 [@ifengkou](mail://ifengkou@hotmail.com)

##License##
MIT