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
using System.Collections;

using CHAI.LISDashboard.CoreDomain.Report;

namespace CHAI.LISDashboard.Modules.VLDashboard
{
    public class VLDashbaordController : ControllerBase
    {
        private IWorkspace _workspace;

        [InjectionConstructor]
        public VLDashbaordController([ServiceDependency] IHttpContextLocatorService httpContextLocatorService, [ServiceDependency]INavigationService navigationService)
            : base(httpContextLocatorService, navigationService)
        {
            _workspace = ZadsServices.Workspace;
        }
        #region UserLocations
        public IList<UserLocation> GetUserLocations(int userId)
        {
            return WorkspaceFactory.CreateReadOnly().Query<UserLocation>( x => x.User.Id == userId).ToList();
        }
        #endregion

        #region Province
        public IList<Province> GetProvinces()
        {
            return WorkspaceFactory.CreateReadOnly().Query<Province>(null).OrderBy(x => x.ProvinceName).ToList();
        }

        public IList<Facility> GetFacilities()
        {
            return WorkspaceFactory.CreateReadOnly().Query<Facility>(null).OrderBy(x => x.FacilityName).ToList();
        }

        public Province GetProvince(int ProvinceId)
        {
            return _workspace.Single<Province>(x => x.Id == ProvinceId);
        }
        #endregion
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


        public IList<LabInstrument> GetLabInstruments()
        {
            return WorkspaceFactory.CreateReadOnly().Query<LabInstrument>(null).OrderBy(x => x.LabInstrumentname).ToList();
        }

        //public DataSet GetLabInfo(int userId)
        //{
        //    EIDDashboardDao re = new EIDDashboardDao();
        //    return re.GetLabInfo(userId);
        //}

        #region Labratory
        public Laboratory GetLaboratory(int Id)
        {
            return _workspace.Single<Laboratory>(x => x.Id == Id);
        }
        public IList<Laboratory> GetLabratories()
        {
            return WorkspaceFactory.CreateReadOnly().Query<Laboratory>(null).OrderBy(x => x.LaboratoryName).ToList();
        }
        #endregion
        #region VL Summary

        public IList GetVLTestYearly(int province, int user_id, string role)
        {
            VLDashboardDao re = new VLDashboardDao();
            return re.GetVLTestYearly(province, user_id, role);
        }

        public IList GetVLTestYearlyByLab(string labCode, int datefrom, int dateto, int user_id, string role)
        {
            VLDashboardDao re = new VLDashboardDao();
            return re.GetVLTestYearlyByLab(labCode, datefrom, dateto, user_id, role);
        }

        public IList GetVLTestQuarterly(int province, int datefrom, int dateto, int user_id, string role)
        {
            VLDashboardDao re = new VLDashboardDao();
            return re.GetVLTestQuarterly(province, datefrom, dateto, user_id, role);
        }

        public IList GetVLTestQuarterlyByLab(string labCode, int datefrom, int dateto, int user_id, string role)
        {
            VLDashboardDao re = new VLDashboardDao();
            return re.GetVLTestQuarterlyByLab(labCode, datefrom, dateto, user_id, role);
        }

        public IList GetVLTestMonthly(int province, int datefrom, int dateto, int user_id, string role)
        {
            VLDashboardDao re = new VLDashboardDao();
            return re.GetVLTestMonthly(province, datefrom, dateto, user_id, role);
        }

        public IList GetVLTestMonthlyByLab(string labCode, int datefrom, int dateto, int user_id, string role)
        {
            VLDashboardDao re = new VLDashboardDao();
            return re.GetVLTestMonthlyByLab(labCode, datefrom, dateto, user_id, role);
        }

        public IList GetVLTestByAgeYearly(int province, int dateFrom, int dateTo, int user_id, string role)
        {
            VLDashboardDao re = new VLDashboardDao();
            return re.GetVLTestByAgeYearly(province, dateFrom, dateTo, user_id, role);
        }

        public IList GetVLTestByAgeYearlyForLab(string labCode, int dateFrom, int dateTo, int user_id, string role)
        {
            VLDashboardDao re = new VLDashboardDao();
            return re.GetVLTestByAgeYearlyForLab(labCode, dateFrom, dateTo, user_id, role);
        }

