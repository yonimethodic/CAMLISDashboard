using CHAI.LISDashboard.CoreDomain.DataAccess;
using Microsoft.Practices.ObjectBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;

namespace CHAI.LISDashboard.Modules.EIDDashboard.Views
{
    public partial class frmLabPerformance : POCBasePage, IfrmLabPerformanceView
    {
        private frmLabPerformancePresenter _presenter;
        private ReportDao dao;
        public IList jsonEIDTestByAge { get; set; }
        public string JstringEIDTestByAge { get; set; }
        public IList jsonEIDTestByModeOfDelivery { get; set; }
        public string JstringEIDTestByModeOfDelivery { get; set; }

        public IList jsonEIDOutcome { get; set; }
        public string JstringEIDOutcome { get; set; }
        public IList jsonInfantFeeding { get; set; }
        public string JstringInfantFeeding { get; set; }

        public IList jsonEIDIntialPCR { get; set; }
        public string JstringEIDIntialPCR { get; set; }

        public IList jsonEIDIntialPCRbyProvince { get; set; }
        public string JstringEIDIntialPCRbyProvince { get; set; }

        public IList jsonLabEIDRejectionbyYear { get; set; }
        public string JstringLabEIDRejectionbyYear { get; set; }

        public IList jsonLabEIDPoitivityTrendbyYear { get; set; }
        public string JstringLabEIDPoitivityTrendbyYear { get; set; }
        public IList jsonLabEIDValidOutcome { get; set; }
        public string JstringLabEIDValidOutcome { get; set; }
        public IList jsonLabEIDTestTrendbyYear { get; set; }
        public string JstringLabEIDTestTrendbyYear { get; set; }
        public IList jsonLabRejectedSamplebyCountry { get; set; }
        public string JstringLabRejectedSamplebyCountry { get; set; }

