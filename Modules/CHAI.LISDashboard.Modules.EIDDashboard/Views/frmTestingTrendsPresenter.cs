using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.CompositeWeb;
using System.Collections;
using CHAI.LISDashboard.CoreDomain.Setting;

namespace CHAI.LISDashboard.Modules.EIDDashboard.Views
{
    public class frmTestingTrendsPresenter : Presenter<IfrmTestingTrendsView>
    {

        // NOTE: Uncomment the following code if you want ObjectBuilder to inject the module controller
        //       The code will not work in the Shell module, as a module controller is not created by default
        //
        private CHAI.LISDashboard.Modules.EIDDashboard.EIDDashboardController _controller;
        public frmTestingTrendsPresenter([CreateNew] CHAI.LISDashboard.Modules.EIDDashboard.EIDDashboardController controller)
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
        //public IList GetEIDAllTestbyYear(int province, int dateFrom, int dateTo, int user_id, string role)//, DateTime datefrom, DateTime dateto)
        //{
        //    return _controller.GetEIDAllTestbyYear(province, dateFrom, dateTo, user_id, role);//, datefrom, dateto);
        //}

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
        // TODO: Handle other view events and set state in the view
    }
}




