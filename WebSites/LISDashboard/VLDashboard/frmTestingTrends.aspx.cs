using CHAI.LISDashboard.CoreDomain.DataAccess;
using Microsoft.Practices.ObjectBuilder;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CHAI.LISDashboard.Modules.VLDashboard.Views
{

    public partial class frmTestingTrends : POCBasePage, IfrmTestingTrendsView
    {
        private frmTestingTrendsPresenter _presenter;
        public  IList jsonVLTestingTrends { get; set; }
        public string JstringVLTestingTrends { get;set;}
        public IList jsonVLTestingbyAgeTrends { get; set; }
        public string JstringVLTestingbyAgeTrends { get; set; }
        public IList jsonVLSuppressionTrends { get; set; }
        public string JstringVLSuppressionTrends { get; set; }
        public IList jsonVLValidTestingTrends { get; set; }
        public string JstringVLValidTestingTrends { get; set; }
        public IList jsonVLRejectedTrends { get; set; }
        public string JstringVLRejectedTrends { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this._presenter.OnViewInitialized();
                BindLocation();
            }
            this._presenter.OnViewLoaded();

            GetVLTestingTrendOutcome();
            GetVLTestbyAgeTrends();
            GetVLSuppressionTrends();
            GetVLValidTestingTrends();
            GetVLRejectedTrends();
            ;
        }
        public override string PageID
        {

            get
            {
                return "{59C87105-3301-46FD-93AC-D3FAAE5064F7}";
            }
        }
        [CreateNew]
        public frmTestingTrendsPresenter Presenter
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

        private void BindLocation()
        {
            ddlLocation.DataSource = _presenter.GetProvinces();
            ddlLocation.DataBind();
        }
       
        private void GetVLTestingTrendOutcome()
        {

            jsonVLTestingTrends =  _presenter.GetVLTestingTrendOutcome(Convert.ToInt32(ddlLocation.SelectedValue), int.Parse(ddlDate.SelectedValue));
            JstringVLTestingTrends = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLTestingTrends);
        }
        private void GetVLTestbyAgeTrends()
        {

            jsonVLTestingbyAgeTrends = _presenter.GetVLTestbyAgeTrends(Convert.ToInt32(ddlLocation.SelectedValue));
            JstringVLTestingbyAgeTrends = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLTestingbyAgeTrends);
        }
        private void GetVLSuppressionTrends()
        {

            jsonVLSuppressionTrends = _presenter.GetVLSuppressionTrends(Convert.ToInt32(ddlLocation.SelectedValue),int.Parse(ddlDate.SelectedValue));
            JstringVLSuppressionTrends = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLSuppressionTrends);
        }
        private void GetVLValidTestingTrends()
        {

            jsonVLValidTestingTrends = _presenter.GetVLValidTestingTrends(Convert.ToInt32(ddlLocation.SelectedValue), int.Parse(ddlDate.SelectedValue));
            JstringVLValidTestingTrends = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLValidTestingTrends);
        }
        private void GetVLRejectedTrends()
        {

            jsonVLRejectedTrends = _presenter.GetVLRejectedTrends(Convert.ToInt32(ddlLocation.SelectedValue), int.Parse(ddlDate.SelectedValue));
            JstringVLRejectedTrends = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLRejectedTrends);
        }
        protected void btnFilter_Click(object sender, EventArgs e)
        {
            if (ddlLocation.SelectedValue != "0")
            {
                lbllocation.Text = ddlLocation.SelectedItem.Text + " State/Region";
                
            }
            else
            {
                lbllocation.Text = "National";
               
            }
            GetVLTestingTrendOutcome();
            GetVLTestbyAgeTrends();
            GetVLSuppressionTrends();
            GetVLValidTestingTrends();
            GetVLRejectedTrends();
        }

       
    }
}