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


using System.Data;
using CHAI.LISDashboard.CoreDomain.Setting;

namespace CHAI.LISDashboard.Modules.ViralLoad
{
    public class ViralLoadController : ControllerBase
    {
        private IWorkspace _workspace;
        
        [InjectionConstructor]
        public ViralLoadController([ServiceDependency] IHttpContextLocatorService httpContextLocatorService, [ServiceDependency]INavigationService navigationService)
            : base(httpContextLocatorService, navigationService)
        {
            _workspace = ZadsServices.Workspace;
        }
        
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

        //Added by ZaySoe 19_Dec_2018
        #region Locations
        public IList<Province> GetProvinces()
        {
            return WorkspaceFactory.CreateReadOnly().Query<Province>(null).ToList();
        }
        public IList<District> GetDistricts(int provinceId)
        {
            return WorkspaceFactory.CreateReadOnly().Query<District>(x => x.Province.Id == provinceId).ToList();
        }
        public IList<LLG> GetLLGs(int districtId)
        {
            return WorkspaceFactory.CreateReadOnly().Query<LLG>(x => x.District.Id == districtId).ToList();
        }
        //public IList<Facility> GetFacilities(int LLGId)
        //{
        //    return WorkspaceFactory.CreateReadOnly().Query<Facility>(x => x.LLG.Id == LLGId).ToList();
        //}
        public IList<Facility> GetFacilities(int provinceId)
        {
            return WorkspaceFactory.CreateReadOnly().Query<Facility>(x => x.ProvinceId == provinceId).ToList();
        }
        public IList<Laboratory> GetLaboratories()
        {
            return WorkspaceFactory.CreateReadOnly().Query<Laboratory>(null).OrderBy(x => x.LaboratoryName).ToList();
        }
        #endregion

        public IList<Year> GetYear()
        {
            EIDDashboardDao dao = new EIDDashboardDao();
            return dao.GetYears();
        }
    }
}
