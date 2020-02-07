using CHAI.LISDashboard.CoreDomain.DataAccess;
using Microsoft.Practices.ObjectBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using CHAI.LISDashboard.CoreDomain.Report;
using CHAI.LISDashboard.CoreDomain.Users;
using CHAI.LISDashboard.CoreDomain;
using System.Data;

namespace CHAI.LISDashboard.Modules.EIDDashboard.Views
{
    public partial class FrmProgram : POCBasePage, IFrmProgramView
    {
        private FrmProgramPresenter _presenter;
        private ReportDao dao;

        //public string JstringEIDOutcome { get; set; }
        //public IList jsonInfantFeeding { get; set; }
        //public string JstringInfantFeeding { get; set; }

        public IList jsonEIDInitialPCRbyYearly { get; set; }
        public string JstringEIDInitialPCRbyYearly { get; set; }

        public IList jsonEIDInitialPCRbyMonthly { get; set; }
        public string JstringEIDInitialPCRbyMonthly { get; set; }

        public IList jsonEIDInitialPCRbyQuarterly { get; set; }
        public string JstringEIDInitialPCRbyQuarterly { get; set; }

        public IList jsonEIDPCRByFacility { get; set; }
        public string JstringEIDPCRByFacility { get; set; }
        
        public IList jsonEIDIntialPCRAgeByYearly { get; set; }
        public string JstringEIDIntialPCRAgeByYearly { get; set; }

        public IList jsonEIDIntialPCRAgeByQuarterly { get; set; }
        public string JstringEIDIntialPCRAgeByQuarterly { get; set; }

        public IList jsonEIDIntialPCRAgeByMonthly { get; set; }
        public string JstringEIDIntialPCRAgeByMonthly { get; set; }
        public IList jsonEIDTestByAgeOutcome { get; set; }
        public string JstringEIDTestByAgeOutcome { get; set; }
        public IList jsonEIDTestByGender { get; set; }
        public string JstringEIDTestByGender { get; set; }

        public IList jsonEIDTurnaroundTime { get; set; }
        public string JstringEIDTurnaroundTime { get; set; }

        public IList jsonEIDTurnaroundbyYear { get; set; }
        public string JstringEIDTurnaroundbyYear { get; set; }

        public IList jsonEIDSummary { get; set; }
        public string JstringEIDSummary { get; set; }

        public IList jsonEIDLabByLabInstrumentAbbott { get; set; }
        public string JstringEIDLabByLabInstrumentAbbott { get; set; }
        public IList jsonEIDLabByLabInstrumentBioCentric { get; set; }
        public string JstringEIDLabByLabInstrumentBioCentric { get; set; }
        public IList jsonEIDLabByLabInstrumentGeneXpert { get; set; }
        public string JstringEIDLabByLabInstrumentGeneXpert { get; set; }
        public IList jsonEIDLabByLabInstrumentComparison { get; set; }
        public string JstringEIDLabByLabInstrumentComparison { get; set; }

        public IList jsonEIDTestRejectByProvince { get; set; }
        public string JstringEIDTestRejectByProvince { get; set; }

        public IList jsonEIDTestReasonAll { get; set; }
        public string JstringEIDTestReasonAll { get; set; }
        public IList jsonEIDTestReasonByAbbott { get; set; }
        public string JstringEIDTestReasonByAbbott { get; set; }
        public IList jsonEIDTestReasonByBioCentric { get; set; }
        public string JstringEIDTestReasonByBioCentric { get; set; }
        public IList jsonEIDTestReasonByGeneXpert { get; set; }
        public string JstringEIDTestReasonByGeneXpert { get; set; }

        //public string filter_criteria { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this._presenter.OnViewInitialized();
                BindLocation();
                PopulateYears();

                GetEIDInitialPCRbyYearly();
                GetEIDInitialPCRbyQuarterly();
                GetEIDInitialPCRbyMonthly();

                GetEIDIntialPCRAgeByYearly();
                GetEIDIntialPCRAgeByQuarterly();
                GetEIDIntialPCRAgeByMonthly();

                GetEIDTestByAgeOutcome();
                GetEIDTestByGenderOutcome();

                GetEIDPCRByFacility();
                GetEIDSummary();
                //GetEIDTurnaroundbyYear();
                //BindSummaryStat();

