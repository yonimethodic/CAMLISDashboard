using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.CompositeWeb;
using CHAI.LISDashboard.CoreDomain.Users;
using CHAI.LISDashboard.Shared;

namespace CHAI.LISDashboard.Modules.Admin.Views
{
    public class RolesPresenter : Presenter<IRolesView>
    {
        private AdminController _controller;

        public RolesPresenter([CreateNew] AdminController controller)
        {
            _controller = controller;
        }

        public override void OnViewLoaded()
        {
            // TODO: Implement code that will be executed every time the view loads
        }

        public override void OnViewInitialized()
        {
            View.BindRoles();
        }

        public void AddNewRole()
        {
            string url = String.Format("~/Admin/RoleEdit.aspx?{0}=0&{1}=0", AppConstants.TABID, AppConstants.ROLEID);
            _controller.Navigate(url);
        }

       public IList<Role> GetAllRoles()
       {
           return _controller.GetRoles;
       }
    }
}




