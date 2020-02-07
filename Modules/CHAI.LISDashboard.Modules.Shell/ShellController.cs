using System;
using System.Web.SessionState;
using Microsoft.Practices.CompositeWeb;
using Microsoft.Practices.CompositeWeb.Interfaces;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.CompositeWeb.Web;
using System.Linq;
using System.Linq.Expressions;

using CHAI.LISDashboard.CoreDomain;
using CHAI.LISDashboard.CoreDomain.DataAccess;
using CHAI.LISDashboard.CoreDomain.Admins;
using CHAI.LISDashboard.Shared.Navigation;
using CHAI.LISDashboard.Services;

using CHAI.LISDashboard.CoreDomain.Users;
using System.Collections.Generic;


namespace CHAI.LISDashboard.Modules.Shell
{
    public class ShellController : ControllerBase
    {
        private IWorkspace _workspace;
        private int currentUser;
        [InjectionConstructor]
        public ShellController([ServiceDependency] IHttpContextLocatorService httpContextLocatorService,
           [ServiceDependency] INavigationService navigationService)
            : base(httpContextLocatorService,navigationService)
        {
            _workspace = ZadsServices.Workspace;
        }
      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodeid"></param>
        /// <returns></returns>
        public Node ActiveNode(int nodeid)
        {
            using (var vr = WorkspaceFactory.CreateReadOnly())
            {
                return vr.Single<Node>(x => x.Id == nodeid, x => x.NodeRoles.Select(y => y.Role));     
            }
        }

        public Tab ActiveTab(int tabid)
        {
            using (var vr = WorkspaceFactory.CreateReadOnly())
            {
                return vr.Single<Tab>(x => x.Id == tabid, x => x.PocModule, x => x.TabRoles.Select(z => z.Role), x => x.TaskPans.Select(y => y.TaskPanNodes.Select(w => w.Node.PocModule)), x => x.TaskPans.Select(y => y.TaskPanNodes.Select(w => w.Node.NodeRoles.Select(a => a.Role) )));
            }
        }

        #region CurrenrObject
        public object CurrentObject
        {
            get
            {
                return GetCurrentContext().Session["CurrentObject"];
            }
            set
            {
                GetCurrentContext().Session["CurrentObject"] = value;
            }
        }
        #endregion
        
        #region Entity Manipulation
        public void SaveOrUpdateEntity<T>(T item) where T : class
        {
            IEntity entity = (IEntity)item;
            if (entity.Id == 0)
                _workspace.Add<T>(item);
            else
                _workspace.Update<T>(item);

            _workspace.CommitChanges();
        }
        public void DeleteEntity<T>(T item) where T : class
        {
            _workspace.Delete<T>(item);
            _workspace.CommitChanges();
        }

        public void Commit()
        {
            _workspace.CommitChanges();
        }
        #endregion

        //Added by ZaySoe on 11_Jan_2019
        public AppUser GetUser(int userid)
        {
            return _workspace.Single<AppUser>(x => x.Id == userid, x => x.AppUserRoles.Select(y => y.Role), x => x.UserLocations, x => x.UserLocations.Select(p => p.province), x => x.UserLocations.Select(d => d.District), x => x.UserLocations.Select(l => l.LLG), x => x.UserLocations.Select(f => f.Facility));
        }
    }
}
