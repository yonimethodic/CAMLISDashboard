using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.Practices.CompositeWeb;
using Microsoft.Practices.CompositeWeb.Interfaces;
using Microsoft.Practices.CompositeWeb.Utility;
using Microsoft.Practices.ObjectBuilder;

using CHAI.LISDashboard.CoreDomain;
using CHAI.LISDashboard.CoreDomain.DataAccess;
using CHAI.LISDashboard.CoreDomain.Admins;
using CHAI.LISDashboard.CoreDomain.Users;
using CHAI.LISDashboard.Services;
using CHAI.LISDashboard.Shared.Navigation;
using CHAI.LISDashboard.CoreDomain.Setting;

namespace CHAI.LISDashboard.Modules.Admin
{
    public class AdminController : ControllerBase
    {
        private IWorkspace _workspace;

        [InjectionConstructor]
        public AdminController([ServiceDependency] IHttpContextLocatorService httpContextLocatorService, [ServiceDependency]INavigationService navigationService)
            : base(httpContextLocatorService, navigationService)
        {
            _workspace = ZadsServices.Workspace;
        }

        #region Security And Administration
        public IList<Role> GetRoles
        {
            get
            {
                return WorkspaceFactory.CreateReadOnly().Query<Role>(null).ToList();
            }
        }
        public IList<AppUser> GetUsers()
        {
            return WorkspaceFactory.CreateReadOnly().Query<AppUser>(null).ToList();
        }
        
        public Role GetRoleById(int roleid)
        {
            return _workspace.Single<Role>(x => x.Id == roleid);
        }
        public AppUser GetUser(int userid)
        {
            return _workspace.Single<AppUser>(x => x.Id == userid, x => x.AppUserRoles.Select(y => y.Role), x => x.UserLocations,x=> x.UserLocations.Select(p=>p.province), x => x.UserLocations.Select(d => d.District), x => x.UserLocations.Select(l => l.LLG), x => x.UserLocations.Select(f => f.Facility));
        }
        public IList<AppUser> SearchUsers(string username)
        {
            return ZadsServices.AdminServices.SearchUsers(username).ToList();
        }
        public void SaveOrUpdateUser(AppUser user)
        {
            if (user.Id <= 0)
            {
                user.DateCreated = DateTime.Now;
                user.DateModified = DateTime.Now;

                using (var wr = WorkspaceFactory.CreateReadOnly())
                {
                    if (wr.Single<AppUser>(x => x.UserName == user.UserName) != null)
                        throw new Exception("User name already exists");
                }
            }
            else
            {
                foreach (AppUserRole r in user.AppUserRoles)
                {
                    if (r.Id == 0)
                        _workspace.Add(r);
                }
            }

            SaveOrUpdateEntity<AppUser>(user);
        }
        public void RemoveListOfObjects<T>(T[] items) where T : class
        {
            for (int i = 0; i < items.Length; i++)
            {
                _workspace.Delete<T>(items[i]);
            }
        }
        public Node GetNodeById(int nodeid)
        {
            return _workspace.Single<Node>(x => x.Id == nodeid, x => x.NodeRoles.Select(y => y.Role));
        }
        public IList<Node> GetListOfNodeByModuleId(int modid)
        {
            return WorkspaceFactory.CreateReadOnly().Query<Node>(x => x.PocModule.Id == modid).ToList();
        }
        public IList<Node> GetListOfAllNodes()
        {
            return WorkspaceFactory.CreateReadOnly().Query<Node>(null).ToList();
        }
        public PocModule GetModuleById(int modid)
        {
            return _workspace.Single<PocModule>(x => x.Id == modid);
        }
        public IList<PocModule> GetListOfAllPocModules()
        {
            return WorkspaceFactory.CreateReadOnly().Query<PocModule>(null).ToList();
        }
        public Tab GetTabById(int tabid)
        {
            return _workspace.Single<Tab>(x => x.Id == tabid, x => x.PocModule, x => x.TabRoles.Select(y => y.Role), x => x.TaskPans.Select(z => z.TaskPanNodes.Select(w => w.Node)));
        }
        public IEnumerable<Tab> GetListOfAllTab()
        {
            return WorkspaceFactory.CreateReadOnly().Query<Tab>(null);
        }
        public void MoveTabUp(Tab tab)
        {
            ZadsServices.AdminServices.MoveTabUp(tab);
            _workspace.Refresh(tab);
        }
        public void MoveTabDown(Tab tab)
        {
            ZadsServices.AdminServices.MoveTabDown(tab);
        }
        public void MoveUpTaskPan(int panid)
        {
            ZadsServices.AdminServices.MoveUpTaskPan(panid);
        }
        public void MoveDownTaskPan(int panid)
        {
           
            ZadsServices.AdminServices.MoveDownTaskPan(panid);
        }
        public void MoveUpPanNode(int id)
        {
            ZadsServices.AdminServices.MoveUpPanNode(id);
        }
        public void MoveDownPanNode(int id)
        {
            ZadsServices.AdminServices.MoveDownPanNode(id);
        }
        public int GetMaxTabPosition()
        {
            return ZadsServices.AdminServices.GetMaxTabPosition();
        }
        #endregion

        #region Locations
        public IList<Province> GetProvinces()
        {
            return WorkspaceFactory.CreateReadOnly().Query<Province>(null).ToList();
        }
        public IList<District> GetDistricts(int provinceId)
        {
            return WorkspaceFactory.CreateReadOnly().Query<District>(x=>x.Province.Id==provinceId).ToList();
        }
        public IList<LLG> GetLLGs(int districtId)
        {
            return WorkspaceFactory.CreateReadOnly().Query<LLG>(x=>x.District.Id == districtId).ToList();
        }
        public IList<Facility> GetFacilities(int LLGId)
        {
            return WorkspaceFactory.CreateReadOnly().Query<Facility>(x=>x.LLG.Id==LLGId).ToList();
        }

        public Province GetProvince(int Id)
        {
            return _workspace.Single<Province>(x => x.Id == Id);
        }
        public District GetDistrict(int Id)
        {
            return _workspace.Single<District>(x => x.Id == Id);
        }
        public LLG GetLLG(int Id)
        {
            return _workspace.Single<LLG>(x => x.Id == Id);
        }
        public Facility GetFacility(int Id)
        {
            return _workspace.Single<Facility>(x => x.Id == Id);
        }
        #endregion
        #region UserLocation
        public IList<UserLocation> GetUserLocations(int userId)
        {
            return WorkspaceFactory.CreateReadOnly().Query<UserLocation>(x=>x.User.Id== userId).ToList();
        }

        #endregion
        #region Labratories
        public IList<Laboratory> GetLabratories()
        {
            return WorkspaceFactory.CreateReadOnly().Query<Laboratory>(null).ToList();
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
            _workspace.Refresh(item);
        }
        public void DeleteEntity<T>(T item) where T : class
        {
            _workspace.Delete<T>(item);
            _workspace.CommitChanges();
        }
        #endregion

    }
}
