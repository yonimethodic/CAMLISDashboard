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

using System.Data;


namespace CHAI.LISDashboard.Modules.Report
{
    public class ReportController : ControllerBase
    {
        private IWorkspace _workspace;

        [InjectionConstructor]
        public ReportController([ServiceDependency] IHttpContextLocatorService httpContextLocatorService, [ServiceDependency]INavigationService navigationService)
            : base(httpContextLocatorService, navigationService)
        {
            _workspace = ZadsServices.Workspace;
        }

        #region Locations
        public IList<Province> GetProvinces()
        {
            return WorkspaceFactory.CreateReadOnly().Query<Province>(null).ToList();
        }
        public IList<Facility> GetFacilities()
        {
            return WorkspaceFactory.CreateReadOnly().Query<Facility>(null).OrderBy(x => x.FacilityName).ToList();
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
        public IList<FacilityType> GetFacilityTypeByFacilityType2(string value)
        {
            IList<FacilityType> list = new List<FacilityType>();
            if (string.IsNullOrEmpty(value))
                list = WorkspaceFactory.CreateReadOnly().Query<FacilityType>(null).OrderBy(x => x.FacilityTypeName).ToList();
            else
            {              
                list = WorkspaceFactory.CreateReadOnly().Query<FacilityType>(x => x.FacilityType2 == value).ToList();
            }
            return list;
        }

        #endregion

        public IList<Year> GetYear()
        {
            EIDDashboardDao dao = new EIDDashboardDao();
            return dao.GetYears();
        }


    }
}
