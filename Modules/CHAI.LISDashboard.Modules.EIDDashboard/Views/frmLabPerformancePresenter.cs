using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.CompositeWeb;
using CHAI.LISDashboard.CoreDomain.Setting;
using System.Collections;
using System.Data;
namespace CHAI.LISDashboard.Modules.EIDDashboard.Views
{
    public class frmLabPerformancePresenter : Presenter<IfrmLabPerformanceView>
    {

        // NOTE: Uncomment the following code if you want ObjectBuilder to inject the module controller
        //       The code will not work in the Shell module, as a module controller is not created by default
        //
        private CHAI.LISDashboard.Modules.EIDDashboard.EIDDashboardController _controller;
        public frmLabPerformancePresenter([CreateNew] CHAI.LISDashboard.Modules.EIDDashboard.EIDDashboardController controller)
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
        public IList<Laboratory> GetLaboratories()
        {
            return _controller.GetLaboratories();
        }

        public IList GetLabEIDRejectionbyYear(string lab, DateTime datefrom, DateTime dateto)
        {
            return _controller.GetLabEIDRejectionbyYear(lab, datefrom, dateto);
        }
        public IList GetLabEIDPoitivityTrendbyYear(string lab, DateTime datefrom, DateTime dateto)
        {
            return _controller.GetLabEIDPoitivityTrendbyYear(lab, datefrom, dateto);
        }
        public IList GetLabEIDValidOutcome(string lab, DateTime datefrom, DateTime dateto)
        {
            return _controller.GetLabEIDValidOutcome(lab, datefrom, dateto);
        }
        public IList GetLabEIDTestTrendbyYear(string lab, DateTime datefrom, DateTime dateto)
        {
            return _controller.GetLabEIDTestTrendbyYear(lab, datefrom, dateto);
        }
        public IList GetLabRejectedSamplebyCountry(string lab, DateTime datefrom, DateTime dateto)
        {
            return _controller.GetLabRejectedSamplebyCountry(lab, datefrom, dateto);
        }
        public DataSet GetLabPerformance(string lab, DateTime datefrom, DateTime dateto)
        {
            return _controller.GetLabPerformance(lab, datefrom, dateto);
        }

        //public DataSet GetTurnaroundTime(int province, int dateFrom, int dateTo, int user_id, string role)
        //{
        //    return _controller.GetTurnaroundTime(province, dateFrom, dateTo, user_id, role);
        //}

    }
}




