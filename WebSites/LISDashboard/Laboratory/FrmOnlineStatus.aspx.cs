using CHAI.LISDashboard.CoreDomain.DataAccess;
using Microsoft.Practices.ObjectBuilder;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CHAI.LISDashboard.Modules.EID.Views
{
    public partial class FrmOnlineStatus : POCBasePage, IFrmOnlineStatusView
    {
        private FrmOnlineStatusPresenter _presenter;
        private ReportDao  dao;
        
        public IList listLabPerformance { get; set; }
        public string jsonLabPerformance { get; set; }

        public IList listLabPerformanceHistory { get; set; }
        public string jsonLabPerformanceHistory { get; set; }

        //public IList jsonLabOnlineHistory { get; set; }
        //public string JstringLabOnlineHistory { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this._presenter.OnViewInitialized();
                this.PopulateYears();

                this.GetLabPerformanceByDateRange();
                this.GetLabPerformanceHistory();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(FrmOnlineStatus), "OnlineStatusHistory", "RedrawOnlineStatusHistory(" + this.GetLabPerformanceHistory2() + ")", true);
                //ScriptManager.RegisterClientScriptBlock(Page, typeof(Default), "LabDataEntryPerformance", "RedrawLabDataEntryPerformance()", true);
            }
            this._presenter.OnViewLoaded();

            //ScriptManager.GetCurrent(this).RegisterPostBackControl(btnFilter);
            //ClientScript.GetPostBackEventReference(pnlHistory, "");
            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "Onload", "bindEvents();", true);
            //ScriptManager.GetCurrent(this).RegisterPostBackControl(btnFilter);

            //this.GetLabPerformanceByDateRange();
            //this.GetLabPerformanceHistory();
            //this.GetLabOnlineHistory();
        }
        public override string PageID
        {

            get
            {
                return "{cbeb14d4-d9b4-413f-a23a-4ad3a3ae8bfa}";
            }
        }
        [CreateNew]
        public FrmOnlineStatusPresenter Presenter
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

        #region "Private Methods"

        private void PopulateYears()
        {
            // Year Picker for Lab Performance History            
            var startYear = 2018;
            var currentYear = DateTime.Now.Year;
            for (var i = 0; i < currentYear - startYear + 1; i++)
            {
                ddlYear.Items.Add((startYear + i).ToString());
                //if ((startYear + i) == currentYear)
                //    ddlYear.Items.Add((startYear + i).ToString());                        
                //else
                //        $(this).append('<option value="' + (startYear + i) + '">' + (startYear + i) + '</option>');
                //alert(startYear + i);
            }
            ddlYear.SelectedValue = currentYear.ToString();
        }

        private void GetLabPerformanceByDateRange()
        {
            //if (txtdatefrom.Text == "" && txtdateto.Text == "")
            //{
            //lblDatefromyear.Text = DateTime.Now.AddYears(-1).Year.ToString();
            //lblDatetoyear.Text = DateTime.Now.Year.ToString();
            listLabPerformance = _presenter.GetLabPerformanceByDateRange(DateTime.Now.AddYears(-1).ToShortDateString(),
                DateTime.Today.Date.ToShortDateString());
            jsonLabPerformance = Newtonsoft.Json.JsonConvert.SerializeObject(listLabPerformance);
            //}
            //else
            //{
            //    lblDatefromyear.Text = Convert.ToDateTime(txtdatefrom.Text).Year.ToString();
            //    lblDatetoyear.Text = Convert.ToDateTime(txtdateto.Text).Year.ToString();
            //    jsonVLTestingTrends = _presenter.GetVLLABTestingTrends(txtdatefrom.Text, txtdateto.Text);
            //    JstringVLTestingTrends = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLTestingTrends);
            //}
        }

        private void GetLabPerformanceHistory()
        {
            //if (txtdatefrom.Text == "" && txtdateto.Text == "")
            //{
            //lblDatefromyear.Text = DateTime.Now.AddYears(-1).Year.ToString();
            //lblDatetoyear.Text = DateTime.Now.Year.ToString();
            listLabPerformanceHistory = _presenter.GetLabPerformanceHistory(Convert.ToInt32(ddlYear.SelectedValue));
            jsonLabPerformanceHistory = Newtonsoft.Json.JsonConvert.SerializeObject(listLabPerformanceHistory);

            //String colNames = string.Empty;
            //if(listLabPerformanceHistory!= null && listLabPerformanceHistory.Count > 0)
            //{
            //    for (int i = 0; i < listLabPerformanceHistory.; i++)
            //    {
            //        if (!Convert.IsDBNull(dr[i]))
            //            row.Add(dr[i]);
            //        else
            //            row.Add(0);
            //    }
            //    listLabPerformanceHistory
            //    foreach ()
            //}            
            //}
            //else
            //{
            //    lblDatefromyear.Text = Convert.ToDateTime(txtdatefrom.Text).Year.ToString();
            //    lblDatetoyear.Text = Convert.ToDateTime(txtdateto.Text).Year.ToString();
            //    jsonVLTestingTrends = _presenter.GetVLLABTestingTrends(txtdatefrom.Text, txtdateto.Text);
            //    JstringVLTestingTrends = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVLTestingTrends);
            //}
        }

        private string GetLabPerformanceHistory2()
        {            
            listLabPerformanceHistory = _presenter.GetLabPerformanceHistory(Convert.ToInt32(ddlYear.SelectedValue));
            return Newtonsoft.Json.JsonConvert.SerializeObject(listLabPerformanceHistory);
        }

        //private void GetLabOnlineHistory()
        //{
        //    jsonLabOnlineHistory = _presenter.GetLabOnlineHistory(Convert.ToInt32(ddlYear.SelectedValue));
        //    JstringLabOnlineHistory = Newtonsoft.Json.JsonConvert.SerializeObject(jsonLabOnlineHistory);
        //}

        #endregion

        protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            //listLabPerformanceHistory = _presenter.GetLabPerformanceHistory(Convert.ToInt32(ddlYear.SelectedValue));
            //jsonLabPerformanceHistory = Newtonsoft.Json.JsonConvert.SerializeObject(listLabPerformanceHistory);
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            this.GetLabPerformanceHistory();
            //this.GetLabOnlineHistory();
        }
    }
}