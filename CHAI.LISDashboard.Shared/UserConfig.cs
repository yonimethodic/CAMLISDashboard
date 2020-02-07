using System;
using System.Configuration;
using System.Xml;
using System.Collections.Specialized;

namespace CHAI.LISDashboard.Shared
{
    /// <summary>
    /// Summary description for Config.
    /// </summary>
    public class UserConfig
    {
        private UserConfig()
        {
        }

        public static NameValueCollection GetConfiguration()
        {
            return (NameValueCollection)ConfigurationManager.GetSection("SKDHTechnicalSettings");
        }
    }

    public class ChaiUserSectionHandler : NameValueSectionHandler
    {
        protected override string KeyAttributeName
        {
            get { return "setting"; }
        }

        protected override string ValueAttributeName
        {
            get { return base.ValueAttributeName; }
        }
    }
}
