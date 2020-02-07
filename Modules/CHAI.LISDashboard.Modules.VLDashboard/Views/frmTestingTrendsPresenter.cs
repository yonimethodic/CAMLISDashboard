using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.CompositeWeb;
using CHAI.LISDashboard.CoreDomain.Setting;
using System.Data;
using System.Collections;

namespace CHAI.LISDashboard.Modules.VLDashboard.Views
{
    public class frmTestingTrendsPresenter : Presenter<IfrmTestingTrendsView>
    {

        // NOTE: Uncomment the following code if you want ObjectBuilder to inject the module controller
        //       The code will not work in the Shell module, as a module controller is not created by default
        //
        private CHAI.LISDashboard.Modules.VLDashboard.VLDashbaordController _controller;
        public frmTestingTrendsPresenter([CreateNew] CHAI.LISDashboard.Modules.VLDashboard.VLDashbaordController controller)
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
    }
}




