using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using License.Model;
using Microsoft.Win32;
using System;
using License.Base;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Windows;
using System.Configuration;
namespace License.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;

        /// <summary>
        /// The <see cref="WelcomeTitle" /> property's name.
        /// </summary>
        public const string WelcomeTitlePropertyName = "WelcomeTitle";
        public const string LicFilePropertyName = "LicFileName";
        public const string LicContentPropertyName = "LicContentName";
        public const string LicPropertyType = "LicType";
        public const string LicPropertyCompany = "Lic4Company";
        public const string LicPropertyProduct = "LicProduct";
        public const string LicPropertyMajorVersion = "LicMajorVersion";
        public const string LicPropertyMinorVersion = "LicMinorVersion";
        public const string LicPropertyExpireTo = "LicExpireTo";
        public const string LicPropertyHardwareInfo = "LicHardwareInfo";

        private SaveFileDialog sfd;
        private OpenFileDialog ofd;
        private static Dictionary<string, string> dicVerdata = new Dictionary<string, string>();

        public RelayCommand CreateCommand { get; set; }
        public RelayCommand BrowseCommand { get; set; }
        /// <summary>
        /// Gets the WelcomeTitle property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        #region welcomeTitle
        private string _welcomeTitle = string.Empty;
        public string WelcomeTitle
        {
            get
            {
                return _welcomeTitle;
            }

            set
            {
                if (_welcomeTitle == value)
                {
                    return;
                }

                _welcomeTitle = value;
                RaisePropertyChanged(WelcomeTitlePropertyName);
            }
        }
        #endregion
        #region LicFileName
        private string _LicFileName = string.Empty;
        public string LicFileName
        {
            get
            {
                return _LicFileName;
            }

            set
            {
                if (_LicFileName == value)
                {
                    return;
                }

                _LicFileName = value;
                RaisePropertyChanged(LicFilePropertyName);
            }
        }
        #endregion 
        #region LicContentName
        private string _LicContentName = string.Empty;
        public string LicContentName
        {
            get
            {
                return _LicContentName;
            }

            set
            {
                if (_LicContentName == value)
                {
                    return;
                }

                _LicContentName = value;
                RaisePropertyChanged(LicContentPropertyName);
            }
        }
        #endregion 
        #region LicType
        private List<string> _LicType = new List<string>();
        public List<string> LicType
        {
            get
            {
                return _LicType;
            }
        }
        #endregion 
        #region Lic4Company
        private string _Lic4Company = string.Empty;
        public string Lic4Company
        {
            get
            {
                return _Lic4Company;
            }

            set
            {
                if (_Lic4Company == value)
                {
                    return;
                }

                _Lic4Company = value;
                RaisePropertyChanged(LicPropertyCompany);
            }
        }
        #endregion 
        #region LicProduct
        private string _LicProduct = string.Empty;
        public string LicProduct
        {
            get
            {
                return _LicProduct;
            }

            set
            {
                if (_LicProduct == value)
                {
                    return;
                }

                _LicProduct = value;
                RaisePropertyChanged(LicPropertyProduct);
            }
        }
        #endregion
        #region LicMajorVersion
        private int _LicMajorVersion = 1;
        public int LicMajorVersion
        {
            get
            {
                return _LicMajorVersion;
            }

            set
            {
                if (_LicMajorVersion == value)
                {
                    return;
                }

                _LicMajorVersion = value;
                RaisePropertyChanged(LicPropertyMajorVersion);
            }
        }
        #endregion
        #region LicMinorVersion
        private int _LicMinorVersion = 0;
        public int LicMinorVersion
        {
            get
            {
                return _LicMinorVersion;
            }

            set
            {
                if (_LicMinorVersion == value)
                {
                    return;
                }

                _LicMinorVersion = value;
                RaisePropertyChanged(LicPropertyMinorVersion);
            }
        }
        #endregion
        #region LicExpireTo
        private DateTime _LicExpireTo;
        public DateTime LicExpireTo
        {
            get
            {
                return _LicExpireTo;
            }

            set
            {
                if (_LicExpireTo == value)
                {
                    return;
                }

                _LicExpireTo = value;
                RaisePropertyChanged(LicPropertyExpireTo);
            }
        }
        #endregion
        #region LicHardwareInfo
        private string _LicHardwareInfo = string.Empty;
        public string LicHardwareInfo
        {
            get
            {
                return _LicHardwareInfo;
            }

            set
            {
                if (_LicHardwareInfo == value)
                {
                    return;
                }

                _LicHardwareInfo = value;
                RaisePropertyChanged(LicPropertyHardwareInfo);
            }
        }
        #endregion
        #region Edition
        private string _Edition = string.Empty;
        public string Edition
        {
            get
            {
                return _Edition;
            }

            set
            {
                if (_Edition == value)
                {
                    return;
                }

                _Edition = value;
                RaisePropertyChanged("Edition");
            }
        }
        #endregion
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IDataService dataService)
        {
            _dataService = dataService;
            _dataService.GetData(
                (item, error) =>
                {
                    if (error != null)
                    {
                        // Report error here
                        return;
                    }

                    WelcomeTitle = item.Title;
                });
            dicVerdata.Clear();

            //初始化表单控件默认值
            LicExpireTo = DateTime.Today;
            initVersion();
            //文件对话框初始化
            sfd = new SaveFileDialog();
            sfd.DefaultExt = "lic";
            sfd.FileName = "license.lic";
            sfd.Filter = "授权文件(*.lic)|*.lic|所有文件|*.*";
            sfd.Title = "保存授权文件";
            ofd = new OpenFileDialog();
            ofd.DefaultExt = "lic";
            ofd.Filter = "授权文件(*.lic)|*.lic|所有文件|*.*";
            ofd.FileName = "licence.lic";

            //command 初始化
            CreateCommand = new RelayCommand(CreateButton_click);
            BrowseCommand = new RelayCommand(BrowseButton_Click);
           
        }
        private void initVersion()
        {
            try
            {
                string versions = ConfigurationManager.AppSettings["version"];
                string[] vs = versions.Split(',');
                foreach (var v in vs)
                {
                    string[] vd = v.Split('@');
                    LicType.Add(vd[0]);
                    dicVerdata.Add(vd[0], vd[1]);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("初始化程序失败，请检查配置文件是否正确!error:" + e.Message);
            }
        }
        private string getUserData(string tag)
        {
            return ConfigurationManager.AppSettings["data" + tag];
        }
        private void CreateButton_click()
        {
            if (this.FormIsValid())
            {
                sfd.ShowDialog();
                try
                {
                    License.Base.License lic = new Base.License();
                    lic.SerialNumber = System.Guid.NewGuid().ToString().ToUpper();
                    lic.LicenceTo = Lic4Company.Trim();
                    lic.ProductName = LicProduct.Trim();
                    lic.Edition = Edition;
                    lic.MajorVersion = LicMajorVersion;
                    lic.MinorVersion = LicMinorVersion;
                    lic.ExpireTo = LicExpireTo;
                    if (!string.IsNullOrWhiteSpace(LicHardwareInfo))
                    {
                        lic.MachineDesc = LicHardwareInfo.Trim();
                    }
                    License.Utils.Security security = new License.Utils.Security();
                    string tag = dicVerdata[Edition];
                    lic.UserData = getUserData(tag);
                    string hash = security.GetHash(lic.GetHashString());
                    lic.Signature = security.SignatureFormatter(hash);
                    lic.Save(sfd.FileName);
                }
                catch (Exception)
                {

                }
            }
        }
        private void BrowseButton_Click()
        {
            ofd.ShowDialog();
            string f = ofd.FileName;
            LicFileName = f;
            try
            {
                License.Base.License license = GetLicense(f);
                LicContentName = license.ToString();
            }
            catch (System.Exception ex)
            {
                LicContentName = ex.ToString();
            }
        }
        private bool FormIsValid()
        {
            if (string.IsNullOrEmpty(Edition))
            {
                //边框变红
                MessageBox.Show("版本信息为空");
                return false;
            }
            return true;
        }
        public License.Base.License GetLicense(string licenseFile)
        {
            License.Base.License result;
            try
            {
                if (!System.IO.File.Exists(licenseFile))
                {
                    throw new LicenseInvalidException("没有找到程序授权信息,请联系中联重科!");
                }
                Security security = new Security();
                string encodedString = System.IO.File.ReadAllText(licenseFile);
                string s = security.DecodeString(encodedString);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(License.Base.License));
                License.Base.License license = (License.Base.License)xmlSerializer.Deserialize(new System.IO.StringReader(s));
                if (!this.VerifyLicense(license))
                {
                    throw new LicenseInvalidException("许可无效,License Invalid!");
                }
                result = license;
            }
            catch
            {
                throw;
            }
            return result;
        }
        private bool VerifyLicense(License.Base.License lic)
        {
            Security security = new Security();
            string hash = security.GetHash(lic.GetHashString());
            bool flag = security.SignatureDeformatter(hash, lic.Signature);
            return flag;
        }
        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}