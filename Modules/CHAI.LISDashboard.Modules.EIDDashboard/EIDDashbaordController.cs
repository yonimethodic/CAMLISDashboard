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
using System.Collections;
using CHAI.LISDashboard.CoreDomain.Setting;
using CHAI.LISDashboard.CoreDomain.Report;

namespace CHAI.LISDashboard.Modules.EIDDashboard
{
    public class EIDDashboardController : ControllerBase
    {
        private IWorkspace _workspace;

        [InjectionConstructor]
        public EIDDashboardController([ServiceDependency] IHttpContextLocatorService httpContextLocatorService, [ServiceDependency]INavigationService navigationService)
            : base(httpContextLocatorService, navigationService)
        {
            _workspace = ZadsServices.Workspace;
        }
        public IList GetEIDOutcomesbyAge(int province, DateTime datefrom, DateTime dateto)
        {
            EIDDashboardDao re = new EIDDashboardDao();
            return re.GetEIDOutcomesbyAge(province, datefrom, dateto);
        }
        public IList GetEIDModeofDelivery(int province, DateTime datefrom, DateTime dateto)
        {
            EIDDashboardDao re = new EIDDashboardDao();
            return re.GetEIDModeofDelivery(province, datefrom, dateto);
        }
        public IList GetEIDOutcomes(int province, DateTime datefrom, DateTime dateto)
        {
            EIDDashboardDao re = new EIDDashboardDao();
            return re.GetEIDOutcomes(province, datefrom, dateto);
        }
        public IList GetInfantFeeding(int province, DateTime datefrom, DateTime dateto)
        {
            EIDDashboardDao re = new EIDDashboardDao();
            return re.GetInfantFeeding(province, datefrom, dateto);
        }
        public IList GetEIDIntialPCR(int province, DateTime datefrom, DateTime dateto)
        {
            EIDDashboardDao re = new EIDDashboardDao();
            return re.GetEIDIntialPCR(province, datefrom, dateto);
        }
        public IList GetEIDIntialPCRbyProvince(int province, DateTime datefrom, DateTime dateto)
        {
            EIDDashboardDao re = new EIDDashboardDao();
            return re.GetEIDIntialPCRbyProvince(province, datefrom, dateto);
        }
        public IList<Province> GetProvinces()
        {
            return WorkspaceFactory.CreateReadOnly().Query<Province>(null).OrderBy(x => x.ProvinceName).ToList();
        }

        public IList<Facility> GetFacilities()
        {
            return WorkspaceFactory.CreateReadOnly().Query<Facility>(null).OrderBy(x => x.FacilityName).ToList();
        }

        public IList<Laboratory> GetLabratories()
        {
            return WorkspaceFactory.CreateReadOnly().Query<Laboratory>(null).OrderBy(x => x.LaboratoryName).ToList();
        }
        public IList GetEIDIntialPCRbyYear(int province, int user_id, string role)//, DateTime datefrom, DateTime dateto)
        {
            EIDDashboardDao re = new EIDDashboardDao();
            return re.GetEIDIntialPCRbyYear(province, user_id, role);
        }

        public IList GetEIDIntialPCRbyYearForLab(string labCode, int dateFrom, int dateTo, int user_id, string role)//, DateTime datefrom, DateTime dateto)
        {
            EIDDashboardDao re = new EIDDashboardDao();
            return re.GetEIDIntialPCRbyYearForLab(labCode, dateFrom, dateTo, user_id, role);
        }

        public IList GetEIDIntialPCRbyQuarter(int province, int dateFrom, int dateTo, int user_id, string role)//, DateTime datefrom, DateTime dateto)
        {
            EIDDashboardDao re = new EIDDashboardDao();
            return re.GetEIDIntialPCRbyQuarter(province, dateFrom, dateTo, user_id, role);
        }

