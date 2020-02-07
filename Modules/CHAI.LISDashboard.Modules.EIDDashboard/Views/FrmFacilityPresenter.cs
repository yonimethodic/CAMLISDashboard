using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.CompositeWeb;
using System.Collections;
using CHAI.LISDashboard.CoreDomain.Setting;
using CHAI.LISDashboard.CoreDomain.Report;
using System.Data;

namespace CHAI.LISDashboard.Modules.EIDDashboard.Views
{
    public class FrmFacilityPresenter : Presenter<IFrmFacilityView>
    {

        // NOTE: Uncomment the following code if you want ObjectBuilder to inject the module controller
        //       The code will not work in the Shell module, as a module controller is not created by default
        //
        private CHAI.LISDashboard.Modules.EIDDashboard.EIDDashboardController _controller;
        public FrmFacilityPresenter([CreateNew] CHAI.LISDashboard.Modules.EIDDashboard.EIDDashboardController controller)
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

        // TODO: Handle other view events and set state in the view
        public IList GetEIDOutcomesbyAge(int province, DateTime datefrom, DateTime dateto)
        {
            return _controller.GetEIDOutcomesbyAge(province, datefrom, dateto);
        }
        public IList GetEIDModeofDelivery(int province, DateTime datefrom, DateTime dateto)
        {
            return _controller.GetEIDModeofDelivery(province, datefrom, dateto);
        }
        public IList GetInfantFeeding(int province, DateTime datefrom, DateTime dateto)
        {
            return _controller.GetInfantFeeding(province, datefrom, dateto);
        }
        public IList GetEIDIntialPCR(int province, DateTime datefrom, DateTime dateto)
        {
            return _controller.GetEIDIntialPCR(province, datefrom, dateto);
        }
        public IList GetEIDIntialPCRbyProvince(int province, DateTime datefrom, DateTime dateto)
        {
            return _controller.GetEIDIntialPCRbyProvince(province, datefrom, dateto);
        }
        public IList<Province> GetProvinces()
        {
            return _controller.GetProvinces();
        }

        public IList<Facility> GetFacilities()
        {
            return _controller.GetFacilities();
        }

        public IList<FacilityType> GetFacilityTypeByFacilityType2(string value)
        {
            return _controller.GetFacilityTypeByFacilityType2(value);
        }

        //Trend
        public IList GetEIDFacilityIntialPCRbyYear(int facility, int user_id, string role, string provinceIDs, string facilityTypes)
        {

            return _controller.GetEIDFacilityIntialPCRbyYear(facility, user_id, role, provinceIDs, facilityTypes);
        }
        public IList GetEIDFacilityAllTestbyYear(int facility, int dateFrom, int dateTo, int user_id, string role, string provinceIDs, string facilityTypes)
        {
            return _controller.GetEIDFacilityAllTestbyYear(facility, dateFrom, dateTo, user_id, role, provinceIDs, facilityTypes);//, datefrom, dateto);
        }

        //Added by Zay Soe on 9_Jan_2019
        public IList GetEIDFacilityIntialPCRbyMonth(int facility, int dateFrom, int dateTo, int user_id, string role, string provinceIDs, string facilityTypes)
        {
            return _controller.GetEIDFacilityIntialPCRbyMonth(facility, dateFrom, dateTo, user_id, role, provinceIDs, facilityTypes);
        }

        public IList GetEIDAllTestInfant2MbyYear(int province, string provinceIDs, string facilityTypes)
        {
            return _controller.GetEIDAllTestInfant2MbyYear(province);//, datefrom, dateto);
        }
        public IList GetEIDFacilityIntialPCRAgeByYearly(int facility, int user_id, string role, string provinceIDs, string facilityTypes)
        {
            return _controller.GetEIDFacilityIntialPCRAgeByYearly(facility, user_id, role, provinceIDs, facilityTypes);//, datefrom, dateto);
        }
        public IList GetEIDFacilityIntialPCRAgeByQuarterly(int facility, int dateFrom, int dateTo, int user_id, string role, string provinceIDs, string facilityTypes)
        {
            return _controller.GetEIDFacilityIntialPCRAgeByQuarterly(facility, dateFrom, dateTo, user_id, role, provinceIDs, facilityTypes);//, datefrom, dateto);
        }
        public IList GetEIDFacilityIntialPCRAgeByMonthly(int facility, int dateFrom, int dateTo, int user_id, string role, string provinceIDs, string facilityTypes)
        {
            return _controller.GetEIDFacilityIntialPCRAgeByMonthly(facility, dateFrom, dateTo, user_id, role, provinceIDs, facilityTypes);
        }

