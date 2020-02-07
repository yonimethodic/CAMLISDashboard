using CHAI.LISDashboard.CoreDomain.DataAccess;
using Microsoft.Practices.ObjectBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CHAI.LISDashboard.Modules.VLDashboard.Views
{
    public partial class Default : POCBasePage, IDefaultView
    {
        private DefaultPresenter _presenter;
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this._presenter.OnViewInitialized();
            }
            this._presenter.OnViewLoaded();
            
        
        }
        public override string PageID
        {

            get
            {
                return "{59C87105-9301-46FD-93AC-D3FAAE5064F7}";
            }
        }
        [CreateNew]
        public DefaultPresenter Presenter
        {
            get
            {
                return this._presenter;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");

                this._presenter = value;
                this._presenter.View = this;
            }
        }

    }
}