        public IList GetEIDIntialPCRbyQuarterForLab(string labCode, int dateFrom, int dateTo, int user_id, string role)//, DateTime datefrom, DateTime dateto)
        {
            EIDDashboardDao re = new EIDDashboardDao();
            return re.GetEIDIntialPCRbyQuarterForLab(labCode, dateFrom, dateTo, user_id, role);
        }

        //Added by Zay Soe on 9_Jan_2019
        public IList GetEIDIntialPCRbyMonth(int province, int dateFrom, int dateTo, int user_id, string role)//, DateTime datefrom, DateTime dateto)
        {
            EIDDashboardDao re = new EIDDashboardDao();
            return re.GetEIDIntialPCRbyMonth(province, dateFrom, dateTo, user_id, role);
        }

        public IList GetEIDIntialPCRbyMonthForLab(string labCode, int dateFrom, int dateTo, int user_id, string role)//, DateTime datefrom, DateTime dateto)
        {
            EIDDashboardDao re = new EIDDashboardDao();
            return re.GetEIDIntialPCRbyMonthForLab(labCode, dateFrom, dateTo, user_id, role);
        }

        public IList GetEIDAllTestInfant2MbyYear(int province)//, DateTime datefrom, DateTime dateto)
        {
            EIDDashboardDao re = new EIDDashboardDao();
            return re.GetEIDAllTestInfant2MbyYear(province);
        }
        //Added by ZaySoe on 09_Jan_2019
        public IList GetEIDIntialPCRAgeByYearly(int province, int user_id, string role)//, DateTime datefrom, DateTime dateto)
        {
            EIDDashboardDao re = new EIDDashboardDao();
            return re.GetEIDIntialPCRAgeByYearly(province, user_id, role);
        }

        public IList GetEIDIntialPCRAgeByYearForLab(string labCode, int dateFrom, int dateTo, int user_id, string role)//, DateTime datefrom, DateTime dateto)
        {
            EIDDashboardDao re = new EIDDashboardDao();
            return re.GetEIDIntialPCRAgeByYearForLab(labCode, dateFrom, dateTo, user_id, role);
        }

        public IList GetEIDIntialPCRAgeByQuarterly(int province, int dateFrom, int dateTo, int user_id, string role)//, DateTime datefrom, DateTime dateto)
        {
            EIDDashboardDao re = new EIDDashboardDao();
            return re.GetEIDIntialPCRAgeByQuarterly(province, dateFrom, dateTo, user_id, role);
        }

        public IList GetEIDIntialPCRAgeByQuarterForLab(string labCode, int dateFrom, int dateTo, int user_id, string role)//, DateTime datefrom, DateTime dateto)
        {
            EIDDashboardDao re = new EIDDashboardDao();
            return re.GetEIDIntialPCRAgeByQuarterForLab(labCode, dateFrom, dateTo, user_id, role);
        }

        public IList GetEIDIntialPCRAgeByMonthly(int province, int dateFrom, int dateTo, int user_id, string role)//, DateTime datefrom, DateTime dateto)
        {
            EIDDashboardDao re = new EIDDashboardDao();
            return re.GetEIDIntialPCRAgeByMonthly(province, dateFrom, dateTo, user_id, role);
        }
        
        public IList GetEIDIntialPCRAgeByMonthForLab(string labCode, int dateFrom, int dateTo, int user_id, string role)//, DateTime datefrom, DateTime dateto)
        {
            EIDDashboardDao re = new EIDDashboardDao();
            return re.GetEIDIntialPCRAgeByMonthForLab(labCode, dateFrom, dateTo, user_id, role);
        }

        public IList GetEIDPCRbyFacility(int province, int dateFrom, int dateTo, int user_id, string role)//, DateTime datefrom, DateTime dateto)
        {
            EIDDashboardDao re = new EIDDashboardDao();
            return re.GetEIDPCRbyFacility(province, dateFrom, dateTo, user_id, role);
        }

        public IList GetEIDPCRbyFacilityForLab(string labCode, int dateFrom, int dateTo, int user_id, string role)//, DateTime datefrom, DateTime dateto)
        {
            EIDDashboardDao re = new EIDDashboardDao();
            return re.GetEIDPCRbyFacilityForLab(labCode, dateFrom, dateTo, user_id, role);
        }