        public IList GetVLTestByGenderOutcome(int province, int dateFrom, int dateTo, int user_id, string role)
        {
            VLDashboardDao re = new VLDashboardDao();
            return re.GetVLTestByGenderOutcome(province, dateFrom, dateTo, user_id, role);
        }

        public IList GetVLTestByGenderOutcomeForLab(string labCode, int dateFrom, int dateTo, int user_id, string role)
        {
            VLDashboardDao re = new VLDashboardDao();
            return re.GetVLTestByGenderOutcomeForLab(labCode, dateFrom, dateTo, user_id, role);
        }

        public IList GetVLTestByProvince(int province, int dateFrom, int dateTo, int user_id, string role)
        {
            VLDashboardDao re = new VLDashboardDao();
            return re.GetVLTestByProvince(province, dateFrom, dateTo, user_id, role);
        }

        public IList GetVLTestAgeGroupByProvince(int province, int dateFrom, int dateTo, int user_id, string role)
        {
            VLDashboardDao re = new VLDashboardDao();
            return re.GetVLTestAgeGroupByProvince(province, dateFrom, dateTo, user_id, role);
        }

        public IList GetVLTestByProvinceForLab(string labCode, int dateFrom, int dateTo, int user_id, string role)
        {
            VLDashboardDao re = new VLDashboardDao();
            return re.GetVLTestByProvinceForLab(labCode, dateFrom, dateTo, user_id, role);
        }

        public IList GetVLTestAgeGroupByProvinceForLab(string labCode, int dateFrom, int dateTo, int user_id, string role)
        {
            VLDashboardDao re = new VLDashboardDao();
            return re.GetVLTestAgeGroupByProvinceForLab(labCode, dateFrom, dateTo, user_id, role);
        }

        public IList GetVLTestByStateRegionFacility(string labCode, int dateFrom, int dateTo, int user_id, string role)
        {
            VLDashboardDao re = new VLDashboardDao();
            return re.GetVLTestByStateRegionFacility(labCode, dateFrom, dateTo, user_id, role);
        }

        public IList GetVLTestByLab(int province, int dateFrom, int dateTo, int user_id, string role, int labInstruId)
        {
            VLDashboardDao re = new VLDashboardDao();
            return re.GetVLTestByLab(province, dateFrom, dateTo, user_id, role, labInstruId);
        }

        public IList GetVLTestByLab(string labCode, int dateFrom, int dateTo, int user_id, string role, int labInstruId)
        {
            VLDashboardDao re = new VLDashboardDao();
            return re.GetVLTestByLab(labCode, dateFrom, dateTo, user_id, role, labInstruId);
        }

        public IList GetVLTestAllInstrumentsByLab(int province, int dateFrom, int dateTo, int user_id, string role)
        {
            VLDashboardDao re = new VLDashboardDao();
            return re.GetVLTestAllInstrumentsByLab(province, dateFrom, dateTo, user_id, role);
        }

        public IList GetVLTestAllInstrumentsByLab(string labCode, int dateFrom, int dateTo, int user_id, string role)
        {
            VLDashboardDao re = new VLDashboardDao();
            return re.GetVLTestAllInstrumentsByLab(labCode, dateFrom, dateTo, user_id, role);
        }

        public IList GetVLTurnAroundTime(int province, int dateFrom, int dateTo, int user_id, string role)
        {
            VLDashboardDao re = new VLDashboardDao();
            return re.GetVLTurnAroundTime(province, dateFrom, dateTo, user_id, role);
        }

        //public IList GetVLTestByAgeQuarterly(int province, int datefrom, int dateto, int user_id, string role)
        //{
        //    VLDashboardDao re = new VLDashboardDao();
        //    return re.GetVLTestByAgeQuarterly(province, datefrom, dateto, user_id, role);
        //}

        //public IList GetVLTestByAgeMonthly(int province, int datefrom, int dateto, int user_id, string role)
        //{
        //    VLDashboardDao re = new VLDashboardDao();
        //    return re.GetVLTestByAgeMonthly(province, datefrom, dateto, user_id, role);
        //}

        public VLStat VLSummaryStat(string datefrom, string dateto, int province, int user_id, string role)
        {
            VLDashboardDao re = new VLDashboardDao();
            return re.VLSummaryStat(datefrom, dateto, province, user_id, role);
        }

