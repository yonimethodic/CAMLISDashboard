using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.CompositeWeb;
using CHAI.LISDashboard.CoreDomain.Setting;
using System.Data;
using System.Collections;
using CHAI.LISDashboard.CoreDomain.Report;

namespace CHAI.LISDashboard.Modules.VLDashboard.Views
{
    public class FrmFacilityPresenter : Presenter<IFrmFacilityView>
    {

        // NOTE: Uncomment the following code if you want ObjectBuilder to inject the module controller
        //       The code will not work in the Shell module, as a module controller is not created by default
        //
        private CHAI.LISDashboard.Modules.VLDashboard.VLDashbaordController _controller;
        public FrmFacilityPresenter([CreateNew] CHAI.LISDashboard.Modules.VLDashboard.VLDashbaordController controller)
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
        public IList<Province> GetProvinces()
        {
            return _controller.GetProvinces();
        }
        public IList<Facility> GetFacilities()
        {
            return _controller.GetFacilities();
        }

        public IList<LabInstrument> GetLabInstruments()
        {
            return _controller.GetLabInstruments();
        }
        public IList<FacilityType> GetFacilityTypeByFacilityType2(string value)
        {
            return _controller.GetFacilityTypeByFacilityType2(value);
        }

        public IList GetVLoutcome(int province, string datefrom, string dateto)
        {
            return _controller.GetVLOutcome(province, datefrom, dateto);
        }
        public IList GetVLTestingTrendOutcome(int province, int isQuarter)
        {
            return _controller.GetVLTestingTrendOutcome(province, isQuarter);
        }
        public IList GetVLTestbyAgeTrends(int province)
        {
            return _controller.GetVLTestbyAgeTrends(province);
        }
        public IList GetVLSuppressionTrends(int province, int isQuarter)
        {
            return _controller.GetVLSuppressionTrends(province, isQuarter);
        }
        public IList GetVLValidTestingTrends(int province, int isQuarter)
        {
            return _controller.GetVLValidTestingTrends(province, isQuarter);
        }
        public IList GetVLRejectedTrends(int province, int isQuarter)
        {
            return _controller.GetVLRejectedTrends(province, isQuarter);
        }

        public IList GetVLTestYearly(int province, int user_id, string type)
        {
            return _controller.GetVLTestYearly(province, user_id, type);
        }

        public IList GetVLTestQuarterly(int province, int datefrom, int dateto, int user_id, string type)
        {
            return _controller.GetVLTestQuarterly(province, datefrom, dateto, user_id, type);
        }

        public IList GetVLTestMonthly(int province, int datefrom, int dateto, int user_id, string type)
        {
            return _controller.GetVLTestMonthly(province, datefrom, dateto, user_id, type);
        }

        public IList GetVLTestByAgeYearly(int province, int dateFrom, int dateTo, int user_id, string type)
        {
            return _controller.GetVLTestByAgeYearly(province, dateFrom, dateTo, user_id, type);
        }

        public IList GetVLTestByGenderOutcome(int province, int dateFrom, int dateTo, int user_id, string type)
        {
            return _controller.GetVLTestByGenderOutcome(province, dateFrom, dateTo, user_id, type);
        }

        public IList GetVLTestByProvince(int province, int dateFrom, int dateTo, int user_id, string type)
        {
            return _controller.GetVLTestByProvince(province, dateFrom, dateTo, user_id, type);
        }        

        public IList GetVLLabByLabInstrument(int dateFrom, int dateTo, int user_id, string type, int labInstruId)
        {
            return _controller.GetVLLabByLabInstrument(dateFrom, dateTo, user_id, type, labInstruId);
        }

        //public IList GetVLLabByLabInstrumentComparison(int dateFrom, int dateTo, int user_id, string type)
        //{
        //    return _controller.GetVLLabByLabInstrumentComparison(dateFrom, dateTo, user_id, type);
        //}

        public IList GetVLTurnAroundTime(int province, int dateFrom, int dateTo, int user_id, string role)
        {
            return _controller.GetVLTurnAroundTime(province, dateFrom, dateTo, user_id, role);
        }

        //public IList GetVLTestByLab(int province, int dateFrom, int dateTo, int user_id, string role, int labInstruId)
        //{
        //    return _controller.GetVLTestByLab(province, dateFrom, dateTo, user_id, role, labInstruId);
        //}

