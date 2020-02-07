using System;
using System.Collections.Generic;
using System.Text;
using CHAI.LISDashboard.CoreDomain.Users;

namespace CHAI.LISDashboard.Modules.Shell.MasterPages
{
    public interface IHomeMasterView
    {
        AppUser user { set; get; }
    }
}