        public VLStat VLSummaryStat(string datefrom, string dateto, string labCode, int user_id, string role)
        {
            VLDashboardDao re = new VLDashboardDao();
            return re.VLSummaryStat(datefrom, dateto, labCode, user_id, role);
        }

        public IList GetVLSummary(int province, int dateFrom, int dateTo, int user_id, string role)
        {
            VLDashboardDao re = new VLDashboardDao();
            return re.GetVLSummary(province, dateFrom, dateTo, user_id, role);
        }
        public IList GetVLSummary(string labCode, int dateFrom, int dateTo, int user_id, string role)
        {
            VLDashboardDao re = new VLDashboardDao();
            return re.GetVLSummary(labCode, dateFrom, dateTo, user_id, role);
        }
        public IList GetTestTrends(int province, int testreason, string datefrom, string dateto)
        {
            VLDashboardDao re = new VLDashboardDao();
            return re.GetTestTrends(province,  testreason,datefrom, dateto);
        }
        public IList GetVLOutcome(int province, string datefrom, string dateto)
        {
            VLDashboardDao re = new VLDashboardDao();
            return re.GetVLOutcome(province, datefrom, dateto);
        }
        public IList GetVLTestbyGender(int province, string datefrom, string dateto)
        {
            VLDashboardDao re = new VLDashboardDao();
            return re.GetVLTestbyGender(province, datefrom, dateto);
        }
        public IList GetVLTestbyAge(int province, string datefrom, string dateto)
        {
            VLDashboardDao re = new VLDashboardDao();
            return re.GetVLTestbyAge(province, datefrom, dateto);
        }
        public IList GetVLreasonforTest(int province, string datefrom, string dateto)
        {
            VLDashboardDao re = new VLDashboardDao();
            return re.GetVLreasonforTest(province, datefrom, dateto);
        }
        public IList GetVLOutcomebyProvince(int province, string datefrom, string dateto)
        {
            VLDashboardDao re = new VLDashboardDao();
            return re.GetVLOutcomebyProvince(province, datefrom, dateto);
        }

        public IList GetVLTurnaroundbyYear(string labCode, int dateFrom, int dateTo, int user_id, string role)//, DateTime datefrom, DateTime dateto)
        {
            VLDashboardDao re = new VLDashboardDao();
            return re.GetVLTurnaroundbyYear(labCode, dateFrom, dateTo, user_id, role);
        }

        public IList GetVLTurnaroundbyQuarter(string labCode, int dateFrom, int dateTo, int user_id, string role)//, DateTime datefrom, DateTime dateto)
        {
            VLDashboardDao re = new VLDashboardDao();
            return re.GetVLTurnaroundbyQuarter(labCode, dateFrom, dateTo, user_id, role);
        }

        #endregion
        #region Testing Trends
        public IList GetVLTestingTrendOutcome(int province, int isQuarter)
        {
            VLDashboardDao re = new VLDashboardDao();
            return re.GetVLTestingTrendOutcome(province, isQuarter);
        }
        public IList GetVLTestbyAgeTrends(int province)
        {
            VLDashboardDao re = new VLDashboardDao();
            return re.GetVLTestbyAgeTrends(province);
        }
        public IList GetVLSuppressionTrends(int province,int isQuarter)
        {
            VLDashboardDao re = new VLDashboardDao();
            return re.GetVLSuppressionTrends(province, isQuarter);
        }
        public IList GetVLValidTestingTrends(int province, int isQuarter)
        {
            VLDashboardDao re = new VLDashboardDao();
            return re.GetVLValidTestingTrends(province, isQuarter);
        }
        public IList GetVLRejectedTrends(int province, int isQuarter)
        {
            VLDashboardDao re = new VLDashboardDao();
            return re.GetVLRejectedTrends(province, isQuarter);
        }
        #endregion
        #region LabPerformance
        public DataSet VLLabPerStatSummary(string datefrom, string dateto,string LabName, string labCode)
        {
            VLDashboardDao re = new VLDashboardDao();
            return re.VLLabPerStatSummary(datefrom, dateto, LabName, labCode);
        }
        public IList GetVLLABTestingTrends(string datefrom, string dateto)
        {
            VLDashboardDao re = new VLDashboardDao();
            return re.GetVLLABTestingTrends(datefrom, dateto);
        }
        public IList GetVLLABRejectionTrends(string datefrom, string dateto)
        {
            VLDashboardDao re = new VLDashboardDao();
            return re.GetVLLABRejectionTrends(datefrom, dateto);
        }