        DataSet _Worksheet = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this._presenter.OnViewInitialized();
                BindLocation();
            }
            this._presenter.OnViewLoaded();
            BindLabPerformance();
            GetLabEIDRejectionbyYear();
            GetLabEIDPoitivityTrendbyYear();
            GetLabEIDValidOutcome();
            GetLabEIDTestTrendbyYear();
            GetLabRejectedSamplebyCountry();
        }
        public override string PageID
        {

            get
            {
                return "{D7AB2789-EF3A-4E03-8634-CCBDE57E5AD47}";
            }
        }
        [CreateNew]
        public frmLabPerformancePresenter Presenter
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
            ddlLocation.DataSource = _presenter.GetLaboratories();
            ddlLocation.DataBind();
        }

        private void GetLabEIDRejectionbyYear()
        {
            if (txtdatefrom.Text == "" || txtdateto.Text == "")
                jsonLabEIDRejectionbyYear = _presenter.GetLabEIDRejectionbyYear(ddlLocation.SelectedValue, new DateTime(DateTime.Today.Year - 100, 1, 1), DateTime.Today);

            else
                jsonLabEIDRejectionbyYear = _presenter.GetLabEIDRejectionbyYear(ddlLocation.SelectedValue, DateTime.Parse(txtdatefrom.Text), DateTime.Parse(txtdateto.Text));
            JstringLabEIDRejectionbyYear = Newtonsoft.Json.JsonConvert.SerializeObject(jsonLabEIDRejectionbyYear);
        }
        private void GetLabEIDPoitivityTrendbyYear()
        {
            if (txtdatefrom.Text == "" || txtdateto.Text == "")
                jsonLabEIDPoitivityTrendbyYear = _presenter.GetLabEIDPoitivityTrendbyYear(ddlLocation.SelectedValue, new DateTime(DateTime.Today.Year - 100, 1, 1), DateTime.Today);

            else
                jsonLabEIDPoitivityTrendbyYear = _presenter.GetLabEIDPoitivityTrendbyYear(ddlLocation.SelectedValue, DateTime.Parse(txtdatefrom.Text), DateTime.Parse(txtdateto.Text));
            JstringLabEIDPoitivityTrendbyYear = Newtonsoft.Json.JsonConvert.SerializeObject(jsonLabEIDPoitivityTrendbyYear);
        }
        private void GetLabEIDTestTrendbyYear()
        {
            if (txtdatefrom.Text == "" || txtdateto.Text == "")
                jsonLabEIDTestTrendbyYear = _presenter.GetLabEIDTestTrendbyYear(ddlLocation.SelectedValue, new DateTime(DateTime.Today.Year - 100, 1, 1), DateTime.Today);

            else
                jsonLabEIDTestTrendbyYear = _presenter.GetLabEIDTestTrendbyYear(ddlLocation.SelectedValue, DateTime.Parse(txtdatefrom.Text), DateTime.Parse(txtdateto.Text));
            JstringLabEIDTestTrendbyYear = Newtonsoft.Json.JsonConvert.SerializeObject(jsonLabEIDTestTrendbyYear);
        }

        private void GetLabEIDValidOutcome()
        {
            if (txtdatefrom.Text == "" || txtdateto.Text == "")
                jsonLabEIDValidOutcome = _presenter.GetLabEIDValidOutcome(ddlLocation.SelectedValue, new DateTime(DateTime.Today.Year - 100, 1, 1), DateTime.Today);

            else
                jsonLabEIDValidOutcome = _presenter.GetLabEIDValidOutcome(ddlLocation.SelectedValue, DateTime.Parse(txtdatefrom.Text), DateTime.Parse(txtdateto.Text));
            JstringLabEIDValidOutcome = Newtonsoft.Json.JsonConvert.SerializeObject(jsonLabEIDValidOutcome);
        }
        private void GetLabRejectedSamplebyCountry()
        {
            if (txtdatefrom.Text == "" || txtdateto.Text == "")
                jsonLabRejectedSamplebyCountry = _presenter.GetLabRejectedSamplebyCountry(ddlLocation.SelectedValue, new DateTime(DateTime.Today.Year - 100, 1, 1), DateTime.Today);

            else
                jsonLabRejectedSamplebyCountry = _presenter.GetLabRejectedSamplebyCountry(ddlLocation.SelectedValue, DateTime.Parse(txtdatefrom.Text), DateTime.Parse(txtdateto.Text));
            JstringLabRejectedSamplebyCountry = Newtonsoft.Json.JsonConvert.SerializeObject(jsonLabRejectedSamplebyCountry);
        }
        private void BindLabPerformance()
        {


            if (txtdatefrom.Text == "" && txtdateto.Text == "")
                _Worksheet = _presenter.GetLabPerformance(ddlLocation.SelectedValue, new DateTime(DateTime.Today.Year - 100, 1, 1), DateTime.Today);
            else
                _Worksheet = _presenter.GetLabPerformance(ddlLocation.SelectedValue, DateTime.Parse(txtdatefrom.Text), DateTime.Parse(txtdateto.Text));
            gvLabStats.DataSource = _Worksheet.Tables[0];
            gvLabStats.DataBind();


        }
        protected void btnFilter_Click(object sender, EventArgs e)
        {
            if (ddlLocation.SelectedValue != "0")
            {
                lbllocation.Text = ddlLocation.SelectedItem.Text + " Laboratory";
                //lbloutcomeProFac.Text = "Laboratory Outcome under " + ddlLocation.SelectedItem.Text + " Laboratry";
            }
            else
            {
                lbllocation.Text = "All";
                // lbloutcomeProFac.Text = "Laboratory Outcome";
            }
            BindLabPerformance();
            GetLabEIDRejectionbyYear();
            GetLabEIDPoitivityTrendbyYear();
            GetLabEIDValidOutcome();
            GetLabEIDTestTrendbyYear();
            GetLabRejectedSamplebyCountry();
        }
        protected void gvLabStats_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            gvLabStats.PageIndex = e.NewPageIndex;
            BindLabPerformance();
        }
    }
}