using System;
using System.Web;
using System.Web.UI;
using Microsoft.Practices.ObjectBuilder;
using CHAI.LISDashboard.CoreDomain;
using CHAI.LISDashboard.CoreDomain.Users;

namespace CHAI.LISDashboard.Modules.Shell.MasterPages
{
    public partial class AdminMaster : BaseMaster
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
            base.Message += new MessageEventHandler(AdminMaster_Message);
        }
       
        
        void AdminMaster_Message(object sender, CHAI.LISDashboard.Shared.Events.MessageEventArgs e)
        {
            BaseMessageControl ctr = (BaseMessageControl)Page.LoadControl("~/Shared/Controls/RMessageBox.ascx");
            ctr.Message = e.Message;
            this.plhMessage.Controls.Add(ctr);   
        }
    }
}
