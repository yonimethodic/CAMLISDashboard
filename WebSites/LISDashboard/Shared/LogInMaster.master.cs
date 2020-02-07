using System;
using Microsoft.Practices.ObjectBuilder;
using CHAI.LISDashboard.Modules.Admin.Views;
using System.Web.Security;

namespace CHAI.LISDashboard.Modules.Shell.MasterPages
{
    public partial class LogInMaster : BaseMaster
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                base.Presenter.OnViewInitialized();
            }
            base.Presenter.OnViewLoaded();
        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            base.Message += new MessageEventHandler(LogInMaster_Message);
        }
        protected void LogInMaster_Message(object sender, CHAI.LISDashboard.Shared.Events.MessageEventArgs e)
        {
            BaseMessageControl ctr = (BaseMessageControl)Page.LoadControl("~/Shared/Controls/RMessageBox.ascx");
            ctr.Message = e.Message;
            this.plhMessage.Controls.Add(ctr);
        }
}
}
