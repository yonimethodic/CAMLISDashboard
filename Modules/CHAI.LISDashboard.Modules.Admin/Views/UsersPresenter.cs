using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.CompositeWeb;

using CHAI.LISDashboard.CoreDomain.Users;
using CHAI.LISDashboard.Shared;

namespace CHAI.LISDashboard.Modules.Admin.Views
{
    public class UsersPresenter : Presenter<IUsersView>
    {
        private AdminController _controller;
 
        public UsersPresenter([CreateNew] AdminController controller)
        {
            _controller = controller;
        }

        public override void OnViewLoaded()
        {
            // TODO: Implement code that will be executed every time the view loads
        }

        public override void OnViewInitialized()
        {
            // TODO: Implement code that will be executed the first time the view loads
        }

        public AdminController Controller { get { return _controller; } }

        public void AddNewUser()
        {
            string url = String.Format("~/Admin/UserEdit.aspx?{0}=0&{1}=0", AppConstants.TABID, AppConstants.USERID);
            _controller.Navigate(url);
        }

        public IList<AppUser> SearchUser(string username)
        {
            return _controller.SearchUsers(username);
        }
    }
}




