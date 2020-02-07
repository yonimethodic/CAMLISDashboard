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
    public class FrmLabPresenter : Presenter<IFrmLabView>
    {

        // NOTE: Uncomment the following code if you want ObjectBuilder to inject the module controller
        //       The code will not work in the Shell module, as a module controller is not created by default
        //
        private CHAI.LISDashboard.Modules.VLDashboard.VLDashbaordController _controller;
        public FrmLabPresenter([CreateNew] CHAI.LISDashboard.Modules.VLDashboard.VLDashbaordController controller)
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

        public IList<Laboratory> GetLabratories()
        {
            return _controller.GetLabratories();
        }

        public IList<LabInstrument> GetLabInstruments()
        {
            return _controller.GetLabInstruments();
        }

        //public DataSet GetLabInfo(int userId)
        //{
        //    return _controller.GetLabInfo(userId);
        //}

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

        public IList GetVLTestYearly(string labCode, int datefrom, int dateto, int user_id, string type)
        {
            return _controller.GetVLTestYearlyByLab(labCode, datefrom, dateto, user_id, type);
        }

        public IList GetVLTestQuarterly(string labCode, int datefrom, int dateto, int user_id, string type)
        {
            return _controller.GetVLTestQuarterlyByLab(labCode, datefrom, dateto, user_id, type);
        }

        public IList GetVLTestMonthly(string labCode, int datefrom, int dateto, int user_id, string type)
        {
            return _controller.GetVLTestMonthlyByLab(labCode, datefrom, dateto, user_id, type);
        }

        public IList GetVLTestByAgeYearly(string labCode, int dateFrom, int dateTo, int user_id, string type)
        {
            return _controller.GetVLTestByAgeYearlyForLab(labCode, dateFrom, dateTo, user_id, type);
        }

        public IList GetVLTestByGenderOutcome(string labCode, int dateFrom, int dateTo, int user_id, string type)
        {
            return _controller.GetVLTestByGenderOutcomeForLab(labCode, dateFrom, dateTo, user_id, type);
        }

        public IList GetVLTestByProvince(string labCode, int dateFrom, int dateTo, int user_id, string type)
        {
            return _controller.GetVLTestByProvinceForLab(labCode, dateFrom, dateTo, user_id, type);
        }

        public IList GetVLTestAgeGroupByProvince(string labCode, int dateFrom, int dateTo, int user_id, string type)
        {
            return _controller.GetVLTestAgeGroupByProvinceForLab(labCode, dateFrom, dateTo, user_id, type);
        }

        public IList GetVLTestByStateRegionFacility(string labCode, int dateFrom, int dateTo, int user_id, string role)
        {
            return _controller.GetVLTestByStateRegionFacility(labCode, dateFrom, dateTo, user_id, role);
        }

        public IList GetVLLabByLabInstrument(string labCode, int dateFrom, int dateTo, int user_id, string type, int labInstruId)
        {
            return _controller.GetVLLabByLabInstrument(labCode, dateFrom, dateTo, user_id, type, labInstruId);
        }

        public IList GetVLLabByLabInstrumentComparison(string labCode, int dateFrom, int dateTo, int user_id, string type)
        {
            return _controller.GetVLLabByLabInstrumentComparisonForLab(labCode, dateFrom, dateTo, user_id, type);
        }

        public IList GetVLTurnAroundTime(int province, int dateFrom, int dateTo, int user_id, string role)
        {
            return _controller.GetVLTurnAroundTime(province, dateFrom, dateTo, user_id, role);
        }

        public IList GetVLTestByLab(string labCode, int dateFrom, int dateTo, int user_id, string role, int labInstruId)
        {
            return _controller.GetVLTestByLab(labCode, dateFrom, dateTo, user_id, role, labInstruId);
        }
        public IList GetVLTestAllInstrumentsByLab(string labCode, int dateFrom, int dateTo, int user_id, string role)
        {
            return _controller.GetVLTestAllInstrumentsByLab(labCode, dateFrom, dateTo, user_id, role);
        }        
        public IList GetVLTurnaroundbyYear(string labCode, int dateFrom, int dateTo, int user_id, string role)//, DateTime datefrom, DateTime dateto)
        {
            return _controller.GetVLTurnaroundbyYear(labCode, dateFrom, dateTo, user_id, role);//, datefrom, dateto);
        }

        public IList GetVLTurnaroundbyQuarter(string labCode, int dateFrom, int dateTo, int user_id, string role)//, DateTime datefrom, DateTime dateto)
        {
            return _controller.GetVLTurnaroundbyQuarter(labCode, dateFrom, dateTo, user_id, role);//, datefrom, dateto);
        }

        public IList GetVLSummary(string labCode, int dateFrom, int dateTo, int user_id, string role)//, DateTime datefrom, DateTime dateto)
        {
            return _controller.GetVLSummary(labCode, dateFrom, dateTo, user_id, role);//, datefrom, dateto);
        }

        //public IList GetVLTestByAgeQuarterly(int province, int datefrom, int dateto, int user_id, string type)
        //{
        //    return _controller.GetVLTestByAgeQuarterly(province, datefrom, dateto, user_id, type);
        //}

        //public IList GetVLTestByAgeMonthly(int province, int datefrom, int dateto, int user_id, string type)
        //{
        //    return _controller.GetVLTestByAgeMonthly(province, datefrom, dateto, user_id, type);
        //}

        public VLStat VLSummaryStat(string datefrom, string dateto, string labCode, int user_id, string type)
        {
            return _controller.VLSummaryStat(datefrom, dateto, labCode, user_id, type);
        }

        public IList GetVLTestRejectByProvinceForLab(string labCode, int dateFrom, int dateTo, int user_id, string role)
        {
            return _controller.GetVLTestRejectByProvinceForLab(labCode, dateFrom, dateTo, user_id, role);
        }
    }
}




