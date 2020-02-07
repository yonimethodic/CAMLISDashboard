using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using CHAI.LISDashboard.Modules.Shell.Views;
using Microsoft.Practices.ObjectBuilder;
using CHAI.LISDashboard.Modules.Shell.MasterPages;
using CHAI.LISDashboard.Shared;
using CHAI.LISDashboard.CoreDomain.Users;
using CHAI.LISDashboard.Enums;


public partial class ShellDefault : Microsoft.Practices.CompositeWeb.Web.UI.Page, IBaseMasterView
{
    private BaseMasterPresenter _presenter;
    private AppUser currentUser;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            this._presenter.OnViewInitialized();
                        

        }
        this._presenter.OnViewLoaded();
      
      
    }

    [CreateNew]
    public BaseMasterPresenter Presenter
    {
        get
		{
			return this._presenter;
		}
        set
        {
            if(value == null)
                throw new ArgumentNullException("value");

            this._presenter = value;
            this._presenter.View = this;
        }
    }

    public string TabId
    {
        get { return Request.QueryString[AppConstants.TABID]; } 
    }
    public string NodeId
    {
        get { return Request.QueryString[AppConstants.NODEID];} 
    }
    public CHAI.LISDashboard.CoreDomain.Users.AppUser CurrentUser
    {
        get
        {
            return currentUser;
        }
        set
        {
            currentUser = value;
        }
    }
   
    
}
