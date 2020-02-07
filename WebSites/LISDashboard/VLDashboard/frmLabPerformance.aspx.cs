using CHAI.LISDashboard.CoreDomain;
using CHAI.LISDashboard.CoreDomain.DataAccess;
using CHAI.LISDashboard.CoreDomain.Users;
using CHAI.LISDashboard.Modules.Shell;
using Microsoft.Practices.ObjectBuilder;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CHAI.LISDashboard.Modules.VLDashboard.Views
{
    public partial class frmLabPerformance : POCBasePage, IfrmLabPerformanceView
    {        
        private frmLabPerformancePresenter _presenter;
        private int itemNumber = 0;
        System.Data.DataSet _Worksheet = null;
        public IList jsonVLTestingTrends { get; set; }
        public string JstringVLTestingTrends { get; set; }
        public string JstringVLRejectionTrends { get; set; }
        public IList jsonVLRejectionTrends { get; set; }
        public IList jsonVLLAbSampleTypeTrends { get; set; }
        public string JstringVLLAbSampleTypeTrends { get; set; }
        public IList jsonVLLAbGenderTrends { get; set; }
        public string JstringVLLAbGenderTrends { get; set; }
        public IList jsonVLLAbAgeTrends { get; set; }
        public string JstringVLLAbAgeTrends { get; set; }
        public IList jsonVLLAbOutcome { get; set; }
        public string JstringVLLAbOutcome { get; set; }
        public IList jsonVLLAbNationalRejectionRes { get; set; }
        public string JstringVLLAbNationalRejectionRes { get; set; }
        public IList jsonVLLAbOutcomebyLab { get; set; }
        public string JstringVLLAbOutcomebyLab { get; set; }
        public IList jsonVLLAbSuppressionTrendbyLab { get; set; }
        public string JstringVLLAbSuppressionTrendbyLab { get; set; }
        public IList jsonVLLAbValidTestingTrendsbyLab { get; set; }
        public string JstringVLLAbValidTestingTrendsbyLab { get; set; }
        public IList jsonVLLAbRejectedTrendbyLab { get; set; }
        public string JstringVLLAbRejectedTrendbyLab { get; set; }
        public IList jsonVLLAbRejectionReasonbyLab { get; set; }
        public string JstringVLLabRejectionReasonbyLab { get; set; }
        public string  datefrom { get; set; }
        public string  dateto { get; set; }

        //Added by ZaySoe on 13-Nov-18
        public AppUser CurrentUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this._presenter.OnViewInitialized();
                BindLaboratories();
            }
            this._presenter.OnViewLoaded();
            BindLabStatData();
            GetVLTestingTrend();
            GetVLLABRejectionTrends();
            GetVLLABSampleTypeTrends();
            GetVLLABGenderTrends();
            GetVLLABAgeTrends();
            GetVLLABOutcome();
            GetVLLABRejectionReasonNational();




        }
        public override string PageID
        {

            get
            {
                return "{59C88995-9301-46FD-93AC-D3FAAE5064F7}";
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

        public void BindLaboratories()
        {
            ddlLab.DataSource = _presenter.GetLabratories();
            ddlLab.DataBind();
        }
        protected void BindLabStatData()
        {
            //Added by ZaySoe on 13-Nov-2018            
            //ChaiPrincipal chaiPrincipal = (ChaiPrincipal)HttpContext.Current.User;
            //AppUser currentUser = chaiPrincipal.CurrentAppUser;

            //Added by ZaySoe on 13-Nov-2018            
            List<UserLocation> locs = (List<UserLocation>)this._presenter.View.CurrentUser.UserLocations;

            AppUser user = this.CurrentUser;

            string labCode = null;
            foreach (UserLocation loc in locs)
            {
                if (!string.IsNullOrEmpty(loc.LabCode))
                    labCode = loc.LabCode;
            }            

            if (txtdatefrom.Text == "" && txtdateto.Text == "")
            {
                lblDatefromyear.Text = DateTime.Now.AddYears(-1).Year.ToString();
                lblDatetoyear.Text = DateTime.Now.Year.ToString();
                _Worksheet = _presenter.VLLabPerStatSummary(DateTime.Now.AddYears(-1).ToShortDateString(), DateTime.Today.Date.ToShortDateString(),txtLabName.Text, labCode);
            }
            else
            {
                lblDatefromyear.Text = Convert.ToDateTime(txtdatefrom.Text).Year.ToString();
                lblDatetoyear.Text = Convert.ToDateTime(txtdateto.Text).Year.ToString();
                _Worksheet = _presenter.VLLabPerStatSummary(txtdatefrom.Text, txtdateto.Text,txtLabName.Text, labCode);
            }
            datefrom = lblDatefromyear.Text;
            dateto = lblDatetoyear.Text;
            gvLabStats.DataSource = _Worksheet.Tables[0];
            gvLabStats.DataBind();
        }
       
        protected string ItemNumber()
        {

            itemNumber++;
            return itemNumber.ToString();
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            if (ddlLab.SelectedValue != "0")
            {
                lblLab.Text = ddlLab.SelectedItem.Text + " Laboratory";
               
            }
            else
            {
                lblLab.Text = "All Labs";
                
            }
            BindLabStatData();
            GetVLTestingTrend();
            GetVLLABRejectionTrends();
            GetVLLABSampleTypeTrends();
            GetVLLABGenderTrends();
            GetVLLABAgeTrends();
            GetVLLABOutcome();
            GetVLLABRejectionReasonNational();
            GetVLLAbOutcomebyLab();
            GetVLLABRejectionReasonlab();
        }

        protected void ddlLab_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlLab.SelectedValue != "0")
            {
                first.Attributes.Add("style", "display:none");
                second.Attributes.Add("style", "display:block");
                lblLab.Text = ddlLab.SelectedItem.Text + " Laboratory";
            }
            else
            {
                first.Attributes.Add("style", "display:block");
                second.Attributes.Add("style", "display:none");
                lblLab.Text = "All Labs";
            }
            GetVLLAbOutcomebyLab();
            GetVLLabperformanceSuppressionTrends();
            GetVLLabValidTestingTrends();
            GetVLLabPerfomaceRejectedTrends();
            GetVLLABRejectionReasonlab();
        }
        
        protected void gvLabStats_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            gvLabStats.PageIndex = e.NewPageIndex;
            BindLabStatData();
        }
        
        protected void txtLabName_TextChanged(object sender, EventArgs e)
        {
            BindLabStatData();
        }
        private void GetVLTestingTrend()
        {
            if (txtdatefrom.Text == "" && txtdateto.Text == "")
            {
                lblDatefromyear.Text = DateTime.Now.AddYears(-1).Year.ToString();
                lblDatetoyear.Text = DateTime.Now.Year.ToString();
                jsonVLTestingTrends = _presenter.GetVLLABTestingTrends(DateTime.Now.AddYears(-1).ToShortDateString(), DateTime.Today.Date.ToShortDateString());
                JstringVLTestingTrends = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLTestingTrends);

            }
            else
            {
                lblDatefromyear.Text = Convert.ToDateTime(txtdatefrom.Text).Year.ToString();
                lblDatetoyear.Text = Convert.ToDateTime(txtdateto.Text).Year.ToString();
                jsonVLTestingTrends = _presenter.GetVLLABTestingTrends(txtdatefrom.Text, txtdateto.Text);
                JstringVLTestingTrends = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLTestingTrends);

            }


            
        }
        private void GetVLLABRejectionTrends()
        {
            if (txtdatefrom.Text == "" && txtdateto.Text == "")
            {
                lblDatefromyear.Text = DateTime.Now.AddYears(-1).Year.ToString();
                lblDatetoyear.Text = DateTime.Now.Year.ToString();
                jsonVLRejectionTrends = _presenter.GetVLLABRejectionTrends(DateTime.Now.AddYears(-1).ToShortDateString(), DateTime.Today.Date.ToShortDateString());
                JstringVLRejectionTrends = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLRejectionTrends);

            }
            else
            {
                lblDatefromyear.Text = Convert.ToDateTime(txtdatefrom.Text).Year.ToString();
                lblDatetoyear.Text = Convert.ToDateTime(txtdateto.Text).Year.ToString();
                jsonVLRejectionTrends = _presenter.GetVLLABRejectionTrends(txtdatefrom.Text, txtdateto.Text);
                JstringVLRejectionTrends = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLRejectionTrends);

            }



        }
        private void GetVLLABSampleTypeTrends()
        {
            if (txtdatefrom.Text == "" && txtdateto.Text == "")
            {
                lblDatefromyear.Text = DateTime.Now.AddYears(-1).Year.ToString();
                lblDatetoyear.Text = DateTime.Now.Year.ToString();
                jsonVLLAbSampleTypeTrends = _presenter.GetVLLABTestbySampleType(DateTime.Now.AddYears(-1).ToShortDateString(), DateTime.Today.Date.ToShortDateString());
                JstringVLLAbSampleTypeTrends = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLLAbSampleTypeTrends);

            }
            else
            {
                lblDatefromyear.Text = Convert.ToDateTime(txtdatefrom.Text).Year.ToString();
                lblDatetoyear.Text = Convert.ToDateTime(txtdateto.Text).Year.ToString();
                jsonVLLAbSampleTypeTrends = _presenter.GetVLLABTestbySampleType(txtdatefrom.Text, txtdateto.Text);
                JstringVLLAbSampleTypeTrends = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLLAbSampleTypeTrends);

            }



        }
        private void GetVLLABGenderTrends()
        {
            if (txtdatefrom.Text == "" && txtdateto.Text == "")
            {
                lblDatefromyear.Text = DateTime.Now.AddYears(-1).Year.ToString();
                lblDatetoyear.Text = DateTime.Now.Year.ToString();
                jsonVLLAbGenderTrends = _presenter.GetVLLABTestbyGender(DateTime.Now.AddYears(-1).ToShortDateString(), DateTime.Today.Date.ToShortDateString());
                JstringVLLAbGenderTrends = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLLAbGenderTrends);

            }
            else
            {
                lblDatefromyear.Text = Convert.ToDateTime(txtdatefrom.Text).Year.ToString();
                lblDatetoyear.Text = Convert.ToDateTime(txtdateto.Text).Year.ToString();
                jsonVLLAbGenderTrends = _presenter.GetVLLABTestbyGender(txtdatefrom.Text, txtdateto.Text);
                JstringVLLAbGenderTrends = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLLAbGenderTrends);

            }
            
        }
        private void GetVLLABAgeTrends()
        {
            if (txtdatefrom.Text == "" && txtdateto.Text == "")
            {
                lblDatefromyear.Text = DateTime.Now.AddYears(-1).Year.ToString();
                lblDatetoyear.Text = DateTime.Now.Year.ToString();
                jsonVLLAbAgeTrends = _presenter.GetVLLABTestbyAge(DateTime.Now.AddYears(-1).ToShortDateString(), DateTime.Today.Date.ToShortDateString());
                JstringVLLAbAgeTrends = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLLAbAgeTrends);

            }
            else
            {
                lblDatefromyear.Text = Convert.ToDateTime(txtdatefrom.Text).Year.ToString();
                lblDatetoyear.Text = Convert.ToDateTime(txtdateto.Text).Year.ToString();
                jsonVLLAbAgeTrends = _presenter.GetVLLABTestbyAge(txtdatefrom.Text, txtdateto.Text);
                JstringVLLAbAgeTrends = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLLAbAgeTrends);

            }



        }
        private void GetVLLABOutcome()
        {
            if (txtdatefrom.Text == "" && txtdateto.Text == "")
            {
                lblDatefromyear.Text = DateTime.Now.AddYears(-1).Year.ToString();
                lblDatetoyear.Text = DateTime.Now.Year.ToString();
                jsonVLLAbOutcome = _presenter.GetVLLABOutcome(DateTime.Now.AddYears(-1).ToShortDateString(), DateTime.Today.Date.ToShortDateString());
                JstringVLLAbOutcome = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLLAbOutcome);

            }
            else
            {
                lblDatefromyear.Text = Convert.ToDateTime(txtdatefrom.Text).Year.ToString();
                lblDatetoyear.Text = Convert.ToDateTime(txtdateto.Text).Year.ToString();
                jsonVLLAbOutcome = _presenter.GetVLLABOutcome(txtdatefrom.Text, txtdateto.Text);
                JstringVLLAbOutcome = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLLAbOutcome);

            }



        }
        private void GetVLLABRejectionReasonNational()
        {
            if (txtdatefrom.Text == "" && txtdateto.Text == "")
            {
                lblDatefromyear.Text = DateTime.Now.AddYears(-1).Year.ToString();
                lblDatetoyear.Text = DateTime.Now.Year.ToString();
                jsonVLLAbNationalRejectionRes = _presenter.GetVLLABRejectionReasonNational(DateTime.Now.AddYears(-1).ToShortDateString(), DateTime.Today.Date.ToShortDateString());
                JstringVLLAbNationalRejectionRes = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLLAbNationalRejectionRes);

            }
            else
            {
                lblDatefromyear.Text = Convert.ToDateTime(txtdatefrom.Text).Year.ToString();
                lblDatetoyear.Text = Convert.ToDateTime(txtdateto.Text).Year.ToString();
                jsonVLLAbNationalRejectionRes = _presenter.GetVLLABRejectionReasonNational(txtdatefrom.Text, txtdateto.Text);
                JstringVLLAbNationalRejectionRes = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLLAbNationalRejectionRes);

            }



        }
        private void GetVLLAbOutcomebyLab()
        {
            if (txtdatefrom.Text == "" && txtdateto.Text == "")
            {
                lblDatefromyear.Text = DateTime.Now.AddYears(-1).Year.ToString();
                lblDatetoyear.Text = DateTime.Now.Year.ToString();
                jsonVLLAbOutcomebyLab = _presenter.GetVLLABOutcomeTrends(DateTime.Now.AddYears(-1).ToShortDateString(), DateTime.Today.Date.ToShortDateString(),ddlLab.SelectedValue);
                JstringVLLAbOutcomebyLab = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLLAbOutcomebyLab);

            }
            else
            {
                lblDatefromyear.Text = Convert.ToDateTime(txtdatefrom.Text).Year.ToString();
                lblDatetoyear.Text = Convert.ToDateTime(txtdateto.Text).Year.ToString();
                jsonVLLAbOutcomebyLab = _presenter.GetVLLABTestbyAge(txtdatefrom.Text, txtdateto.Text);
                JstringVLLAbOutcomebyLab = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLLAbOutcomebyLab);

            }



        }
        private void GetVLLabperformanceSuppressionTrends()
        {

            jsonVLLAbSuppressionTrendbyLab = _presenter.GetVLLabperformanceSuppressionTrends(ddlLab.SelectedValue);
            JstringVLLAbSuppressionTrendbyLab = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLLAbSuppressionTrendbyLab);
        }
        private void GetVLLabValidTestingTrends()
        {

            jsonVLLAbValidTestingTrendsbyLab = _presenter.GetVLLabValidTestingTrends(ddlLab.SelectedValue);
            JstringVLLAbValidTestingTrendsbyLab = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLLAbValidTestingTrendsbyLab);
        }
        private void GetVLLabPerfomaceRejectedTrends()
        {

            jsonVLLAbRejectedTrendbyLab = _presenter.GetVLLabPerfomaceRejectedTrends(ddlLab.SelectedValue);
            JstringVLLAbRejectedTrendbyLab = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLLAbRejectedTrendbyLab);
        }
        private void GetVLLABRejectionReasonlab()
        {
            if (txtdatefrom.Text == "" && txtdateto.Text == "")
            {
                lblDatefromyear.Text = DateTime.Now.AddYears(-1).Year.ToString();
                lblDatetoyear.Text = DateTime.Now.Year.ToString();
                jsonVLLAbRejectionReasonbyLab = _presenter.GetVLLABRejectionReasonbyLab(DateTime.Now.AddYears(-1).ToShortDateString(), DateTime.Today.Date.ToShortDateString(), ddlLab.SelectedValue);
                JstringVLLabRejectionReasonbyLab = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLLAbRejectionReasonbyLab);

            }
            else
            {
                lblDatefromyear.Text = Convert.ToDateTime(txtdatefrom.Text).Year.ToString();
                lblDatetoyear.Text = Convert.ToDateTime(txtdateto.Text).Year.ToString();
                jsonVLLAbRejectionReasonbyLab = _presenter.GetVLLABRejectionReasonbyLab(txtdatefrom.Text, txtdateto.Text, ddlLab.SelectedValue);
                JstringVLLabRejectionReasonbyLab = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLLAbRejectionReasonbyLab);

            }
        }

        AppUser IfrmLabPerformanceView.CurrentUser
        {
            get
            {
                return CurrentUser;
            }
            set
            {
                CurrentUser = value;
            }
        }
    }
}