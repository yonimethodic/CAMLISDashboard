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
using CHAI.LISDashboard.CoreDomain.Setting;

namespace CHAI.LISDashboard.Modules.EIDDashboard.Views
{
    public partial class FrmFacility : POCBasePage, IFrmFacilityView
    {
        private FrmFacilityPresenter _presenter;
        private ReportDao dao;
        
        public IList jsonEIDInitialPCRbyYearly { get; set; }
        public string JstringEIDInitialPCRbyYearly { get; set; }

        public IList jsonEIDInitialPCRbyMonthly { get; set; }
        public string JstringEIDInitialPCRbyMonthly { get; set; }

        public IList jsonEIDInitialPCRbyQuarterly { get; set; }
        public string JstringEIDInitialPCRbyQuarterly { get; set; }
        
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

        public IList jsonEIDPCRByFacility { get; set; }
        public string JstringEIDPCRByFacility { get; set; }

        public IList jsonEIDSummary { get; set; }
        public string JstringEIDSummary { get; set; }

        public IList jsonEIDTestRejectByProvince { get; set; }
        public string JstringEIDTestRejectByProvince { get; set; }

        public IList jsonEIDTestLabAndFacility { get; set; }
        public string JstringEIDTestLabAndFacility { get; set; }

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

                GetEIDInitialPCRbyYearly();
                GetEIDInitialPCRbyQuarterly();
                GetEIDInitialPCRbyMonthly();

                GetEIDIntialPCRAgeByYearly();
                GetEIDIntialPCRAgeByQuarterly();
                GetEIDIntialPCRAgeByMonthly();

                GetEIDTestByAgeOutcome();
                GetEIDTestByGenderOutcome();

                GetEIDPCRByFacility();
                GetEIDTestLabAndFacility();
                //BindSummaryStat();
                GetEIDSummary();
                GetEIDTestRejectByProvince();                

                rdbFacilityType.Items[2].Selected = true;
                foreach (ListItem li in ddlFacilityType.Items)
                {
                    li.Selected = true;
                }
            }
            this._presenter.OnViewLoaded();
                       
