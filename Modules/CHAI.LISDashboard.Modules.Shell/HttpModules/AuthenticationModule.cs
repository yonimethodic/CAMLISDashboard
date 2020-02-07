using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Linq;
using System.Linq.Expressions;

using Microsoft.Practices.CompositeWeb;
using CHAI.LISDashboard.CoreDomain;
using CHAI.LISDashboard.CoreDomain.Users;
using CHAI.LISDashboard.CoreDomain.DataAccess;
using CHAI.LISDashboard.Shared;
using CHAI.LISDashboard.Services;

namespace CHAI.LISDashboard.Modules.Shell
{
    /// <summary>
    /// Summary description for AuthenticationModule
    /// </summary>
    public class AuthenticationModule : IHttpModule
    {
        private const int AUTHENTICATION_TIMEOUT = 20;
        
        public AuthenticationModule()
        {
        }

        public void Init(HttpApplication context)
        {
            context.AuthenticateRequest += new EventHandler(Context_AuthenticateRequest);
        }

        public void Dispose()
        {
            // Nothing here 
        }

        /// <summary>
        /// Try to authenticate the user.
       /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool AuthenticateUser(string username, string password, bool persistLogin)
        {
            string hashedPassword = Encryption.StringToMD5Hash(password);

            try
            {
                using (var wr = WorkspaceFactory.Create())
                {
                    AppUser user = wr.Single<AppUser>(x => x.UserName == username && x.Password == hashedPassword);                     
                    if (user != null)
                    {                        
                        if (!user.IsActive)
                        {
                            throw new Exception("The account is disabled.");
                        }

                        // Added by ZaySoe on 14_Jan_2019 for getting UserLocations
                        //user = wr.Single<AppUser>(x => x.Id == user.Id, x => x.AppUserRoles.Select(y => y.Role), x => x.UserLocations, x => x.UserLocations.Select(p => p.province), x => x.UserLocations.Select(d => d.District), x => x.UserLocations.Select(l => l.LLG), x => x.UserLocations.Select(f => f.Facility), x => x.UserLocations.Select(l => l.Laboratory));

                        //user = wr.Single<AppUser>(x => x.Id == user.Id, x => x.AppUserRoles.Select(y => y.Role), x => x.UserLocations, x => x.UserLocations.Select(p => p.province), x => x.UserLocations.Select(d => d.District), x => x.UserLocations.Select(l => l.LLG), x => x.UserLocations.Select(f => f.Facility));                        

                        user = wr.Single<AppUser>(x => x.Id == user.Id, x => x.AppUserRoles.Select(y => y.Role));
                        //if(user.AppUserRoles != null && user.AppUserRoles[0].Role.Id == 14)  // Lab Role
                        //    user = wr.Single<AppUser>(x => x.Id == user.Id, x => x.AppUserRoles.Select(y => y.Role), x => x.UserLocations.Select(y => y.LabCode));
                        //else if (user.AppUserRoles != null && user.AppUserRoles[0].Role.Id == 13)  // Facility Role
                        //    user = wr.Single<AppUser>(x => x.Id == user.Id, x => x.AppUserRoles.Select(y => y.Role), x => x.UserLocations, x => x.UserLocations.Select(p => p.province), x => x.UserLocations.Select(d => d.District), x => x.UserLocations.Select(l => l.LLG), x => x.UserLocations.Select(f => f.Facility));

                        user.IsAuthenticated = true;
                        string currentIp = HttpContext.Current.Request.UserHostAddress;
                        user.LastLogin = DateTime.Now;
                        user.LastIp = currentIp;
                        wr.CommitChanges();
                        
                        HttpContext.Current.User = new ChaiPrincipal(user);
                        FormsAuthentication.SetAuthCookie(user.Name, persistLogin);                        

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Unable to log in user '{0}': " + ex.Message, username), ex);
            }
            return false;
        }
        ///
        /// <summary>
        /// Log out the current user.
        /// </summary>
        /// 
        public void Logout()
        {
            if (HttpContext.Current.User != null && HttpContext.Current.User.Identity.IsAuthenticated)
            {
                FormsAuthentication.SignOut();
            }
        }

        private void Context_AuthenticateRequest(object sender, EventArgs e)
        {
            HttpApplication app = (HttpApplication)sender;

            if (app.Context.User != null && app.Context.User.Identity.IsAuthenticated)
            {
                int userId = Int32.Parse(app.Context.User.Identity.Name);

                using (var wr = WorkspaceFactory.CreateReadOnly())
                {
                    AppUser user = wr.Single<AppUser>(x => x.Id == userId, x => x.AppUserRoles.Select(y => y.Role));
                    user.IsAuthenticated = true;
                    app.Context.User = new ChaiPrincipal(user);
                }
            }
        }
    }
}
