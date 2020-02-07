using System;
using System.Configuration;
using System.Xml;
using System.Collections.Specialized;

namespace CHAI.LISDashboard.Shared
{
    /// <summary>
    /// Summary description for Config.
    /// </summary>
    public class TechnicalConfig
    {
        private TechnicalConfig()
        {
        }

        public static NameValueCollection GetConfiguration()
        {
            return (NameValueCollection)ConfigurationManager.GetSection("SKDHTechnicalSettings");
        }
    }

    public class SKDHTechnicalSectionHandler : NameValueSectionHandler
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