        //public IList GetVLTestByAgeQuarterly(int province, int datefrom, int dateto, int user_id, string type)
        //{
        //    return _controller.GetVLTestByAgeQuarterly(province, datefrom, dateto, user_id, type);
        //}

        //public IList GetVLTestByAgeMonthly(int province, int datefrom, int dateto, int user_id, string type)
        //{
        //    return _controller.GetVLTestByAgeMonthly(province, datefrom, dateto, user_id, type);
        //}
        public IList GetVLSummary(int province, int dateFrom, int dateTo, int user_id, string role)//, DateTime datefrom, DateTime dateto)
        {
            return _controller.GetVLSummary(province, dateFrom, dateTo, user_id, role);//, datefrom, dateto);
        }
        public VLStat VLSummaryStat(string datefrom, string dateto, int province, int user_id, string type)
        {
            return _controller.VLSummaryStat(datefrom, dateto, province, user_id, type);
        }

        #region Facilities

        public IList GetVLFacilityTestYearly(int facility, int user_id, string type, string provinceIDs, string facilityTypes)
        {
            return _controller.GetVLFacilityTestYearly(facility, user_id, type, provinceIDs, facilityTypes);
        }

        public IList GetVLFacilityTestQuarterly(int facility, int datefrom, int dateto, int user_id, string type, string provinceIDs, string facilityTypes)
        {
            return _controller.GetVLFacilityTestQuarterly(facility, datefrom, dateto, user_id, type, provinceIDs, facilityTypes);
        }

        public IList GetVLFacilityTestMonthly(int facility, int datefrom, int dateto, int user_id, string type, string provinceIDs, string facilityTypes)
        {
            return _controller.GetVLFacilityTestMonthly(facility, datefrom, dateto, user_id, type, provinceIDs, facilityTypes);
        }

        public IList GetVLFacilityTestByAgeYearly(int facility, int dateFrom, int dateTo, int user_id, string type, string provinceIDs, string facilityTypes)
        {
            return _controller.GetVLFacilityTestByAgeYearly(facility, dateFrom, dateTo, user_id, type, provinceIDs, facilityTypes);
        }

        public IList GetVLFacilityTestByGenderOutcome(int facility, int dateFrom, int dateTo, int user_id, string type, string provinceIDs, string facilityTypes)
        {
            return _controller.GetVLFacilityTestByGenderOutcome(facility, dateFrom, dateTo, user_id, type, provinceIDs, facilityTypes);
        }

        public IList GetVLFacilityTestByProvince(int facility, int dateFrom, int dateTo, int user_id, string type, string provinceIDs, string facilityTypes)
        {
            return _controller.GetVLFacilityTestByProvince(facility, dateFrom, dateTo, user_id, type, provinceIDs, facilityTypes);
        }

        public IList GetVLTestAgeGroupByProvince(int facility, int dateFrom, int dateTo, int user_id, string type, string provinceIDs, string facilityTypes)
        {
            return _controller.GetVLTestAgeGroupByProvinceForFacility(facility, dateFrom, dateTo, user_id, type, provinceIDs, facilityTypes);
        }

        public IList GetVLFacilitySummary(int facility, int dateFrom, int dateTo, int user_id, string role, string provinceIDs, string facilityTypes)//, DateTime datefrom, DateTime dateto)
        {
            return _controller.GetVLFacilitySummary(facility, dateFrom, dateTo, user_id, role, provinceIDs, facilityTypes);//, datefrom, dateto);
        }
        public VLStat VLFacilitySummaryStat(string datefrom, string dateto, int facility, int user_id, string type, string provinceIDs, string facilityTypes)
        {
            return _controller.VLFacilitySummaryStat(datefrom, dateto, facility, user_id, type, provinceIDs, facilityTypes);
        }

        public IList GetVLTestRejectByProvinceForFacility(int facility, int datefrom, int dateto, int user_id, string type, string provinceIDs, string facilityTypes)
        {
            return _controller.GetVLTestRejectByProvinceForFacility(facility, datefrom, dateto, user_id, type, provinceIDs, facilityTypes);
        }

        public IList GetVLTestLabAndFacility(int facility, int datefrom, int dateto, int user_id, string type, string provinceIDs, string facilityTypes)
        {
            return _controller.GetVLTestLabAndFacility(facility, datefrom, dateto, user_id, type, provinceIDs, facilityTypes);
        }

        #endregion
    }
}