            divNational.Visible = false;
        }
        public override string PageID
        {
            get
            {
                return "{224a56ae-fe31-4c34-8a66-c95125f2fe1d}";
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
            else
            {
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
                        if (row["ProvinceId"].ToString() == selProvinceId)
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
                facilityTypeList = (IList<FacilityType>)Session["FacilityTypeList"];
            }

            IList<FacilityType> typeList = null;
            if (value == "")
                typeList = facilityTypeList;
            else
                typeList = facilityTypeList.Where(x => x.FacilityType2 == value).ToList();

            IList<FacilityType> selectedList = new List<FacilityType>();
            #region Show only FacilityType2 for Selected Faclilities            
            DataTable table = (DataTable)Session["FacilityList"];

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

        private void GetEIDInitialPCRbyYearly()
        {            
            jsonEIDInitialPCRbyYearly = _presenter.GetEIDFacilityIntialPCRbyYear(Convert.ToInt32(ddlFacility.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name, provinceIDs, facilityTypes);
            JstringEIDInitialPCRbyYearly = Newtonsoft.Json.JsonConvert.SerializeObject(jsonEIDInitialPCRbyYearly);
        }
        private void GetEIDInitialPCRbyMonthly()
        {
            jsonEIDInitialPCRbyMonthly = _presenter.GetEIDFacilityIntialPCRbyMonth(Convert.ToInt32(ddlFacility.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name, provinceIDs, facilityTypes);
            JstringEIDInitialPCRbyMonthly = Newtonsoft.Json.JsonConvert.SerializeObject(jsonEIDInitialPCRbyMonthly);
        }
        private void GetEIDInitialPCRbyQuarterly()
        {
            jsonEIDInitialPCRbyQuarterly = _presenter.GetEIDFacilityAllTestbyYear(Convert.ToInt32(ddlFacility.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name, provinceIDs, facilityTypes);
            JstringEIDInitialPCRbyQuarterly = Newtonsoft.Json.JsonConvert.SerializeObject(jsonEIDInitialPCRbyQuarterly);
        }
        
        //Added by ZaySoe on 09_Jan_2019
        private void GetEIDIntialPCRAgeByYearly()
        {
            jsonEIDIntialPCRAgeByYearly = _presenter.GetEIDFacilityIntialPCRAgeByYearly(Convert.ToInt32(ddlFacility.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name, provinceIDs, facilityTypes);
            JstringEIDIntialPCRAgeByYearly = Newtonsoft.Json.JsonConvert.SerializeObject(jsonEIDIntialPCRAgeByYearly);
        }
        private void GetEIDIntialPCRAgeByQuarterly()
        {
            jsonEIDIntialPCRAgeByQuarterly = _presenter.GetEIDFacilityIntialPCRAgeByQuarterly(Convert.ToInt32(ddlFacility.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name, provinceIDs, facilityTypes);
            JstringEIDIntialPCRAgeByQuarterly = Newtonsoft.Json.JsonConvert.SerializeObject(jsonEIDIntialPCRAgeByQuarterly);
        }
        private void GetEIDIntialPCRAgeByMonthly()
        {
            jsonEIDIntialPCRAgeByMonthly = _presenter.GetEIDFacilityIntialPCRAgeByMonthly(Convert.ToInt32(ddlFacility.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name, provinceIDs, facilityTypes);
            JstringEIDIntialPCRAgeByMonthly = Newtonsoft.Json.JsonConvert.SerializeObject(jsonEIDIntialPCRAgeByMonthly);
        }

        private void GetEIDTestByAgeOutcome()
        {
            jsonEIDTestByAgeOutcome = _presenter.GetEIDTestByAgeOutcomeForFacility(
                Convert.ToInt32(ddlFacility.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name, provinceIDs, facilityTypes);
            JstringEIDTestByAgeOutcome = Newtonsoft.Json.JsonConvert.SerializeObject(jsonEIDTestByAgeOutcome);
        }

        private void GetEIDTestByGenderOutcome()
        {
            jsonEIDTestByGender = _presenter.GetEIDFacilityTestByGenderOutcome(
                Convert.ToInt32(ddlFacility.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name, provinceIDs, facilityTypes);
            JstringEIDTestByGender = Newtonsoft.Json.JsonConvert.SerializeObject(jsonEIDTestByGender);
        }

        //Sample Drainage by Lab
        private void GetEIDTestLabAndFacility()
        {
            jsonEIDTestLabAndFacility = _presenter.GetEIDTestLabAndFacility(
                Convert.ToInt32(ddlFacility.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name, provinceIDs, facilityTypes);
            JstringEIDTestLabAndFacility = Newtonsoft.Json.JsonConvert.SerializeObject(jsonEIDTestLabAndFacility);
        }

        private void GetEIDPCRByFacility()
        {
            jsonEIDPCRByFacility = _presenter.GetEIDFacilityPCR(Convert.ToInt32(ddlFacility.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name, provinceIDs, facilityTypes);
            JstringEIDPCRByFacility = Newtonsoft.Json.JsonConvert.SerializeObject(jsonEIDPCRByFacility);
        }

        private void GetEIDTestRejectByProvince()
        {
            jsonEIDTestRejectByProvince = _presenter.GetEIDTestRejectByProvinceForFacility(
                Convert.ToInt32(ddlFacility.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name, provinceIDs, facilityTypes);
            JstringEIDTestRejectByProvince = Newtonsoft.Json.JsonConvert.SerializeObject(jsonEIDTestRejectByProvince);
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            //if (ddlLocation.SelectedValue != "0")
            //{
            //    lbllocation.Text = ddlLocation.SelectedItem.Text + " District";
            //    lbloutcomeProFac.Text = "Facility Outcome under " + ddlLocation.SelectedItem.Text + " Province";
            //}
            //else
            //{
            //    lbllocation.Text = "National";
            //    lbloutcomeProFac.Text = "Province Outcome";
            //}
            if (ddlLocation.SelectedValue != "0")
            {
                //lbllocation.Text = "National / " + ddlLocation.SelectedItem.Text;
                //lbloutcomeProFac.Text = "Facility Outcome under " + ddlLocation.SelectedItem.Text + " Province";
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
            GetEIDInitialPCRbyYearly();
            GetEIDInitialPCRbyQuarterly();
            GetEIDInitialPCRbyMonthly();

            GetEIDIntialPCRAgeByYearly();
            GetEIDIntialPCRAgeByQuarterly();
            GetEIDIntialPCRAgeByMonthly();

            GetEIDTestByAgeOutcome();
            GetEIDTestByGenderOutcome();
            GetEIDTestLabAndFacility();

            GetEIDPCRByFacility();
            //BindSummaryStat();

            GetEIDSummary();
            GetEIDTestRejectByProvince();
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
        #endregion

        //private void BindSummaryStat()
        //{
        //    EIDStat result = _presenter.EIDFacilitySummaryStat(ddlYearFrom.Text, ddlYearTo.Text, Convert.ToInt32(ddlFacility.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name, provinceIDs, facilityTypes);

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

        //        lblTotalInitial.Text = result.Tot_Initial.ToString();
        //        lblTotalInitialPositive.Text = result.Tot_Initial_Positive.ToString();
        //        lblTotalInitial_lt2months.Text = result.Total_Initial_lt2month.ToString();
        //        lblInitialRate.Text = result.Initial_Rate.ToString();
        //        lblInitialPositiveRate.Text = result.Initial_Positive_Rate.ToString();
        //        lblInitialLT2Months.Text = result.Initial_lt2months_Rate.ToString();
        //    }
        //}

        private void GetEIDSummary()
        {
            jsonEIDSummary = _presenter.GetEIDFacilitySummary(Convert.ToInt32(ddlFacility.SelectedValue), Convert.ToInt32(ddlYearFrom.SelectedValue), Convert.ToInt32(ddlYearTo.SelectedValue), CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name, provinceIDs, facilityTypes);
            JstringEIDSummary = Newtonsoft.Json.JsonConvert.SerializeObject(jsonEIDSummary);
        }

        private void BindUserInfo()
        {            
            dao = new ReportDao();
            DataSet infoDS = dao.GetUserLocationsInfo(CurrentUser.Id);
            DataTable table = infoDS.Tables[0];

            DataView dview = new DataView(table);
            dview.Sort = "FacilityName";        // for descending   "FacilityName DESC"
            table = dview.ToTable();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                //lbllocation.Text = table.Rows[0]["LaboratoryName"].ToString();
                LinkButton hyp = new LinkButton();
                hyp.ID = "hyp" + table.Rows[i]["FacilityId"].ToString();
                //hyp.NavigateUrl = "";
                hyp.Text = table.Rows[i]["FacilityName"].ToString();
                hyp.ToolTip = table.Rows[i]["FacilityName"].ToString();
                hyp.CssClass = "btn btn-info";
                //hyp.CssClass = "btn btn-link";
                hyp.Style.Add("margin-right", "5px");
                hyp.Style.Add("margin-bottom", "2px");
                //hyp.Target = "_new";            
                //hyp.Click += (hypFacility_Click);

                //plhFacilities.Controls.Add(hyp);
            }                
        }

        protected void checkedAll(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;
            string strchkname = chk.ID;
            string FacilityType2 = string.Empty;
            switch (strchkname)
            {
                case "chkRegion":
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
    }
}