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
    public class FrmProgramPresenter : Presenter<IFrmProgramView>
    {

        // NOTE: Uncomment the following code if you want ObjectBuilder to inject the module controller
        //       The code will not work in the Shell module, as a module controller is not created by default
        //
        private CHAI.LISDashboard.Modules.VLDashboard.VLDashbaordController _controller;
        public FrmProgramPresenter([CreateNew] CHAI.LISDashboard.Modules.VLDashboard.VLDashbaordController controller)
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

        public IList<LabInstrument> GetLabInstruments()
        {
            return _controller.GetLabInstruments();
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

        public IList GetVLTestAgeGroupByProvince(int province, int dateFrom, int dateTo, int user_id, string type)
        {
            return _controller.GetVLTestAgeGroupByProvince(province, dateFrom, dateTo, user_id, type);
        }

        public IList GetVLLabByLabInstrument(int dateFrom, int dateTo, int user_id, string type, int labInstruId)
        {
            return _controller.GetVLLabByLabInstrument(dateFrom, dateTo, user_id, type, labInstruId);
        }

        public IList GetVLLabByLabInstrumentComparison(int dateFrom, int dateTo, int user_id, string type)
        {
            return _controller.GetVLLabByLabInstrumentComparison(dateFrom, dateTo, user_id, type);
        }

        public IList GetVLTurnAroundTime(int province, int dateFrom, int dateTo, int user_id, string role)
        {
            return _controller.GetVLTurnAroundTime(province, dateFrom, dateTo, user_id, role);
        }

        public IList GetVLTestByLab(int province, int dateFrom, int dateTo, int user_id, string role, int labInstruId)
        {
            return _controller.GetVLTestByLab(province, dateFrom, dateTo, user_id, role, labInstruId);
        }

        public IList GetVLTestAllInstrumentsByLab(int province, int dateFrom, int dateTo, int user_id, string role)
        {
            return _controller.GetVLTestAllInstrumentsByLab(province, dateFrom, dateTo, user_id, role);
        }

        //public IList GetVLTestByAgeQuarterly(int province, int datefrom, int dateto, int user_id, string type)
        //{
        //    return _controller.GetVLTestByAgeQuarterly(province, datefrom, dateto, user_id, type);
        //}

        //public IList GetVLTestByAgeMonthly(int province, int datefrom, int dateto, int user_id, string type)
        //{
        //    return _controller.GetVLTestByAgeMonthly(province, datefrom, dateto, user_id, type);
        //}

        public VLStat VLSummaryStat(string datefrom, string dateto, int province, int user_id, string type)
        {
            return _controller.VLSummaryStat(datefrom, dateto, province, user_id, type);
        }

        public IList GetVLSummary(int province, int dateFrom, int dateTo, int user_id, string role)//, DateTime datefrom, DateTime dateto)
        {
            return _controller.GetVLSummary(province, dateFrom, dateTo, user_id, role);//, datefrom, dateto);
        }

        public IList GetVLTestRejectByProvince(int province, int dateFrom, int dateTo, int user_id, string type)
        {
            return _controller.GetVLTestRejectByProvince(province, dateFrom, dateTo, user_id, type);
        }
    }
}




