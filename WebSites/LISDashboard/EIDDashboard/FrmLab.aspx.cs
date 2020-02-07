using CHAI.LISDashboard.CoreDomain.DataAccess;
using Microsoft.Practices.ObjectBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using CHAI.LISDashboard.CoreDomain.Users;
using CHAI.LISDashboard.CoreDomain.Report;
using CHAI.LISDashboard.CoreDomain;
using System.Data;

namespace CHAI.LISDashboard.Modules.EIDDashboard.Views
{
    public partial class FrmLab : POCBasePage, IFrmLabView
    {
        private FrmLabPresenter _presenter;
        private ReportDao dao;

        public IList jsonEIDInitialPCRbyYear { get; set; }
        public string JstringEIDInitialPCRbyYear { get; set; }

        public IList jsonEIDInitialPCRbyMonth { get; set; }
        public string JstringEIDInitialPCRbyMonth { get; set; }

        public IList jsonEIDInitialPCRbyQuarter { get; set; }
        public string JstringEIDInitialPCRbyQuarter { get; set; }

        public IList jsonEIDIntialPCRAgeByYear { get; set; }
        public string JstringEIDIntialPCRAgeByYear { get; set; }

        public IList jsonEIDIntialPCRAgeByQuarter { get; set; }
        public string JstringEIDIntialPCRAgeByQuarter { get; set; }

        public IList jsonEIDIntialPCRAgeByMonth { get; set; }
        public string JstringEIDIntialPCRAgeByMonth { get; set; }
        public IList jsonEIDTestByAgeOutcome { get; set; }
        public string JstringEIDTestByAgeOutcome { get; set; }
        public IList jsonEIDTestByGender { get; set; }
        public string JstringEIDTestByGender { get; set; }

        public IList jsonEIDPCRByFacility { get; set; }
        public string JstringEIDPCRByFacility { get; set; }

        public IList jsonEIDLabByLabInstrumentAbbott { get; set; }
        public string JstringEIDLabByLabInstrumentAbbott { get; set; }
        public IList jsonEIDLabByLabInstrumentBioCentric { get; set; }
        public string JstringEIDLabByLabInstrumentBioCentric { get; set; }
        public IList jsonEIDLabByLabInstrumentGeneXpert { get; set; }
        public string JstringEIDLabByLabInstrumentGeneXpert { get; set; }
        public IList jsonEIDLabByLabInstrumentComparison { get; set; }
        public string JstringEIDLabByLabInstrumentComparison { get; set; }

        public IList jsonEIDTestReasonAll { get; set; }
        public string JstringEIDTestReasonAll { get; set; }
        public IList jsonEIDTestReasonByAbbott { get; set; }
        public string JstringEIDTestReasonByAbbott { get; set; }
        public IList jsonEIDTestReasonByBioCentric { get; set; }
        public string JstringEIDTestReasonByBioCentric { get; set; }
        public IList jsonEIDTestReasonByGeneXpert { get; set; }
        public string JstringEIDTestReasonByGeneXpert { get; set; }
        public IList jsonEIDTestByLabFacility { get; set; }
        public string JstringEIDTestByLabFaclility { get; set; }

        public IList jsonEIDTurnaroundbyYear { get; set; }
        public string JstringEIDTurnaroundbyYear { get; set; }

        public IList jsonEIDTurnaroundbyQuarter { get; set; }
        public string JstringEIDTurnaroundbyQuarter { get; set; }

        public IList jsonEIDSummary { get; set; }
        public string JstringEIDSummary { get; set; }

        public IList jsonEIDTestRejectByProvince { get; set; }
        public string JstringEIDTestRejectByProvince { get; set; }

        //private string labCodes = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this._presenter.OnViewInitialized();
                BindLaboratories();
                PopulateYears();
                //BindUserInfo();

                //GetLabCodes();

                GetEIDInitialPCRbyYear();
                GetEIDInitialPCRbyQuarter();
                GetEIDInitialPCRbyMonth();

                GetEIDIntialPCRAgeByYear();
                GetEIDIntialPCRAgeByQuarter();
                GetEIDIntialPCRAgeByMonth();

                GetEIDTestByAgeOutcome();
                GetEIDTestByGenderOutcome();

                GetEIDPCRByFacility();
                //BindSummaryStat();
                GetEIDSummary();

                GetEIDLabByLabInstruments();
                GetEIDLabByLabInstrumentComparison();
                GetEIDTestReasonByLab();
                GetEIDTestByStateRegionFacility();

