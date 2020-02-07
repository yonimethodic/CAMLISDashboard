using System;
using System.Collections.Generic;
using System.Text;
using CHAI.LISDashboard.CoreDomain.Users;

namespace CHAI.LISDashboard.Modules.Shell.MasterPages
{
    public interface IBaseMasterView
    {
        string TabId { get; }
        AppUser CurrentUser { set; get; }
    }
}
