using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.CompositeWeb;
using System.Data;


namespace CHAI.LISDashboard.Modules.Report.Views
{
    public class ReportPresenter : Presenter<IReportView>
    {

        // NOTE: Uncomment the following code if you want ObjectBuilder to inject the module controller
        //       The code will not work in the Shell module, as a module controller is not created by default
        //
         private CHAI.LISDashboard.Modules.Report.ReportController _controller;
         private CHAI.LISDashboard.Modules.Setting.SettingController _settingcontroller;
         public ReportPresenter([CreateNew] CHAI.LISDashboard.Modules.Report.ReportController controller, [CreateNew] CHAI.LISDashboard.Modules.Setting.SettingController settingcontroller)
         {
         		_controller = controller;
                _settingcontroller = settingcontroller;
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
    }
}




