using CHAI.LISDashboard.CoreDomain;
using CHAI.LISDashboard.CoreDomain.DataAccess;
using CHAI.LISDashboard.CoreDomain.Report;
using CHAI.LISDashboard.CoreDomain.Users;
using CHAI.LISDashboard.CoreDomain.Setting;
using Microsoft.Practices.ObjectBuilder;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CHAI.LISDashboard.Modules.VLDashboard.Views
{
    public partial class FrmFacility : POCBasePage, IFrmFacilityView
    {
        private FrmFacilityPresenter _presenter;
        private ReportDao dao;

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

        public IList jsonVLTestReasonByAbbott { get; set; }
        public string JstringVLTestReasonByAbbott { get; set; }

        public IList jsonVLTestReasonByBioCentric { get; set; }
        public string JstringVLTestReasonByBioCentric { get; set; }

        public IList jsonVLTestReasonByGeneXpert { get; set; }
        public string JstringVLTestReasonByGeneXpert { get; set; }

        public IList jsonVLSummary { get; set; }
        public string JstringVLSummary { get; set; }

        public IList jsonVLTestLabAndFacility { get; set; }
        public string JstringVLTestLabAndFacility { get; set; }

        //public string filter_criteria { get; set; }

        // Added by ZaySoe Searching by FacilityType
        private String provinceIDs = string.Empty;
        //String PrFacility = string.Empty;
        private String facilityTypes = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this._presenter.OnViewInitialized();

                //Session.Remove("FacilityTypeList");
                //Session.Remove("FacilityList");

                BindLocation();
                PopulateYears();
                BindFacility();                
                BindFacilityType("");
                BindUserInfo();
                //BindInstruments();
                
                GetVLTestYearly();
                GetVLTestQuarterly();
                GetVLTestMonthly();

                GetVLTestByAgeYearly();
                GetVLTestByGenderOutcome();
                GetVLTestByProvince();
                //GetVLTestAgeGroupByProvince();
                GetVLTestRejectByProvince();
                GetVLTestLabAndFacility();
                //GetVLTestReasonByLab();

                //GetVLLabByLabInstruments();
                //GetVLLabByLabInstrumentComparison();

                //GetVLTATTrends();
                GetVLSummary();

                //this.BindSummaryStat();
                //this.filter_criteria = "(" + ddlYearFrom.SelectedValue + " - " + ddlYearTo.SelectedValue + ")";

                rdbFacilityType.Items[2].Selected = true;
                foreach (ListItem li in ddlFacilityType.Items)
                {
                    li.Selected = true;
                }
            }            
            this._presenter.OnViewLoaded();

            ddlYearFrom.DataBind();
            ddlYearTo.DataBind();

            divNational.Visible = false;
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
        public FrmFacilityPresenter Presenter
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

        private void BindFacility()
        {
            ddlProvince.Items.Clear();
            //ddlFacility.DataSource = null;
            ddlFacilityType.Items.Clear();
                                    
            if (CurrentUser.AppUserRoles[0].Role.Name == "Administrator")
            {                
                // Provinces
                IList<Province> dtProvince = _presenter.GetProvinces();
                foreach (Province obj in dtProvince)
                {
                    ddlProvince.Items.Add(new ListItem(obj.ProvinceName, obj.Id.ToString()));
                }

                chkAllRegion_OnCheckedChanged(chkAllRegion, null);

                // Facilities
                IList<Facility> facilityList = _presenter.GetFacilities();                

                //convert list to datatable
                DataTable table = new DataTable("Facility");
                table.Columns.Add("FacilityId", typeof(int));
                table.Columns.Add("FacilityName");
                table.Columns.Add("ProvinceId", typeof(int));
                table.Columns.Add("FacilityType2");
                foreach (Facility obj in facilityList)
                {
                    DataRow facilityRow = table.NewRow();
                    facilityRow["FacilityId"] = obj.Id;
                    facilityRow["FacilityName"] = obj.FacilityName;
                    facilityRow["ProvinceId"] = obj.ProvinceId;
                    facilityRow["FacilityType2"] = obj.FacilityType2;
                    table.Rows.Add(facilityRow);
                }

                ddlFacility.DataValueField = "FacilityId";
                ddlFacility.DataTextField = "FacilityName";
                ddlFacility.DataSource = table;
                ddlFacility.DataBind();

                Session["FacilityList"] = table;
            }            
            else {
                dao = new ReportDao();
                DataSet infoDS = dao.GetUserLocationsInfo(CurrentUser.Id);
                DataTable table = infoDS.Tables[0];
                DataView dview = new DataView(table);
                dview.Sort = "FacilityName";        // for descending   "FacilityName DESC"
                table = dview.ToTable();

                Session["FacilityList"] = table;

                // Provinces
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
                    ddlProvince.Items.Add(new ListItem(row.attrib_name2, row.attrib_name1.ToString()));
                }

                chkAllRegion_OnCheckedChanged(chkAllRegion, null);

                // Facilities
                DataTable dtFacility = new DataTable("Facility");
                dtFacility.Columns.Add("FacilityId");
                dtFacility.Columns.Add("FacilityName");

                //string selectedProvinceIds = string.Empty;
                List<string> selectedProvinceIds = new List<string>();
                foreach (ListItem item in ddlProvince.Items)
                {
                    if (item.Selected)
                        selectedProvinceIds.Add(item.Value);
                        //selectedProvinceIds = (selectedProvinceIds == string.Empty ? "\"" + item.Value + "\"" : ",\"" + item.Value + "\"");                                            
                }

                //DataRow[] dr = table.Select("ProvinceId IN [" + selectedProvinceIds + "]");
                //DataRow[] dr = table.Select("ProvinceId IN " + selectedProvinceIds);
                foreach (DataRow row in table.Rows)
                {
                    //string a = row["ProvinceId"].ToString();
                    foreach (string selProvinceId in selectedProvinceIds)
                    {
                        if(row["ProvinceId"].ToString() == selProvinceId)
                        {
                            DataRow facilityRow = dtFacility.NewRow();
                            facilityRow["FacilityId"] = row["FacilityId"];
                            facilityRow["FacilityName"] = row["FacilityName"];
                            dtFacility.Rows.Add(facilityRow);
                        }
                    }                                         
                }

                ddlFacility.DataValueField = "FacilityId";
                ddlFacility.DataTextField = "FacilityName";
                ddlFacility.DataSource = dtFacility;
                ddlFacility.DataBind();

                //foreach(DataRow row in table.Rows)
                //{
                //    bool contain = ddlProvince.Items.Contains(new ListItem(row["ProvinceName"].ToString(), row["ProvinceId"].ToString()));
                //    if(!contain)
                //    {
                //        ddlProvince.Items.Add(new ListItem(row["ProvinceName"].ToString(), row["ProvinceId"].ToString()));
                //    }                                                                                                                        
                //}
            }
        }
        
        protected void rdbFacilityType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdbFacilityType.SelectedValue == "Public")
            {
                BindFacilityType("Public");
            }
            else if (rdbFacilityType.SelectedValue == "Private")
            {
                BindFacilityType("Private");
            }
            else if (rdbFacilityType.SelectedValue == "All")
            {
                BindFacilityType("");
            }

            foreach (ListItem li in ddlFacilityType.Items)
            {
                li.Selected = true;
            }
        }        

        protected void BindFacilityType(string value)
        {
            ddlFacilityType.Items.Clear();

            IList<FacilityType> facilityTypeList = null;
            if (Session["FacilityTypeList"] == null)
            {
                facilityTypeList = _presenter.GetFacilityTypeByFacilityType2(string.Empty);
                Session["FacilityTypeList"] = facilityTypeList;
            }
            else
            {
                facilityTypeList = (IList<FacilityType>) Session["FacilityTypeList"];
            }

            IList<FacilityType> typeList = null;
            if(value == "")
                typeList = facilityTypeList;
            else
                typeList = facilityTypeList.Where(x => x.FacilityType2 == value).ToList();

            IList<FacilityType> selectedList = new List<FacilityType>();
            #region Show only FacilityType2 for Selected Faclilities            
            DataTable table = (DataTable) Session["FacilityList"];

            // selected provinceIds
            List<int> selectedProvinceIds = new List<int>();
            foreach (ListItem item in ddlProvince.Items)
            {
                if (item.Selected)
                {
                    var distinctValues = table.AsEnumerable()
                            .Select(row => new
                            {
                                attrib_name1 = row.Field<string>("FacilityType2"),
                                attrib_name2 = row.Field<int>("ProvinceId"),
                            }).Where(x => x.attrib_name2 == Convert.ToInt32(item.Value))
                            .Distinct();
                    foreach (var row in distinctValues)
                    {
                        foreach (FacilityType type in typeList)
                        {
                            if (row.attrib_name1 != null && row.attrib_name1.ToString() == type.FacilityType2
                                && !selectedList.Contains(type))
                                selectedList.Add(type);
                        }
                    }
                }                    
            }            

            
            #endregion            

            //Label1.Text = "" + distinctValues.Count();
            //Label1.Text = selectedList.Count + " @@ " + value;

            ddlFacilityType.DataSource = selectedList;
            ddlFacilityType.DataBind();            
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
            jsonVLTestYearly = _presenter.GetVLFacilityTestYearly(                
                Convert.ToInt32(ddlFacility.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name, provinceIDs, facilityTypes);
            JstringVLTestYearly = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLTestYearly);
        }

        private void GetVLTestQuarterly()
        {
            jsonVLTestQuarterly = _presenter.GetVLFacilityTestQuarterly(
                Convert.ToInt32(ddlFacility.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name, provinceIDs, facilityTypes);
            JstringVLTestQuarterly = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLTestQuarterly);
        }

        private void GetVLTestMonthly()
        {
            jsonVLTestMonthly = _presenter.GetVLFacilityTestMonthly(
                Convert.ToInt32(ddlFacility.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name, provinceIDs, facilityTypes);
            JstringVLTestMonthly = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLTestMonthly);
        }

        private void GetVLTestByAgeYearly()
        {
            jsonVLTestByAgeYearly = _presenter.GetVLFacilityTestByAgeYearly(
                Convert.ToInt32(ddlFacility.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name, provinceIDs, facilityTypes);
            JstringVLTestByAgeYearly = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLTestByAgeYearly);
        }

        private void GetVLTestByGenderOutcome()
        {
            jsonVLTestByGender = _presenter.GetVLFacilityTestByGenderOutcome(
                Convert.ToInt32(ddlFacility.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name, provinceIDs, facilityTypes);
            JstringVLTestByGender = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLTestByGender);
        }

        private void GetVLTestByProvince()
        {
            jsonVLTestByProvince = _presenter.GetVLFacilityTestByProvince(
                Convert.ToInt32(ddlFacility.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name, provinceIDs, facilityTypes);
            JstringVLTestByProvince = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLTestByProvince);
        }

        //private void GetVLTestAgeGroupByProvince()
        //{
        //    jsonVLTestAgeGroupByProvince = _presenter.GetVLTestAgeGroupByProvince(
        //        Convert.ToInt32(ddlFacility.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name, provinceIDs, facilityTypes);
        //    JstringVLTestAgeGroupByProvince = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLTestAgeGroupByProvince);
        //}

        private void GetVLTestRejectByProvince()
        {
            jsonVLTestRejectByProvince = _presenter.GetVLTestRejectByProvinceForFacility(
                Convert.ToInt32(ddlFacility.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name, provinceIDs, facilityTypes);
            JstringVLTestRejectByProvince = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLTestRejectByProvince);
        }

        //Sample Drainage by Lab
        private void GetVLTestLabAndFacility()
        {
            jsonVLTestLabAndFacility = _presenter.GetVLTestLabAndFacility(
                Convert.ToInt32(ddlFacility.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name, provinceIDs, facilityTypes);
            JstringVLTestLabAndFacility = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLTestLabAndFacility);
        }

        //private void GetVLTestReasonByLab()
        //{
        //    //Abbott
        //    int labInstruId = 7;
        //    jsonVLTestReasonByAbbott = _presenter.GetVLFacilityTestByLab(
        //        Convert.ToInt32(ddlFacility.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name, labInstruId);
        //    JstringVLTestReasonByAbbott= Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLTestReasonByAbbott);

        //    //BioCentric
        //    labInstruId = 8;
        //    jsonVLTestReasonByBioCentric = _presenter.GetVLFacilityTestByLab(
        //        Convert.ToInt32(ddlFacility.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name, labInstruId);
        //    JstringVLTestReasonByBioCentric = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLTestReasonByBioCentric);

        //    //GeneXpert
        //    labInstruId = 9;
        //    jsonVLTestReasonByGeneXpert = _presenter.GetVLFacilityTestByLab(
        //        Convert.ToInt32(ddlFacility.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name, labInstruId);
        //    JstringVLTestReasonByGeneXpert = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLTestReasonByGeneXpert);
        //}

        //private void GetVLLabByLabInstruments()
        //{
        //    //Abbott
        //    int labInstruId = 7;
        //    jsonVLLabByLabInstrumentAbbott = _presenter.GetVLLabByLabInstrument(
        //        Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name, labInstruId);
        //    JstringVLLabByLabInstrumentAbbott = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLLabByLabInstrumentAbbott);

        //    //BioCentric
        //    labInstruId = 8;
        //    jsonVLLabByLabInstrumentBioCentric = _presenter.GetVLLabByLabInstrument(
        //        Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name, labInstruId);
        //    JstringVLLabByLabInstrumentBioCentric = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLLabByLabInstrumentBioCentric);            

        //    //GeneXpert
        //    labInstruId = 9;
        //    jsonVLLabByLabInstrumentGeneXpert = _presenter.GetVLLabByLabInstrument(
        //        Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name, labInstruId);
        //    JstringVLLabByLabInstrumentGeneXpert = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLLabByLabInstrumentGeneXpert);

        //    //Conventional PCR
        //    //labInstruId = 5;
        //    //jsonVLLabByLabInstrumentConventional = _presenter.GetVLLabByLabInstrument(
        //    //    Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name, labInstruId);
        //    //JstringVLLabByLabInstrumentConventional = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLLabByLabInstrumentConventional);
        //}

        //private void GetVLLabByLabInstrumentComparison()
        //{            
        //    jsonVLLabByLabInstrumentComparison = _presenter.GetVLLabByLabInstrumentComparison(
        //        Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name);
        //    JstringVLLabByLabInstrumentComparison = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLLabByLabInstrumentComparison);            
        //}

        //private void GetVLTATTrends()
        //{
        //    jsonVLTATTrends = _presenter.GetVLTurnAroundTime(
        //        Convert.ToInt32(ddlFacility.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name);
        //    JstringVLTATTrends = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLTATTrends);
        //}

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            //if (ddlFacility.SelectedValue != "0")
            //{
            //    lbllocation.Text = "National / " + ddlFacility.SelectedItem.Text;                
            //}
            //else
            //{
            //    lbllocation.Text = "National";               
            //}
            if (ddlFacility.SelectedValue != "0")
            {
                //lbllocation.Text = "National / " + ddlFacility.SelectedItem.Text;
                //lbloutcomeProFac.Text = "Facility Outcome under " + ddlFacility.SelectedItem.Text + " Province";
            }
            else
            {
                //lbllocation.Text = "National";
                //lbloutcomeProFac.Text = "Province Outcome";
            }

            //if (CurrentUser.UserLocations != null && CurrentUser.UserLocations.Count > 0)
            //    lbllocation.Text = CurrentUser.UserLocations[0].LabCode;
            
            foreach (ListItem lst in ddlProvince.Items)
            {
                if (lst.Selected)
                {
                    provinceIDs += lst.Value + ",";
                }
            }

            if (provinceIDs != "") provinceIDs += "," + provinceIDs;

            if (rdbFacilityType.SelectedValue != "All")
            {
                foreach (ListItem lst in ddlFacilityType.Items)
                {
                    if (lst.Selected)
                    {
                        facilityTypes += lst.Value + ",";
                        //PrFacility = PrFacility + lst.Text + ",";
                    }
                }
                if (facilityTypes != "") facilityTypes += "," + facilityTypes;
            }

            BindUserInfo();
            GetVLTestYearly();
            GetVLTestQuarterly();
            GetVLTestMonthly();

            GetVLTestByAgeYearly();
            GetVLTestByGenderOutcome();
            GetVLTestByProvince();
            //GetVLTestAgeGroupByProvince();
            GetVLTestRejectByProvince();
            GetVLTestLabAndFacility();
            //GetVLTestReasonByLab();

            //GetVLLabByLabInstruments();
            //GetVLLabByLabInstrumentComparison();

            //GetVLTATTrends();
            GetVLSummary();
            //BindSummaryStat();
            //this.filter_criteria = "(" + ddlYearFrom.SelectedValue + " - " + ddlYearTo.SelectedValue + ")";            
        }

        protected void btnLabFilter_Click(object sender, EventArgs e)
        {
            ////Abbott
            //int labInstruId = 7;
            //jsonVLLabByLabInstrumentAbbott = _presenter.GetVLLabByLabInstrument(
            //    Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name, labInstruId);
            //JstringVLLabByLabInstrumentAbbott = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLLabByLabInstrumentAbbott);

            ////BioCentric
            //labInstruId = 8;
            //jsonVLLabByLabInstrumentBioCentric = _presenter.GetVLLabByLabInstrument(
            //    Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name, labInstruId);
            //JstringVLLabByLabInstrumentBioCentric = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLLabByLabInstrumentBioCentric);

            ////GeneXpert
            //labInstruId = 9;
            //jsonVLLabByLabInstrumentGeneXpert = _presenter.GetVLLabByLabInstrument(
            //    Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name, labInstruId);
            //JstringVLLabByLabInstrumentGeneXpert = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLLabByLabInstrumentGeneXpert);

            //Conventional PCR
            //labInstruId = 5;
            //jsonVLLabByLabInstrumentConventional = _presenter.GetVLLabByLabInstrument(
            //    Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name, labInstruId);
            //JstringVLLabByLabInstrumentConventional = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLLabByLabInstrumentConventional);
        }

        private void GetVLSummary()
        {
            jsonVLSummary = _presenter.GetVLFacilitySummary(Convert.ToInt32(ddlFacility.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name, provinceIDs, facilityTypes);//, DateTime.Parse(txtdatefrom.Text), DateTime.Parse(txtdateto.Text));
            JstringVLSummary = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLSummary);
        }

        //private void BindSummaryStat()
        //{
        //    VLStat result = _presenter.VLFacilitySummaryStat(ddlYearFrom.Text, ddlYearTo.Text, Convert.ToInt32(ddlFacility.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name, provinceIDs, facilityTypes);

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

        private void BindUserInfo()
        {            
            //dao = new ReportDao();
            //DataSet infoDS = dao.GetUserLocationsInfo(CurrentUser.Id);
            //DataTable table = infoDS.Tables[0];

            //DataView dview = new DataView(table);
            //dview.Sort = "FacilityName";        // for descending   "FacilityName DESC"
            //table = dview.ToTable();

            //for (int i = 0; i < table.Rows.Count; i++)
            //{
            //    //lbllocation.Text = table.Rows[0]["LaboratoryName"].ToString();
            //    LinkButton hyp = new LinkButton();
            //    hyp.ID = "hyp" + table.Rows[i]["FacilityId"].ToString();
            //    //hyp.NavigateUrl = "";
            //    hyp.Text = table.Rows[i]["FacilityName"].ToString();
            //    hyp.ToolTip = table.Rows[i]["FacilityName"].ToString();
            //    hyp.CssClass = "btn btn-info";
            //    //hyp.CssClass = "btn btn-link";
            //    hyp.Style.Add("margin-right", "5px");
            //    hyp.Style.Add("margin-bottom", "2px");
            //    //hyp.Target = "_new";            
            //    //hyp.Click += (hypFacility_Click);

            //    plhFacilities.Controls.Add(hyp);
            //}
        }

        protected void chkAllRegion_OnCheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;
            string strchkname = chk.ID;
            string FacilityType2 = string.Empty;
            switch (strchkname)
            {
                case "chkAllRegion":
                    if (chk.Checked == true)
                    {
                        foreach (ListItem li in ddlProvince.Items)
                        {
                            li.Selected = true;
                        }
                    }
                    else
                    {
                        ddlProvince.ClearSelection();
                    }
                    break;
            }
            this.UpdateFacilities();
            this.rdbFacilityType_SelectedIndexChanged(rdbFacilityType, null);
        }

        protected void ddlProvince_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            this.UpdateFacilities();
            this.rdbFacilityType_SelectedIndexChanged(rdbFacilityType, null);
        }

        private void UpdateFacilities()
        {
            if (Session["FacilityList"] == null)
                return;

            ddlFacility.Items.Clear();
            DataTable table = (DataTable)Session["FacilityList"];

            // Facilities
            DataTable dtFacility = new DataTable("Facility");
            dtFacility.Columns.Add("FacilityId");
            dtFacility.Columns.Add("FacilityName");
            List<string> selectedProvinceIds = new List<string>();
            foreach (ListItem item in ddlProvince.Items)
            {
                if (item.Selected)
                    selectedProvinceIds.Add(item.Value);
            }
            
            if (selectedProvinceIds.Count == ddlProvince.Items.Count)
                chkAllRegion.Checked = true;
            else
                chkAllRegion.Checked = false;

            //DataRow[] dr = table.Select("ProvinceId IN " + selectedProvinceIds);
            DataRow facilityRow = null;
            int c = 0;            
            foreach (DataRow row in table.Rows)
            {
                //string a = row["ProvinceId"].ToString();
                Boolean found = false;
                foreach (string selProvinceId in selectedProvinceIds)
                {
                    if (row["ProvinceId"].ToString() == selProvinceId)
                    {
                        found = true;
                        break;
                    }
                }
                if (found)
                {
                    c++;
                    facilityRow = dtFacility.NewRow();
                    facilityRow["FacilityId"] = row["FacilityId"];
                    facilityRow["FacilityName"] = row["FacilityName"];
                    dtFacility.Rows.Add(facilityRow);
                }
            }

            //int count = dtFacility.Rows.Count;
            //Label1.Text = string.Empty;
            //foreach (string selProvinceId in selectedProvinceIds)
            //{
            //    Label1.Text += selProvinceId.ToString() + ", ";
            //}
            //Label1.Text += "$$ " + c;

            DataView dview = new DataView(dtFacility);
            dview.Sort = "FacilityName";        // for descending   "FacilityName DESC"
            dtFacility = dview.ToTable();

            facilityRow = dtFacility.NewRow();
            facilityRow["FacilityId"] = 0;
            facilityRow["FacilityName"] = "All Facilities";
            dtFacility.Rows.InsertAt(facilityRow, 0);

            //ddlFacility.DataValueField = "Id";
            //ddlFacility.DataTextField = "FacilityName";
            //ddlFacility.DataSource = dtFacility;
            //ddlFacility.DataBind();

            ddlFacility.DataValueField = "FacilityId";
            ddlFacility.DataTextField = "FacilityName";
            ddlFacility.DataSource = dtFacility;
            ddlFacility.DataBind();

            //UpdatePanel1.Update();
            //ddlFacility.SelectedIndex = 0;
            ddlFacility.SelectedIndex = 0;
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