        public IList GetVLLABTestbySampleType(string datefrom, string dateto)
        {
            VLDashboardDao re = new VLDashboardDao();
            return re.GetVLLABTestbySampleType(datefrom, dateto);
        }
        public IList GetVLLABTestbyGender(string datefrom, string dateto)
        {
            VLDashboardDao re = new VLDashboardDao();
            return re.GetVLLABTestbyGender(datefrom, dateto);
        }
        public IList GetVLLABTestbyAge(string datefrom, string dateto)
        {
            VLDashboardDao re = new VLDashboardDao();
            return re.GetVLLABTestbyAge(datefrom, dateto);
        }
        public IList GetVLLABOutcome(string datefrom, string dateto)
        {
            VLDashboardDao re = new VLDashboardDao();
            return re.GetVLLABOutcome(datefrom, dateto);
        }
        public IList GetVLLABRejectionReasonNational(string datefrom, string dateto)
        {
            VLDashboardDao re = new VLDashboardDao();
            return re.GetVLLABRejectionReasonNational(datefrom, dateto);
        }
        public IList GetVLLABOutcomeTrends(string datefrom, string dateto,string LabCode)
        {
            VLDashboardDao re = new VLDashboardDao();
            return re.GetVLLABOutcomeTrends(datefrom, dateto, LabCode);
        }
        public IList GetVLLabperformanceSuppressionTrends(string LabCode)
        {
            VLDashboardDao re = new VLDashboardDao();
            return re.GetVLLabperformanceSuppressionTrends(LabCode);
        }
        public IList GetVLLabValidTestingTrends( string LabCode)
        {
            VLDashboardDao re = new VLDashboardDao();
            return re.GetVLLabValidTestingTrends(LabCode);
        }
        public IList GetVLLabPerfomaceRejectedTrends(string LabCode)
        {
            VLDashboardDao re = new VLDashboardDao();
            return re.GetVLLabPerfomaceRejectedTrends( LabCode);
        }
        public IList GetVLLABRejectionReasonbyLab(string datefrom, string dateto, string LabCode)
        {
            VLDashboardDao re = new VLDashboardDao();
            return re.GetVLLABRejectionReasonbyLab(datefrom, dateto, LabCode);
        }

        public IList GetVLLabByLabInstrument(int dateFrom, int dateTo, int user_id, string role, int labInstruId)
        {
            VLDashboardDao re = new VLDashboardDao();
            return re.GetVLLabByLabInstrument(dateFrom, dateTo, user_id, role, labInstruId);
        }

        public IList GetVLLabByLabInstrument(string labCode, int dateFrom, int dateTo, int user_id, string role, int labInstruId)
        {
            VLDashboardDao re = new VLDashboardDao();
            return re.GetVLLabByLabInstrument(labCode, dateFrom, dateTo, user_id, role, labInstruId);
        }

        public IList GetVLLabByLabInstrumentComparison(int dateFrom, int dateTo, int user_id, string role)
        {
            VLDashboardDao re = new VLDashboardDao();
            return re.GetVLLabByLabInstrumentComparison(dateFrom, dateTo, user_id, role);
        }

