using CHAI.LISDashboard.CoreDomain;
using CHAI.LISDashboard.CoreDomain.DataAccess;
using CHAI.LISDashboard.CoreDomain.Report;
using CHAI.LISDashboard.CoreDomain.Users;
using Microsoft.Practices.ObjectBuilder;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CHAI.LISDashboard.Modules.VLDashboard.Views
{
    public partial class FrmProgram : POCBasePage, IFrmProgramView
    {
        private FrmProgramPresenter _presenter;

        public IList jsonVLTestYearly { get; set; }
        public string JstringVLTestYearly { get; set; }
        public IList jsonVLTestQuarterly { get; set; }
        public string JstringVLTestQuarterly { get; set; }
        public IList jsonVLTestMonthly { get; set; }
        public string JstringVLTestMonthly { get; set; }

        public IList jsonVLTestByAgeYearly { get; set; }
        public string JstringVLTestByAgeYearly { get; set; }

        public IList jsonVLTestByGender { get; set; }
        public string JstringVLTestByGender { get; set; }
        public IList jsonVLTestByProvince { get; set; }
        public string JstringVLTestByProvince { get; set; }

        public IList jsonVLTestAgeGroupByProvince { get; set; }
        public string JstringVLTestAgeGroupByProvince { get; set; }

        public IList jsonVLLabByLabInstrumentAbbott { get; set; }
        public string JstringVLLabByLabInstrumentAbbott { get; set; }
        public IList jsonVLLabByLabInstrumentBioCentric { get; set; }
        public string JstringVLLabByLabInstrumentBioCentric { get; set; }
        public IList jsonVLLabByLabInstrumentGeneXpert { get; set; }
        public string JstringVLLabByLabInstrumentGeneXpert { get; set; }
        //public IList jsonVLLabByLabInstrumentConventional { get; set; }
        //public string JstringVLLabByLabInstrumentConventional { get; set; }
        public IList jsonVLLabByLabInstrumentComparison { get; set; }
        public string JstringVLLabByLabInstrumentComparison { get; set; }
        public IList jsonVLTATTrends { get; set; }
        public string JstringVLTATTrends { get; set; }
        public IList jsonVLTestReasonAll { get; set; }
        public string JstringVLTestReasonAll { get; set; }
        public IList jsonVLTestReasonByAbbott { get; set; }
        public string JstringVLTestReasonByAbbott { get; set; }

        public IList jsonVLTestReasonByBioCentric { get; set; }
        public string JstringVLTestReasonByBioCentric { get; set; }

        public IList jsonVLTestReasonByGeneXpert { get; set; }
        public string JstringVLTestReasonByGeneXpert { get; set; }
        public IList jsonVLSummary { get; set; }
        public string JstringVLSummary { get; set; }
        
        public IList jsonVLTestRejectByProvince { get; set; }
        public string JstringVLTestRejectByProvince { get; set; }        

        //public string filter_criteria { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this._presenter.OnViewInitialized();
                BindLocation();
                PopulateYears();
                //BindInstruments();
                
                GetVLTestYearly();
                GetVLTestQuarterly();
                GetVLTestMonthly();

                GetVLTestByAgeYearly();
                GetVLTestByGenderOutcome();
                GetVLTestByProvince();
                //GetVLTestAgeGroupByProvince();
                GetVLTestReasonByLab();

                GetVLLabByLabInstruments();
                GetVLLabByLabInstrumentComparison();

                //GetVLTATTrends();

                //this.BindSummaryStat();
                this.GetVLSummary();
                //this.filter_criteria = "(" + ddlYearFrom.SelectedValue + " - " + ddlYearTo.SelectedValue + ")";

                this.GetVLTestRejectByProvince();
            }            
            this._presenter.OnViewLoaded();

            ddlYearFrom.DataBind();
            ddlYearTo.DataBind();
        }

        protected override void OnPreRender(EventArgs e)
        {
            
        }

        public override string PageID
        {

            get
            {
                return "{59C87105-3301-46FD-93AC-D3FAAE5064F7}";
            }
        }
        [CreateNew]
        public FrmProgramPresenter Presenter
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
            if (CurrentUser.AppUserRoles[0].Role.Name == "Administrator")
            {
                ddlLocation.DataSource = _presenter.GetProvinces();
                ddlLocation.DataBind();
            }
            else
            {
                ReportDao dao = new ReportDao();
                DataSet infoDS = dao.GetUserLocationsInfo(CurrentUser.Id);
                DataTable table = infoDS.Tables[0];

                var distinctValues = table.AsEnumerable()
                            .Select(row => new
                            {
                                attrib_name1 = row.Field<int>("ProvinceId"),
                                attrib_name2 = row.Field<string>("ProvinceName")
                            })
                            .Distinct();
                DataTable dt = new DataTable("Location");
                dt.Columns.Add("ProvinceId");
                dt.Columns.Add("ProvinceName");
                foreach (var row in distinctValues)
                {
                    ddlLocation.Items.Add(new ListItem(row.attrib_name2, row.attrib_name1.ToString()));
                }
            }            
        }

        //private void BindInstruments()
        //{
        //    ddlLabInstrument.DataSource = _presenter.GetLabInstruments();
        //    ddlLabInstrument.DataValueField = "Id";
        //    ddlLabInstrument.DataTextField = "LabInstrumentname";
        //    ddlLabInstrument.DataBind();
        //}

        private void PopulateYears()
        {
            // Year Picker for Lab Performance History            
            //var startYear = 2017;
            //var currentYear = DateTime.Now.Year;
            //for (var i = 0; i < currentYear - startYear + 1; i++)
            //{
            //    ddlYearFrom.Items.Add((startYear + i).ToString());
            //    ddlYearTo.Items.Add((startYear + i).ToString());
            //    //if ((startYear + i) == currentYear)
            //    //    ddlYear.Items.Add((startYear + i).ToString());                        
            //    //else
            //    //        $(this).append('<option value="' + (startYear + i) + '">' + (startYear + i) + '</option>');
            //    //alert(startYear + i);
            //}
            ////ddlYearFrom.SelectedValue = currentYear.ToString();
            //ddlYearTo.SelectedValue = currentYear.ToString();

            // Year Picker for Lab Performance History
            var startYear = DateTime.Now.Year;
            for (var i = startYear; i >= 2018; i--)
            {
                ddlYearFrom.Items.Add((i).ToString());
                ddlYearTo.Items.Add((i).ToString());
            }
            ddlYearTo.SelectedValue = startYear.ToString();
        }        

        private void GetVLTestYearly()
        {
            jsonVLTestYearly = _presenter.GetVLTestYearly(                
                Convert.ToInt32(ddlLocation.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name);
            JstringVLTestYearly = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLTestYearly);
        }

        private void GetVLTestQuarterly()
        {
            jsonVLTestQuarterly = _presenter.GetVLTestQuarterly(
                Convert.ToInt32(ddlLocation.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name);
            JstringVLTestQuarterly = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLTestQuarterly);
        }

        private void GetVLTestMonthly()
        {
            jsonVLTestMonthly = _presenter.GetVLTestMonthly(
                Convert.ToInt32(ddlLocation.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name);
            JstringVLTestMonthly = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLTestMonthly);
        }

        private void GetVLTestByAgeYearly()
        {
            jsonVLTestByAgeYearly = _presenter.GetVLTestByAgeYearly(
                Convert.ToInt32(ddlLocation.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name);
            JstringVLTestByAgeYearly = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLTestByAgeYearly);
        }

        private void GetVLTestByGenderOutcome()
        {
            jsonVLTestByGender = _presenter.GetVLTestByGenderOutcome(
                Convert.ToInt32(ddlLocation.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name);
            JstringVLTestByGender = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLTestByGender);
        }

        private void GetVLTestByProvince()
        {
            jsonVLTestByProvince = _presenter.GetVLTestByProvince(
                Convert.ToInt32(ddlLocation.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name);
            JstringVLTestByProvince = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLTestByProvince);
        }

        //private void GetVLTestAgeGroupByProvince()
        //{
        //    jsonVLTestAgeGroupByProvince = _presenter.GetVLTestAgeGroupByProvince(
        //        Convert.ToInt32(ddlLocation.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name);
        //    JstringVLTestAgeGroupByProvince = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLTestAgeGroupByProvince);
        //}

        private void GetVLTestReasonByLab()
        {
            jsonVLTestReasonAll = _presenter.GetVLTestAllInstrumentsByLab(
                Convert.ToInt32(ddlLocation.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name);
            JstringVLTestReasonAll = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLTestReasonAll);

            //Abbott
            int labInstruId = 7;
            jsonVLTestReasonByAbbott = _presenter.GetVLTestByLab(
                Convert.ToInt32(ddlLocation.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name, labInstruId);
            JstringVLTestReasonByAbbott= Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLTestReasonByAbbott);

            //BioCentric
            labInstruId = 8;
            jsonVLTestReasonByBioCentric = _presenter.GetVLTestByLab(
                Convert.ToInt32(ddlLocation.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name, labInstruId);
            JstringVLTestReasonByBioCentric = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLTestReasonByBioCentric);

            //GeneXpert
            labInstruId = 9;
            jsonVLTestReasonByGeneXpert = _presenter.GetVLTestByLab(
                Convert.ToInt32(ddlLocation.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name, labInstruId);
            JstringVLTestReasonByGeneXpert = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLTestReasonByGeneXpert);
        }

        private void GetVLLabByLabInstruments()
        {
            //Abbott
            int labInstruId = 7;
            jsonVLLabByLabInstrumentAbbott = _presenter.GetVLLabByLabInstrument(
                Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name, labInstruId);
            JstringVLLabByLabInstrumentAbbott = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLLabByLabInstrumentAbbott);

            //BioCentric
            labInstruId = 8;
            jsonVLLabByLabInstrumentBioCentric = _presenter.GetVLLabByLabInstrument(
                Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name, labInstruId);
            JstringVLLabByLabInstrumentBioCentric = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLLabByLabInstrumentBioCentric);            

            //GeneXpert
            labInstruId = 9;
            jsonVLLabByLabInstrumentGeneXpert = _presenter.GetVLLabByLabInstrument(
                Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name, labInstruId);
            JstringVLLabByLabInstrumentGeneXpert = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLLabByLabInstrumentGeneXpert);

            //Conventional PCR
            //labInstruId = 5;
            //jsonVLLabByLabInstrumentConventional = _presenter.GetVLLabByLabInstrument(
            //    Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name, labInstruId);
            //JstringVLLabByLabInstrumentConventional = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLLabByLabInstrumentConventional);
        }

        private void GetVLLabByLabInstrumentComparison()
        {            
            jsonVLLabByLabInstrumentComparison = _presenter.GetVLLabByLabInstrumentComparison(
                Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name);
            JstringVLLabByLabInstrumentComparison = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLLabByLabInstrumentComparison);            
        }

        private void GetVLTATTrends()
        {
            jsonVLTATTrends = _presenter.GetVLTurnAroundTime(
                Convert.ToInt32(ddlLocation.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name);
            JstringVLTATTrends = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLTATTrends);
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            if (ddlLocation.SelectedValue != "0")
            {
                lbllocation.Text = string.Format("{0} / {1}", ddlLocation.Items[0].Text, ddlLocation.SelectedItem.Text);
            }
            else
            {
                lbllocation.Text = string.Format("{0}", ddlLocation.Items[0].Text);
            }
            
            GetVLTestYearly();
            GetVLTestQuarterly();
            GetVLTestMonthly();

            GetVLTestByAgeYearly();
            GetVLTestByGenderOutcome();
            GetVLTestByProvince();
            //GetVLTestAgeGroupByProvince();
            GetVLTestReasonByLab();

            GetVLLabByLabInstruments();
            GetVLLabByLabInstrumentComparison();

            //GetVLTATTrends();

            //this.BindSummaryStat();
            this.GetVLSummary();
            //this.filter_criteria = "(" + ddlYearFrom.SelectedValue + " - " + ddlYearTo.SelectedValue + ")";

            this.GetVLTestRejectByProvince();
        }

        private void GetVLSummary()
        {
            jsonVLSummary = _presenter.GetVLSummary(Convert.ToInt32(ddlLocation.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name);//, DateTime.Parse(txtdatefrom.Text), DateTime.Parse(txtdateto.Text));
            JstringVLSummary = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLSummary);
        }

        protected void btnLabFilter_Click(object sender, EventArgs e)
        {
            //Abbott
            int labInstruId = 7;
            jsonVLLabByLabInstrumentAbbott = _presenter.GetVLLabByLabInstrument(
                Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name, labInstruId);
            JstringVLLabByLabInstrumentAbbott = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLLabByLabInstrumentAbbott);

            //BioCentric
            labInstruId = 8;
            jsonVLLabByLabInstrumentBioCentric = _presenter.GetVLLabByLabInstrument(
                Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name, labInstruId);
            JstringVLLabByLabInstrumentBioCentric = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLLabByLabInstrumentBioCentric);

            //GeneXpert
            labInstruId = 9;
            jsonVLLabByLabInstrumentGeneXpert = _presenter.GetVLLabByLabInstrument(
                Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name, labInstruId);
            JstringVLLabByLabInstrumentGeneXpert = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLLabByLabInstrumentGeneXpert);

            //Conventional PCR
            //labInstruId = 5;
            //jsonVLLabByLabInstrumentConventional = _presenter.GetVLLabByLabInstrument(
            //    Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name, labInstruId);
            //JstringVLLabByLabInstrumentConventional = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLLabByLabInstrumentConventional);
        }

        //private void BindSummaryStat()
        //{
        //    VLStat result = _presenter.VLSummaryStat(ddlYearFrom.Text, ddlYearTo.Text, Convert.ToInt32(ddlLocation.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name);

        //    if (result != null)
        //    {
        //        //lblNoOfSampleReceived.Text = result.No_Sample_Recieved.ToString();
        //        //lblNoOfRejectedSample.Text = result.RejectedSamples.ToString();
        //        //lblTotTests.Text = result.Tot_Tests.ToString();
        //        //lblTotDetectedLE1000.Text = result.Tot_Detected_LE_1000.ToString();
        //        //lblTotDetectedG1000.Text = result.Tot_Detected_G_1000.ToString();
        //        //lblTotSuppressed.Text = result.Total_Suppressed.ToString("0.##");

        //        //lblRateDectedLE1000.Text = result.Rate_Detected_LE_1000.ToString("0.##");                
        //        //lblRateDectedG1000.Text = result.Rate_Detected_G_1000.ToString("0.##");
        //        //lblRateError.Text = result.Rate_Error.ToString("0.##");                
                
        //        //lblRejection.Text = result.RejectedSamples.ToString() + "%";
        //        //lblDetLes.Text = result.Tot_Detected_LE_1000.ToString();
        //        //lbldetgre.Text = result.Tot_Detected_G_1000.ToString();
        //        //lblSupp.Text = result.Total_Suppressed.ToString() + "%";

        //        //lblError.Text = result.Error.ToString();
        //    }
        //}

        private void GetVLTestRejectByProvince()
        {
            jsonVLTestRejectByProvince = _presenter.GetVLTestRejectByProvince(
                Convert.ToInt32(ddlLocation.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name);
            JstringVLTestRejectByProvince = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLTestRejectByProvince);
        }

        private AppUser CurrentUser
        {
            get { return ((ChaiPrincipal)HttpContext.Current.User).CurrentAppUser; }
        }

        //public string FromYear
        //{
        //    get {
        //        if (ddlYearFrom.SelectedIndex > -1)
        //            return ddlYearFrom.SelectedItem.Text;
        //        else
        //            return "";
        //    }
        //}

        //public string ToYear
        //{
        //    get
        //    {
        //        if (ddlYearTo.SelectedIndex > -1)
        //            return ddlYearTo.SelectedItem.Text;
        //        else
        //            return "";
        //    }
        //}
    }
}