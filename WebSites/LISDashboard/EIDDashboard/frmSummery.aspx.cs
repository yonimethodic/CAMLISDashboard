using CHAI.LISDashboard.CoreDomain.DataAccess;
using Microsoft.Practices.ObjectBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace CHAI.LISDashboard.Modules.EIDDashboard.Views
{
    public partial class frmSummery : POCBasePage, IfrmSummeryView
    {
        private frmSummeryPresenter _presenter;
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



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this._presenter.OnViewInitialized();
                BindLocation();
            }
            this._presenter.OnViewLoaded();
            GetEIDTestbyAge();
            GetEIDTestbyModeOfDelivery();
            GetEIDOutcomes();
            GetInfantFeeding();
            GetEIDIntialPCR();
            GetEIDIntialPCRbyProvince();


        }
        public override string PageID
        {

            get
            {
                return "{1e78e6f5-db7b-4a6b-a38d-93ec0108a675}";
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

        private void GetEIDTestbyAge()
        {
            if (txtdatefrom.Text == "" || txtdateto.Text == "")
                //jsonEIDTestByAge = _presenter.GetEIDOutcomesbyAge(Convert.ToInt32(ddlLocation.SelectedValue), new DateTime(DateTime.Today.Year, 1, 1), DateTime.Today);
                jsonEIDTestByAge = _presenter.GetEIDOutcomesbyAge(Convert.ToInt32(ddlLocation.SelectedValue), new DateTime(DateTime.Today.Year - 100, 1, 1), DateTime.Today);
            else
                jsonEIDTestByAge = _presenter.GetEIDOutcomesbyAge(Convert.ToInt32(ddlLocation.SelectedValue), DateTime.Parse(txtdatefrom.Text), DateTime.Parse(txtdateto.Text));
            JstringEIDTestByAge = Newtonsoft.Json.JsonConvert.SerializeObject(jsonEIDTestByAge);
        }
        private void GetEIDTestbyModeOfDelivery()
        {
            if (txtdatefrom.Text == "" || txtdateto.Text == "")
                jsonEIDTestByModeOfDelivery = _presenter.GetEIDModeofDelivery(Convert.ToInt32(ddlLocation.SelectedValue), new DateTime(DateTime.Today.Year - 100, 1, 1), DateTime.Today);

            else
                jsonEIDTestByModeOfDelivery = _presenter.GetEIDModeofDelivery(Convert.ToInt32(ddlLocation.SelectedValue), DateTime.Parse(txtdatefrom.Text), DateTime.Parse(txtdateto.Text));
            JstringEIDTestByModeOfDelivery = Newtonsoft.Json.JsonConvert.SerializeObject(jsonEIDTestByModeOfDelivery);

        }
        private void GetEIDOutcomes()
        {
            if (txtdatefrom.Text == "" || txtdateto.Text == "")
                jsonEIDOutcome = _presenter.GetEIDOutcomes(Convert.ToInt32(ddlLocation.SelectedValue), new DateTime(DateTime.Today.Year - 100, 1, 1), DateTime.Today);

            else
                jsonEIDOutcome = _presenter.GetEIDOutcomes(Convert.ToInt32(ddlLocation.SelectedValue), DateTime.Parse(txtdatefrom.Text), DateTime.Parse(txtdateto.Text));
            JstringEIDOutcome = Newtonsoft.Json.JsonConvert.SerializeObject(jsonEIDOutcome);
        }
        private void GetInfantFeeding()
        {
            // jsonEIDTestByAge = _presenter.GetEIDOutcomesbyAge(Convert.ToInt32(ddlLocation.SelectedValue), DateTime.Parse(txtdatefrom.Text), DateTime.Parse(txtdateto.Text));
            // jsonInfantFeeding = _presenter.GetInfantFeeding(Convert.ToInt32(ddlLocation.SelectedValue), DateTime.Parse("1/1/2015"), DateTime.Parse("1/1/2018"));
            if (txtdatefrom.Text == "" || txtdateto.Text == "")
                jsonInfantFeeding = _presenter.GetInfantFeeding(Convert.ToInt32(ddlLocation.SelectedValue), new DateTime(DateTime.Today.Year - 100, 1, 1), DateTime.Today);

            else
                jsonInfantFeeding = _presenter.GetInfantFeeding(Convert.ToInt32(ddlLocation.SelectedValue), DateTime.Parse(txtdatefrom.Text), DateTime.Parse(txtdateto.Text));

            JstringInfantFeeding = Newtonsoft.Json.JsonConvert.SerializeObject(jsonInfantFeeding);
        }
        private void GetEIDIntialPCR()
        {
            if (txtdatefrom.Text == "" || txtdateto.Text == "")
                jsonEIDIntialPCR = _presenter.GetEIDIntialPCR(Convert.ToInt32(ddlLocation.SelectedValue), new DateTime(DateTime.Today.Year - 100, 1, 1), DateTime.Today);

            else
                jsonEIDIntialPCR = _presenter.GetEIDIntialPCR(Convert.ToInt32(ddlLocation.SelectedValue), DateTime.Parse(txtdatefrom.Text), DateTime.Parse(txtdateto.Text));
            JstringEIDIntialPCR = Newtonsoft.Json.JsonConvert.SerializeObject(jsonEIDIntialPCR);
        }
        private void GetEIDIntialPCRbyProvince()
        {
            if (txtdatefrom.Text == "" || txtdateto.Text == "")
                jsonEIDIntialPCRbyProvince = _presenter.GetEIDIntialPCRbyProvince(Convert.ToInt32(ddlLocation.SelectedValue), new DateTime(DateTime.Today.Year - 100, 1, 1), DateTime.Today);

            else
                jsonEIDIntialPCRbyProvince = _presenter.GetEIDIntialPCRbyProvince(Convert.ToInt32(ddlLocation.SelectedValue), DateTime.Parse(txtdatefrom.Text), DateTime.Parse(txtdateto.Text));
            JstringEIDIntialPCRbyProvince = Newtonsoft.Json.JsonConvert.SerializeObject(jsonEIDIntialPCRbyProvince);
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
                lbloutcomeProFac.Text = "State/Region Outcome";
            }
            GetEIDTestbyAge();
            GetEIDTestbyModeOfDelivery();
            GetEIDOutcomes();
            GetInfantFeeding();
            GetEIDIntialPCR();

        }
    }
}