        public IList GetEIDFacilityTestByGenderOutcome(int facility, int dateFrom, int dateTo, int user_id, string role, string provinceIDs, string facilityTypes)
        {
            return _controller.GetEIDFacilityTestByGenderOutcome(facility, dateFrom, dateTo, user_id, role, provinceIDs, facilityTypes);
        }        
        public IList GetEIDTestRejectByProvinceForFacility(int facility, int dateFrom, int dateTo, int user_id, string role, string provinceIDs, string facilityTypes)
        {
            return _controller.GetEIDTestRejectByProvinceForFacility(facility, dateFrom, dateTo, user_id, role, provinceIDs, facilityTypes);
        }
        public IList GetEIDFacilityPCR(int facility, int dateFrom, int dateTo, int user_id, string role, string provinceIDs, string facilityTypes)
        {
            return _controller.GetEIDFacilityPCR(facility, dateFrom, dateTo, user_id, role, provinceIDs, facilityTypes);
        }        
        public IList GetEIDRejectionbyYear(int province, int season)//, DateTime datefrom, DateTime dateto)
        {
            return _controller.GetEIDRejectionbyYear(province, season);//, datefrom, dateto);
        }
        //public IList GetEIDTurnaroundbyYear(int province, int dateFrom, int dateTo, int user_id, string role)//, DateTime datefrom, DateTime dateto)
        //{
        //    return _controller.GetEIDTurnaroundbyYear(province, dateFrom, dateTo, user_id, role);//, datefrom, dateto);
        //}
        public IList GetEIDAllTestInfant2MbyYear(int province, int season)//, DateTime datefrom, DateTime dateto)
        {
            return _controller.GetEIDAllTestInfant2MbyYear(province, season);//, datefrom, dateto);
        }
        public IList GetEIDPoitivityTrendbyYear(int province, int season)//, DateTime datefrom, DateTime dateto)
        {
            return _controller.GetEIDPoitivityTrendbyYear(province, season);//, datefrom, dateto);
        }

        public EIDStat EIDFacilitySummaryStat(string datefrom, string dateto, int facility, int user_id, string role, string provinceIDs, string facilityTypes)
        {
            return _controller.EIDFacilitySummaryStat(datefrom, dateto, facility, user_id, role, provinceIDs, facilityTypes);
        }

        public IList GetEIDFacilitySummary(int facility, int dateFrom, int dateTo, int user_id, string role, string provinceIDs, string facilityTypes)//, DateTime datefrom, DateTime dateto)
        {
            return _controller.GetEIDFacilitySummary(facility, dateFrom, dateTo, user_id, role, provinceIDs, facilityTypes);//, datefrom, dateto);
        }

        public IList GetEIDTestByAgeOutcomeForFacility(int facility, int dateFrom, int dateTo, int user_id, string role, string provinceIDs, string facilityTypes)//, DateTime datefrom, DateTime dateto)
        {
            return _controller.GetEIDTestByAgeOutcomeForFacility(facility, dateFrom, dateTo, user_id, role, provinceIDs, facilityTypes);//, datefrom, dateto);
        }

        public IList GetEIDTestLabAndFacility(int facility, int dateFrom, int dateTo, int user_id, string role, string provinceIDs, string facilityTypes)//, DateTime datefrom, DateTime dateto)
        {
            return _controller.GetEIDTestLabAndFacility(facility, dateFrom, dateTo, user_id, role, provinceIDs, facilityTypes);//, datefrom, dateto);
        }
    }
}




