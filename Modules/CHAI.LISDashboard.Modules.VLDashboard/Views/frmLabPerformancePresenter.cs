using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.CompositeWeb;
using CHAI.LISDashboard.CoreDomain.Setting;
using System.Data;
using System.Collections;
using CHAI.LISDashboard.CoreDomain.Users;

namespace CHAI.LISDashboard.Modules.VLDashboard.Views
{
    public class frmLabPerformancePresenter : Presenter<IfrmLabPerformanceView>
    {

        // NOTE: Uncomment the following code if you want ObjectBuilder to inject the module controller
        //       The code will not work in the Shell module, as a module controller is not created by default
        //
        private CHAI.LISDashboard.Modules.VLDashboard.VLDashbaordController _controller;
        public frmLabPerformancePresenter([CreateNew] CHAI.LISDashboard.Modules.VLDashboard.VLDashbaordController controller)
        {
            _controller = controller;
        }

        public override void OnViewLoaded()
        {
            // TODO: Implement code that will be executed every time the view loads            

            //Added by ZaySoe on 14-Nov-18
            View.CurrentUser = _controller.GetCurrentUser();
            View.CurrentUser.UserLocations = (List<UserLocation>) _controller.GetUserLocations(View.CurrentUser.Id);
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
        public IList GetVLOutcomebyProvince(int province, string datefrom, string dateto)
        {
            return _controller.GetVLOutcomebyProvince(province, datefrom, dateto);
        }
        public DataSet VLLabPerStatSummary(string datefrom, string dateto, string LabName, string labCode)
        {
            return _controller.VLLabPerStatSummary(datefrom, dateto, LabName, labCode);
        }
        public IList GetVLLABTestingTrends(string datefrom, string dateto)
        {
            return _controller.GetVLLABTestingTrends(datefrom, dateto);
        }
        public IList GetVLLABRejectionTrends(string datefrom, string dateto)
        {
            return _controller.GetVLLABRejectionTrends(datefrom, dateto);
        }
        public IList GetVLLABTestbySampleType(string datefrom, string dateto)
        {
            return _controller.GetVLLABTestbySampleType(datefrom, dateto);
        }
        public IList GetVLLABTestbyGender(string datefrom, string dateto)
        {
            return _controller.GetVLLABTestbyGender(datefrom, dateto);
        }
        public IList GetVLLABTestbyAge(string datefrom, string dateto)
        {
            return _controller.GetVLLABTestbyAge(datefrom, dateto);
        }
        public IList GetVLLABOutcome(string datefrom, string dateto)
        {
            
            return _controller.GetVLLABOutcome(datefrom, dateto);
        }
        public IList GetVLLABRejectionReasonNational(string datefrom, string dateto)
        {
           
            return _controller.GetVLLABRejectionReasonNational(datefrom, dateto);
        }
        public IList GetVLLABOutcomeTrends(string datefrom, string dateto, string LabCode)
        {
            
            return _controller.GetVLLABOutcomeTrends(datefrom, dateto, LabCode);
        }
        public IList GetVLLabperformanceSuppressionTrends(string LabCode)
        {
            
            return _controller.GetVLLabperformanceSuppressionTrends(LabCode);
        }
        public IList GetVLLabValidTestingTrends(string LabCode)
        {
            
            return _controller.GetVLLabValidTestingTrends(LabCode);
        }
        public IList GetVLLabPerfomaceRejectedTrends( string LabCode)
        {
            
            return _controller.GetVLLabPerfomaceRejectedTrends(LabCode);
        }
        public IList GetVLLABRejectionReasonbyLab(string datefrom, string dateto, string LabCode)
        {
         
            return _controller.GetVLLABRejectionReasonbyLab(datefrom, dateto, LabCode);
        }
    }
}




