using System;
using System.Collections.Generic;
using System.Text;
using CHAI.LISDashboard.CoreDomain;

using CHAI.LISDashboard.CoreDomain.Users;

namespace CHAI.LISDashboard.Modules.Admin.Views
{
    public interface IUserEditView
    {
        string GetUserId { get; }
        string GetUserName { get; }
        string GetFirstName { get; }
        string GetLastName { get; }
        string GetEmail { get; }
        bool GetIsActive { get; }
        string GetPassword { get; }
      
        
       
       

        //IList<Role> Roles { set; }
        
    }
}