                GetEIDTurnaroundbyYear();
                GetEIDTurnaroundbyQuarter();
                GetEIDTestRejectByProvince();

            }
            this._presenter.OnViewLoaded();
            
            
            //if (this.CurrentUser.UserLocations != null && this.CurrentUser.UserLocations.Count > 0)
            //{
            //    divLocation.Attributes.Add("style", "display:none");
            //    lbllocation.Text = this.CurrentUser.UserLocations[0].Laboratory.Description;
            //}

            //divNational.Visible = true;
        }
        public override string PageID
        {

            get
            {
                return "{224a56ae-fe31-4c34-8a66-c95125f2fe1d}";
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

        private void GetEIDInitialPCRbyYear()
        {
            string[] fromDate = txtStartDate.Text.Split(new Char[] { '/' });
            string[] toDate = txtEndDate.Text.Split(new Char[] { '/' });
            hdnStartDate.Value = fromDate[1];
            jsonEIDInitialPCRbyYear = _presenter.GetEIDIntialPCRbyYear(ddlLab.SelectedValue,
                Convert.ToInt32(fromDate[1] + fromDate[0]), Convert.ToInt32(toDate[1] + toDate[0]),
                CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name);//, DateTime.Parse(txtdatefrom.Text), DateTime.Parse(txtdateto.Text));
            JstringEIDInitialPCRbyYear = Newtonsoft.Json.JsonConvert.SerializeObject(jsonEIDInitialPCRbyYear);
        }
        private void GetEIDInitialPCRbyMonth()
        {
            string[] fromDate = txtStartDate.Text.Split(new Char[] { '/' });
            string[] toDate = txtEndDate.Text.Split(new Char[] { '/' });
            hdnStartDate.Value = fromDate[1];
            jsonEIDInitialPCRbyMonth = _presenter.GetEIDIntialPCRbyMonth(ddlLab.SelectedValue,
                //Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue), 
                Convert.ToInt32(fromDate[1] + fromDate[0]), Convert.ToInt32(toDate[1] + toDate[0]),
                CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name);//, DateTime.Parse(txtdatefrom.Text), DateTime.Parse(txtdateto.Text));
            JstringEIDInitialPCRbyMonth = Newtonsoft.Json.JsonConvert.SerializeObject(jsonEIDInitialPCRbyMonth);
        }
        private void GetEIDInitialPCRbyQuarter()
        {
            string[] fromDate = txtStartDate.Text.Split(new Char[] { '/' });
            string[] toDate = txtEndDate.Text.Split(new Char[] { '/' });
            hdnStartDate.Value = fromDate[1];
            jsonEIDInitialPCRbyQuarter = _presenter.GetEIDAllTestbyYear(ddlLab.SelectedValue,
                //Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue),
                Convert.ToInt32(fromDate[1] + fromDate[0]), Convert.ToInt32(toDate[1] + toDate[0]),
                CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name);//, DateTime.Parse(txtdatefrom.Text), DateTime.Parse(txtdateto.Text));
            JstringEIDInitialPCRbyQuarter = Newtonsoft.Json.JsonConvert.SerializeObject(jsonEIDInitialPCRbyQuarter);
        }

        //Added by ZaySoe on 09_Jan_2019
        private void GetEIDIntialPCRAgeByYear()
        {
            string[] fromDate = txtStartDate.Text.Split(new Char[] { '/' });
            string[] toDate = txtEndDate.Text.Split(new Char[] { '/' });
            hdnStartDate.Value = fromDate[1];
            jsonEIDIntialPCRAgeByYear = _presenter.GetEIDIntialPCRAgeByYear(ddlLab.SelectedValue,
                Convert.ToInt32(fromDate[1] + fromDate[0]), Convert.ToInt32(toDate[1] + toDate[0]),
                CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name);//, DateTime.Parse(txtdatefrom.Text), DateTime.Parse(txtdateto.Text));
            JstringEIDIntialPCRAgeByYear = Newtonsoft.Json.JsonConvert.SerializeObject(jsonEIDIntialPCRAgeByYear);
        }
        private void GetEIDIntialPCRAgeByQuarter()
        {
            string[] fromDate = txtStartDate.Text.Split(new Char[] { '/' });
            string[] toDate = txtEndDate.Text.Split(new Char[] { '/' });
            hdnStartDate.Value = fromDate[1];
            jsonEIDIntialPCRAgeByQuarter = _presenter.GetEIDIntialPCRAgeByQuarter(ddlLab.SelectedValue,
                //Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue),
                Convert.ToInt32(fromDate[1] + fromDate[0]), Convert.ToInt32(toDate[1] + toDate[0]),
                CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name);//, DateTime.Parse(txtdatefrom.Text), DateTime.Parse(txtdateto.Text));
            JstringEIDIntialPCRAgeByQuarter = Newtonsoft.Json.JsonConvert.SerializeObject(jsonEIDIntialPCRAgeByQuarter);
        }
        private void GetEIDIntialPCRAgeByMonth()
        {
            string[] fromDate = txtStartDate.Text.Split(new Char[] { '/' });
            string[] toDate = txtEndDate.Text.Split(new Char[] { '/' });
            hdnStartDate.Value = fromDate[1];
            jsonEIDIntialPCRAgeByMonth = _presenter.GetEIDIntialPCRAgeByMonth(ddlLab.SelectedValue,
                //Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue),
                Convert.ToInt32(fromDate[1] + fromDate[0]), Convert.ToInt32(toDate[1] + toDate[0]),
                CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name);//, DateTime.Parse(txtdatefrom.Text), DateTime.Parse(txtdateto.Text));
            JstringEIDIntialPCRAgeByMonth = Newtonsoft.Json.JsonConvert.SerializeObject(jsonEIDIntialPCRAgeByMonth);
        }
        private void GetEIDTestByAgeOutcome()
        {
            string[] fromDate = txtStartDate.Text.Split(new Char[] { '/' });
            string[] toDate = txtEndDate.Text.Split(new Char[] { '/' });
            hdnStartDate.Value = fromDate[1];
            jsonEIDTestByAgeOutcome = _presenter.GetEIDTestByAgeOutcomeForLab(ddlLab.SelectedValue,
                //Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue),
                Convert.ToInt32(fromDate[1] + fromDate[0]), Convert.ToInt32(toDate[1] + toDate[0]),
                CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name);
            JstringEIDTestByAgeOutcome = Newtonsoft.Json.JsonConvert.SerializeObject(jsonEIDTestByAgeOutcome);
        }
        private void GetEIDTestByGenderOutcome()
        {
            string[] fromDate = txtStartDate.Text.Split(new Char[] { '/' });
            string[] toDate = txtEndDate.Text.Split(new Char[] { '/' });
            hdnStartDate.Value = fromDate[1];
            jsonEIDTestByGender = _presenter.GetEIDTestByGenderOutcomeForLab(ddlLab.SelectedValue,
                //Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue),
                Convert.ToInt32(fromDate[1] + fromDate[0]), Convert.ToInt32(toDate[1] + toDate[0]),
                CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name);
            JstringEIDTestByGender = Newtonsoft.Json.JsonConvert.SerializeObject(jsonEIDTestByGender);
        }

        private void GetEIDTestRejectByProvince()
        {
            string[] fromDate = txtStartDate.Text.Split(new Char[] { '/' });
            string[] toDate = txtEndDate.Text.Split(new Char[] { '/' });
            hdnStartDate.Value = fromDate[1];
            jsonEIDTestRejectByProvince = _presenter.GetEIDTestRejectByProvinceForLab(ddlLab.SelectedValue,
                //Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue),
                Convert.ToInt32(fromDate[1] + fromDate[0]), Convert.ToInt32(toDate[1] + toDate[0]),
                CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name);
            JstringEIDTestRejectByProvince = Newtonsoft.Json.JsonConvert.SerializeObject(jsonEIDTestRejectByProvince);
        }

        private void GetEIDPCRByFacility()
        {
            string[] fromDate = txtStartDate.Text.Split(new Char[] { '/' });
            string[] toDate = txtEndDate.Text.Split(new Char[] { '/' });
            hdnStartDate.Value = fromDate[1];
            jsonEIDPCRByFacility = _presenter.GetEIDPCRbyFacility(ddlLab.SelectedValue,
                //Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue),
                Convert.ToInt32(fromDate[1] + fromDate[0]), Convert.ToInt32(toDate[1] + toDate[0]),
                CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name);//, DateTime.Parse(txtdatefrom.Text), DateTime.Parse(txtdateto.Text));
            JstringEIDPCRByFacility = Newtonsoft.Json.JsonConvert.SerializeObject(jsonEIDPCRByFacility);
        }

        private void GetEIDSummary()
        {
            string[] fromDate = txtStartDate.Text.Split(new Char[] { '/' });
            string[] toDate = txtEndDate.Text.Split(new Char[] { '/' });
            hdnStartDate.Value = fromDate[1];
            jsonEIDSummary = _presenter.GetEIDSummary(ddlLab.SelectedValue,
                //Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue),
                Convert.ToInt32(fromDate[1] + fromDate[0]), Convert.ToInt32(toDate[1] + toDate[0]),
                CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name);//, DateTime.Parse(txtdatefrom.Text), DateTime.Parse(txtdateto.Text));
            JstringEIDSummary = Newtonsoft.Json.JsonConvert.SerializeObject(jsonEIDSummary);
        }

        private void GetEIDLabByLabInstruments()
        {
            string[] fromDate = txtStartDate.Text.Split(new Char[] { '/' });
            string[] toDate = txtEndDate.Text.Split(new Char[] { '/' });
            hdnStartDate.Value = fromDate[1];

            //Abbott
            int labInstruId = 7;
            jsonEIDLabByLabInstrumentAbbott = _presenter.GetEIDLabByLabInstrument(
                ddlLab.SelectedValue,
                //Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue),
                Convert.ToInt32(fromDate[1] + fromDate[0]), Convert.ToInt32(toDate[1] + toDate[0]),
                CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name, labInstruId);
            JstringEIDLabByLabInstrumentAbbott = Newtonsoft.Json.JsonConvert.SerializeObject(jsonEIDLabByLabInstrumentAbbott);

            //BioCentric
            labInstruId = 8;
            jsonEIDLabByLabInstrumentBioCentric = _presenter.GetEIDLabByLabInstrument(
                ddlLab.SelectedValue, //Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue),
                Convert.ToInt32(fromDate[1] + fromDate[0]), Convert.ToInt32(toDate[1] + toDate[0]),
                CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name, labInstruId);
            JstringEIDLabByLabInstrumentBioCentric = Newtonsoft.Json.JsonConvert.SerializeObject(jsonEIDLabByLabInstrumentBioCentric);

            //GeneXpert
            labInstruId = 9;
            jsonEIDLabByLabInstrumentGeneXpert = _presenter.GetEIDLabByLabInstrument(
                ddlLab.SelectedValue,
                //Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue),
                Convert.ToInt32(fromDate[1] + fromDate[0]), Convert.ToInt32(toDate[1] + toDate[0]),
                CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name, labInstruId);
            JstringEIDLabByLabInstrumentGeneXpert = Newtonsoft.Json.JsonConvert.SerializeObject(jsonEIDLabByLabInstrumentGeneXpert);

            //Conventional PCR
            //labInstruId = 5;
            //jsonVLLabByLabInstrumentConventional = _presenter.GetVLLabByLabInstrument(
            //    Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name, labInstruId);
            //JstringVLLabByLabInstrumentConventional = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLLabByLabInstrumentConventional);
        }

        private void GetEIDLabByLabInstrumentComparison()
        {
            string[] fromDate = txtStartDate.Text.Split(new Char[] { '/' });
            string[] toDate = txtEndDate.Text.Split(new Char[] { '/' });
            hdnStartDate.Value = fromDate[1];
            jsonEIDLabByLabInstrumentComparison = _presenter.GetEIDLabByLabInstrumentComparison(
                ddlLab.SelectedValue,
                //Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue),
                Convert.ToInt32(fromDate[1] + fromDate[0]), Convert.ToInt32(toDate[1] + toDate[0]),
                CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name);
            JstringEIDLabByLabInstrumentComparison = Newtonsoft.Json.JsonConvert.SerializeObject(jsonEIDLabByLabInstrumentComparison);
        }

        private void GetEIDTestReasonByLab()
        {
            string[] fromDate = txtStartDate.Text.Split(new Char[] { '/' });
            string[] toDate = txtEndDate.Text.Split(new Char[] { '/' });
            hdnStartDate.Value = fromDate[1];
            jsonEIDTestReasonAll = _presenter.GetEIDTestAllInstrumentsByLab(
                ddlLab.SelectedValue,
                //Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue),
                Convert.ToInt32(fromDate[1] + fromDate[0]), Convert.ToInt32(toDate[1] + toDate[0]),
                CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name);
            JstringEIDTestReasonAll = Newtonsoft.Json.JsonConvert.SerializeObject(jsonEIDTestReasonAll);

            //Abbott
            int labInstruId = 7;
            jsonEIDTestReasonByAbbott = _presenter.GetEIDTestByLab(
                ddlLab.SelectedValue,
                //Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue),
                Convert.ToInt32(fromDate[1] + fromDate[0]), Convert.ToInt32(toDate[1] + toDate[0]),
                CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name, labInstruId);
            JstringEIDTestReasonByAbbott = Newtonsoft.Json.JsonConvert.SerializeObject(jsonEIDTestReasonByAbbott);

            //BioCentric
            labInstruId = 8;
            jsonEIDTestReasonByBioCentric = _presenter.GetEIDTestByLab(
                ddlLab.SelectedValue,
                //Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue),
                Convert.ToInt32(fromDate[1] + fromDate[0]), Convert.ToInt32(toDate[1] + toDate[0]),
                CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name, labInstruId);
            JstringEIDTestReasonByBioCentric = Newtonsoft.Json.JsonConvert.SerializeObject(jsonEIDTestReasonByBioCentric);

            //GeneXpert
            labInstruId = 9;
            jsonEIDTestReasonByGeneXpert = _presenter.GetEIDTestByLab(
                ddlLab.SelectedValue,
                //Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue),
                Convert.ToInt32(fromDate[1] + fromDate[0]), Convert.ToInt32(toDate[1] + toDate[0]),
                CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name, labInstruId);
            JstringEIDTestReasonByGeneXpert = Newtonsoft.Json.JsonConvert.SerializeObject(jsonEIDTestReasonByGeneXpert);
        }
        private void GetEIDTestByStateRegionFacility()
        {
            string[] fromDate = txtStartDate.Text.Split(new Char[] { '/' });
            string[] toDate = txtEndDate.Text.Split(new Char[] { '/' });
            hdnStartDate.Value = fromDate[1];
            jsonEIDTestByLabFacility = _presenter.GetEIDTestByStateRegionFacility(
                ddlLab.SelectedValue,
                //Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue),
                Convert.ToInt32(fromDate[1] + fromDate[0]), Convert.ToInt32(toDate[1] + toDate[0]),
                CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name);
            JstringEIDTestByLabFaclility = Newtonsoft.Json.JsonConvert.SerializeObject(jsonEIDTestByLabFacility);
        }

        private void GetEIDTurnaroundbyYear()
        {
            string[] fromDate = txtStartDate.Text.Split(new Char[] { '/' });
            string[] toDate = txtEndDate.Text.Split(new Char[] { '/' });
            hdnStartDate.Value = fromDate[1];
            jsonEIDTurnaroundbyYear = _presenter.GetEIDTurnaroundbyYear(ddlLab.SelectedValue,
                //Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue),
                Convert.ToInt32(fromDate[1] + fromDate[0]), Convert.ToInt32(toDate[1] + toDate[0]),
                CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name);//, DateTime.Parse(txtdatefrom.Text), DateTime.Parse(txtdateto.Text));
            JstringEIDTurnaroundbyYear = Newtonsoft.Json.JsonConvert.SerializeObject(jsonEIDTurnaroundbyYear);
        }

        private void GetEIDTurnaroundbyQuarter()
        {
            string[] fromDate = txtStartDate.Text.Split(new Char[] { '/' });
            string[] toDate = txtEndDate.Text.Split(new Char[] { '/' });
            hdnStartDate.Value = fromDate[1];
            jsonEIDTurnaroundbyQuarter = _presenter.GetEIDTurnaroundbyQuarter(ddlLab.SelectedValue,
                //Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue),
                Convert.ToInt32(fromDate[1] + fromDate[0]), Convert.ToInt32(toDate[1] + toDate[0]),
                CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name);//, DateTime.Parse(txtdatefrom.Text), DateTime.Parse(txtdateto.Text));
            JstringEIDTurnaroundbyQuarter = Newtonsoft.Json.JsonConvert.SerializeObject(jsonEIDTurnaroundbyQuarter);
        }
        protected void btnFilter_Click(object sender, EventArgs e)
        {
            //if (ddlLocation.SelectedValue != "0")
            //{
            //    lbllocation.Text = "National / " + ddlLocation.SelectedItem.Text;
            //}
            //else
            //{
            //    lbllocation.Text = "National";
            //}

            //if (CurrentUser.UserLocations != null && CurrentUser.UserLocations.Count > 0)
            //    lbllocation.Text = CurrentUser.UserLocations[0].LabCode;

            //GetLabCodes();

            GetEIDInitialPCRbyYear();
            GetEIDInitialPCRbyQuarter();
            GetEIDInitialPCRbyMonth();

            GetEIDIntialPCRAgeByYear();
            GetEIDIntialPCRAgeByQuarter();
            GetEIDIntialPCRAgeByMonth();

            GetEIDTestByAgeOutcome();
            GetEIDTestByGenderOutcome();

            GetEIDPCRByFacility();
            //BindSummaryStat();
            GetEIDSummary();
            GetEIDLabByLabInstruments();
            GetEIDLabByLabInstrumentComparison();
            GetEIDTestReasonByLab();
            GetEIDTestByStateRegionFacility();
            GetEIDTurnaroundbyYear();
            GetEIDTurnaroundbyQuarter();
            GetEIDTestRejectByProvince();
        }        

        #region Private Methods
        private void PopulateYears()
        {
            ////// Year Picker for Lab Performance History            
            ////var startYear = 2015;
            ////var currentYear = DateTime.Now.Year;
            ////for (var i = 0; i < currentYear - startYear + 1; i++)
            ////{
            ////    ddlYearFrom.Items.Add((startYear + i).ToString());
            ////    ddlYearTo.Items.Add((startYear + i).ToString());
            ////    //if ((startYear + i) == currentYear)
            ////    //    ddlYear.Items.Add((startYear + i).ToString());                        
            ////    //else
            ////    //        $(this).append('<option value="' + (startYear + i) + '">' + (startYear + i) + '</option>');
            ////    //alert(startYear + i);
            ////}
            //////ddlYearFrom.SelectedValue = currentYear.ToString();
            ////ddlYearTo.SelectedValue = currentYear.ToString();

            //// Year Picker for Lab Performance History
            //var startYear = DateTime.Now.Year;
            //for (var i = startYear; i >= 2015; i--)
            //{
            //    ddlYearFrom.Items.Add((i).ToString());
            //    ddlYearTo.Items.Add((i).ToString());                
            //}
            //ddlYearTo.SelectedValue = startYear.ToString();            
            txtStartDate.Text = DateTime.Today.ToString("MM") + "/" + DateTime.Today.Year;
            hdnStartDate.Value = DateTime.Today.Year.ToString();
            txtEndDate.Text = DateTime.Today.ToString("MM") + "/" + DateTime.Today.Year;
        }

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
        //}

        //private void BindUserInfo()
        //{
        //    //DataSet infoDS = _presenter.GetLabInfo(CurrentUser.Id);
        //    dao = new ReportDao();
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
        #endregion

        //private void BindSummaryStat()
        //{
        //    EIDStat result = _presenter.EIDSummaryStat(ddlYearFrom.Text, ddlYearTo.Text, ddlLab.SelectedValue, CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name);

        //    if (result != null)
        //    {
        //        //lblNoOfSampleReceived.Text = result.No_Sample_Recieved.ToString();
        //        //lblNoOfRejectedSample.Text = result.No_Rejected_Sample.ToString();
        //        //lblTotTests.Text = result.Tot_Tests.ToString();
        //        //lblInitialFirstTime.Text = result.Initial_Rate.ToString();
        //        //lblLessThan2MonthsTesting.Text = result.Initial_lt2months_Rate.ToString();
        //        ////lblRejection.Text = result.RejectedSamples.ToString() + "%";
        //        ////lblDetLes.Text = result.Tot_Detected_LE_1000.ToString();
        //        ////lbldetgre.Text = result.Tot_Detected_G_1000.ToString();
        //        ////lblSupp.Text = result.Total_Suppressed.ToString() + "%";

        //        //lblError.Text = result.Error.ToString();

        //        //lblTotalInitial.Text = result.Tot_Initial.ToString();
        //        //lblTotalInitialPositive.Text = result.Tot_Initial_Positive.ToString();
        //        //lblTotalInitial_lt2months.Text = result.Total_Initial_lt2month.ToString();
        //        //lblInitialRate.Text = result.Initial_Rate.ToString();
        //        //lblInitialPositiveRate.Text = result.Initial_Positive_Rate.ToString();
        //        //lblInitialLT2Months.Text = result.Initial_lt2months_Rate.ToString();
        //    }

        //}

        private AppUser CurrentUser
        {
            get { return ((ChaiPrincipal)HttpContext.Current.User).CurrentAppUser; }
        }
    }
}