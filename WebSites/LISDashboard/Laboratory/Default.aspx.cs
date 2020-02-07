
using Microsoft.Practices.ObjectBuilder;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CHAI.LISDashboard.CoreDomain.DataAccess;

namespace CHAI.LISDashboard.Modules.EID.Views
{
    public partial class Default : POCBasePage , IDefaultView
    {
        private DefaultPresenter _presenter;

        public IList jsonLabDataEntry { get; set; }
        public string JstringLabDataEntry { get; set; }

        public IList jsonLabTestingPerformance { get; set; }
        public string JstringLabTestingPerformance { get; set; }

        private int itemNumber = 0;
        ReportDao dao = new ReportDao();
        System.Data.DataSet _Worksheet = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this._presenter.OnViewInitialized();
                this.PopulateYears();
                this.PopulateMonths();
                this.PopulateLabs();                

                divLastUploadDateimeData.Visible = false;
                divTotalUploadRecordsData.Visible = false;
                dvTableDataEntryPerformance.Visible = false;
                dvTableDataEntryPerformance.Visible = false;

                this.BindingLastUploadDateTimeData();
                this.BindingTotalUploadRecordsData();
                this.BindingLabDataEntryPerformanceList();                

                this.GetLabDataEntryPerformanceDaily();
                this.GetLabTestingPerformanceDaily();
            }
            else
            {
                //if (Session["Performance"] != null && Session["Performance"].ToString() == "DataEntry")
                //{
                    //ScriptManager.RegisterClientScriptBlock(Page, typeof(Default), "LabDataEntryPerformance", "RedrawLabDataEntryPerformance()", true);
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Default), "LabDataEntryPerformance", "RedrawLabDataEntryPerformance(" + this.GetLabDataEntryPerformanceDailyAjax() + ")", true);
                //}
                //else if (Session["Performance"] != null && Session["Performance"].ToString() == "Testing")
                //{
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Default), "LabTestingPerformance", "RedrawLabTestingPerformance(" + this.GetLabTestingPerformanceDailyAjax() + ")", true);
                //}
            }
            this._presenter.OnViewLoaded();            

            //this.GetLabDataEntryPerformanceWeekly();
        }
        public override string PageID
        {
            get
            {
                return "{7fd1cfe8-a653-49a2-9b44-27087254b549}";
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

        private void PopulateYears()
        {
            // Year Picker for Lab Performance History            
            var startYear = 2018;
            var currentYear = DateTime.Now.Year;
            for (var i = 0; i < currentYear - startYear + 1; i++)
            {
                ddlYear.Items.Add((startYear + i).ToString());
                ddlYear2.Items.Add((startYear + i).ToString());
                //if ((startYear + i) == currentYear)
                //    ddlYear.Items.Add((startYear + i).ToString());                        
                //else
                //        $(this).append('<option value="' + (startYear + i) + '">' + (startYear + i) + '</option>');
                //alert(startYear + i);
            }
            ddlYear.SelectedValue = currentYear.ToString();
            ddlYear2.SelectedValue = currentYear.ToString();
        }

        private void PopulateMonths()
        {
            ddlMonth.Items.Add(new ListItem("Jan", "1"));
            ddlMonth.Items.Add(new ListItem("Feb", "2"));
            ddlMonth.Items.Add(new ListItem("Mar", "3"));
            ddlMonth.Items.Add(new ListItem("Apr", "4"));
            ddlMonth.Items.Add(new ListItem("May", "5"));
            ddlMonth.Items.Add(new ListItem("Jun", "6"));
            ddlMonth.Items.Add(new ListItem("Jul", "7"));
            ddlMonth.Items.Add(new ListItem("Aug", "8"));
            ddlMonth.Items.Add(new ListItem("Sep", "9"));
            ddlMonth.Items.Add(new ListItem("Oct", "10"));
            ddlMonth.Items.Add(new ListItem("Nov", "11"));
            ddlMonth.Items.Add(new ListItem("Dec", "12"));

            ddlMonth.SelectedValue = DateTime.Today.Month.ToString();

            ddlMonth2.Items.Add(new ListItem("Jan", "1"));
            ddlMonth2.Items.Add(new ListItem("Feb", "2"));
            ddlMonth2.Items.Add(new ListItem("Mar", "3"));
            ddlMonth2.Items.Add(new ListItem("Apr", "4"));
            ddlMonth2.Items.Add(new ListItem("May", "5"));
            ddlMonth2.Items.Add(new ListItem("Jun", "6"));
            ddlMonth2.Items.Add(new ListItem("Jul", "7"));
            ddlMonth2.Items.Add(new ListItem("Aug", "8"));
            ddlMonth2.Items.Add(new ListItem("Sep", "9"));
            ddlMonth2.Items.Add(new ListItem("Oct", "10"));
            ddlMonth2.Items.Add(new ListItem("Nov", "11"));
            ddlMonth2.Items.Add(new ListItem("Dec", "12"));

            ddlMonth2.SelectedValue = DateTime.Today.Month.ToString();
        }

        private void PopulateLabs()
        {
            ReportDao reportDao = new ReportDao();
            var LabList = reportDao.GetLaboratories();
            for (int i = 0; i < LabList.Count ; i++)
            {
                ArrayList row = (ArrayList) LabList[i];
                ddlLab.Items.Add(new ListItem(row[3].ToString(), row[1].ToString()));

                ddlLab2.Items.Add(new ListItem(row[3].ToString(), row[1].ToString()));
            }

            //ddlLab.DataSource = reportDao.GetLaboratories();
            //ddlLab.DataTextField = "LabCode";
            //ddlLab.DataValueField = "Id";            
            ////ddlLab.DataBind();
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
                    if (_type == "EID")
                        htmlTable = _Worksheet.Tables[2].Rows[0][0].ToString();
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

        protected void BindingLastUploadDateTimeData()
        {
            string htmlTable = string.Empty;
            try
            {
                _Worksheet = dao.GetSyncTotal();
                
                //if (!IsPostBack)
                //{
                    htmlTable = "<table id='dt_basic' class='table table-striped table-bordered table-hover' width='100%'>";
                    htmlTable += "<thead><tr>";
                    htmlTable += "<th>Last Upload Dateime</th>";
                    htmlTable += "<th>Total Upload Records</th>";
                    htmlTable += "<th>Type</th>";
                    htmlTable += "<th>Laboratory Name</th>";
                    htmlTable += "</tr>";
                    htmlTable += "</thead>";
                    htmlTable += "<tbody>";
                    foreach (DataRow dr in _Worksheet.Tables[0].Rows)
                    {
                        htmlTable += "<tr><td>" + Convert.ToDateTime(dr["Last_Upload_Dateime"].ToString()).ToShortDateString() + "</td><td>" + dr["TotalUploadRecords"].ToString() + "</td><td>" + dr["Type"].ToString() + "</td>";
                        htmlTable += "<td>" + dr["LaboratoryName"].ToString() + "</td>";
                    }
                    htmlTable += "</tr></tbody>";
                    htmlTable += "</table>";
                //}
                //return htmlTable;
            }
            catch
            {
                //return htmlTable;
            }

            divLastUploadDateimeData.InnerHtml = htmlTable;
            divLastUploadDateimeData.DataBind();
            divLastUploadDateimeData.Visible = true;
        }        

        protected void BindingTotalUploadRecordsData()
        {
            string htmlTable = string.Empty;
            try
            {
                _Worksheet = dao.GetSyncTotal();

                //if (!IsPostBack)
                //{
                    htmlTable = "<table id='dt_basic_upload_records' class='table table-striped table-bordered table-hover' width='100%'>";

                    htmlTable += "<thead><tr>";                   
                    htmlTable += "<th>Total Upload Records</th>";
                    htmlTable += "<th>Type</th>";
                    htmlTable += "<th>Laboratory Name</th>";
                    htmlTable += "</tr>";
                    htmlTable += "</thead>";
                    htmlTable += "<tbody>";
                    foreach (DataRow dr in _Worksheet.Tables[1].Rows)
                    {
                        htmlTable += "<tr><td>" + dr["TotalUploadRecords"].ToString() + "</td><td>" + dr["Type"].ToString() + "</td>";
                        htmlTable += "<td>" + dr["LaboratoryName"].ToString() + "</td>";
                    }
                    htmlTable += "</tr></tbody>";
                    htmlTable += "</table>";                                      
                //}
                //return htmlTable;
            }
            catch
            {
                //return htmlTable;
            }

            divTotalUploadRecordsData.InnerHtml = htmlTable;
            divTotalUploadRecordsData.DataBind();
            divTotalUploadRecordsData.Visible = true;
        }

        protected void BindingLabDataEntryPerformanceList()
        {
            string htmlTable = string.Empty;
            try
            {
                _Worksheet = dao.GetLabDataEntryPerformanceList();

                //if (!IsPostBack)
                //{
                    htmlTable = "<table id='dt_basic_data_entry_performance' class='table table-striped table-bordered table-hover' width='100%'>";
                    htmlTable += "<thead><tr>";
                    htmlTable += "<th>Form Entry Date</th>";
                    htmlTable += "<th>Total Records</th>";
                    htmlTable += "<th>Type</th>";
                    htmlTable += "<th>Laboratory Name</th>";
                    htmlTable += "</tr>";
                    htmlTable += "</thead>";
                    htmlTable += "<tbody>";
                    foreach (DataRow dr in _Worksheet.Tables[0].Rows)
                    {
                        htmlTable += "<tr><td>" + Convert.ToDateTime(dr["FormCreatedDate"].ToString()).ToShortDateString() + "</td><td>" + dr["TotalRecords"].ToString() + "</td><td>" + dr["Type"].ToString() + "</td>";
                        htmlTable += "<td>" + dr["LaboratoryName"].ToString() + "</td>";
                    }
                    htmlTable += "</tr></tbody>";
                    htmlTable += "</table>";                    
                //}
                //return htmlTable;
            }
            catch
            {
                //return htmlTable;
            }

            dvTableDataEntryPerformance.InnerHtml = htmlTable;
            dvTableDataEntryPerformance.DataBind();
            dvTableDataEntryPerformance.Visible = true;
        }        

        private void GetLabDataEntryPerformanceDaily()
        {
            //Session["Performance"] = "DataEntry";
            jsonLabDataEntry = _presenter.GetLabDataEntryPerformanceDaily(Convert.ToInt32(ddlYear.SelectedValue), Convert.ToInt32(ddlMonth.SelectedValue), ddlLab.SelectedValue);
            JstringLabDataEntry = Newtonsoft.Json.JsonConvert.SerializeObject(jsonLabDataEntry);            
        }

        private string GetLabDataEntryPerformanceDailyAjax()
        {            
            jsonLabDataEntry = _presenter.GetLabDataEntryPerformanceDaily(Convert.ToInt32(ddlYear.SelectedValue), Convert.ToInt32(ddlMonth.SelectedValue), ddlLab.SelectedValue);
            return Newtonsoft.Json.JsonConvert.SerializeObject(jsonLabDataEntry);            
        }

        private void GetLabTestingPerformanceDaily()
        {
            //Session["Performance"] = "Testing";
            jsonLabTestingPerformance = _presenter.GetLabTestingPerformanceDaily(Convert.ToInt32(ddlYear2.SelectedValue), Convert.ToInt32(ddlMonth2.SelectedValue), ddlLab2.SelectedValue);
            JstringLabTestingPerformance = Newtonsoft.Json.JsonConvert.SerializeObject(jsonLabTestingPerformance);
        }

        private string GetLabTestingPerformanceDailyAjax()
        {            
            jsonLabTestingPerformance = _presenter.GetLabTestingPerformanceDaily(Convert.ToInt32(ddlYear2.SelectedValue), Convert.ToInt32(ddlMonth2.SelectedValue), ddlLab2.SelectedValue);
            return Newtonsoft.Json.JsonConvert.SerializeObject(jsonLabTestingPerformance);            
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            //this.GetSyncTotal();
            //this.BindingLastUploadDateTimeData();
            //this.BindingTotalUploadRecordsData();
            //this.BindingLabDataEntryPerformanceList();
            this.GetLabDataEntryPerformanceDaily();            
        }

        protected void btnTestingPerformanceFilter_Click(object sender, EventArgs e)
        {
            //this.GetSyncTotal();
            //this.BindingLastUploadDateTimeData();
            //this.BindingTotalUploadRecordsData();
            //this.BindingLabDataEntryPerformanceList();            
            this.GetLabTestingPerformanceDaily();            
        }

        protected string ItemNumber()
        {
            itemNumber++;
            return itemNumber.ToString();
        }

    }
}