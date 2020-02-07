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
    public partial class FrmLab : POCBasePage, IFrmLabView
    {
        private FrmLabPresenter _presenter;

        public IList jsonVLTestYearly { get; set; }
        public string JstringVLTestYearly { get; set; }
        public IList jsonVLTestQuarterly { get; set; }
        public string JstringVLTestQuarterly { get; set; }
        public IList jsonVLTestMonthly { get; set; }
        public string JstringVLTestMonthly { get; set; }

        public IList jsonVLTestByAgeYearly { get; set; }
        public string JstringVLTestByAgeYearly { get; set; }

        public IList jsonVLTestAgeGroupByProvince { get; set; }
        public string JstringVLTestAgeGroupByProvince { get; set; }

        public IList jsonVLTestByGender { get; set; }
        public string JstringVLTestByGender { get; set; }
        public IList jsonVLTestByProvince { get; set; }
        public string JstringVLTestByProvince { get; set; }

        public IList jsonVLTestRejectByProvince { get; set; }
        public string JstringVLTestRejectByProvince { get; set; }        
        public IList jsonVLTestByLabFacility { get; set; }
        public string JstringVLTestByLabFaclility { get; set; }
        public IList jsonVLTestReasonAll { get; set; }
        public string JstringVLTestReasonAll { get; set; }
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
        //public IList jsonVLTATTrends { get; set; }
        //public string JstringVLTATTrends { get; set; }

        public IList jsonVLTestReasonByAbbott { get; set; }
        public string JstringVLTestReasonByAbbott { get; set; }

        public IList jsonVLTestReasonByBioCentric { get; set; }
        public string JstringVLTestReasonByBioCentric { get; set; }

        public IList jsonVLTestReasonByGeneXpert { get; set; }
        public string JstringVLTestReasonByGeneXpert { get; set; }

        public IList jsonVLTurnaroundbyYear { get; set; }
        public string JstringVLTurnaroundbyYear { get; set; }

        public IList jsonVLTurnaroundbyQuarter { get; set; }
        public string JstringVLTurnaroundbyQuarter { get; set; }

        public IList jsonVLSummary { get; set; }
        public string JstringVLSummary { get; set; }

        //public string filter_criteria { get; set; }

        //private string labCodes = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this._presenter.OnViewInitialized();
                BindLaboratories();
                PopulateYears();
                //BindUserInfo();
                //BindInstruments();

                //GetLabCodes();
                GetVLTestYearly();
                GetVLTestQuarterly();
                GetVLTestMonthly();

                GetVLTestByAgeYearly();
                GetVLTestByGenderOutcome();
                GetVLTestByProvince();
                GetVLTestRejectByProvince();
                //GetVLTestAgeGroupByProvince();
                GetVLTestReasonByLab();

                GetVLLabByLabInstruments();
                GetVLLabByLabInstrumentComparison();

                //GetVLTATTrends();

                GetVLTestByStateRegionFacility();
                //this.BindSummaryStat();

                GetVLTurnaroundbyYear();
                GetVLTurnaroundbyQuarter();
                this.GetVLSummary();
                ////this.filter_criteria = "(" + ddlYearFrom.SelectedValue + " - " + ddlYearTo.SelectedValue + ")";
            }
            this._presenter.OnViewLoaded();

            //divNational.Visible = true;
            //ddlYearFrom.DataBind();
            //ddlYearTo.DataBind();
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
        public FrmLabPresenter Presenter
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

        private void BindLaboratories()
        {
            if (CurrentUser.AppUserRoles[0].Role.Name == "Administrator"
                || CurrentUser.AppUserRoles[0].Role.Name == "SuperUser")
            {
                ddlLab.DataSource = _presenter.GetLabratories();
                ddlLab.DataValueField = "LabCode";
                ddlLab.DataTextField = "Description";
                ddlLab.DataBind();
            }
            else
            {
                ReportDao dao = new ReportDao();
                DataSet infoDS = dao.GetUserLocationsInfo(CurrentUser.Id);
                DataTable table = infoDS.Tables[0];                

                ddlLab.DataSource = table;
                ddlLab.DataValueField = "LabCode";
                ddlLab.DataTextField = "LaboratoryName";
                ddlLab.DataBind();
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
            //var startYear = DateTime.Now.Year;
            //for (var i = startYear; i >= 2018; i--)
            //{
            //    ddlYearFrom.Items.Add((i).ToString());
            //    ddlYearTo.Items.Add((i).ToString());
            //}
            //ddlYearTo.SelectedValue = startYear.ToString();

            txtStartDate.Text = DateTime.Today.ToString("MM") + "/" + DateTime.Today.Year;
            hdnStartDate.Value = DateTime.Today.Year.ToString();
            txtEndDate.Text = DateTime.Today.ToString("MM") + "/" + DateTime.Today.Year;
        }

        //private void BindUserInfo()
        //{
        //    //DataSet infoDS = _presenter.GetLabInfo(CurrentUser.Id);
        //    ReportDao dao = new ReportDao();
        //    DataSet infoDS = dao.GetUserLocationsInfo(CurrentUser.Id);
        //    DataTable table = infoDS.Tables[0];
        //    if (table.Rows.Count > 0)
        //    {
        //        lbllocation.Text = table.Rows[0]["LaboratoryName"].ToString();
        //        ddlLab.SelectedValue = table.Rows[0]["LabCode"].ToString();

        //        if (CurrentUser.AppUserRoles[0].Role.Name == "Administrator" ||
        //            CurrentUser.AppUserRoles[0].Role.Name == "Program")
        //        {
        //            ddlLab.Visible = true;
        //            lbllocation.Visible = false;
        //        }
        //        else
        //        {
        //            ddlLab.Visible = false;
        //            lbllocation.Visible = true;
        //        }
        //    }
        //}

        private void GetVLTestYearly()
        {
            string[] fromDate = txtStartDate.Text.Split(new Char[] { '/' });
            string[] toDate = txtEndDate.Text.Split(new Char[] { '/' });
            hdnStartDate.Value = fromDate[1];
            jsonVLTestYearly = _presenter.GetVLTestYearly(
                ddlLab.SelectedValue, Convert.ToInt32(fromDate[1] + fromDate[0]), Convert.ToInt32(toDate[1] + toDate[0]),
                CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name);
            JstringVLTestYearly = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLTestYearly);
        }

        private void GetVLTestQuarterly()
        {
            string[] fromDate = txtStartDate.Text.Split(new Char[] { '/' });
            string[] toDate = txtEndDate.Text.Split(new Char[] { '/' });
            hdnStartDate.Value = fromDate[1];
            jsonVLTestQuarterly = _presenter.GetVLTestQuarterly(
                ddlLab.SelectedValue, Convert.ToInt32(fromDate[1] + fromDate[0]), Convert.ToInt32(toDate[1] + toDate[0]),
                //Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue),
                CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name);
            JstringVLTestQuarterly = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLTestQuarterly);            
        }

        private void GetVLTestMonthly()
        {
            string[] fromDate = txtStartDate.Text.Split(new Char[] { '/' });
            string[] toDate = txtEndDate.Text.Split(new Char[] { '/' });
            hdnStartDate.Value = fromDate[1];
            jsonVLTestMonthly = _presenter.GetVLTestMonthly(
                ddlLab.SelectedValue, Convert.ToInt32(fromDate[1] + fromDate[0]), Convert.ToInt32(toDate[1] + toDate[0]),
                //Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue),
                CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name);
            JstringVLTestMonthly = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLTestMonthly);            
        }

        private void GetVLTestByAgeYearly()
        {
            string[] fromDate = txtStartDate.Text.Split(new Char[] { '/' });
            string[] toDate = txtEndDate.Text.Split(new Char[] { '/' });
            hdnStartDate.Value = fromDate[1];
            jsonVLTestByAgeYearly = _presenter.GetVLTestByAgeYearly(
                ddlLab.SelectedValue, Convert.ToInt32(fromDate[1] + fromDate[0]), Convert.ToInt32(toDate[1] + toDate[0]),
                //Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue),
                CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name);
            JstringVLTestByAgeYearly = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLTestByAgeYearly);
        }

        private void GetVLTestByGenderOutcome()
        {
            string[] fromDate = txtStartDate.Text.Split(new Char[] { '/' });
            string[] toDate = txtEndDate.Text.Split(new Char[] { '/' });
            hdnStartDate.Value = fromDate[1];
            jsonVLTestByGender = _presenter.GetVLTestByGenderOutcome(
                ddlLab.SelectedValue, Convert.ToInt32(fromDate[1] + fromDate[0]), Convert.ToInt32(toDate[1] + toDate[0]),
                //Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue),
                CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name);
            JstringVLTestByGender = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLTestByGender);
        }

        private void GetVLTestByProvince()
        {
            string[] fromDate = txtStartDate.Text.Split(new Char[] { '/' });
            string[] toDate = txtEndDate.Text.Split(new Char[] { '/' });
            hdnStartDate.Value = fromDate[1];
            jsonVLTestByProvince = _presenter.GetVLTestByProvince(
                ddlLab.SelectedValue, Convert.ToInt32(fromDate[1] + fromDate[0]), Convert.ToInt32(toDate[1] + toDate[0]),
                //Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue),
                CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name);
            JstringVLTestByProvince = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLTestByProvince);
        }

        private void GetVLTestRejectByProvince()
        {
            string[] fromDate = txtStartDate.Text.Split(new Char[] { '/' });
            string[] toDate = txtEndDate.Text.Split(new Char[] { '/' });
            hdnStartDate.Value = fromDate[1];
            jsonVLTestRejectByProvince = _presenter.GetVLTestRejectByProvinceForLab(
                ddlLab.SelectedValue, Convert.ToInt32(fromDate[1] + fromDate[0]), Convert.ToInt32(toDate[1] + toDate[0]),
                //Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue),
                CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name);
            JstringVLTestRejectByProvince = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLTestRejectByProvince);
        }

        //private void GetVLTestAgeGroupByProvince()
        //{
        //    jsonVLTestAgeGroupByProvince = _presenter.GetVLTestAgeGroupByProvince(
        //        ddlLab.SelectedValue, Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name);
        //    JstringVLTestAgeGroupByProvince = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLTestAgeGroupByProvince);
        //}
        private void GetVLTestByStateRegionFacility()
        {
            string[] fromDate = txtStartDate.Text.Split(new Char[] { '/' });
            string[] toDate = txtEndDate.Text.Split(new Char[] { '/' });
            hdnStartDate.Value = fromDate[1];
            jsonVLTestByLabFacility = _presenter.GetVLTestByStateRegionFacility(
                ddlLab.SelectedValue, Convert.ToInt32(fromDate[1] + fromDate[0]), Convert.ToInt32(toDate[1] + toDate[0]),
                //Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue),
                CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name);
            JstringVLTestByLabFaclility = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLTestByLabFacility);
        }

        private void GetVLTestReasonByLab()
        {
            string[] fromDate = txtStartDate.Text.Split(new Char[] { '/' });
            string[] toDate = txtEndDate.Text.Split(new Char[] { '/' });
            hdnStartDate.Value = fromDate[1];
            jsonVLTestReasonAll = _presenter.GetVLTestAllInstrumentsByLab(
                ddlLab.SelectedValue, Convert.ToInt32(fromDate[1] + fromDate[0]), Convert.ToInt32(toDate[1] + toDate[0]),
                //Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue),
                CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name);
            JstringVLTestReasonAll = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLTestReasonAll);

            //Abbott
            int labInstruId = 7;
            jsonVLTestReasonByAbbott = _presenter.GetVLTestByLab(
                ddlLab.SelectedValue, Convert.ToInt32(fromDate[1] + fromDate[0]), Convert.ToInt32(toDate[1] + toDate[0]),
                //Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue),
                CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name, labInstruId);
            JstringVLTestReasonByAbbott= Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLTestReasonByAbbott);

            //BioCentric
            labInstruId = 8;
            jsonVLTestReasonByBioCentric = _presenter.GetVLTestByLab(
                ddlLab.SelectedValue, Convert.ToInt32(fromDate[1] + fromDate[0]), Convert.ToInt32(toDate[1] + toDate[0]),
                //Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue),
                CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name, labInstruId);
            JstringVLTestReasonByBioCentric = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLTestReasonByBioCentric);

            //GeneXpert
            labInstruId = 9;
            jsonVLTestReasonByGeneXpert = _presenter.GetVLTestByLab(
                ddlLab.SelectedValue, Convert.ToInt32(fromDate[1] + fromDate[0]), Convert.ToInt32(toDate[1] + toDate[0]),
                //Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue),
                CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name, labInstruId);
            JstringVLTestReasonByGeneXpert = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLTestReasonByGeneXpert);
        }

        private void GetVLLabByLabInstruments()
        {
            string[] fromDate = txtStartDate.Text.Split(new Char[] { '/' });
            string[] toDate = txtEndDate.Text.Split(new Char[] { '/' });
            hdnStartDate.Value = fromDate[1];
            //Abbott
            int labInstruId = 7;
            jsonVLLabByLabInstrumentAbbott = _presenter.GetVLLabByLabInstrument(ddlLab.SelectedValue,
                Convert.ToInt32(fromDate[1] + fromDate[0]), Convert.ToInt32(toDate[1] + toDate[0]),
                //Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue),
                CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name, labInstruId);
            JstringVLLabByLabInstrumentAbbott = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLLabByLabInstrumentAbbott);

            //BioCentric
            labInstruId = 8;
            jsonVLLabByLabInstrumentBioCentric = _presenter.GetVLLabByLabInstrument(ddlLab.SelectedValue,
                Convert.ToInt32(fromDate[1] + fromDate[0]), Convert.ToInt32(toDate[1] + toDate[0]),
                //Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue),
                CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name, labInstruId);
            JstringVLLabByLabInstrumentBioCentric = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLLabByLabInstrumentBioCentric);            

            //GeneXpert
            labInstruId = 9;
            jsonVLLabByLabInstrumentGeneXpert = _presenter.GetVLLabByLabInstrument(ddlLab.SelectedValue,
                Convert.ToInt32(fromDate[1] + fromDate[0]), Convert.ToInt32(toDate[1] + toDate[0]),
                //Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue),
                CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name, labInstruId);
            JstringVLLabByLabInstrumentGeneXpert = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLLabByLabInstrumentGeneXpert);

            //Conventional PCR
            //labInstruId = 5;
            //jsonVLLabByLabInstrumentConventional = _presenter.GetVLLabByLabInstrument(
            //    Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name, labInstruId);
            //JstringVLLabByLabInstrumentConventional = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLLabByLabInstrumentConventional);
        }

        private void GetVLLabByLabInstrumentComparison()
        {
            string[] fromDate = txtStartDate.Text.Split(new Char[] { '/' });
            string[] toDate = txtEndDate.Text.Split(new Char[] { '/' });
            hdnStartDate.Value = fromDate[1];
            jsonVLLabByLabInstrumentComparison = _presenter.GetVLLabByLabInstrumentComparison(
                ddlLab.SelectedValue, //Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue),
                Convert.ToInt32(fromDate[1] + fromDate[0]), Convert.ToInt32(toDate[1] + toDate[0]),
                CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name);
            JstringVLLabByLabInstrumentComparison = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLLabByLabInstrumentComparison);            
        }

        //private void GetVLTATTrends()
        //{
        //    jsonVLTATTrends = _presenter.GetVLTurnAroundTime(
        //        Convert.ToInt32(ddlLocation.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name);
        //    JstringVLTATTrends = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLTATTrends);
        //}

        private void GetVLTurnaroundbyYear()
        {
            string[] fromDate = txtStartDate.Text.Split(new Char[] { '/' });
            string[] toDate = txtEndDate.Text.Split(new Char[] { '/' });
            hdnStartDate.Value = fromDate[1];
            jsonVLTurnaroundbyYear = _presenter.GetVLTurnaroundbyYear(ddlLab.SelectedValue,
                //Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue),
                Convert.ToInt32(fromDate[1] + fromDate[0]), Convert.ToInt32(toDate[1] + toDate[0]),
                CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name);//, DateTime.Parse(txtdatefrom.Text), DateTime.Parse(txtdateto.Text));
            JstringVLTurnaroundbyYear = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLTurnaroundbyYear);
        }

        private void GetVLTurnaroundbyQuarter()
        {
            string[] fromDate = txtStartDate.Text.Split(new Char[] { '/' });
            string[] toDate = txtEndDate.Text.Split(new Char[] { '/' });
            hdnStartDate.Value = fromDate[1];
            jsonVLTurnaroundbyQuarter = _presenter.GetVLTurnaroundbyQuarter(ddlLab.SelectedValue,
                //Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue),
                Convert.ToInt32(fromDate[1] + fromDate[0]), Convert.ToInt32(toDate[1] + toDate[0]),
                CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name);//, DateTime.Parse(txtdatefrom.Text), DateTime.Parse(txtdateto.Text));
            JstringVLTurnaroundbyQuarter = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLTurnaroundbyQuarter);
        }

        private void GetVLSummary()
        {
            string[] fromDate = txtStartDate.Text.Split(new Char[] { '/' });
            string[] toDate = txtEndDate.Text.Split(new Char[] { '/' });
            hdnStartDate.Value = fromDate[1];
            jsonVLSummary = _presenter.GetVLSummary(ddlLab.SelectedValue,
                //Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue),
                Convert.ToInt32(fromDate[1] + fromDate[0]), Convert.ToInt32(toDate[1] + toDate[0]),
                CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name);//, DateTime.Parse(txtdatefrom.Text), DateTime.Parse(txtdateto.Text));
            JstringVLSummary = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLSummary);
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            //GetVLTestYearly();
            //GetVLTestQuarterly();
            //GetVLTestMonthly();
            //GetVLTestByAgeYearly();
            //GetVLTestByGenderOutcome();
            //GetVLTestByProvince();
            //GetVLTestRejectByProvince();
            //GetVLTestReasonByLab();

            //GetVLLabByLabInstruments();
            //GetVLLabByLabInstrumentComparison();

            //GetVLTestByStateRegionFacility();
            //GetVLTurnaroundbyYear();
            //GetVLTurnaroundbyQuarter();
            //this.GetVLSummary();

            ///////////////////////////////////////////////////

            //if (ddlLocation.SelectedValue != "0")
            //{
            //    lbllocation.Text = "National / " + ddlLocation.SelectedItem.Text;                
            //}
            //else
            //{
            //    lbllocation.Text = "National";
            //}
            //GetLabCodes();
            GetVLTestYearly();
            GetVLTestQuarterly();
            GetVLTestMonthly();

            GetVLTestByAgeYearly();
            GetVLTestByGenderOutcome();
            GetVLTestByProvince();
            GetVLTestRejectByProvince();
            ////GetVLTestAgeGroupByProvince();
            GetVLTestReasonByLab();

            GetVLLabByLabInstruments();
            GetVLLabByLabInstrumentComparison();

            //GetVLTATTrends();
            GetVLTestByStateRegionFacility();
            //this.BindSummaryStat();

            GetVLTurnaroundbyYear();
            GetVLTurnaroundbyQuarter();
            this.GetVLSummary();
            //this.filter_criteria = "(" + ddlYearFrom.SelectedValue + " - " + ddlYearTo.SelectedValue + ")";
        }

        protected void btnLabFilter_Click(object sender, EventArgs e)
        {
            string[] fromDate = txtStartDate.Text.Split(new Char[] { '/' });
            string[] toDate = txtEndDate.Text.Split(new Char[] { '/' });
            hdnStartDate.Value = fromDate[1];
            //Abbott
            int labInstruId = 7;
            jsonVLLabByLabInstrumentAbbott = _presenter.GetVLLabByLabInstrument(
                ddlLab.SelectedValue,
                //Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue),
                Convert.ToInt32(fromDate[1] + fromDate[0]), Convert.ToInt32(toDate[1] + toDate[0]),
                CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name, labInstruId);
            JstringVLLabByLabInstrumentAbbott = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLLabByLabInstrumentAbbott);

            //BioCentric
            labInstruId = 8;
            jsonVLLabByLabInstrumentBioCentric = _presenter.GetVLLabByLabInstrument(
                ddlLab.SelectedValue,
                //Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue),
                Convert.ToInt32(fromDate[1] + fromDate[0]), Convert.ToInt32(toDate[1] + toDate[0]),
                CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name, labInstruId);
            JstringVLLabByLabInstrumentBioCentric = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLLabByLabInstrumentBioCentric);

            //GeneXpert
            labInstruId = 9;
            jsonVLLabByLabInstrumentGeneXpert = _presenter.GetVLLabByLabInstrument(
                ddlLab.SelectedValue,
                //Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue),
                Convert.ToInt32(fromDate[1] + fromDate[0]), Convert.ToInt32(toDate[1] + toDate[0]),
                CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name, labInstruId);
            JstringVLLabByLabInstrumentGeneXpert = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLLabByLabInstrumentGeneXpert);

            //Conventional PCR
            //labInstruId = 5;
            //jsonVLLabByLabInstrumentConventional = _presenter.GetVLLabByLabInstrument(
            //    Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name, labInstruId);
            //JstringVLLabByLabInstrumentConventional = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLLabByLabInstrumentConventional);
        }

        //private void BindSummaryStat()
        //{
        //    VLStat result = _presenter.VLSummaryStat(ddlYearFrom.Text, ddlYearTo.Text, ddlLab.SelectedValue, CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name);

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

        //private void GetLabCodes()
        //{
        //    if (ddlLab.SelectedValue != "0")            
        //        labCodes = ddlLab.SelectedValue.Trim();
        //    else
        //    {
        //        //foreach (ListItem lst in ddlLab.Items)
        //        //{
        //        //    labCodes += (labCodes == string.Empty) ? "'" + lst.Value + "'" : ", '" + lst.Value + "'";
        //        //}
        //        labCodes = "0";
        //    }                

        //    //if (ddlLab.SelectedValue != "0")
        //    //{
        //    //    foreach (ListItem lst in ddlLab.Items)
        //    //    {
        //    //        if (lst.Selected)
        //    //        {
        //    //            labCodes += (labCodes == string.Empty) ? "'" + lst.Value + "'" : ", '" + lst.Value + "'";
        //    //        }
        //    //    }
        //    //}
        //    //else
        //    //    labCodes = ddlLab.SelectedValue.Trim();
        //}

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