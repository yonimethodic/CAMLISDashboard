using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.CompositeWeb;
using CHAI.LISDashboard.CoreDomain.Setting;
namespace CHAI.LISDashboard.Modules.Report.Views
{
    public class DefaultPresenter : Presenter<IDefaultView>
    {
        private ReportController _controller;
        // NOTE: Uncomment the following code if you want ObjectBuilder to inject the module controller
        //       The code will not work in the Shell module, as a module controller is not created by default
        //
        // private ICHAI.LISDashboard.Modules.ReportController _controller;
        // public DefaultPresenter([CreateNew] ICHAI.LISDashboard.Modules.ReportController controller)
        // {
        // 		_controller = controller;
        // }
        public DefaultPresenter([CreateNew] ReportController controller)
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

        #region Province
        public IList<Province> GetProvinces()
        {
            return _controller.GetProvinces();
        }

        public IList<Facility> GetFacilities()
        {
            return _controller.GetFacilities();
        }
        public IList<District> GetDistricts(int provinceId)
        {
            return _controller.GetDistricts(provinceId);
        }
        public IList<LLG> GetLLGs(int districtId)
        {
            return _controller.GetLLGs(districtId);
        }
        public IList<Facility> GetFacilities(int LLGId)
        {
            return _controller.GetFacilities(LLGId);
        }
        public IList<Laboratory> GetLaboratories()
        {
            return _controller.GetLaboratories();
        }
        public IList<FacilityType> GetFacilityTypeByFacilityType2(string value)
        {
            return _controller.GetFacilityTypeByFacilityType2(value);
        }
        #endregion

        public IList<Year> GetYears()
        {
            return _controller.GetYear();
        }
    }
}




