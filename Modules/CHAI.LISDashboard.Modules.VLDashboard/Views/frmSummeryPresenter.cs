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
    public class frmSummeryPresenter : Presenter<IfrmSummeryView>
    {

        // NOTE: Uncomment the following code if you want ObjectBuilder to inject the module controller
        //       The code will not work in the Shell module, as a module controller is not created by default
        //
        private CHAI.LISDashboard.Modules.VLDashboard.VLDashbaordController _controller;
        public frmSummeryPresenter([CreateNew] CHAI.LISDashboard.Modules.VLDashboard.VLDashbaordController controller)
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
          return  _controller.GetProvinces();
        }
        public VLStat VLSummaryStat(string datefrom, string dateto, int province, int user_id, string role)
        {           
            return _controller.VLSummaryStat(datefrom, dateto, province, user_id, role);
        }
        public IList GetTestTrends(int province, int testreason, string datefrom, string dateto)
        {
            
            return _controller.GetTestTrends(province, testreason, datefrom, dateto);
        }
        public IList GetVLoutcome(int province, string datefrom, string dateto)
        {            
            return _controller.GetVLOutcome(province, datefrom, dateto);
        }
        public IList GetVLTestbyGender(int province, string datefrom, string dateto)
        {
            return _controller.GetVLTestbyGender(province, datefrom, dateto);
        }
        public IList GetVLTestbyAge(int province, string datefrom, string dateto)
        {
            return _controller.GetVLTestbyAge(province, datefrom, dateto);
        }
        public IList GetVLreasonforTest(int province, string datefrom, string dateto)
        {
            return _controller.GetVLreasonforTest(province, datefrom, dateto);
        }
        public IList GetVLOutcomebyProvince(int province, string datefrom, string dateto)
        {
            return _controller.GetVLOutcomebyProvince(province, datefrom, dateto);
        }
    }
}