        public IList GetEIDLabByLabInstrument(int province, int dateFrom, int dateTo, int user_id, string role, int labInstruId)
        {
            EIDDashboardDao re = new EIDDashboardDao();
            return re.GetEIDLabByLabInstrument(province, dateFrom, dateTo, user_id, role, labInstruId);
        }

        public IList GetEIDLabByLabInstrumentForLab(string labCode, int dateFrom, int dateTo, int user_id, string role, int labInstruId)
        {
            EIDDashboardDao re = new EIDDashboardDao();
            return re.GetEIDLabByLabInstrumentForLab(labCode, dateFrom, dateTo, user_id, role, labInstruId);
        }

        public IList GetEIDLabByLabInstrumentComparison(int province, int dateFrom, int dateTo, int user_id, string role)
        {
            EIDDashboardDao re = new EIDDashboardDao();
            return re.GetEIDLabByLabInstrumentComparison(province, dateFrom, dateTo, user_id, role);
        }

        public IList GetEIDLabByLabInstrumentComparisonForLab(string labCode, int dateFrom, int dateTo, int user_id, string role)
        {
            EIDDashboardDao re = new EIDDashboardDao();
            return re.GetEIDLabByLabInstrumentComparisonForLab(labCode, dateFrom, dateTo, user_id, role);
        }

        public IList GetEIDTestByLab(int province, int dateFrom, int dateTo, int user_id, string role, int labInstruId)
        {
            EIDDashboardDao re = new EIDDashboardDao();
            return re.GetEIDTestByLab(province, dateFrom, dateTo, user_id, role, labInstruId);
        }

        public IList GetEIDTestByLab(string labCode, int dateFrom, int dateTo, int user_id, string role, int labInstruId)
        {
            EIDDashboardDao re = new EIDDashboardDao();
            return re.GetEIDTestByLab(labCode, dateFrom, dateTo, user_id, role, labInstruId);
        }

        public IList GetEIDTestAllInstrumentsByLab(int province, int dateFrom, int dateTo, int user_id, string role)
        {
            EIDDashboardDao re = new EIDDashboardDao();
            return re.GetEIDTestAllInstrumentsByLab(province, dateFrom, dateTo, user_id, role);
        }

        public IList GetEIDTestAllInstrumentsByLab(string labCode, int dateFrom, int dateTo, int user_id, string role)
        {
            EIDDashboardDao re = new EIDDashboardDao();
            return re.GetEIDTestAllInstrumentsByLab(labCode, dateFrom, dateTo, user_id, role);
        }        

        public IList GetEIDTestByStateRegionFacility(string labCode, int dateFrom, int dateTo, int user_id, string role)
        {
            EIDDashboardDao re = new EIDDashboardDao();
            return re.GetEIDTestByStateRegionFacility(labCode, dateFrom, dateTo, user_id, role);
        }

        public IList GetEIDRejectionbyYear(int province, int season)//, DateTime datefrom, DateTime dateto)
        {
            EIDDashboardDao re = new EIDDashboardDao();
            return re.GetEIDRejectionbyYear(province, season);
        }
        //public IList GetEIDTurnaroundbyYear(int province, int dateFrom, int dateTo, int user_id, string role)//, DateTime datefrom, DateTime dateto)
        //{
        //    EIDDashboardDao re = new EIDDashboardDao();
        //    return re.GetEIDTurnaroundbyYear(province, dateFrom, dateTo, user_id, role);
        //}

        public IList GetEIDTurnaroundbyYear(string labCode, int dateFrom, int dateTo, int user_id, string role)//, DateTime datefrom, DateTime dateto)
        {
            EIDDashboardDao re = new EIDDashboardDao();
            return re.GetEIDTurnaroundbyYear(labCode, dateFrom, dateTo, user_id, role);
        }

