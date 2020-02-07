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
using CHAI.LISDashboard.CoreDomain;

namespace CHAI.LISDashboard.Modules.EIDDashboard.Views
{
    public partial class frmTestingTrends : POCBasePage, IfrmTestingTrendsView
    {
        private frmTestingTrendsPresenter _presenter;
        private ReportDao dao;

        public string JstringEIDOutcome { get; set; }
        public IList jsonInfantFeeding { get; set; }
        public string JstringInfantFeeding { get; set; }


        public IList jsonEIDIntialPCRbyYear { get; set; }
        public string JstringEIDIntialPCRbyYear { get; set; }

        public IList jsonEIDIntialPCRbyMonth { get; set; }
        public string JstringEIDIntialPCRbyMonth { get; set; }

        public IList jsonEIDAllTestbyYear { get; set; }
        public string JstringEIDAllTestbyYear { get; set; }

        public IList jsonEIDAllTestInfantbyYear { get; set; }
        public string JstringEIDAllTestInfantbyYear { get; set; }

        public IList jsonEIDIntialPCRAgeByYearly { get; set; }
        public string JstringEIDIntialPCRAgeByYearly { get; set; }

        public IList jsonEIDIntialPCRAgeByQuarterly { get; set; }
        public string JstringEIDIntialPCRAgeByQuarterly { get; set; }

        public IList jsonEIDIntialPCRAgeByMonthly { get; set; }
        public string JstringEIDIntialPCRAgeByMonthly { get; set; }

        public IList jsonEIDRejectionByYear { get; set; }
        public string JstringEIDRejectionByYear { get; set; }

        public IList jsonEIDTurnaroundbyYear { get; set; }
        public string JstringEIDTurnaroundbyYear { get; set; }

        public IList jsonEIDAllTestInfant2MbyYear { get; set; }
        public string JstringEIDAllTestInfant2MbyYear { get; set; }

        public IList jsonEIDPoitivityTrendbyYear { get; set; }
        public string JstringEIDPoitivityTrendbyYear { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this._presenter.OnViewInitialized();
                BindLocation();
                PopulateYears();
            }
            this._presenter.OnViewLoaded();
            GetEIDIntialPCRbyYear();    // DNA PCR Test by Yearly
            //GetEIDAllTestbyYear();      // DNA PCR Test by Quarterly
            GetEIDIntialPCRbyMonth();   // DNA PCR Test by Monthly

            GetEIDIntialPCRAgeByYearly();
            GetEIDIntialPCRAgeByQuarterly();
            GetEIDIntialPCRAgeByMonthly();

