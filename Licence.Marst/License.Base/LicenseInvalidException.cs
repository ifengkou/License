using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace License.Base
{
    public class LicenseInvalidException : Exception
    {
        public LicenseInvalidException()
            : base()
        {
        }
        public LicenseInvalidException(string message)
            : base(message)
        {
        }
        public LicenseInvalidException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
