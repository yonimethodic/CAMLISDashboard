using System;
using System.Collections.Generic;
using CHAI.LISDashboard.Shared;

namespace CHAI.LISDashboard.Modules.Shell
{
    public class BaseMessageControl : Microsoft.Practices.CompositeWeb.Web.UI.UserControl
    {
        private AppMessage _message;

        public AppMessage Message
        {
            get { return _message; }
            set { _message = value; }
        }

        public BaseMessageControl()
        {
        }
    }
}
