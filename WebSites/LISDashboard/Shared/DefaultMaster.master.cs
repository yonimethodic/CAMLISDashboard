using System;
using Microsoft.Practices.ObjectBuilder;
using CHAI.LISDashboard.Modules.Admin.Views;
using System.Web.Security;
using CHAI.LISDashboard.CoreDomain.Users;

namespace CHAI.LISDashboard.Modules.Shell.MasterPages
{
    public partial class DefaultMaster : BaseMaster
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                base.Presenter.OnViewInitialized();
            }
            base.Presenter.OnViewLoaded();
          

        }
        protected void LoginStatus1_LoggedOut(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
        }
    
        protected void lnkAdmin_Click(object sender, EventArgs e)
        {
            this.Page.Response.Redirect(string.Format("~/Admin/Default.aspx?{0}=0", CHAI.LISDashboard.Shared.AppConstants.TABID));
        }
      
}
}
