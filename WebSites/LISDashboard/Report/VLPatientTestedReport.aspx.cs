using System;
using System.Web.UI.WebControls;
using Microsoft.Practices.ObjectBuilder;
using System.Data;
using System.Web;
using CrystalDecisions.CrystalReports.Engine;
using CHAI.LISDashboard.CoreDomain.Setting;
using CHAI.LISDashboard.CoreDomain.DataAccess;
using CHAI.LISDashboard.Shared;
using CHAI.LISDashboard.CoreDomain.Users;
using CHAI.LISDashboard.CoreDomain.Report;
using CHAI.LISDashboard.CoreDomain;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace CHAI.LISDashboard.Modules.Report.Views
{
    public partial class VLPatientTestedReport : POCBasePage, IDefaultView
    {
        private DefaultPresenter _presenter;
        ReportDao dao = new ReportDao();        
        ReportDocument rprt = new ReportDocument();

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (IsPostBack)
            //{
            //    ReportDocument doc = (ReportDocument)Session["ReportDocument"];
            //    CRVLLabSummary.ReportSource = doc;
            //}
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {                
                //Session.Remove("FacilityTypeList");
                //Session.Remove("FacilityList");

                BindStateRegion();
                BindFacilityType("");
                BindLaboratories();

                rdbFacilityType.Items[2].Selected = true;
                foreach (ListItem li in ddlFacilityType.Items)
                {
                    li.Selected = true;
                }

                LoadReport();
            }
            else
            {
                ReportDocument doc = (ReportDocument)Session["ReportDocument"];
                CRVLPatientTested.ReportSource = doc;
            }
        }

        public override string PageID
        {

            get
            {
                return "{74987d34-74f9-47b2-8955-494ac9bc3855}";
            }
        }
        [CreateNew]
        public DefaultPresenter Presenter
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

        private void BindStateRegion()
        {
            //ddlProvince.DataSource = _presenter.GetProvinces();
            //ddlProvince.DataBind();

            ddlProvince.Items.Clear();

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
                    if (row.attrib_name2 != null && !string.IsNullOrEmpty(row.attrib_name2))
                        ddlProvince.Items.Add(new ListItem(row.attrib_name2, row.attrib_name1.ToString()));
                }

                chkAllRegion_OnCheckedChanged(chkAllRegion, null);

                // Facilities
                //DataTable dtFacility = new DataTable("Facility");
                //dtFacility.Columns.Add("FacilityId");
                //dtFacility.Columns.Add("FacilityName");

                ////string selectedProvinceIds = string.Empty;
                //List<string> selectedProvinceIds = new List<string>();
                //foreach (ListItem item in ddlProvince.Items)
                //{
                //    if (item.Selected)
                //        selectedProvinceIds.Add(item.Value);
                //    //selectedProvinceIds = (selectedProvinceIds == string.Empty ? "\"" + item.Value + "\"" : ",\"" + item.Value + "\"");                                            
                //}

                ////DataRow[] dr = table.Select("ProvinceId IN [" + selectedProvinceIds + "]");
                ////DataRow[] dr = table.Select("ProvinceId IN " + selectedProvinceIds);
                //foreach (DataRow row in table.Rows)
                //{
                //    //string a = row["ProvinceId"].ToString();
                //    foreach (string selProvinceId in selectedProvinceIds)
                //    {
                //        if (row["ProvinceId"].ToString() == selProvinceId)
                //        {
                //            DataRow facilityRow = dtFacility.NewRow();
                //            facilityRow["FacilityId"] = row["FacilityId"];
                //            facilityRow["FacilityName"] = row["FacilityName"];
                //            dtFacility.Rows.Add(facilityRow);
                //        }
                //    }
                //}

                //ddlFacility.DataValueField = "FacilityId";
                //ddlFacility.DataTextField = "FacilityName";
                //ddlFacility.DataSource = dtFacility;
                //ddlFacility.DataBind();

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

        protected void BindFacilityType(string value)
        {
            //ddlFacilityType.DataSource = _presenter.GetFacilityTypeByFacilityType2(value);
            //ddlFacilityType.DataBind();

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

        //private void BindStateRegion()
        //{
        //    ddlProvince.DataSource = _presenter.GetProvinces();
        //    ddlProvince.DataBind();
        //}

        //protected void BindFacilityType(string value)
        //{
        //    ddlFacilityType.DataSource = _presenter.GetFacilityTypeByFacilityType2(value);
        //    ddlFacilityType.DataBind();
        //}

        //protected void BindLaboratories()
        //{
        //    //ddlLab.DataSource = _presenter.GetLaboratories();
        //    //ddlLab.DataBind();

        //    if (CurrentUser.AppUserRoles[0].Role.Name == "Administrator")
        //    {
        //        ddlLab.DataSource = _presenter.GetLaboratories();
        //        ddlLab.DataValueField = "LabCode";
        //        ddlLab.DataTextField = "Description";
        //        ddlLab.DataBind();
        //    }
        //    else
        //    {
        //        ReportDao dao = new ReportDao();
        //        DataSet infoDS = dao.GetUserLocationsInfo(CurrentUser.Id);
        //        DataTable table = infoDS.Tables[0];

        //        ddlLab.DataSource = table;
        //        ddlLab.DataValueField = "LabCode";
        //        ddlLab.DataTextField = "LaboratoryName";
        //        ddlLab.DataBind();
        //    }
        //}        

        protected void BindLaboratories()
        {
            //ddlLab.DataSource = _presenter.GetLaboratories();
            //ddlLab.DataBind();

            if (CurrentUser.AppUserRoles[0].Role.Name == "Administrator"
                || CurrentUser.AppUserRoles[0].Role.Name == "SuperUser")
            {
                ddlLab.DataSource = _presenter.GetLaboratories();
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

        private void LoadReport()
        {
            try
            {
                string DateFrom = string.Empty;
                string DateTo = string.Empty;
                string PrDateDescription = string.Empty;
                string ReceiveFrom = string.Empty, ReceiveTo = string.Empty, CollectFrom = string.Empty, CollectTo = string.Empty, ProvinceId = string.Empty;
                string FacilityType1 = string.Empty;


                string PrFacility = string.Empty;

                if (txtSrchNotDate.Text != "") DateFrom = ChangeDateFormat2(txtSrchNotDate.Text);
                if (txtSrchNotDateTo.Text != "") DateTo = ChangeDateFormat2(txtSrchNotDateTo.Text);

                PrDateDescription = "Sample Tested Date";
                if (rdbDate.SelectedValue == "Received")
                {
                    ReceiveFrom = DateFrom;
                    ReceiveTo = DateTo;
                    PrDateDescription = "Sample Received Date";
                }
                else
                {
                    CollectFrom = DateFrom;
                    CollectTo = DateTo;
                    PrDateDescription = "Sample Collection Date";
                }

                foreach (ListItem lst in ddlProvince.Items)
                {
                    if (lst.Selected)
                    {
                        ProvinceId += lst.Value + ",";
                    }
                }

                if (ProvinceId != "") ProvinceId += "," + ProvinceId;

                if (rdbFacilityType.SelectedValue != "All")
                {
                    foreach (ListItem lst in ddlFacilityType.Items)
                    {
                        if (lst.Selected)
                        {
                            FacilityType1 += lst.Value + ",";
                            PrFacility = PrFacility + lst.Text + ",";
                        }
                    }
                    if (FacilityType1 != "") FacilityType1 += "," + FacilityType1;
                }

                string strCopiesml = string.Empty;
                if (ddlCopiesml.SelectedValue == "<=1000") { strCopiesml = "And <=1000 Copies/ml"; }
                else if (ddlCopiesml.SelectedValue == ">1000") { strCopiesml = "And >1000 Copies/ml"; }
                else if (ddlCopiesml.SelectedValue == "ValidOutcome") { strCopiesml = "And Valid Outcome"; }

                //var path = Server.MapPath(Convert.ToString("~/Report/VLLabTestedSummaryReport.rpt"));
                //var ds = dao.VLTestedSummary(
                //    0, CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name,
                //    DateFrom, DateTo, ProvinceId, FacilityType1, ddlLab.SelectedValue);

                //DataSet ds = new DataSet();

                //DataTable dtVLSummaryOT = ds.Tables[0].Copy();
                //dtVLSummaryOT.TableName = "VLTestedSummaryReport";

                string path = string.Empty;
                DataTable dtVLSummaryOT = null;
                DataSet ds = new DataSet();                
                if (ddlReportShowing.SelectedValue == "Age")
                {
                    //if (ddlViewOption.SelectedValue == "StateRegion")
                    //{
                        var dsResult = dao.VLPatientTestedByAge(0, CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name,
                            ReceiveFrom, ReceiveTo, CollectFrom, CollectTo, ProvinceId, FacilityType1, ddlLab.SelectedValue, ddlCopiesml.SelectedValue, ddlViewOption.SelectedValue);
                        path = Server.MapPath(Convert.ToString("~/Report/VLPatientTestedByAge_" + ddlViewOption.SelectedValue + ".rpt"));

                        //ds.Tables[0].TableName = "VLPatientTestedByAge_" + ddlViewOption.SelectedValue;
                        //int count = ds.Tables[0].Rows.Count;

                        dtVLSummaryOT = dsResult.Tables[0].Copy();
                        dtVLSummaryOT.TableName = "VLPatientTestedByAge_" + ddlViewOption.SelectedValue;
                        int count = dtVLSummaryOT.Rows.Count;
                    //}
                    //else if (ddlViewOption.SelectedValue == "FacilityType")
                    //{
                    //    ds = dao.VLPatientTestedByAge(0, CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name,
                    //        DateFrom, DateTo, "", "", ProvinceId, FacilityType1, ddlLab.SelectedValue, ddlCopiesml.SelectedValue, ddlViewOption.SelectedValue);
                    //    path = Server.MapPath(Convert.ToString("~/Report/VLPatientTestedByAge_" + ddlViewOption.SelectedValue + ".rpt"));

                    //    dtVLSummaryOT = ds.Tables[0].Copy();
                    //    dtVLSummaryOT.TableName = "VLPatientTestedByAge_" + ddlViewOption.SelectedValue;
                    //}
                }
                else if (ddlReportShowing.SelectedValue == "Gender")
                {
                    //if (ddlViewOption.SelectedValue == "StateRegion")
                    //{
                        ds = dao.VLPatientTestedByGender(0, CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name,
                            DateFrom, DateTo, "", "", ProvinceId, FacilityType1, ddlLab.SelectedValue, ddlCopiesml.SelectedValue, ddlViewOption.SelectedValue);
                        path = Server.MapPath(Convert.ToString("~/Report/VLPatientTestedByGender_" + ddlViewOption.SelectedValue + ".rpt"));

                        dtVLSummaryOT = ds.Tables[0].Copy();
                        dtVLSummaryOT.TableName = "VLPatientTestedByGender_" + ddlViewOption.SelectedValue;
                    //}
                    //else if (ddlViewOption.SelectedValue == "FacilityType")
                    //{
                    //    ds = dao.VLPatientTestedByGender(0, CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name,
                    //        DateFrom, DateTo, "", "", ProvinceId, FacilityType1, ddlLab.SelectedValue, ddlCopiesml.SelectedValue, ddlViewOption.SelectedValue);
                    //    path = Server.MapPath(Convert.ToString("~/Report/VLPatientTestedByGender_" + ddlViewOption.SelectedValue + ".rpt"));

                    //    dtVLSummaryOT = ds.Tables[0].Copy();
                    //    dtVLSummaryOT.TableName = "VLPatientTestedByGender_" + ddlViewOption.SelectedValue;
                    //}
                }
                else if (ddlReportShowing.SelectedValue == "Reason")
                {
                    //if (ddlViewOption.SelectedValue == "StateRegion")
                    //{
                        ds = dao.VLPatientTestedByReason(0, CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name,
                            DateFrom, DateTo, "", "", ProvinceId, FacilityType1, ddlLab.SelectedValue, ddlCopiesml.SelectedValue, ddlViewOption.SelectedValue);
                        path = Server.MapPath(Convert.ToString("~/Report/VLPatientTestedByReason_" + ddlViewOption.SelectedValue + ".rpt"));

                        dtVLSummaryOT = ds.Tables[0].Copy();
                        dtVLSummaryOT.TableName = "VLPatientTestedByReason_" + ddlViewOption.SelectedValue;
                    //}
                    //else if (ddlViewOption.SelectedValue == "FacilityType")
                    //{
                    //    ds = dao.VLPatientTestedByReason(0, CurrentUser.Id, CurrentUser.AppUserRoles[0].Role.Name,
                    //        DateFrom, DateTo, "", "", ProvinceId, FacilityType1, ddlLab.SelectedValue, ddlCopiesml.SelectedValue, ddlViewOption.SelectedValue);
                    //    path = Server.MapPath(Convert.ToString("~/Report/VLPatientTestedByReason_" + ddlViewOption.SelectedValue + ".rpt"));

                    //    dtVLSummaryOT = ds.Tables[0].Copy();
                    //    dtVLSummaryOT.TableName = "VLPatientTestedByReason_" + ddlViewOption.SelectedValue;
                    //}
                }

                int tblCount = ds.Tables.Count;                
                ds.Tables.Add(dtVLSummaryOT);
                //DataTable dtTemp = ds.Tables[0];
                
                //CRVLPatientTested.ReportSource = null;
                //CRVLPatientTested.RefreshReport();

                rprt.Load(path);                
                rprt.SetDataSource(ds);                
                rprt.SetParameterValue("PrDateFrom", txtSrchNotDate.Text);
                rprt.SetParameterValue("PrDateTo", txtSrchNotDateTo.Text);
                rprt.SetParameterValue("PrDateDescription", PrDateDescription);
                rprt.SetParameterValue("PrFacility", PrFacility);
                rprt.SetParameterValue("PrCopiesml", strCopiesml);
                CRVLPatientTested.ReportSource = rprt;
                CRVLPatientTested.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None;
                Session["ReportDocument"] = rprt;

                //rprt.Refresh();
                //rprt.SetParameterValue("PrDateFrom", txtSrchNotDate.Text);
                //rprt.SetParameterValue("PrDateTo", txtSrchNotDateTo.Text);
                //rprt.SetParameterValue("PrDateDescription", PrDateDescription);
                //rprt.SetParameterValue("PrFacility", PrFacility);
                //rprt.SetParameterValue("PrCopiesml", strCopiesml);
                //CRVLPatientTested.RefreshReport();
            }
            catch (Exception ex)
            {
                Master.ShowMessage(new AppMessage(ex.Message, CHAI.LISDashboard.Enums.RMessageType.Error));
            }
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            LoadReport();
        }

        protected DateTime ConvertToDateTime(string strDateTime)
        {
            DateTime dtFinaldate; string sDateTime;
            try { dtFinaldate = Convert.ToDateTime(strDateTime); }
            catch (Exception e)
            {
                string[] sDate = strDateTime.Split('/');
                sDateTime = sDate[1] + '/' + sDate[0] + '/' + sDate[2];
                dtFinaldate = Convert.ToDateTime(sDateTime);
            }
            return dtFinaldate;
        }
        protected string ChangeDateFormat2(String dString)
        {
            if (dString != string.Empty)
            {
                DateTime tempDate = new DateTime();
                //if (DateTime.TryParse(dString, out tempDate))
                //    dString = dt.ToString("MM/dd/yyyy");
                if (DateTime.TryParseExact(dString, "dd/MM/yyyy",
                                 new CultureInfo("pt-BR"),
                                 DateTimeStyles.None, out tempDate))
                    dString = tempDate.ToString("MM/dd/yyyy");
            }
            return dString;
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

        //protected void checkedAll(object sender, EventArgs e)
        //{
        //    CheckBox chk = sender as CheckBox;
        //    string strchkname = chk.ID;
        //    string FacilityType2 = string.Empty;
        //    switch (strchkname)
        //    {
        //        case "chkRegion":
        //            if (chk.Checked == true)
        //            {
        //                foreach (ListItem li in ddlProvince.Items)
        //                {
        //                    li.Selected = true;
        //                }
        //            }
        //            else
        //            {
        //                ddlProvince.ClearSelection();
        //            }
        //            break;
        //    }
        //}

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

        protected void ddlProvince_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            this.UpdateFacilities();
            this.rdbFacilityType_SelectedIndexChanged(rdbFacilityType, null);
        }

        private void UpdateFacilities()
        {
            if (Session["FacilityList"] == null)
                return;

            //ddlFacility.Items.Clear();
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

            //DataView dview = new DataView(dtFacility);
            //dview.Sort = "FacilityName";        // for descending   "FacilityName DESC"
            //dtFacility = dview.ToTable();

            //facilityRow = dtFacility.NewRow();
            //facilityRow["FacilityId"] = 0;
            //facilityRow["FacilityName"] = "All Facilities";
            //dtFacility.Rows.InsertAt(facilityRow, 0);

            //ddlFacility.DataValueField = "FacilityId";
            //ddlFacility.DataTextField = "FacilityName";
            //ddlFacility.DataSource = dtFacility;
            //ddlFacility.DataBind();

            //ddlFacility.SelectedIndex = 0;
        }
        
        private AppUser CurrentUser
        {
            get { return ((ChaiPrincipal)HttpContext.Current.User).CurrentAppUser; }
        }
    }

}




