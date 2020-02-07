using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Practices.CompositeWeb;
using Microsoft.Practices.CompositeWeb.Web;
using Microsoft.Practices.CompositeWeb.Interfaces;
using Microsoft.Practices.ObjectBuilder;

using CHAI.LISDashboard.CoreDomain.Users;
using CHAI.LISDashboard.Shared;
using CHAI.LISDashboard.CoreDomain.Setting;

namespace CHAI.LISDashboard.Modules.Admin.Views
{
    public class UserEditPresenter : Presenter<IUserEditView>
    {
        private AdminController _controller;
        
        private AppUser _user;

        public UserEditPresenter([CreateNew] AdminController controller)
        {
            _controller = controller;
          
        }

        public override void OnViewLoaded()
        {
            
        }

        public override void OnViewInitialized()
        {
           
        }

        public AppUser CurrentUser
        {
            get 
            {
                if (_user == null)
                {
                    int id = int.Parse(View.GetUserId);
                    if (id > 0)
                        _user = _controller.GetUser(id);
                    else
                        _user = new AppUser();
                }
                return _user; }
        }
        
       
        public Role GetRoleById(int roleid)
        {
            return _controller.GetRoleById(roleid);
        }
        public IList<Role> GetRoles()
        {
            return _controller.GetRoles;
        }

        public void SaveOrUpdateUser()       
        {
            AppUser user = CurrentUser;

            if (user.Id <= 0)
                user.UserName = View.GetUserName;
            
            user.FirstName = View.GetFirstName;
            user.LastName = View.GetLastName;
            
            user.Email = View.GetEmail;
            user.IsActive = View.GetIsActive;
            user.DateModified = DateTime.Now;
            
            if (View.GetPassword.Length > 0)
            {
                try
                {
                    user.Password = AppUser.HashPassword(View.GetPassword);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            if (user.Id <= 0 && user.Password == null)
                throw new Exception("Password is required");

            _controller.SaveOrUpdateUser(user);
        }

        public void RemoveUserRoles()
        {
            if (CurrentUser.AppUserRoles.Count > 0)
            {
                AppUserRole[] uroles = new AppUserRole[CurrentUser.AppUserRoles.Count];
                CurrentUser.AppUserRoles.CopyTo(uroles, 0);
                CurrentUser.AppUserRoles.Clear();
                _controller.RemoveListOfObjects<AppUserRole>(uroles);
            }
        }

        public void DeleteUser()
        {
            if (CurrentUser.Id >0)
               _controller.DeleteEntity<AppUser>(CurrentUser);
        }

        public void CancelPage()
        {
            _controller.Navigate(String.Format("~/Admin/Users.aspx?{0}=0", AppConstants.TABID));
        }
        public void RedirectPage(string url)
        {
            _controller.Navigate(url);

        }
        public IList<AppUser> GetUsers()
        {

            return _controller.GetUsers();

        }
        public AppUser GetUser(int userid)
        {
            return _controller.GetUser(userid);
        }
        #region Province
        public IList<Province> GetProvinces()
        {
            return _controller.GetProvinces();
        }
        public IList<District> GetDistricts(int provinceId)
        {
            return _controller.GetDistricts(provinceId);
        }
        public IList<LLG> GetLLGs(int districtId)
        {
            return _controller.GetLLGs(districtId);
        }
        public IList<Facility> GetFacilities(int LLGId)
        {
            return _controller.GetFacilities(LLGId);
        }
        #endregion
        #region UserLocation
        public IList<UserLocation> GetUserLocations(int userId)
        {
            return _controller.GetUserLocations(userId);
        }
        #endregion
        #region Labratories
        public IList<Laboratory> GetLabratories()
        {
            return _controller.GetLabratories();
        }
        public Province GetProvince(int Id)
        {
            return _controller.GetProvince(Id);
        }
        public District GetDistrict(int Id)
        {
            return _controller.GetDistrict(Id);
        }
        public LLG GetLLG(int Id)
        {
            return _controller.GetLLG(Id);
        }
        public Facility GetFacility(int Id)
        {
            return _controller.GetFacility(Id);
        }
        public void Delete(UserLocation UL)
        {
            _controller.DeleteEntity(UL);
        }
        #endregion
    }
}




