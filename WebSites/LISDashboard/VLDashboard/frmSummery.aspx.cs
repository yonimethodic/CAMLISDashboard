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
using CHAI.LISDashboard.CoreDomain.Report;

namespace CHAI.LISDashboard.Modules.VLDashboard.Views
{

    public partial class frmSummery : POCBasePage, IfrmSummeryView
    {
        private frmSummeryPresenter _presenter;
        public  IList json { get; set; }
        public string Jstring {get;set;}
        public IList jsonVLOutcome { get; set; }
        public string JstringVLOutcome { get; set; }
        public IList jsonVLTestBygender { get; set; }
        public string JstringVLTestBygender { get; set; }
        public IList jsonVLTestByAge { get; set; }
        public string JstringVLTestByAge { get; set; }
        public IList jsonVLTestBytest{ get; set; }
        public string JstringVLTestBytest { get; set; }
        public IList jsonVLTestByprovince { get; set; }
        public string JstringVLTestByprovince { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this._presenter.OnViewInitialized();
                BindLocation();
            }
            this._presenter.OnViewLoaded();
            GetTestTrends();
            GetVLOutCome();
            GetVLTestbyGender();
            GetVLTestbyAge();
            GetVLTestbyReasonfortest();
            GetVLOutcomebyProvince();
            BindSummeryStat();
        }
        public override string PageID
        {

            get
            {
                return "{59C87105-3301-46FD-93AC-D3FAAE5064F7}";
            }
        }
        [CreateNew]
        public frmSummeryPresenter Presenter
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
        private void BindSummeryStat()
        {
            VLStat result = _presenter.VLSummaryStat(txtdatefrom.Text, txtdateto.Text, Convert.ToInt32(ddlLocation.SelectedValue), 2, "Administrator");

            if (result != null)
            {
                lblTotTests.Text = result.Tot_Tests.ToString();
                lblRejection.Text = result.RejectedSamples.ToString() + "%";
                lblDetLes.Text = result.Tot_Detected_LE_1000.ToString();
                lbldetgre.Text = result.Tot_Detected_G_1000.ToString();
                lblSupp.Text = result.Total_Suppressed.ToString() + "%";
                lblError.Text = result.Error.ToString();
            }
            
        }
        private void GetTestTrends()
        {
            if (txtdatefrom.Text == "" && txtdateto.Text == "")
            {
                lblDatefromyear.Text = DateTime.Now.AddYears(-2).Year.ToString();
                lblDatetoyear.Text = DateTime.Now.Year.ToString();
                json = _presenter.GetTestTrends(Convert.ToInt32(ddlLocation.SelectedValue), int.Parse(ddltestreason.SelectedValue), DateTime.Now.AddYears(-2).ToShortDateString(), DateTime.Today.Date.ToShortDateString());
            }
            else
            {
                lblDatefromyear.Text = Convert.ToDateTime(txtdatefrom.Text).Year.ToString();
                lblDatetoyear.Text = Convert.ToDateTime(txtdateto.Text).Year.ToString();
                json = _presenter.GetTestTrends(Convert.ToInt32(ddlLocation.SelectedValue), int.Parse(ddltestreason.SelectedValue), txtdatefrom.Text, txtdateto.Text);
            }
            Jstring = Newtonsoft.Json.JsonConvert.SerializeObject(json);
        }
        private void GetVLOutCome()
        {

            jsonVLOutcome = _presenter.GetVLoutcome(Convert.ToInt32(ddlLocation.SelectedValue), txtdatefrom.Text, txtdateto.Text);
            JstringVLOutcome = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLOutcome);
        }
        private void GetVLTestbyGender()
        {
            jsonVLTestBygender = _presenter.GetVLTestbyGender(Convert.ToInt32(ddlLocation.SelectedValue), txtdatefrom.Text, txtdateto.Text);
            JstringVLTestBygender = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLTestBygender);
        }
        private void GetVLTestbyAge()
        {
            jsonVLTestByAge = _presenter.GetVLTestbyAge(Convert.ToInt32(ddlLocation.SelectedValue), txtdatefrom.Text, txtdateto.Text);
            JstringVLTestByAge = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLTestByAge);
        }
        private void GetVLTestbyReasonfortest()
        {
            jsonVLTestBytest = _presenter.GetVLreasonforTest(Convert.ToInt32(ddlLocation.SelectedValue), txtdatefrom.Text, txtdateto.Text);
            JstringVLTestBytest = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLTestBytest);
        }
        private void GetVLOutcomebyProvince()
        {
            jsonVLTestByprovince = _presenter.GetVLOutcomebyProvince(Convert.ToInt32(ddlLocation.SelectedValue), txtdatefrom.Text, txtdateto.Text);
            JstringVLTestByprovince = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLTestByprovince);
        }

        protected void ddltestreason_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetTestTrends();
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            if (ddlLocation.SelectedValue != "0")
            {
                lbllocation.Text = ddlLocation.SelectedItem.Text + " State/Region";
                lbloutcomeProFac.Text = "Facility Outcome under " + ddlLocation.SelectedItem.Text + " State/Region";
            }
            else
            {
                lbllocation.Text = "National";
                lbloutcomeProFac.Text = "Province Outcome";
            }
            GetTestTrends();
            GetVLOutCome();
            GetVLTestbyGender();
            GetVLTestbyAge();
            GetVLTestbyReasonfortest();
            GetVLOutcomebyProvince();
            BindSummeryStat();
        }
    }
}