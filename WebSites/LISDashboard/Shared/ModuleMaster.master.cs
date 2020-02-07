using System;
using Microsoft.Practices.ObjectBuilder;
using CHAI.LISDashboard.Services;
using CHAI.LISDashboard.CoreDomain;
using System.Web.UI;
using CHAI.LISDashboard.CoreDomain.Users;

namespace CHAI.LISDashboard.Modules.Shell.MasterPages
{
    public partial class ModuleMaster : BaseMaster
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                base.Presenter.OnViewInitialized();
            }

            base.CheckTransferdMessage();
            base.Presenter.OnViewLoaded();
           
        }
        
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            base.Message += new MessageEventHandler(ModuleMaster_Message);
        }
     
     
        protected void lnkAdmin_Click(object sender, EventArgs e)
        {
            this.Page.Response.Redirect(string.Format("~/Admin/Default.aspx?{0}=0", CHAI.LISDashboard.Shared.AppConstants.TABID));
        }
        protected void lnkassign_Click(object sender, EventArgs e)
        {
            this.Page.Response.Redirect(string.Format("~/Admin/AssignJob.aspx?{0}=0", CHAI.LISDashboard.Shared.AppConstants.TABID));
        }
        protected void ModuleMaster_Message(object sender, CHAI.LISDashboard.Shared.Events.MessageEventArgs e)
        {
            BaseMessageControl ctr = (BaseMessageControl)Page.LoadControl("~/Shared/Controls/RMessageBox.ascx");
            ctr.Message = e.Message;
            this.plhMessage.Controls.Add(ctr);
        }
    }
}