            GetEIDAllTestInfantbyYear();            
            GetEIDRejectionByYear();
            GetEIDTurnaroundbyYear();
            GetEIDAllTestInfant2MbyYear();
            GetEIDPoitivityTrendbyYear();
        }
        public override string PageID
        {

            get
            {
                return "{224a56ae-fe31-4c34-8a66-c95125f2fe1d}";
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

        private void GetEIDIntialPCRbyYear()
        {
            jsonEIDIntialPCRbyYear = _presenter.GetEIDIntialPCRbyYear(Convert.ToInt32(ddlLocation.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name);//, DateTime.Parse(txtdatefrom.Text), DateTime.Parse(txtdateto.Text));
            JstringEIDIntialPCRbyYear = Newtonsoft.Json.JsonConvert.SerializeObject(jsonEIDIntialPCRbyYear);
        }
        private void GetEIDIntialPCRbyMonth()
        {
            jsonEIDIntialPCRbyMonth = _presenter.GetEIDIntialPCRbyMonth(Convert.ToInt32(ddlLocation.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name);//, DateTime.Parse(txtdatefrom.Text), DateTime.Parse(txtdateto.Text));
            JstringEIDIntialPCRbyMonth = Newtonsoft.Json.JsonConvert.SerializeObject(jsonEIDIntialPCRbyMonth);
        }
        //private void GetEIDAllTestbyYear()
        //{
        //    jsonEIDAllTestbyYear = _presenter.GetEIDAllTestbyYear(Convert.ToInt32(ddlLocation.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name);//, DateTime.Parse(txtdatefrom.Text), DateTime.Parse(txtdateto.Text));
        //    JstringEIDAllTestbyYear = Newtonsoft.Json.JsonConvert.SerializeObject(jsonEIDAllTestbyYear);
        //}
        private void GetEIDAllTestInfantbyYear()
        {
            jsonEIDAllTestInfantbyYear = _presenter.GetEIDAllTestInfant2MbyYear(Convert.ToInt32(ddlLocation.SelectedValue));//, DateTime.Parse(txtdatefrom.Text), DateTime.Parse(txtdateto.Text));
            JstringEIDAllTestInfantbyYear = Newtonsoft.Json.JsonConvert.SerializeObject(jsonEIDAllTestInfantbyYear);
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

        private void GetEIDRejectionByYear()
        {
            jsonEIDRejectionByYear = _presenter.GetEIDRejectionbyYear(Convert.ToInt32(ddlLocation.SelectedValue), int.Parse(ddlDate.SelectedValue));//, DateTime.Parse(txtdatefrom.Text), DateTime.Parse(txtdateto.Text));
            JstringEIDRejectionByYear = Newtonsoft.Json.JsonConvert.SerializeObject(jsonEIDRejectionByYear);
        }
        private void GetEIDTurnaroundbyYear()
        {

            //jsonEIDTurnaroundbyYear = _presenter.GetEIDTurnaroundbyYear(Convert.ToInt32(ddlLocation.SelectedValue), int.Parse(ddlDate.SelectedValue));//, DateTime.Parse(txtdatefrom.Text), DateTime.Parse(txtdateto.Text));
            //JstringEIDTurnaroundbyYear = Newtonsoft.Json.JsonConvert.SerializeObject(jsonEIDTurnaroundbyYear);
        }
        private void GetEIDAllTestInfant2MbyYear()
        {

            jsonEIDAllTestInfant2MbyYear = _presenter.GetEIDAllTestInfant2MbyYear(Convert.ToInt32(ddlLocation.SelectedValue), int.Parse(ddlDate.SelectedValue));//, DateTime.Parse(txtdatefrom.Text), DateTime.Parse(txtdateto.Text));
            JstringEIDAllTestInfant2MbyYear = Newtonsoft.Json.JsonConvert.SerializeObject(jsonEIDAllTestInfant2MbyYear);
        }
        private void GetEIDPoitivityTrendbyYear()
        {

            jsonEIDPoitivityTrendbyYear = _presenter.GetEIDPoitivityTrendbyYear(Convert.ToInt32(ddlLocation.SelectedValue), int.Parse(ddlDate.SelectedValue));//, DateTime.Parse(txtdatefrom.Text), DateTime.Parse(txtdateto.Text));
            JstringEIDPoitivityTrendbyYear = Newtonsoft.Json.JsonConvert.SerializeObject(jsonEIDPoitivityTrendbyYear);
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            if (ddlLocation.SelectedValue != "0")
            {
                lbllocation.Text = ddlLocation.SelectedItem.Text + " State/Region";
                //lbloutcomeProFac.Text = "Facility Outcome under " + ddlLocation.SelectedItem.Text + " Province";
            }
            else
            {
                lbllocation.Text = "National";
                //lbloutcomeProFac.Text = "Province Outcome";
            }
            GetEIDIntialPCRbyYear();
            //GetEIDAllTestbyYear();
            GetEIDAllTestInfantbyYear();
            GetEIDIntialPCRAgeByQuarterly();
            GetEIDRejectionByYear();
            GetEIDTurnaroundbyYear();
            GetEIDAllTestInfant2MbyYear();
            GetEIDPoitivityTrendbyYear();
        }

        #region Private Methods
        private void PopulateYears()
        {
            // Year Picker for Lab Performance History            
            var startYear = 2015;
            var currentYear = DateTime.Now.Year;
            for (var i = 0; i < currentYear - startYear + 1; i++)
            {
                ddlYearFrom.Items.Add((startYear + i).ToString());
                ddlYearTo.Items.Add((startYear + i).ToString());
                //if ((startYear + i) == currentYear)
                //    ddlYear.Items.Add((startYear + i).ToString());                        
                //else
                //        $(this).append('<option value="' + (startYear + i) + '">' + (startYear + i) + '</option>');
                //alert(startYear + i);
            }
            ddlYearFrom.SelectedValue = currentYear.ToString();
            ddlYearTo.SelectedValue = currentYear.ToString();
        }
        #endregion

        private AppUser CurrentUser
        {
            get { return ((ChaiPrincipal)HttpContext.Current.User).CurrentAppUser; }
        }
    }
}