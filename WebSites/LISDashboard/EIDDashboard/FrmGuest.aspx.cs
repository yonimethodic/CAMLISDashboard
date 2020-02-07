using CHAI.LISDashboard.CoreDomain.DataAccess;
using Microsoft.Practices.ObjectBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CHAI.LISDashboard.Modules.EIDDashboard.Views
{
    public partial class FrmGuest : POCBasePage, IFrmGuestView
    {
        private FrmGuestPresenter _presenter;
        private ReportDao dao;
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
                return "{D8AB2709-EF3A-4E03-8634-BBBDE57E5AD47}";
            }
        }
        [CreateNew]
        public FrmGuestPresenter Presenter
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