        public IList GetVLLabByLabInstrumentComparisonForLab(string labCode, int dateFrom, int dateTo, int user_id, string role)
        {
            VLDashboardDao re = new VLDashboardDao();
            return re.GetVLLabByLabInstrumentComparisonForLab(labCode, dateFrom, dateTo, user_id, role);
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

        #region Facilities

        public IList GetVLFacilityTestYearly(int facility, int user_id, string role, string provinceIDs, string facilityTypes)
        {
            VLDashboardDao re = new VLDashboardDao();
            return re.GetVLFacilityTestYearly(facility, user_id, role, provinceIDs, facilityTypes);
        }

        public IList GetVLFacilityTestQuarterly(int facility, int datefrom, int dateto, int user_id, string role, string provinceIDs, string facilityTypes)
        {
            VLDashboardDao re = new VLDashboardDao();
            return re.GetVLFacilityTestQuarterly(facility, datefrom, dateto, user_id, role, provinceIDs, facilityTypes);
        }

        public IList GetVLFacilityTestMonthly(int facility, int datefrom, int dateto, int user_id, string role, string provinceIDs, string facilityTypes)
        {
            VLDashboardDao re = new VLDashboardDao();
            return re.GetVLFacilityTestMonthly(facility, datefrom, dateto, user_id, role, provinceIDs, facilityTypes);
        }

        public IList GetVLFacilityTestByAgeYearly(int facility, int dateFrom, int dateTo, int user_id, string role, string provinceIDs, string facilityTypes)
        {
            VLDashboardDao re = new VLDashboardDao();
            return re.GetVLFacilityTestByAgeYearly(facility, dateFrom, dateTo, user_id, role, provinceIDs, facilityTypes);
        }

        public IList GetVLFacilityTestByGenderOutcome(int facility, int dateFrom, int dateTo, int user_id, string role, string provinceIDs, string facilityTypes)
        {
            VLDashboardDao re = new VLDashboardDao();
            return re.GetVLFacilityTestByGenderOutcome(facility, dateFrom, dateTo, user_id, role, provinceIDs, facilityTypes);
        }

        public IList GetVLFacilityTestByProvince(int facility, int dateFrom, int dateTo, int user_id, string role, string provinceIDs, string facilityTypes)
        {
            VLDashboardDao re = new VLDashboardDao();
            return re.GetVLFacilityTestByProvince(facility, dateFrom, dateTo, user_id, role, provinceIDs, facilityTypes);
        }

        public IList GetVLTestAgeGroupByProvinceForFacility(int facility, int dateFrom, int dateTo, int user_id, string role, string provinceIDs, string facilityTypes)
        {
            VLDashboardDao re = new VLDashboardDao();
            return re.GetVLTestAgeGroupByProvinceForFacility(facility, dateFrom, dateTo, user_id, role, provinceIDs, facilityTypes);
        }        

        public VLStat VLFacilitySummaryStat(string datefrom, string dateto, int facility, int user_id, string role, string provinceIDs, string facilityTypes)
        {
            VLDashboardDao re = new VLDashboardDao();
            return re.VLFacilitySummaryStat(datefrom, dateto, facility, user_id, role, provinceIDs, facilityTypes);
        }
        public IList GetVLFacilitySummary(int facility, int dateFrom, int dateTo, int user_id, string role, string provinceIDs, string facilityTypes)//, DateTime datefrom, DateTime dateto)
        {
            VLDashboardDao re = new VLDashboardDao();
            return re.GetVLFacilitySummary(facility, dateFrom, dateTo, user_id, role, provinceIDs, facilityTypes);
        }

        public IList GetVLTestRejectByProvince(int province, int dateFrom, int dateTo, int user_id, string role)
        {
            VLDashboardDao re = new VLDashboardDao();
            return re.GetVLTestRejectByProvince(province, dateFrom, dateTo, user_id, role);
        }

        public IList GetVLTestRejectByProvinceForLab(string labCode, int dateFrom, int dateTo, int user_id, string role)
        {
            VLDashboardDao re = new VLDashboardDao();
            return re.GetVLTestRejectByProvinceForLab(labCode, dateFrom, dateTo, user_id, role);
        }

        public IList GetVLTestRejectByProvinceForFacility(int facility, int dateFrom, int dateTo, int user_id, string role, string provinceIDs, string facilityTypes)//, DateTime datefrom, DateTime dateto)
        {
            VLDashboardDao re = new VLDashboardDao();
            return re.GetVLTestRejectByProvinceForFacility(facility, dateFrom, dateTo, user_id, role, provinceIDs, facilityTypes);
        }

        public IList GetVLTestLabAndFacility(int facility, int dateFrom, int dateTo, int user_id, string role, string provinceIDs, string facilityTypes)//, DateTime datefrom, DateTime dateto)
        {
            VLDashboardDao re = new VLDashboardDao();
            return re.GetVLTestLabAndFacility(facility, dateFrom, dateTo, user_id, role, provinceIDs, facilityTypes);
        }

        #endregion
    }
}
