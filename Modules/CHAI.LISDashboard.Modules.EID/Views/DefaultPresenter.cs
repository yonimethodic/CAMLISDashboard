﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.CompositeWeb;
using CHAI.LISDashboard.CoreDomain.Setting;
using CHAI.LISDashboard.CoreDomain.DataAccess;
using System.Data;
using System.Collections;

namespace CHAI.LISDashboard.Modules.EID.Views
{
    public class DefaultPresenter : Presenter<IDefaultView>
    {
        //Added by ZaySoe on 19_Dec_2018
        private EIDController _controller;

        // NOTE: Uncomment the following code if you want ObjectBuilder to inject the module controller
        //       The code will not work in the Shell module, as a module controller is not created by default
        //
        // private ICHAI.LISDashboard.Modules.ReportController _controller;
        // public DefaultPresenter([CreateNew] ICHAI.LISDashboard.Modules.ReportController controller)
        // {
        // 		_controller = controller;
        // }

        //Added by ZaySoe on 19_Dec_2018
        public DefaultPresenter([CreateNew] EIDController controller)
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

        // Added by ZaySoe on 19_Dec_2018        
        public IList<Province> GetProvinces()
        {
            return _controller.GetProvinces();
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

        public IList<Year> GetYears()
        {
            return _controller.GetYear();
        }
    
        public IList GetLabDataEntryPerformanceDaily(int year, int month, string labCode)
        {
            return _controller.GetLabDataEntryPerformanceDaily(year, month, labCode);
        }

        public IList GetLabTestingPerformanceDaily(int year, int month, string labCode)
        {
            return _controller.GetLabTestingPerformanceDaily(year, month, labCode);
        }        
        //public DataSet EIDReport()
        //{
        //    return _controller.EIDReport();
        //}
    }
}