        //public IList GetEIDTurnaroundbyQuarter(int province, int dateFrom, int dateTo, int user_id, string role)//, DateTime datefrom, DateTime dateto)
        //{
        //    EIDDashboardDao re = new EIDDashboardDao();
        //    return re.GetEIDTurnaroundbyQuarter(province, dateFrom, dateTo, user_id, role);
        //}

        public IList GetEIDTurnaroundbyQuarter(string labCode, int dateFrom, int dateTo, int user_id, string role)//, DateTime datefrom, DateTime dateto)
        {
            EIDDashboardDao re = new EIDDashboardDao();
            return re.GetEIDTurnaroundbyQuarter(labCode, dateFrom, dateTo, user_id, role);
        }

        public IList GetEIDAllTestInfant2MbyYear(int province, int season)//, DateTime datefrom, DateTime dateto)
        {
            EIDDashboardDao re = new EIDDashboardDao();
            return re.GetEIDAllTestInfant2MbyYear(province, season);
        }

        public IList GetEIDPoitivityTrendbyYear(int province, int season)//, DateTime datefrom, DateTime dateto)
        {
            EIDDashboardDao re = new EIDDashboardDao();
            return re.GetEIDPoitivityTrendbyYear(province, season);
        }

        #region Lab Performance
        public IList GetLabEIDRejectionbyYear(string lab, DateTime datefrom, DateTime dateto)
        {
            EIDDashboardDao re = new EIDDashboardDao();
            return re.GetLabEIDRejectionbyYear(lab, datefrom, dateto);
        }
        public IList GetLabEIDPoitivityTrendbyYear(string lab, DateTime datefrom, DateTime dateto)
        {
            EIDDashboardDao re = new EIDDashboardDao();
            return re.GetLabEIDPoitivityTrendbyYear(lab, datefrom, dateto);
        }
        public IList GetLabEIDTestTrendbyYear(string lab, DateTime datefrom, DateTime dateto)
        {
            EIDDashboardDao re = new EIDDashboardDao();
            return re.GetLabEIDTestTrendbyYear(lab, datefrom, dateto);

        }
        public IList GetLabEIDValidOutcome(string lab, DateTime datefrom, DateTime dateto)
        {
            EIDDashboardDao re = new EIDDashboardDao();
            return re.GetLabEIDValidOutcome(lab, datefrom, dateto);
        }
        public IList GetLabRejectedSamplebyCountry(string lab, DateTime datefrom, DateTime dateto)
        {
            EIDDashboardDao re = new EIDDashboardDao();
            return re.GetLabRejectedSamplebyCountry(lab, datefrom, dateto);
        }
        public DataSet GetLabPerformance(string lab, DateTime datefrom, DateTime dateto)
        {
            EIDDashboardDao re = new EIDDashboardDao();
            return re.GetLabPerformance(lab, datefrom, dateto);
        }

        //public DataSet GetTurnaroundTime(int province, int dateFrom, int dateTo, int user_id, string role)
        //{
        //    EIDDashboardDao re = new EIDDashboardDao();
        //    return re.GetTurnaroundTime(province, dateFrom, dateTo, user_id, role);
        //}

        public IList GetEIDTestByGenderOutcome(int province, int dateFrom, int dateTo, int user_id, string role)
        {
            EIDDashboardDao re = new EIDDashboardDao();
            return re.GetEIDTestByGenderOutcome(province, dateFrom, dateTo, user_id, role);
        }

        public IList GetEIDFacilityTestByGenderOutcome(int facility, int dateFrom, int dateTo, int user_id, string role, string provinceIDs, string facilityTypes)
        {
            EIDDashboardDao re = new EIDDashboardDao();
            return re.GetEIDFacilityTestByGenderOutcome(facility, dateFrom, dateTo, user_id, role, provinceIDs, facilityTypes);
        }

        public IList GetEIDTestByGenderOutcomeForLab(string labCode, int dateFrom, int dateTo, int user_id, string role)
        {
            EIDDashboardDao re = new EIDDashboardDao();
            return re.GetEIDTestByGenderOutcomeForLab(labCode, dateFrom, dateTo, user_id, role);
        }