                GetEIDLabByLabInstruments();
                GetEIDLabByLabInstrumentComparison();
                GetEIDTestRejectByProvince();

                GetEIDTestReasonByLab();

                //this.filter_criteria = "(" + ddlYearFrom.SelectedItem.Text + " - " + ddlYearTo.SelectedItem.Text + ")";
            }
            this._presenter.OnViewLoaded();           
        }
        public override string PageID
        {

            get
            {
                return "{224a56ae-fe31-4c34-8a66-c95125f2fe1d}";
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

        private void GetEIDInitialPCRbyYearly()
        {
            jsonEIDInitialPCRbyYearly = _presenter.GetEIDIntialPCRbyYear(Convert.ToInt32(ddlLocation.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name);//, DateTime.Parse(txtdatefrom.Text), DateTime.Parse(txtdateto.Text));
            JstringEIDInitialPCRbyYearly = Newtonsoft.Json.JsonConvert.SerializeObject(jsonEIDInitialPCRbyYearly);
        }
        private void GetEIDInitialPCRbyMonthly()
        {
            jsonEIDInitialPCRbyMonthly = _presenter.GetEIDIntialPCRbyMonth(Convert.ToInt32(ddlLocation.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name);//, DateTime.Parse(txtdatefrom.Text), DateTime.Parse(txtdateto.Text));
            JstringEIDInitialPCRbyMonthly = Newtonsoft.Json.JsonConvert.SerializeObject(jsonEIDInitialPCRbyMonthly);
        }
        private void GetEIDInitialPCRbyQuarterly()
        {
            jsonEIDInitialPCRbyQuarterly = _presenter.GetEIDIntialPCRbyQuarter(Convert.ToInt32(ddlLocation.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name);//, DateTime.Parse(txtdatefrom.Text), DateTime.Parse(txtdateto.Text));
            JstringEIDInitialPCRbyQuarterly = Newtonsoft.Json.JsonConvert.SerializeObject(jsonEIDInitialPCRbyQuarterly);
        }
                
        //Added by ZaySoe on 09_Jan_2019
        private void GetEIDIntialPCRAgeByYearly()
        {
            jsonEIDIntialPCRAgeByYearly = _presenter.GetEIDIntialPCRAgeByYearly(Convert.ToInt32(ddlLocation.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name);//, DateTime.Parse(txtdatefrom.Text), DateTime.Parse(txtdateto.Text));
            JstringEIDIntialPCRAgeByYearly = Newtonsoft.Json.JsonConvert.SerializeObject(jsonEIDIntialPCRAgeByYearly);
        }
        private void GetEIDIntialPCRAgeByQuarterly()
        {
            jsonEIDIntialPCRAgeByQuarterly = _presenter.GetEIDIntialPCRAgeByQuarterly(Convert.ToInt32(ddlLocation.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name);//, DateTime.Parse(txtdatefrom.Text), DateTime.Parse(txtdateto.Text));
            JstringEIDIntialPCRAgeByQuarterly = Newtonsoft.Json.JsonConvert.SerializeObject(jsonEIDIntialPCRAgeByQuarterly);
        }
        private void GetEIDIntialPCRAgeByMonthly()
        {
            jsonEIDIntialPCRAgeByMonthly = _presenter.GetEIDIntialPCRAgeByMonthly(Convert.ToInt32(ddlLocation.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name);//, DateTime.Parse(txtdatefrom.Text), DateTime.Parse(txtdateto.Text));
            JstringEIDIntialPCRAgeByMonthly = Newtonsoft.Json.JsonConvert.SerializeObject(jsonEIDIntialPCRAgeByMonthly);
        }

        private void GetEIDTestByAgeOutcome()
        {
            jsonEIDTestByAgeOutcome = _presenter.GetEIDTestByAgeOutcome(
                Convert.ToInt32(ddlLocation.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name);
            JstringEIDTestByAgeOutcome = Newtonsoft.Json.JsonConvert.SerializeObject(jsonEIDTestByAgeOutcome);
        }

        private void GetEIDTestByGenderOutcome()
        {
            jsonEIDTestByGender = _presenter.GetEIDTestByGenderOutcome(
                Convert.ToInt32(ddlLocation.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name);
            JstringEIDTestByGender = Newtonsoft.Json.JsonConvert.SerializeObject(jsonEIDTestByGender);
        }

        private void GetEIDPCRByFacility()
        {
            jsonEIDPCRByFacility = _presenter.GetEIDPCRbyFacility(Convert.ToInt32(ddlLocation.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name);//, DateTime.Parse(txtdatefrom.Text), DateTime.Parse(txtdateto.Text));
            JstringEIDPCRByFacility = Newtonsoft.Json.JsonConvert.SerializeObject(jsonEIDPCRByFacility);
        }
        
        private void GetEIDSummary()
        {
            jsonEIDSummary = _presenter.GetEIDSummary(Convert.ToInt32(ddlLocation.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name);//, DateTime.Parse(txtdatefrom.Text), DateTime.Parse(txtdateto.Text));
            JstringEIDSummary = Newtonsoft.Json.JsonConvert.SerializeObject(jsonEIDSummary);
        }

        //private void GetEIDTurnaroundbyYear()
        //{
        //    jsonEIDTurnaroundbyYear = _presenter.GetEIDTurnaroundbyYear(Convert.ToInt32(ddlLocation.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name);//, DateTime.Parse(txtdatefrom.Text), DateTime.Parse(txtdateto.Text));
        //    JstringEIDTurnaroundbyYear = Newtonsoft.Json.JsonConvert.SerializeObject(jsonEIDTurnaroundbyYear);
        //}

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

            GetEIDInitialPCRbyYearly();
            GetEIDInitialPCRbyQuarterly();
            GetEIDInitialPCRbyMonthly();            

            GetEIDIntialPCRAgeByYearly();
            GetEIDIntialPCRAgeByQuarterly();
            GetEIDIntialPCRAgeByMonthly();

            GetEIDTestByAgeOutcome();
            GetEIDTestByGenderOutcome();

            GetEIDPCRByFacility();
            GetEIDSummary();
            //GetEIDTurnaroundbyYear();
            //BindSummaryStat();

            GetEIDLabByLabInstruments();
            GetEIDLabByLabInstrumentComparison();
            GetEIDTestRejectByProvince();
            GetEIDTestReasonByLab();            

            //this.filter_criteria = "(" + ddlYearFrom.SelectedItem.Text + " - " + ddlYearTo.SelectedItem.Text + ")";            
        }

        private void GetEIDLabByLabInstruments()
        {
            //Abbott
            int labInstruId = 7;
            jsonEIDLabByLabInstrumentAbbott = _presenter.GetEIDLabByLabInstrument(
                Convert.ToInt32(ddlLocation.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name, labInstruId);
            JstringEIDLabByLabInstrumentAbbott = Newtonsoft.Json.JsonConvert.SerializeObject(jsonEIDLabByLabInstrumentAbbott);

            //BioCentric
            labInstruId = 8;
            jsonEIDLabByLabInstrumentBioCentric = _presenter.GetEIDLabByLabInstrument(
                Convert.ToInt32(ddlLocation.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name, labInstruId);
            JstringEIDLabByLabInstrumentBioCentric = Newtonsoft.Json.JsonConvert.SerializeObject(jsonEIDLabByLabInstrumentBioCentric);

            //GeneXpert
            labInstruId = 9;
            jsonEIDLabByLabInstrumentGeneXpert = _presenter.GetEIDLabByLabInstrument(
                Convert.ToInt32(ddlLocation.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name, labInstruId);
            JstringEIDLabByLabInstrumentGeneXpert = Newtonsoft.Json.JsonConvert.SerializeObject(jsonEIDLabByLabInstrumentGeneXpert);

            //Conventional PCR
            //labInstruId = 5;
            //jsonVLLabByLabInstrumentConventional = _presenter.GetVLLabByLabInstrument(
            //    Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name, labInstruId);
            //JstringVLLabByLabInstrumentConventional = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLLabByLabInstrumentConventional);
        }

        private void GetEIDLabByLabInstrumentComparison()
        {
            jsonEIDLabByLabInstrumentComparison = _presenter.GetEIDLabByLabInstrumentComparison(
                Convert.ToInt32(ddlLocation.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name);            
            JstringEIDLabByLabInstrumentComparison = Newtonsoft.Json.JsonConvert.SerializeObject(jsonEIDLabByLabInstrumentComparison);
        }

        private void GetEIDTestRejectByProvince()
        {
            jsonEIDTestRejectByProvince = _presenter.GetEIDTestRejectByProvince(
                Convert.ToInt32(ddlLocation.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name);
            JstringEIDTestRejectByProvince = Newtonsoft.Json.JsonConvert.SerializeObject(jsonEIDTestRejectByProvince);
        }

        private void GetEIDTestReasonByLab()
        {
            jsonEIDTestReasonAll = _presenter.GetEIDTestAllInstrumentsByLab(
                Convert.ToInt32(ddlLocation.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name);
            JstringEIDTestReasonAll = Newtonsoft.Json.JsonConvert.SerializeObject(jsonEIDTestReasonAll);

            //Abbott
            int labInstruId = 7;
            jsonEIDTestReasonByAbbott = _presenter.GetEIDTestByLab(
                Convert.ToInt32(ddlLocation.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name, labInstruId);
            JstringEIDTestReasonByAbbott = Newtonsoft.Json.JsonConvert.SerializeObject(jsonEIDTestReasonByAbbott);

            //BioCentric
            labInstruId = 8;
            jsonEIDTestReasonByBioCentric = _presenter.GetEIDTestByLab(
                Convert.ToInt32(ddlLocation.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name, labInstruId);
            JstringEIDTestReasonByBioCentric = Newtonsoft.Json.JsonConvert.SerializeObject(jsonEIDTestReasonByBioCentric);

            //GeneXpert
            labInstruId = 9;
            jsonEIDTestReasonByGeneXpert = _presenter.GetEIDTestByLab(
                Convert.ToInt32(ddlLocation.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name, labInstruId);
            JstringEIDTestReasonByGeneXpert = Newtonsoft.Json.JsonConvert.SerializeObject(jsonEIDTestReasonByGeneXpert);
        }

        #region Private Methods
        private void PopulateYears()
        {
            // Year Picker for Lab Performance History            
            //var startYear = 2015;
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
            for (var i = startYear; i >= 2015; i--)
            {
                ddlYearFrom.Items.Add((i).ToString());
                ddlYearTo.Items.Add((i).ToString());
            }
            ddlYearTo.SelectedValue = startYear.ToString();
        }

        //private void BindSummaryStat()
        //{
        //    EIDStat result = _presenter.EIDSummaryStat(ddlYearFrom.SelectedValue, ddlYearTo.SelectedValue, Convert.ToInt32(ddlLocation.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name);

        //    if (result != null)
        //    {                
        //        //lblTotalInitial.Text = result.Tot_Initial.ToString();
        //        //lblTotalInitialPositive.Text = result.Tot_Initial_Positive.ToString();
        //        //lblTotalInitial_lt2months.Text = result.Total_Initial_lt2month.ToString();
        //        ////lblInitialRate.Text = result.Initial_Rate.ToString();
        //        //lblInitialRate.Text = string.Format("{0:0.00}", result.Initial_Rate);
        //        ////lblInitialPositiveRate.Text = result.Initial_Positive_Rate.ToString();
        //        //lblInitialPositiveRate.Text = string.Format("{0:0.00}", result.Initial_Positive_Rate);
        //        ////lblInitialLT2Months.Text = result.Initial_lt2months_Rate.ToString();
        //        //lblInitialLT2Months.Text = string.Format("{0:0.00}", result.Initial_lt2months_Rate);
        //        //lblInitialLT2Months.Text = result.Total_Initial_lt2month.ToString("#,##0.##");
        //        //lblError.Text = result.Error.ToString();

        //        //lblRejection.Text = result.RejectedSamples.ToString() + "%";
        //        //lblDetLes.Text = result.Tot_Detected_LE_1000.ToString();
        //        //lbldetgre.Text = result.Tot_Detected_G_1000.ToString();
        //        //lblSupp.Text = result.Total_Suppressed.ToString() + "%";                

        //        //lblNoOfSampleReceived.DataBind();
        //        //lblNoOfRejectedSample.DataBind();
        //        //lblTotTests.DataBind();
        //        //lblInitialFirstTime.DataBind();
        //        //lblLessThan2MonthsTesting.DataBind();
        //    }

        //}
        #endregion
        private AppUser CurrentUser
        {
            get { return ((ChaiPrincipal)HttpContext.Current.User).CurrentAppUser; }
        }
    }
}