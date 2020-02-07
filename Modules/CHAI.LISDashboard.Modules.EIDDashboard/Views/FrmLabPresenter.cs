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
    public class FrmLabPresenter : Presenter<IFrmLabView>
    {

        // NOTE: Uncomment the following code if you want ObjectBuilder to inject the module controller
        //       The code will not work in the Shell module, as a module controller is not created by default
        //
        private CHAI.LISDashboard.Modules.EIDDashboard.EIDDashboardController _controller;
        public FrmLabPresenter([CreateNew] CHAI.LISDashboard.Modules.EIDDashboard.EIDDashboardController controller)
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

        public IList<Laboratory> GetLabratories()
        {
            return _controller.GetLabratories();
        }

        //Trend
        public IList GetEIDIntialPCRbyYear(string labCode, int dateFrom, int dateTo, int user_id, string role)//, DateTime datefrom, DateTime dateto)
        {
            return _controller.GetEIDIntialPCRbyYearForLab(labCode, dateFrom, dateTo, user_id, role);
        }                

        public IList GetEIDAllTestbyYear(string labCode, int dateFrom, int dateTo, int user_id, string role)//, DateTime datefrom, DateTime dateto)
        {
            return _controller.GetEIDIntialPCRbyQuarterForLab(labCode, dateFrom, dateTo, user_id, role);//, datefrom, dateto);
        }

        //Added by Zay Soe on 9_Jan_2019
        public IList GetEIDIntialPCRbyMonth(string labCode, int dateFrom, int dateTo, int user_id, string role)//, DateTime datefrom, DateTime dateto)
        {
            return _controller.GetEIDIntialPCRbyMonthForLab(labCode, dateFrom, dateTo, user_id, role);
        }

        public IList GetEIDAllTestInfant2MbyYear(int province)//, DateTime datefrom, DateTime dateto)
        {
            return _controller.GetEIDAllTestInfant2MbyYear(province);//, datefrom, dateto);
        }
        public IList GetEIDIntialPCRAgeByYear(string labCode, int dateFrom, int dateTo, int user_id, string role)//, DateTime datefrom, DateTime dateto)
        {
            return _controller.GetEIDIntialPCRAgeByYearForLab(labCode, dateFrom, dateTo, user_id, role);//, datefrom, dateto);
        }
        public IList GetEIDIntialPCRAgeByQuarter(string labCode, int dateFrom, int dateTo, int user_id, string role)//, DateTime datefrom, DateTime dateto)
        {
            return _controller.GetEIDIntialPCRAgeByQuarterForLab(labCode, dateFrom, dateTo, user_id, role);//, datefrom, dateto);
        }
        public IList GetEIDIntialPCRAgeByMonth(string labCode, int dateFrom, int dateTo, int user_id, string role)//, DateTime datefrom, DateTime dateto)
        {
            return _controller.GetEIDIntialPCRAgeByMonthForLab(labCode, dateFrom, dateTo, user_id, role);//, datefrom, dateto);
        }

        public IList GetEIDTestByGenderOutcomeForLab(string labCode, int dateFrom, int dateTo, int user_id, string role)//, DateTime datefrom, DateTime dateto)
        {
            return _controller.GetEIDTestByGenderOutcomeForLab(labCode, dateFrom, dateTo, user_id, role);//, datefrom, dateto);
        }

        public IList GetEIDTestRejectByProvinceForLab(string labCode, int dateFrom, int dateTo, int user_id, string role)//, DateTime datefrom, DateTime dateto)
        {
            return _controller.GetEIDTestRejectByProvinceForLab(labCode, dateFrom, dateTo, user_id, role);//, datefrom, dateto);
        }        

        public IList GetEIDPCRbyFacility(string labCode, int dateFrom, int dateTo, int user_id, string role)//, DateTime datefrom, DateTime dateto)
        {
            return _controller.GetEIDPCRbyFacilityForLab(labCode, dateFrom, dateTo, user_id, role);//, datefrom, dateto);
        }

        public IList GetEIDLabByLabInstrument(string labCode, int dateFrom, int dateTo, int user_id, string type, int labInstruId)
        {
            return _controller.GetEIDLabByLabInstrumentForLab(labCode, dateFrom, dateTo, user_id, type, labInstruId);
        }

        public IList GetEIDLabByLabInstrumentComparison(string labCode, int dateFrom, int dateTo, int user_id, string type)
        {
            return _controller.GetEIDLabByLabInstrumentComparisonForLab(labCode, dateFrom, dateTo, user_id, type);
        }
        public IList GetEIDTestByLab(string labCode, int dateFrom, int dateTo, int user_id, string role, int labInstruId)
        {
            return _controller.GetEIDTestByLab(labCode, dateFrom, dateTo, user_id, role, labInstruId);
        }
        public IList GetEIDTestAllInstrumentsByLab(string labCode, int dateFrom, int dateTo, int user_id, string role)
        {
            return _controller.GetEIDTestAllInstrumentsByLab(labCode, dateFrom, dateTo, user_id, role);
        }        

        public IList GetEIDTestByStateRegionFacility(string labCode, int dateFrom, int dateTo, int user_id, string role)
        {
            return _controller.GetEIDTestByStateRegionFacility(labCode, dateFrom, dateTo, user_id, role);
        }

        public IList GetEIDRejectionbyYear(int province, int season)//, DateTime datefrom, DateTime dateto)
        {
            return _controller.GetEIDRejectionbyYear(province, season);//, datefrom, dateto);
        }
        public IList GetEIDSummary(string labCode, int dateFrom, int dateTo, int user_id, string role)//, DateTime datefrom, DateTime dateto)
        {
            return _controller.GetEIDSummaryForLab(labCode, dateFrom, dateTo, user_id, role);//, datefrom, dateto);
        }
        public IList GetEIDTurnaroundbyYear(string labCode, int dateFrom, int dateTo, int user_id, string role)//, DateTime datefrom, DateTime dateto)
        {
            return _controller.GetEIDTurnaroundbyYear(labCode, dateFrom, dateTo, user_id, role);//, datefrom, dateto);
        }

        //public IList GetEIDTurnaroundbyQuarter(int province, int dateFrom, int dateTo, int user_id, string role)//, DateTime datefrom, DateTime dateto)
        //{
        //    return _controller.GetEIDTurnaroundbyQuarter(province, dateFrom, dateTo, user_id, role);//, datefrom, dateto);
        //}

        public IList GetEIDTurnaroundbyQuarter(string labCode, int dateFrom, int dateTo, int user_id, string role)//, DateTime datefrom, DateTime dateto)
        {
            return _controller.GetEIDTurnaroundbyQuarter(labCode, dateFrom, dateTo, user_id, role);//, datefrom, dateto);
        }

        public IList GetEIDAllTestInfant2MbyYear(int province, int season)//, DateTime datefrom, DateTime dateto)
        {
            return _controller.GetEIDAllTestInfant2MbyYear(province, season);//, datefrom, dateto);
        }
        public IList GetEIDPoitivityTrendbyYear(int province, int season)//, DateTime datefrom, DateTime dateto)
        {
            return _controller.GetEIDPoitivityTrendbyYear(province, season);//, datefrom, dateto);
        }

        public EIDStat EIDSummaryStat(string datefrom, string dateto, string labCode, int user_id, string role)
        {
            return _controller.EIDSummaryStatForLab(datefrom, dateto, labCode, user_id, role);
        }

        public IList GetEIDTestByAgeOutcomeForLab(string labCode, int dateFrom, int dateTo, int user_id, string role)//, DateTime datefrom, DateTime dateto)
        {
            return _controller.GetEIDTestByAgeOutcomeForLab(labCode, dateFrom, dateTo, user_id, role);//, datefrom, dateto);
        }

        //public DataSet GetLabInfo(int userId)
        //{
        //    return _controller.GetLabInfo(userId);
        //}

        // TODO: Handle other view events and set state in the view
    }
}




