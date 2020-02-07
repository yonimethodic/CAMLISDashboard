using CHAI.LISDashboard.CoreDomain.DataAccess;
using CHAI.LISDashboard.CoreDomain.Setting;
using CHAI.LISDashboard.Enums;
using Microsoft.Practices.ObjectBuilder;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CHAI.LISDashboard.Modules.ViralLoad.Views
{
    public partial class Default : POCBasePage, IDefaultView
    {
        private DefaultPresenter _presenter;
        private int itemNumber = 0;
        ReportDao dao = new ReportDao();
        System.Data.DataSet _Worksheet = null; 
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!this.IsPostBack)
            {
                this._presenter.OnViewInitialized();
                BindProvince();
                BindReasonForTest();
                BindLaboratories();
                BindYear();
                BindPatientType();

                dvTableContent.Visible = false;
            }

            this._presenter.OnViewLoaded();
        }

        protected string GetSyncTotal(string _type)
        {
            string htmlTable = string.Empty;
            try
            {
                _Worksheet = dao.GetSyncTotal();
                //grvWorksheet.DataSource = _Worksheet;
                //grvWorksheet.DataBind();
                if (!IsPostBack)
                {
                    if (_type =="EID")
                    htmlTable= _Worksheet.Tables[2].Rows[0][0].ToString();
                    else
                        htmlTable = _Worksheet.Tables[2].Rows[1][0].ToString();
                    //lblTable.Text = htmlTable;                    
                }
                return htmlTable;
            }
            catch
            {
                return htmlTable;
            }
        }

        //protected string BindingData()
        //{
        //    string htmlTable = string.Empty;
        //    try
        //    {
        //        _Worksheet= dao.VLReport();
        //        //grvWorksheet.DataSource = _Worksheet;
        //        //grvWorksheet.DataBind();
        //        if (!IsPostBack)
        //        {                                       
        //             htmlTable = "<table id='dt_basic' class='table table-striped table-bordered table-hover' width='100%'>";
                  
        //             htmlTable += "<thead><tr>";
        //             htmlTable += "<th>No.</th>";
        //             htmlTable += "<th>Lab</th>";
        //             htmlTable += "<th>Township / Hospital</th>";
        //             htmlTable += "<th>PatientName</th>";
        //             htmlTable += "<th>Sex</th>";
        //             htmlTable += "<th>Age</th>";
        //             htmlTable += "<th>ART Number</th>";
        //             htmlTable += "<th>Lab Number</th>";
        //             htmlTable += "<th>Test</th>";
        //             htmlTable += "<th>Date Collected</th>";
        //             htmlTable += "<th>Registered Date</th>";
        //             htmlTable += "<th>Specimen Quality</th>";
        //             htmlTable += "<th>Final Result</th>";
        //             htmlTable += "<th>Copies/ml</th>";
        //             htmlTable += "<th>Log (Copies/ml)</th>";
        //             htmlTable += "<th>Result Date</th>";
        //             htmlTable += "</tr>";
        //             htmlTable += "</thead>";
        //            //}
        //            htmlTable += "<tbody>";
        //            foreach (DataRow dr in _Worksheet.Tables[0].Rows)
        //            {
        //                htmlTable += "<tr><td>" + ItemNumber() + "</td><td>" + dr["Lab"].ToString() + "</td><td>" + dr["FacilityName"].ToString() + "</td>";
        //                htmlTable += "<td>" + dr["FullName"].ToString() + "</td><td>" + dr["Sex"].ToString() + "</td><td>" + dr["Age"].ToString() + "</td>";
        //                htmlTable += "<td>" + dr["ARTNumber"].ToString() + "</td><td>" + dr["LabNumber"].ToString() + "</td><td>" + dr["Reasonfortest"].ToString() + "</td>";
        //                htmlTable += "<td>" + Convert.ToDateTime(dr["SampleCollectedDate"].ToString()).ToShortDateString() + "</td><td>" + Convert.ToDateTime(dr["RegistrationDate"].ToString()).ToShortDateString() + "</td><td>" + dr["SpecimenQuality"].ToString() + "</td>";
        //                htmlTable += "<td>" + dr["FinalReportResult"].ToString() + "</td><td>" + ShowLogCopies("Copies", dr["FinalReportResult"].ToString(), dr["Copies_ml"].ToString()) + "</td><td>" + ShowLogCopies("", dr["FinalReportResult"].ToString(), dr["LogCopies"].ToString()) + "</td>";
        //                htmlTable += "<td>" + Convert.ToDateTime(dr["FinalReportDate"].ToString()).ToShortDateString() + "</td></tr>";
        //            }
        //            htmlTable += "</tbody>";
        //            htmlTable += "</table>";
        //            //lblTable.Text = htmlTable;                    
        //        }
        //        return htmlTable;
        //    }
        //    catch
        //    {
        //        return htmlTable;
        //    }
        //}
        protected string ItemNumber()
        {

            itemNumber++;
            return itemNumber.ToString();
        }
        public override string PageID
        {

            get
            {
                return "{59C87105-9301-46FD-93AC-D3FCDE5064F7}";
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

        protected string ShowLogCopies(string type, object objresult, object objlog)
        {
            string strresult = objresult != null ? objresult.ToString() : "";
            string strlog = objlog != null ? objlog.ToString() : "";

            if (strresult != "Detected")
            {
                return "";
            }
            else
            {
                if (type == "Copies")
                {
                    //long intlog = Convert.ToInt64(Convert.ToDouble(strlog));
                    // Fixed by Zay Soe on 10-Apr-2019
                    long intlog = Convert.ToInt64(string.IsNullOrEmpty(strlog)? 0 : Convert.ToDouble(strlog));
                    return intlog.ToString();
                }
            }
            return strlog.ToString();
        }

        #region "Added by ZaySoe On 19_Dec_2018"

        protected void BindProvince()
        {
            ddlProvince.DataSource = _presenter.GetProvinces();
            ddlProvince.DataBind();
        }

        protected void BindYear()
        {
            ddlYear.DataSource = _presenter.GetYears();
            ddlYear.DataBind();
        }
        protected void BindReasonForTest()
        {
            //ddlTests.DataSource = Enum.GetNames(typeof(Chai.EID.Enums.ReasonforTest));

            string[] s = Enum.GetNames(typeof(ReasonforTest));

            for (int i = 0; i < s.Length; i++)
            {
                ddlTests.Items.Add(new ListItem(s[i].Replace('_', ' '), s[i].Replace('_', ' ')));
                ddlTests.DataBind();
            }
        }

        protected void BindLaboratories()
        {
            ddlLab.DataSource = _presenter.GetLaboratories();
            ddlLab.DataValueField = "LabCode";
            ddlLab.DataTextField = "Description";
            ddlLab.DataBind();
        }

        protected void BindPatientType()
        {            
            string[] s = { "OPD", "IPD" };

            for (int i = 0; i < s.Length; i++)
            {
                ddlPatientType.Items.Add(new ListItem(s[i], s[i]));
                ddlPatientType.DataBind();
            }
        }

        protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                IList<Facility> _facilityList = _presenter.GetFacilities(Convert.ToInt32(ddlProvince.SelectedValue));
                if (ddlFacility.Items.Count > 0)
                {
                    ddlFacility.Items.Clear();
                }
                ListItem lst = new ListItem();
                lst.Text = "ALL Facility Name";
                lst.Value = "0";
                ddlFacility.Items.Add(lst);

                ddlFacility.DataSource = _facilityList;
                ddlFacility.DataBind();
            }

            catch (Exception ex)
            {
                //Master.ShowMessage (new AppMessage(ex.Message, RMessageType.Error));                
            }
        }

        protected void ddlTests_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        protected void btnFilter_Click(object sender, EventArgs e)
        {
            //try
            //{
            
            _Worksheet = dao.VLReport(Convert.ToInt32(ddlProvince.SelectedValue), Convert.ToInt32(ddlFacility.SelectedValue),
                ddlTests.SelectedValue.ToString(), txtCollectedDateFrom.Text.Trim(), txtCollectedDateTo.Text.Trim(),
                txtReceivedDateFrom.Text.Trim(), txtReceivedDateTo.Text.Trim(), "", string.IsNullOrEmpty(txtnumberOfTests.Text) ? 0 : Convert.ToInt32(txtnumberOfTests.Text),
                txtlabNumber.Text.Trim(), txtlabNumberTo.Text.Trim(), txtPatientCode.Text.Trim(), Convert.ToInt32(ddlYear.SelectedValue),
                txtARTNumber.Text.Trim(), ddlPatientType.SelectedValue.ToString(), ddlLab.SelectedValue);

            string htmlTable = string.Empty;
            htmlTable = "<table id='dt_basic' class='table table-striped table-bordered table-hover' style='width: 100%'>";

            htmlTable += "<thead><tr>";
            htmlTable += "<th>No.</th>";
            htmlTable += "<th>Lab</th>";
            htmlTable += "<th>Township / Hospital</th>";
            htmlTable += "<th>PatientName</th>";
            htmlTable += "<th>Sex</th>";
            htmlTable += "<th>Age</th>";
            htmlTable += "<th>ART Number</th>";
            htmlTable += "<th>Lab Number</th>";
            htmlTable += "<th>Test</th>";
            htmlTable += "<th>Date Collected</th>";
            htmlTable += "<th>Registered Date</th>";
            htmlTable += "<th>Specimen Quality</th>";
            htmlTable += "<th>Final Result</th>";
            htmlTable += "<th>Copies/ml</th>";
            htmlTable += "<th>Log (Copies/ml)</th>";
            htmlTable += "<th>Result Date</th>";
            htmlTable += "</tr>";
            htmlTable += "</thead>";
            
            htmlTable += "<tbody>";
            foreach (DataRow dr in _Worksheet.Tables[0].Rows)
            {
                htmlTable += "<tr><td>" + ItemNumber() + "</td><td>" + dr["Lab"].ToString() + "</td><td>" + dr["FacilityName"].ToString() + "</td>";
                htmlTable += "<td>" + dr["FullName"].ToString() + "</td><td>" + dr["Sex"].ToString() + "</td><td>" + dr["Age"].ToString() + "</td>";
                htmlTable += "<td>" + dr["ARTNumber"].ToString() + "</td><td>" + dr["LabNumber"].ToString() + "</td><td>" + dr["Reasonfortest"].ToString() + "</td>";
                htmlTable += "<td>" + Convert.ToDateTime(dr["SampleCollectedDate"].ToString()).ToShortDateString() + "</td><td>" + Convert.ToDateTime(dr["RegistrationDate"].ToString()).ToShortDateString() + "</td><td>" + dr["SpecimenQuality"].ToString() + "</td>";
                htmlTable += "<td>" + dr["FinalReportResult"].ToString() + "</td><td>" + ShowLogCopies("Copies", dr["FinalReportResult"].ToString(), dr["Copies_ml"].ToString()) + "</td><td>" + ShowLogCopies("", dr["FinalReportResult"].ToString(), dr["LogCopies"].ToString()) + "</td>";
                htmlTable += "<td>" + Convert.ToDateTime(dr["FinalReportDate"].ToString()).ToShortDateString() + "</td></tr>";
            }
            htmlTable += "</tbody>";
            htmlTable += "</table>";
           
            dvTableContent.InnerHtml = htmlTable;
            dvTableContent.DataBind();
            dvTableContent.Visible = true;
        }

        protected void lnkExportToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt1 = new DataTable();

                dt1 = dao.VLReport(Convert.ToInt32(ddlProvince.SelectedValue), Convert.ToInt32(ddlFacility.SelectedValue),
                ddlTests.SelectedValue.ToString(), txtCollectedDateFrom.Text.Trim(), txtCollectedDateTo.Text.Trim(),
                txtReceivedDateFrom.Text.Trim(), txtReceivedDateTo.Text.Trim(), "", string.IsNullOrEmpty(txtnumberOfTests.Text) ? 0 : Convert.ToInt32(txtnumberOfTests.Text),
                txtlabNumber.Text.Trim(), txtlabNumberTo.Text.Trim(), txtPatientCode.Text.Trim(), Convert.ToInt32(ddlYear.SelectedValue),
                txtARTNumber.Text.Trim(), ddlPatientType.SelectedValue.ToString(), ddlLab.SelectedValue).Tables[0];

                using (ExcelPackage pck = new ExcelPackage())
                {
                    ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Viral Load Data");


                    ws.Cells["A1"].LoadFromDataTable(dt1, true);


                    //Write it back to the client
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;  filename=ViralLoad Data.xlsx");
                    Response.BinaryWrite(pck.GetAsByteArray());
                    Response.Flush();
                    Response.End();
                }
            }
            catch (Exception ex)
            {

            }
        }

        #endregion
    }
}