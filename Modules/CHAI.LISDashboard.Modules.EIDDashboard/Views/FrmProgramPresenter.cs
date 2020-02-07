using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.CompositeWeb;
using System.Collections;
using CHAI.LISDashboard.CoreDomain.Setting;
using CHAI.LISDashboard.CoreDomain.Report;

namespace CHAI.LISDashboard.Modules.EIDDashboard.Views
{
    public class FrmProgramPresenter : Presenter<IFrmProgramView>
    {

        // NOTE: Uncomment the following code if you want ObjectBuilder to inject the module controller
        //       The code will not work in the Shell module, as a module controller is not created by default
        //
        private CHAI.LISDashboard.Modules.EIDDashboard.EIDDashboardController _controller;
        public FrmProgramPresenter([CreateNew] CHAI.LISDashboard.Modules.EIDDashboard.EIDDashboardController controller)
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
        //Trend
        public IList GetEIDIntialPCRbyYear(int province, int user_id, string role)//, DateTime datefrom, DateTime dateto)
        {

            return _controller.GetEIDIntialPCRbyYear(province, user_id, role);
        }
        public IList GetEIDIntialPCRbyQuarter(int province, int dateFrom, int dateTo, int user_id, string role)//, DateTime datefrom, DateTime dateto)
        {
            return _controller.GetEIDIntialPCRbyQuarter(province, dateFrom, dateTo, user_id, role);//, datefrom, dateto);
        }

        //Added by Zay Soe on 9_Jan_2019
        public IList GetEIDIntialPCRbyMonth(int province, int dateFrom, int dateTo, int user_id, string role)//, DateTime datefrom, DateTime dateto)
        {
            return _controller.GetEIDIntialPCRbyMonth(province, dateFrom, dateTo, user_id, role);
        }

        public IList GetEIDAllTestInfant2MbyYear(int province)//, DateTime datefrom, DateTime dateto)
        {
            return _controller.GetEIDAllTestInfant2MbyYear(province);//, datefrom, dateto);
        }
        public IList GetEIDIntialPCRAgeByYearly(int province, int user_id, string role)//, DateTime datefrom, DateTime dateto)
        {
            return _controller.GetEIDIntialPCRAgeByYearly(province, user_id, role);//, datefrom, dateto);
        }
        public IList GetEIDIntialPCRAgeByQuarterly(int province, int dateFrom, int dateTo, int user_id, string role)//, DateTime datefrom, DateTime dateto)
        {
            return _controller.GetEIDIntialPCRAgeByQuarterly(province, dateFrom, dateTo, user_id, role);//, datefrom, dateto);
        }
        public IList GetEIDIntialPCRAgeByMonthly(int province, int dateFrom, int dateTo, int user_id, string role)//, DateTime datefrom, DateTime dateto)
        {
            return _controller.GetEIDIntialPCRAgeByMonthly(province, dateFrom, dateTo, user_id, role);//, datefrom, dateto);
        }        
        public IList GetEIDPCRbyFacility(int province, int dateFrom, int dateTo, int user_id, string role)//, DateTime datefrom, DateTime dateto)
        {
            return _controller.GetEIDPCRbyFacility(province, dateFrom, dateTo, user_id, role);//, datefrom, dateto);
        }

        public IList GetEIDRejectionbyYear(int province, int season)//, DateTime datefrom, DateTime dateto)
        {
            return _controller.GetEIDRejectionbyYear(province, season);//, datefrom, dateto);
        }
        //public IList GetEIDTurnaroundbyYear(int province, int dateFrom, int dateTo, int user_id, string role)//, DateTime datefrom, DateTime dateto)
        //{
        //    return _controller.GetEIDTurnaroundbyYear(province, dateFrom, dateTo, user_id, role);//, datefrom, dateto);
        //}

        public IList GetEIDSummary(int province, int dateFrom, int dateTo, int user_id, string role)//, DateTime datefrom, DateTime dateto)
        {
            return _controller.GetEIDSummary(province, dateFrom, dateTo, user_id, role);//, datefrom, dateto);
        }
        public IList GetEIDAllTestInfant2MbyYear(int province, int season)//, DateTime datefrom, DateTime dateto)
        {
            return _controller.GetEIDAllTestInfant2MbyYear(province, season);//, datefrom, dateto);
        }
        public IList GetEIDPoitivityTrendbyYear(int province, int season)//, DateTime datefrom, DateTime dateto)
        {
            return _controller.GetEIDPoitivityTrendbyYear(province, season);//, datefrom, dateto);
        }
        // TODO: Handle other view events and set state in the view

        public EIDStat EIDSummaryStat(string datefrom, string dateto, int province, int user_id, string type)
        {
            return _controller.EIDSummaryStat(datefrom, dateto, province, user_id, type);
        }

        public IList GetEIDTestByGenderOutcome(int province, int dateFrom, int dateTo, int user_id, string type)
        {
            return _controller.GetEIDTestByGenderOutcome(province, dateFrom, dateTo, user_id, type);
        }

        public IList GetEIDFacilityTestByGenderOutcome(int facility, int dateFrom, int dateTo, int user_id, string role, string provinceIDs, string facilityTypes)
        {            
            return _controller.GetEIDFacilityTestByGenderOutcome(facility, dateFrom, dateTo, user_id, role, provinceIDs, facilityTypes);
        }

        public IList GetEIDTestByGenderOutcomeForLab(string labCode, int dateFrom, int dateTo, int user_id, string role)
        {            
            return _controller.GetEIDTestByGenderOutcomeForLab(labCode, dateFrom, dateTo, user_id, role);
        }

        public IList GetEIDLabByLabInstrument(int province, int dateFrom, int dateTo, int user_id, string type, int labInstruId)
        {
            return _controller.GetEIDLabByLabInstrument(province, dateFrom, dateTo, user_id, type, labInstruId);
        }

        public IList GetEIDLabByLabInstrumentComparison(int province, int dateFrom, int dateTo, int user_id, string type)
        {
            return _controller.GetEIDLabByLabInstrumentComparison(province, dateFrom, dateTo, user_id, type);
        }

        public IList GetEIDTestRejectByProvince(int province, int dateFrom, int dateTo, int user_id, string type)
        {
            return _controller.GetEIDTestRejectByProvince(province, dateFrom, dateTo, user_id, type);
        }

        public IList GetEIDTestByLab(int province, int dateFrom, int dateTo, int user_id, string role, int labInstruId)
        {
            return _controller.GetEIDTestByLab(province, dateFrom, dateTo, user_id, role, labInstruId);
        }

        public IList GetEIDTestAllInstrumentsByLab(int province, int dateFrom, int dateTo, int user_id, string role)
        {
            return _controller.GetEIDTestAllInstrumentsByLab(province, dateFrom, dateTo, user_id, role);
        }

        public IList GetEIDTestByAgeOutcome(int province, int dateFrom, int dateTo, int user_id, string role)
        {
            return _controller.GetEIDTestByAgeOutcome(province, dateFrom, dateTo, user_id, role);
        }
    }
}




