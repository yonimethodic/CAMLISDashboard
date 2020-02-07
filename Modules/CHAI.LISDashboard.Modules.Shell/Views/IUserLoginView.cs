using System;
using System.Collections.Generic;
using System.Text;

namespace CHAI.LISDashboard.Modules.Shell.Views
{
    public interface IUserLoginView
    {
        string GetUserName { get; }
        string GetPassword { get; }
        bool PersistLogin { get; }
    }
}