        public IList<Laboratory> GetLaboratories()
        {
            return WorkspaceFactory.CreateReadOnly().Query<Laboratory>(null).OrderBy(x => x.LaboratoryName).ToList();
        }

        #endregion

        #region CurrenrObject
        // public object CurrentObject
        //{
        //    get
        //    {
        //        return GetCurrentContext().Session["CurrentObject"];
        //    }
        //    set
        //    {
        //        GetCurrentContext().Session["CurrentObject"] = value;
        //    }
        //}
        #endregion

        public IList GetEIDFacility(string datefrom, string dateto)
        {
            EIDDashboardDao re = new EIDDashboardDao();
            return re.GetEIDFacility(datefrom, dateto);
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
            // _workspace.Refresh(item);
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

        #region EID Summary
        public EIDStat EIDSummaryStat(string dateFrom, string dateTo, int province, int user_id, string role)
        {
            EIDDashboardDao re = new EIDDashboardDao();
            return re.EIDSummaryStat(dateFrom, dateTo, province, user_id, role);
        }

        public EIDStat EIDSummaryStatForLab(string dateFrom, string dateTo, string labCode, int user_id, string role)
        {
            EIDDashboardDao re = new EIDDashboardDao();
            return re.EIDSummaryStatForLab(dateFrom, dateTo, labCode, user_id, role);
        }

        public IList GetEIDSummary(int province, int dateFrom, int dateTo, int user_id, string role)//, DateTime datefrom, DateTime dateto)
        {
            EIDDashboardDao re = new EIDDashboardDao();
            return re.GetEIDSummary(province, dateFrom, dateTo, user_id, role);
        }

        public IList GetEIDSummaryForLab(string labCode, int dateFrom, int dateTo, int user_id, string role)//, DateTime datefrom, DateTime dateto)
        {
            EIDDashboardDao re = new EIDDashboardDao();
            return re.GetEIDSummaryForLab(labCode, dateFrom, dateTo, user_id, role);
        }
        #endregion

        #region Facilities

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

        //Added by Zay Soe on 5_Mar_2019

        public IList GetEIDFacilityIntialPCRbyYear(int facility, int user_id, string role, string provinceIDs, string facilityTypes)
        {
            EIDDashboardDao re = new EIDDashboardDao();
            return re.GetEIDFacilityIntialPCRbyYear(facility, user_id, role, provinceIDs, facilityTypes);
        }

        public IList GetEIDFacilityIntialPCRbyMonth(int facility, int dateFrom, int dateTo, int user_id, string role, string provinceIDs, string facilityTypes)
        {
            EIDDashboardDao re = new EIDDashboardDao();
            return re.GetEIDFacilityIntialPCRbyMonth(facility, dateFrom, dateTo, user_id, role, provinceIDs, facilityTypes);
        }

        public IList GetEIDFacilityAllTestbyYear(int facility, int dateFrom, int dateTo, int user_id, string role, string provinceIDs, string facilityTypes)
        {
            EIDDashboardDao re = new EIDDashboardDao();
            return re.GetEIDFacilityAllTestbyYear(facility, dateFrom, dateTo, user_id, role, provinceIDs, facilityTypes);
        }

        public IList GetEIDFacilityIntialPCRAgeByYearly(int facility, int user_id, string role, string provinceIDs, string facilityTypes)
        {
            EIDDashboardDao re = new EIDDashboardDao();
            return re.GetEIDFacilityIntialPCRAgeByYearly(facility, user_id, role, provinceIDs, facilityTypes);
        }
        public IList GetEIDFacilityIntialPCRAgeByQuarterly(int facility, int dateFrom, int dateTo, int user_id, string role, string provinceIDs, string facilityTypes)
        {
            EIDDashboardDao re = new EIDDashboardDao();
            return re.GetEIDFacilityIntialPCRAgeByQuarterly(facility, dateFrom, dateTo, user_id, role, provinceIDs, facilityTypes);
        }
        public IList GetEIDFacilityIntialPCRAgeByMonthly(int facility, int dateFrom, int dateTo, int user_id, string role, string provinceIDs, string facilityTypes)
        {
            EIDDashboardDao re = new EIDDashboardDao();
            return re.GetEIDFacilityIntialPCRAgeByMonthly(facility, dateFrom, dateTo, user_id, role, provinceIDs, facilityTypes);
        }

        public IList GetEIDFacilityPCR(int facility, int dateFrom, int dateTo, int user_id, string role, string provinceIDs, string facilityTypes)
        {
            EIDDashboardDao re = new EIDDashboardDao();
            return re.GetEIDFacilityPCR(facility, dateFrom, dateTo, user_id, role, provinceIDs, facilityTypes);
        }

        public EIDStat EIDFacilitySummaryStat(string dateFrom, string dateTo, int facility, int user_id, string role, string provinceIDs, string facilityTypes)
        {
            EIDDashboardDao re = new EIDDashboardDao();
            return re.EIDFacilitySummaryStat(dateFrom, dateTo, facility, user_id, role, provinceIDs, facilityTypes);
        }
        public IList GetEIDFacilitySummary(int facility, int dateFrom, int dateTo, int user_id, string role, string provinceIDs, string facilityTypes)
        {
            EIDDashboardDao re = new EIDDashboardDao();
            return re.GetEIDFacilitySummary(facility, dateFrom, dateTo, user_id, role, provinceIDs, facilityTypes);
        }

        public IList GetEIDTestRejectByProvince(int province, int dateFrom, int dateTo, int user_id, string role)
        {
            EIDDashboardDao re = new EIDDashboardDao();
            return re.GetEIDTestRejectByProvince(province, dateFrom, dateTo, user_id, role);
        }              

        public IList GetEIDTestRejectByProvinceForLab(string labCode, int dateFrom, int dateTo, int user_id, string role)
        {
            EIDDashboardDao re = new EIDDashboardDao();
            return re.GetEIDTestRejectByProvinceForLab(labCode, dateFrom, dateTo, user_id, role);
        }

        public IList GetEIDTestRejectByProvinceForFacility(int facility, int dateFrom, int dateTo, int user_id, string role, string provinceIDs, string facilityTypes)//, DateTime datefrom, DateTime dateto)
        {
            EIDDashboardDao re = new EIDDashboardDao();
            return re.GetEIDTestRejectByProvinceForFacility(facility, dateFrom, dateTo, user_id, role, provinceIDs, facilityTypes);
        }

        public IList GetEIDTestByAgeOutcome(int province, int dateFrom, int dateTo, int user_id, string role)
        {
            EIDDashboardDao re = new EIDDashboardDao();
            return re.GetEIDTestByAgeOutcome(province, dateFrom, dateTo, user_id, role);
        }

        public IList GetEIDTestByAgeOutcomeForLab(string labCode, int dateFrom, int dateTo, int user_id, string role)
        {
            EIDDashboardDao re = new EIDDashboardDao();
            return re.GetEIDTestByAgeOutcomeForLab(labCode, dateFrom, dateTo, user_id, role);
        }

        public IList GetEIDTestByAgeOutcomeForFacility(int facility, int dateFrom, int dateTo, int user_id, string role, string provinceIDs, string facilityTypes)
        {
            EIDDashboardDao re = new EIDDashboardDao();
            return re.GetEIDTestByAgeOutcomeForFacility(facility, dateFrom, dateTo, user_id, role, provinceIDs, facilityTypes);
        }

        public IList GetEIDTestLabAndFacility(int facility, int dateFrom, int dateTo, int user_id, string role, string provinceIDs, string facilityTypes)
        {
            EIDDashboardDao re = new EIDDashboardDao();
            return re.GetEIDTestLabAndFacility(facility, dateFrom, dateTo, user_id, role, provinceIDs, facilityTypes);
        }

        #endregion
    }
}
