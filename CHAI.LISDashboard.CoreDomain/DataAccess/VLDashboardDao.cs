using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using CHAI.LISDashboard.Shared;
using System.Configuration;
using CHAI.LISDashboard.CoreDomain.Report;
using CHAI.LISDashboard.Shared.Settings;

namespace CHAI.LISDashboard.CoreDomain.DataAccess
{
    public class VLDashboardDao
    {
        //Added by ZaySoe ON 18_Jan_2019
        public IList GetVLTestYearly(int province, int user_id, string role)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetVLTestYearly";
                cmd.Parameters.AddWithValue("@prov", province); 
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@type", role);

                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                //cn.Close();
                var testResult = ds.Tables[0].AsEnumerable().Select(
                    dataRow => new ArrayList {
                        dataRow.Field<int>("LE_1000"),
                        dataRow.Field<int>("G_1000"),
                        dataRow.Field<decimal>("Suppression_Rate"),
                        dataRow.Field<int>("ResultDate") }).ToList();               
                return testResult;
            }
        }

        public IList GetVLTestYearlyByLab(string labCode, int dateFrom, int dateTo, int user_id, string role)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetVLTestYearlyByLab";
                cmd.Parameters.AddWithValue("@LabCode", labCode);
                if (dateFrom != 0)
                {
                    cmd.Parameters.AddWithValue("@DateFrom", dateFrom);
                }
                if (dateTo != 0)
                {
                    cmd.Parameters.AddWithValue("@DateTo", dateTo);
                }
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@type", role);
                cmd.CommandTimeout = 0;

                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                cn.Close();
                var testResult = ds.Tables[0].AsEnumerable().Select(
                    dataRow => new ArrayList {
                        dataRow.Field<int>("LE_1000"),
                        dataRow.Field<int>("G_1000"),
                        dataRow.Field<decimal>("Suppression_Rate"),
                        dataRow.Field<int>("ResultDate") }).ToList();
                return testResult;                                                
            }
        }

        public IList GetVLTestQuarterly(int province, int dateFrom, int dateTo, int user_id, string role)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetVLTestQuarterly";
                cmd.Parameters.AddWithValue("@prov", province);
                if (dateFrom != 0)
                {
                    cmd.Parameters.AddWithValue("@DateFrom", dateFrom);
                }
                if (dateTo != 0)
                {
                    cmd.Parameters.AddWithValue("@DateTo", dateTo);
                }
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@type", role);

                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                //cn.Close();

                var testResult = ds.Tables[0].AsEnumerable().Select(
                    dataRow => new ArrayList {
                        dataRow.Field<int>("LE_1000"),
                        dataRow.Field<int>("G_1000"),
                        dataRow.Field<decimal>("Suppression_Rate"),
                        dataRow.Field<string>("ResultDate"),
                        dataRow.Field<int>("YearData")
                    }).ToList();
                return testResult;
            }
        }

        public IList GetVLTestQuarterlyByLab(string labCode, int dateFrom, int dateTo, int user_id, string role)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetVLTestQuarterlyByLab";
                cmd.Parameters.AddWithValue("@LabCode", labCode);                
                if (dateFrom != 0)
                {
                    cmd.Parameters.AddWithValue("@DateFrom", dateFrom);
                }
                if (dateTo != 0)
                {
                    cmd.Parameters.AddWithValue("@DateTo", dateTo);
                }
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@type", role);
                cmd.CommandTimeout = 0;

                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                cn.Close();

                var testResult = ds.Tables[0].AsEnumerable().Select(
                    dataRow => new ArrayList {
                        dataRow.Field<int>("LE_1000"),
                        dataRow.Field<int>("G_1000"),
                        dataRow.Field<decimal>("Suppression_Rate"),
                        dataRow.Field<string>("ResultDate"),
                        dataRow.Field<int>("YearData")
                    }).ToList();
                return testResult;
            }
        }

        public IList GetVLTestMonthly(int province, int dateFrom, int dateTo, int user_id, string role)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetVLTestMonthly";
                cmd.Parameters.AddWithValue("@prov", province);
                if (dateFrom != 0)
                {
                    cmd.Parameters.AddWithValue("@DateFrom", dateFrom);
                }
                if (dateTo != 0)
                {
                    cmd.Parameters.AddWithValue("@DateTo", dateTo);
                }
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@type", role);

                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                //cn.Close();
                var testResult = ds.Tables[0].AsEnumerable().Select(
                    dataRow => new ArrayList {
                        dataRow.Field<int>("LE_1000"),
                        dataRow.Field<int>("G_1000"),
                        dataRow.Field<decimal>("Suppression_Rate"),
                        dataRow.Field<string>("ResultDate") }).ToList();
                return testResult;
            }
        }

        public IList GetVLTestMonthlyByLab(string labCode, int dateFrom, int dateTo, int user_id, string role)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetVLTestMonthlyByLab";
                cmd.Parameters.AddWithValue("@labCode", labCode);                
                if (dateFrom != 0)
                {
                    cmd.Parameters.AddWithValue("@DateFrom", dateFrom);
                }
                if (dateTo != 0)
                {
                    cmd.Parameters.AddWithValue("@DateTo", dateTo);
                }
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@type", role);
                cmd.CommandTimeout = 0;

                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                cn.Close();
                var testResult = ds.Tables[0].AsEnumerable().Select(
                    dataRow => new ArrayList {
                        dataRow.Field<int>("LE_1000"),
                        dataRow.Field<int>("G_1000"),
                        dataRow.Field<decimal>("Suppression_Rate"),
                        dataRow.Field<string>("ResultDate") }).ToList();
                return testResult;
            }
        }

        public IList GetVLTestByAgeYearly(int province, int dateFrom, int dateTo, int user_id, string role)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetVLTestByAgeOutcome";
                cmd.Parameters.AddWithValue("@prov", province);
                if (dateFrom != 0)
                {
                    cmd.Parameters.AddWithValue("@DateFrom", dateFrom);
                }
                if (dateTo != 0)
                {
                    cmd.Parameters.AddWithValue("@DateTo", dateTo);
                }
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@type", role);

                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                //cn.Close();
                var testResult = ds.Tables[0].AsEnumerable().Select(
                    dataRow => new ArrayList {
                        dataRow.Field<int>("LE_1000"),
                        dataRow.Field<int>("G_1000"),
                        dataRow.Field<decimal>("Suppression_Rate"),
                        dataRow.Field<string>("Age_Range")
                        //,dataRow.Field<int>("ResultDate")
                    }).ToList();
                return testResult;
            }
        }

        public IList GetVLTestByAgeYearlyForLab(string labCode, int dateFrom, int dateTo, int user_id, string role)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetVLTestByAgeOutcomeForLab";
                cmd.Parameters.AddWithValue("@LabCode", labCode);
                if (dateFrom != 0)
                {
                    cmd.Parameters.AddWithValue("@DateFrom", dateFrom);
                }
                if (dateTo != 0)
                {
                    cmd.Parameters.AddWithValue("@DateTo", dateTo);
                }
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@type", role);
                cmd.CommandTimeout = 0;

                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                cn.Close();
                var testResult = ds.Tables[0].AsEnumerable().Select(
                    dataRow => new ArrayList {
                        dataRow.Field<int>("LE_1000"),
                        dataRow.Field<int>("G_1000"),
                        dataRow.Field<decimal>("Suppression_Rate"),
                        dataRow.Field<string>("Age_Range")
                        //,dataRow.Field<int>("ResultDate")
                    }).ToList();
                return testResult;
            }
        }

        public IList GetVLTestByGenderOutcome(int province, int dateFrom, int dateTo, int user_id, string role)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetVLTestByGenderOutcome";
                cmd.Parameters.AddWithValue("@prov", province);
                if (dateFrom != 0)
                {
                    cmd.Parameters.AddWithValue("@DateFrom", dateFrom);
                }
                if (dateTo != 0)
                {
                    cmd.Parameters.AddWithValue("@DateTo", dateTo);
                }
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@type", role);

                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                //cn.Close();
                var testResult = ds.Tables[0].AsEnumerable().Select(
                    dataRow => new ArrayList {
                        dataRow.Field<int>("LE_1000"),
                        dataRow.Field<int>("G_1000"),
                        dataRow.Field<decimal>("Suppression_Rate"),
                        dataRow.Field<string>("Sex")                        
                    }).ToList();
                return testResult;
            }
        }

        public IList GetVLTestByGenderOutcomeForLab(string labCode, int dateFrom, int dateTo, int user_id, string role)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetVLTestByGenderOutcomeForLab";
                cmd.Parameters.AddWithValue("@LabCode", labCode);
                if (dateFrom != 0)
                {
                    cmd.Parameters.AddWithValue("@DateFrom", dateFrom);
                }
                if (dateTo != 0)
                {
                    cmd.Parameters.AddWithValue("@DateTo", dateTo);
                }
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@type", role);
                cmd.CommandTimeout = 0;

                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                cn.Close();
                var testResult = ds.Tables[0].AsEnumerable().Select(
                    dataRow => new ArrayList {
                        dataRow.Field<int>("LE_1000"),
                        dataRow.Field<int>("G_1000"),
                        dataRow.Field<decimal>("Suppression_Rate"),
                        dataRow.Field<string>("Sex")
                    }).ToList();
                return testResult;
            }
        }

        public IList GetVLTestByProvince(int province, int dateFrom, int dateTo, int user_id, string role)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetVLTestByFacility";
                cmd.Parameters.AddWithValue("@prov", province);
                if (dateFrom != 0)
                {
                    cmd.Parameters.AddWithValue("@DateFrom", dateFrom);
                }
                if (dateTo != 0)
                {
                    cmd.Parameters.AddWithValue("@DateTo", dateTo);
                }
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@type", role);

                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                //cn.Close();
                var testResult = ds.Tables[0].AsEnumerable().Select(
                    dataRow => new ArrayList {
                        dataRow.Field<int>("LE_1000"),
                        dataRow.Field<int>("G_1000"),
                        dataRow.Field<decimal>("Suppression_Rate"),
                        dataRow.Field<string>("Name")
                    }).ToList();
                return testResult;
            }
        }

        public IList GetVLTestByProvinceForLab(string labCode, int dateFrom, int dateTo, int user_id, string role)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetVLTestByFacilityForLab";
                cmd.Parameters.AddWithValue("@LabCode", labCode);
                if (dateFrom != 0)
                {
                    cmd.Parameters.AddWithValue("@DateFrom", dateFrom);
                }
                if (dateTo != 0)
                {
                    cmd.Parameters.AddWithValue("@DateTo", dateTo);
                }
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@type", role);
                cmd.CommandTimeout = 0;

                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                cn.Close();
                var testResult = ds.Tables[0].AsEnumerable().Select(
                    dataRow => new ArrayList {
                        dataRow.Field<int>("LE_1000"),
                        dataRow.Field<int>("G_1000"),
                        dataRow.Field<decimal>("Suppression_Rate"),
                        dataRow.Field<string>("Name")
                    }).ToList();
                return testResult;
            }
        }

        //public IList GetVLTestByAgeQuarterly(int province, int dateFrom, int dateTo, int user_id, string role)
        //{
        //    string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
        //    using (SqlConnection cn = new SqlConnection(connstring))
        //    {
        //        cn.Open();
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.Connection = cn;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = "GetVLTestByAgeQuarterly";
        //        cmd.Parameters.AddWithValue("@prov", province);
        //        if (dateFrom != 0)
        //        {
        //            cmd.Parameters.AddWithValue("@DateFrom", dateFrom);
        //        }
        //        if (dateTo != 0)
        //        {
        //            cmd.Parameters.AddWithValue("@DateTo", dateTo);
        //        }
        //        cmd.Parameters.AddWithValue("@user_id", user_id);
        //        cmd.Parameters.AddWithValue("@type", role);

        //        var da = new SqlDataAdapter(cmd);
        //        var ds = new DataSet();
        //        da.Fill(ds);
        //        cn.Close();

        //        var testResult = ds.Tables[0].AsEnumerable().Select(
        //            dataRow => new ArrayList {
        //                dataRow.Field<int>("LE_1000"),
        //                dataRow.Field<int>("G_1000"),
        //                dataRow.Field<decimal>("Positivity"),
        //                dataRow.Field<string>("Age_Range"),
        //                dataRow.Field<string>("ResultDate") }).ToList();
        //        return testResult;
        //    }
        //}

        //public IList GetVLTestByAgeMonthly(int province, int dateFrom, int dateTo, int user_id, string role)
        //{
        //    string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
        //    using (SqlConnection cn = new SqlConnection(connstring))
        //    {
        //        cn.Open();
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.Connection = cn;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = "GetVLTestByAgeMonthly";
        //        cmd.Parameters.AddWithValue("@prov", province);
        //        if (dateFrom != 0)
        //        {
        //            cmd.Parameters.AddWithValue("@DateFrom", dateFrom);
        //        }
        //        if (dateTo != 0)
        //        {
        //            cmd.Parameters.AddWithValue("@DateTo", dateTo);
        //        }
        //        cmd.Parameters.AddWithValue("@user_id", user_id);
        //        cmd.Parameters.AddWithValue("@type", role);

        //        var da = new SqlDataAdapter(cmd);
        //        var ds = new DataSet();
        //        da.Fill(ds);
        //        cn.Close();
        //        var testResult = ds.Tables[0].AsEnumerable().Select(
        //            dataRow => new ArrayList {
        //                dataRow.Field<int>("LE_1000"),
        //                dataRow.Field<int>("G_1000"),
        //                dataRow.Field<decimal>("Positivity"),
        //                dataRow.Field<string>("Age_Range"),
        //                dataRow.Field<string>("ResultDate") }).ToList();
        //        return testResult;
        //    }
        //}

        // VL Summery
        #region VL Summery
        public VLStat VLSummaryStat(string dateFrom, string dateTo, int province, int user_id, string role)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetVLSummaryStat";
                cmd.Parameters.AddWithValue("@Province", province);
                if (dateFrom != "")
                {
                    cmd.Parameters.AddWithValue("@DateFrom", dateFrom);
                }
                if (dateTo != "")
                {
                    cmd.Parameters.AddWithValue("@DateTo", dateTo);
                }
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@type", role);                

                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                //cn.Close();
                VLStat vl = new VLStat();
                    vl.Tot_Tests = ds.Tables[0].Rows[0].Field<int>("Tot_Tests");
                    vl.RejectedSamples = ds.Tables[0].Rows[0].Field<decimal>("RejectedSamples");
                    vl.Tot_Detected_LE_1000 = ds.Tables[0].Rows[0].Field<int>("Tot_Detected_LE_1000");
                    vl.Tot_Detected_G_1000 = ds.Tables[0].Rows[0].Field<int>("Tot_Detected_G_1000");
                    vl.Total_Suppressed = ds.Tables[0].Rows[0].Field<decimal>("Total_Suppressed");
                    vl.Rate_Detected_LE_1000 = ds.Tables[0].Rows[0].Field<decimal>("Rate_Detected_LE_1000");
                    vl.Rate_Detected_G_1000 = ds.Tables[0].Rows[0].Field<decimal>("Rate_Detected_G_1000");
                    vl.Rate_Error = ds.Tables[0].Rows[0].Field<decimal>("Rate_Error");
                    vl.Error = ds.Tables[0].Rows[0].Field<int>("Invalid_Error_Noresult");

                //ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<int>("Tot_Tests"), dataRow.Field<decimal>("RejectedSamples"), dataRow.Field<int>("Tot_Detected_LE_1000"), dataRow.Field<int>("Tot_Detected_G_1000"), dataRow.Field<decimal>("Total_Suppressed"), dataRow.Field<int>("Invalid_Error_Noresult") }).ToList();
                return vl;
            }
        }

        public VLStat VLSummaryStat(string dateFrom, string dateTo, string labCode, int user_id, string role)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetVLSummaryStatByLab";
                cmd.Parameters.AddWithValue("@LabCode", labCode);
                if (dateFrom != "")
                {
                    cmd.Parameters.AddWithValue("@DateFrom", dateFrom);
                }
                if (dateTo != "")
                {
                    cmd.Parameters.AddWithValue("@DateTo", dateTo);
                }
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@type", role);

                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                //cn.Close();
                VLStat vl = new VLStat();
                vl.Tot_Tests = ds.Tables[0].Rows[0].Field<int>("Tot_Tests");
                vl.RejectedSamples = ds.Tables[0].Rows[0].Field<decimal>("RejectedSamples");
                vl.Tot_Detected_LE_1000 = ds.Tables[0].Rows[0].Field<int>("Tot_Detected_LE_1000");
                vl.Tot_Detected_G_1000 = ds.Tables[0].Rows[0].Field<int>("Tot_Detected_G_1000");
                vl.Total_Suppressed = ds.Tables[0].Rows[0].Field<decimal>("Total_Suppressed");
                vl.Rate_Detected_LE_1000 = ds.Tables[0].Rows[0].Field<decimal>("Rate_Detected_LE_1000");
                vl.Rate_Detected_G_1000 = ds.Tables[0].Rows[0].Field<decimal>("Rate_Detected_G_1000");
                vl.Rate_Error = ds.Tables[0].Rows[0].Field<decimal>("Rate_Error");
                vl.Error = ds.Tables[0].Rows[0].Field<int>("Invalid_Error_Noresult");

                //ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<int>("Tot_Tests"), dataRow.Field<decimal>("RejectedSamples"), dataRow.Field<int>("Tot_Detected_LE_1000"), dataRow.Field<int>("Tot_Detected_G_1000"), dataRow.Field<decimal>("Total_Suppressed"), dataRow.Field<int>("Invalid_Error_Noresult") }).ToList();
                return vl;
            }
        }

        public IList GetVLSummary(int province, int dateFrom, int dateTo, int user_id, string role)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetVLSummary";
                cmd.Parameters.AddWithValue("@prov", province);
                cmd.Parameters.AddWithValue("@dateFrom", dateFrom);
                cmd.Parameters.AddWithValue("@dateTo", dateTo);
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@type", role);                
                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                //cn.Close();
                var eidIntialPCRbyYear = ds.Tables[0].AsEnumerable().Select(
                    dataRow => new ArrayList {
                        dataRow.Field<int>("Total_Received"),
                        dataRow.Field<int>("Total_Tested"),
                        dataRow.Field<int>("Not_Suppressed"),
                        dataRow.Field<int>("Suppressed"),
                        dataRow.Field<int>("LDL"),
                        dataRow.Field<int>("Rejected"),                        
                        dataRow.Field<decimal>("Rejected_Rate"),
                        dataRow.Field<int>("Error")
                    }).ToList();
                return eidIntialPCRbyYear;
            }
        }

        public IList GetVLSummary(string labCode, int dateFrom, int dateTo, int user_id, string role)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetVLSummaryByLab";
                cmd.Parameters.AddWithValue("@LabCode", labCode);
                cmd.Parameters.AddWithValue("@dateFrom", dateFrom);
                cmd.Parameters.AddWithValue("@dateTo", dateTo);
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@type", role);
                cmd.CommandTimeout = 0;
                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                cn.Close();
                var eidIntialPCRbyYear = ds.Tables[0].AsEnumerable().Select(
                    dataRow => new ArrayList {
                        dataRow.Field<int>("Total_Received"),
                        dataRow.Field<int>("Total_Tested"),
                        dataRow.Field<int>("Not_Suppressed"),
                        dataRow.Field<int>("Suppressed"),
                        dataRow.Field<int>("LDL"),
                        dataRow.Field<int>("Rejected"),
                        dataRow.Field<decimal>("Rejected_Rate"),
                        dataRow.Field<int>("Error")
                    }).ToList();
                return eidIntialPCRbyYear;
            }
        }

        public IList GetTestTrends(int province, int Testreason, string datefrom, string dateto)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetVLTestTrendbyTestreason";
                cmd.Parameters.AddWithValue("@Province", province);
                cmd.Parameters.AddWithValue("@TestReason", Testreason);
                if (datefrom != "")
                {
                    cmd.Parameters.AddWithValue("@DateFrom", datefrom);
                }
                if (dateto != "")
                {
                    cmd.Parameters.AddWithValue("@DateTo", dateto);
                }
                
                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                //cn.Close();
                var testtrends = ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<int>("DBS"), dataRow.Field<int>("Whole_Blood"), dataRow.Field<int>("Plasma"), dataRow.Field<int>("yeardata"), dataRow.Field<string>("monthdata") }).ToList();
                return testtrends;
            }
        }
        public IList GetVLOutcome(int province, string datefrom, string dateto)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetVLOutcomes";
                cmd.Parameters.AddWithValue("@Province", province);
                
                if (datefrom != "")
                {
                    cmd.Parameters.AddWithValue("@DateFrom", datefrom);
                }
                if (dateto != "")
                {
                    cmd.Parameters.AddWithValue("@DateTo", dateto);
                }

                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                //cn.Close();
                var testtrends = ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<int>("Suppressed"), dataRow.Field<int>("Not_Suppressed"), dataRow.Field<int>("LDL") }).ToList();
                return testtrends;
            }
        }

        public IList GetVLTestbyGender(int province, string datefrom, string dateto)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetVLTestbyGender";
                cmd.Parameters.AddWithValue("@Province", province);

                if (datefrom != "")
                {
                    cmd.Parameters.AddWithValue("@DateFrom", datefrom);
                }
                if (dateto != "")
                {
                    cmd.Parameters.AddWithValue("@DateTo", dateto);
                }

                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                //cn.Close();
                var testtrends = ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<int>("Suppressed"), dataRow.Field<int>("Not_Suppressed"), dataRow.Field<string>("Sex") }).ToList();
                return testtrends;
            }
        }

        public IList GetVLTestbyAge(int province, string datefrom, string dateto)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetVLTestbyAge";
                cmd.Parameters.AddWithValue("@Province", province);

                if (datefrom != "")
                {
                    cmd.Parameters.AddWithValue("@DateFrom", datefrom);
                }
                if (dateto != "")
                {
                    cmd.Parameters.AddWithValue("@DateTo", dateto);
                }

                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                //cn.Close();
                var testtrends = ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<int>("Suppressed"), dataRow.Field<int>("Not_Suppressed"), dataRow.Field<string>("Age") }).ToList();
                return testtrends;
            }
        }

        public IList GetVLreasonforTest(int province, string datefrom, string dateto)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetVLTestbyReasonforTest";
                cmd.Parameters.AddWithValue("@Province", province);

                if (datefrom != "")
                {
                    cmd.Parameters.AddWithValue("@DateFrom", datefrom);
                }
                if (dateto != "")
                {
                    cmd.Parameters.AddWithValue("@DateTo", dateto);
                }

                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                //cn.Close();
                var testtrends = ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<int>("ReasonCount"), dataRow.Field<string>("Reasonfortest") }).ToList();
                return testtrends;
            }
        }

        public IList GetVLOutcomebyProvince(int province, string datefrom, string dateto)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetVLProvinceOutcome";
                cmd.Parameters.AddWithValue("@Province", province);

                if (datefrom != "")
                {
                    cmd.Parameters.AddWithValue("@DateFrom", datefrom);
                }
                if (dateto != "")
                {
                    cmd.Parameters.AddWithValue("@DateTo", dateto);
                }

                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                //cn.Close();
                IList testtrends =null;
                if (province == 0)
                {
                     testtrends = ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<int>("Suppressed"), dataRow.Field<int>("Not_Suppressed"), dataRow.Field<int>("LDL"), dataRow.Field<int>("Suppression_Rate"), dataRow.Field<string>("ProvinceName") }).ToList();
                }
                else
                {
                     testtrends = ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<int>("Suppressed"), dataRow.Field<int>("Not_Suppressed"), dataRow.Field<int>("LDL"), dataRow.Field<int>("Suppression_Rate"), dataRow.Field<string>("FacilityName") }).ToList();
                }
                return testtrends;
            }
        }
        #endregion
        // Testing Trends
        #region Testing Trends
        public IList GetVLTestingTrendOutcome(int province, int isQuarter)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetVLTestingTrendOutcome";
                cmd.Parameters.AddWithValue("@Province", province);
                cmd.Parameters.AddWithValue("@IsQuarter", isQuarter);
               
                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                //cn.Close();
                IList testtrends;

                if (isQuarter != 0)
                {
                     testtrends = ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<int>("Suppressed"), dataRow.Field<int>("Not_Suppressed"), dataRow.Field<int>("Suppression_Rate"), dataRow.Field<int>("yeardata"), dataRow.Field<string>("QUARTER") }).ToList();
                }
                else
                {
                     testtrends = ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<int>("Suppressed"), dataRow.Field<int>("Not_Suppressed"), dataRow.Field<int>("Suppression_Rate"), dataRow.Field<int>("yeardata") }).ToList();
                }
                return testtrends;
            }
        }
        public IList GetVLTestbyAgeTrends(int province)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetVLTestbyAgeTrends";
                cmd.Parameters.AddWithValue("@Province", province);
                //cmd.Parameters.AddWithValue("@IsQuarter", isQuarter);

                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                //cn.Close();
                IList testtrends;
                testtrends = ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<int>("NoTests_0-6"), dataRow.Field<int>("NoTests_7-14"), dataRow.Field<int>("NoTests_15-21"), dataRow.Field<int>("NoTests_22-39"), dataRow.Field<int>("NoTests_40-60"), dataRow.Field<int>("NoTests>60"), dataRow.Field<int>("Less_21_Contribution"), dataRow.Field<int>("TestYear") }).ToList();
                
                return testtrends;
            }
        }
        public IList GetVLSuppressionTrends(int province, int isQuarter)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetVLSuppressionTrends";
                cmd.Parameters.AddWithValue("@Province", province);
                cmd.Parameters.AddWithValue("@IsQuarter", isQuarter);

                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                //cn.Close();
                IList testtrends;

                if (isQuarter == 0)
                {
                    testtrends = ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<int>("Jan"), dataRow.Field<int>("Feb"), dataRow.Field<int>("Mar"), dataRow.Field<int>("Apr"),dataRow.Field<int>("May"), dataRow.Field<int>("Jun"), dataRow.Field<int>("Jul"), dataRow.Field<int>("Aug"), dataRow.Field<int>("Sep"), dataRow.Field<int>("Oct"), dataRow.Field<int>("Nov"), dataRow.Field<int>("Dec"), dataRow.Field<int>("yeardata") }).ToList();
                }
                else
                {
                    testtrends = ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<int>("Q1"), dataRow.Field<int>("Q2"), dataRow.Field<int>("Q3"), dataRow.Field<int>("Q4"), dataRow.Field<int>("yeardata") }).ToList();
                }
                return testtrends;
            }
        }
        public IList GetVLValidTestingTrends(int province, int isQuarter)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetVLValidTestingTrends";
                cmd.Parameters.AddWithValue("@Province", province);
                cmd.Parameters.AddWithValue("@IsQuarter", isQuarter);

                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                //cn.Close();
                IList testtrends;

                if (isQuarter == 0)
                {
                    testtrends = ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<int>("Jan"), dataRow.Field<int>("Feb"), dataRow.Field<int>("Mar"), dataRow.Field<int>("Apr"), dataRow.Field<int>("May"), dataRow.Field<int>("Jun"), dataRow.Field<int>("Jul"), dataRow.Field<int>("Aug"), dataRow.Field<int>("Sep"), dataRow.Field<int>("Oct"), dataRow.Field<int>("Nov"), dataRow.Field<int>("Dec"), dataRow.Field<int>("yeardata") }).ToList();
                }
                else
                {
                    testtrends = ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<int>("Q1"), dataRow.Field<int>("Q2"), dataRow.Field<int>("Q3"), dataRow.Field<int>("Q4"), dataRow.Field<int>("yeardata") }).ToList();
                }
                return testtrends;
            }
        }
        public IList GetVLRejectedTrends(int province, int isQuarter)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetVLRejectedTrends";
                cmd.Parameters.AddWithValue("@Province", province);
                cmd.Parameters.AddWithValue("@IsQuarter", isQuarter);

                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                //cn.Close();
                IList testtrends;

                //if (isQuarter == 0)
                //{
                    testtrends = ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<int>("Jan"), dataRow.Field<int>("Feb"), dataRow.Field<int>("Mar"), dataRow.Field<int>("Apr"), dataRow.Field<int>("May"), dataRow.Field<int>("Jun"), dataRow.Field<int>("Jul"), dataRow.Field<int>("Aug"), dataRow.Field<int>("Sep"), dataRow.Field<int>("Oct"), dataRow.Field<int>("Nov"), dataRow.Field<int>("Dec"), dataRow.Field<int>("YearData") }).ToList();
                //}
                //else
                //{
                //    testtrends = ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<int>("Q1"), dataRow.Field<int>("Q2"), dataRow.Field<int>("Q3"), dataRow.Field<int>("Q4"), dataRow.Field<int>("yeardata") }).ToList();
                //}
                return testtrends;
            }
        }

        public IList GetVLTurnAroundTime(int province, int dateFrom, int dateTo, int user_id, string role)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetVLTurnaroundTime";
                cmd.Parameters.AddWithValue("@prov", province);
                if (dateFrom != 0)
                {
                    cmd.Parameters.AddWithValue("@DateFrom", dateFrom);
                }
                if (dateTo != 0)
                {
                    cmd.Parameters.AddWithValue("@DateTo", dateTo);
                }
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@type", role);

                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                //cn.Close();
                IList testtrends;

                //if (isQuarter == 0)
                //{
                    testtrends = ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<int>("Jan"), dataRow.Field<int>("Feb"), dataRow.Field<int>("Mar"), dataRow.Field<int>("Apr"), dataRow.Field<int>("May"), dataRow.Field<int>("Jun"), dataRow.Field<int>("Jul"), dataRow.Field<int>("Aug"), dataRow.Field<int>("Sep"), dataRow.Field<int>("Oct"), dataRow.Field<int>("Nov"), dataRow.Field<int>("Dec"), dataRow.Field<int>("Year") }).ToList();
                //}
                //else
                //{
                //    testtrends = ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<int>("Q1"), dataRow.Field<int>("Q2"), dataRow.Field<int>("Q3"), dataRow.Field<int>("Q4"), dataRow.Field<int>("Year") }).ToList();
                //}
                return testtrends;
            }
        }
        #endregion
        #region Lab Perfomance
        public DataSet VLLabPerStatSummary(string datefrom, string dateto, string LabName, string labCode)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "VLLabPerStatSummary";
                cmd.Parameters.AddWithValue("@LabName", LabName);
                if (datefrom != "")
                {
                    cmd.Parameters.AddWithValue("@DateFrom", datefrom);
                }
                if (dateto != "")
                {
                    cmd.Parameters.AddWithValue("@DateTo", dateto);
                }
                cmd.Parameters.AddWithValue("@LabCode", labCode);

                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                //cn.Close();
                return ds;
            }
        }
            public IList GetVLLABTestingTrends(string datefrom, string dateto)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetVLLABTestingTrends";
                
                if (datefrom != "")
                {
                    cmd.Parameters.AddWithValue("@DateFrom", datefrom);
                }
                if (dateto != "")
                {
                    cmd.Parameters.AddWithValue("@DateTo", dateto);
                }

                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                //cn.Close();
                IList testtrends = ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<int>("Jan"), dataRow.Field<int>("Feb"), dataRow.Field<int>("Mar"), dataRow.Field<int>("Apr"), dataRow.Field<int>("May"), dataRow.Field<int>("Jun"), dataRow.Field<int>("Jul"), dataRow.Field<int>("Aug"), dataRow.Field<int>("Sep"), dataRow.Field<int>("Oct"), dataRow.Field<int>("Nov"), dataRow.Field<int>("Dec"), dataRow.Field<string>("LaboratoryName") }).ToList();
                return testtrends;
            }
        }
        public IList GetVLLABRejectionTrends(string datefrom, string dateto)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetVLLABRejectionTrends";

                if (datefrom != "")
                {
                    cmd.Parameters.AddWithValue("@DateFrom", datefrom);
                }
                if (dateto != "")
                {
                    cmd.Parameters.AddWithValue("@DateTo", dateto);
                }

                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                //cn.Close();
                IList testtrends = ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<int>("Jan"), dataRow.Field<int>("Feb"), dataRow.Field<int>("Mar"), dataRow.Field<int>("Apr"), dataRow.Field<int>("May"), dataRow.Field<int>("Jun"), dataRow.Field<int>("Jul"), dataRow.Field<int>("Aug"), dataRow.Field<int>("Sep"), dataRow.Field<int>("Oct"), dataRow.Field<int>("Nov"), dataRow.Field<int>("Dec"), dataRow.Field<string>("LaboratoryName") }).ToList();
                return testtrends;
            }
        }
        public IList GetVLLABTestbySampleType(string datefrom, string dateto)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetVLLABTestbySampleType";

                if (datefrom != "")
                {
                    cmd.Parameters.AddWithValue("@DateFrom", datefrom);
                }
                if (dateto != "")
                {
                    cmd.Parameters.AddWithValue("@DateTo", dateto);
                }

                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                //cn.Close();
                IList testtrends = ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<int>("DBS"), dataRow.Field<int>("Whole_Blood"), dataRow.Field<int>("Plasma"), dataRow.Field<int>("DBSContribution"), dataRow.Field<int>("WholebloodContribution"), dataRow.Field<int>("PlasmaContribution"),dataRow.Field<string>("LaboratoryName") }).ToList();
                return testtrends;
            }
        }
        public IList GetVLLABTestbyGender(string datefrom, string dateto)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetVLLABTestbyGender";

                if (datefrom != "")
                {
                    cmd.Parameters.AddWithValue("@DateFrom", datefrom);
                }
                if (dateto != "")
                {
                    cmd.Parameters.AddWithValue("@DateTo", dateto);
                }

                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                //cn.Close();
                IList testtrends = ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<int>("Female"), dataRow.Field<int>("Male"), dataRow.Field<int>("Not_Indicated_on_Form"), dataRow.Field<int>("FemaleContribution"), dataRow.Field<int>("MaleContribution"), dataRow.Field<int>("NotIndicatedonFormContribution"), dataRow.Field<string>("LaboratoryName") }).ToList();
                return testtrends;
            }
        }
        public IList GetVLLABTestbyAge(string datefrom, string dateto)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetVLLABTestbyAge";

                if (datefrom != "")
                {
                    cmd.Parameters.AddWithValue("@DateFrom", datefrom);
                }
                if (dateto != "")
                {
                    cmd.Parameters.AddWithValue("@DateTo", dateto);
                }

                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                //cn.Close();
                IList testtrends = ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<int>("Childern"), dataRow.Field<int>("Adult"), dataRow.Field<int>("ChildernContribution"), dataRow.Field<int>("AdultContribution"),dataRow.Field<string>("LaboratoryName") }).ToList();
                return testtrends;
            }
        }
        public IList GetVLLABOutcome(string datefrom, string dateto)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetVLLABOutcome";

                if (datefrom != "")
                {
                    cmd.Parameters.AddWithValue("@DateFrom", datefrom);
                }
                if (dateto != "")
                {
                    cmd.Parameters.AddWithValue("@DateTo", dateto);
                }

                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                //cn.Close();
                IList testtrends = ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<int>("Suppressed"), dataRow.Field<int>("Not_Suppressed"), dataRow.Field<int>("Suppression_Rate"), dataRow.Field<int>("Not_Suppression_Rate"), dataRow.Field<string>("LaboratoryName") }).ToList();
                return testtrends;
            }
        }
        public IList GetVLLABRejectionReasonNational(string datefrom, string dateto)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetVLLABRejectionReasonNational";

                if (datefrom != "")
                {
                    cmd.Parameters.AddWithValue("@DateFrom", datefrom);
                }
                if (dateto != "")
                {
                    cmd.Parameters.AddWithValue("@DateTo", dateto);
                }

                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                //cn.Close();
                IList testtrends = ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<int>("NoofRejectedreason"), dataRow.Field<decimal>("RejectionRate"),  dataRow.Field<string>("Reason") }).ToList();
                return testtrends;
            }
        }
        public IList GetVLLABOutcomeTrends(string datefrom, string dateto, string LabCode)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetVLLABOutcomeTrends";

                if (datefrom != "")
                {
                    cmd.Parameters.AddWithValue("@DateFrom", datefrom);
                }
                if (dateto != "")
                {
                    cmd.Parameters.AddWithValue("@DateTo", dateto);
                }
                cmd.Parameters.AddWithValue("@Lab", LabCode);
                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                //cn.Close();
                IList testtrends = ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<int>("Suppressed"), dataRow.Field<int>("Not_Suppressed"), dataRow.Field<int>("Suppression_Rate"), dataRow.Field<int>("yeardata"), dataRow.Field<string>("monthdata") }).ToList();
                return testtrends;
            }
        }
        public IList GetVLLabperformanceSuppressionTrends(string LabCode)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetVLLabperformanceSuppressionTrends";

               
                cmd.Parameters.AddWithValue("@Lab", LabCode);
                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                //cn.Close();
                IList testtrends = ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<int>("Jan"), dataRow.Field<int>("Feb"), dataRow.Field<int>("Mar"), dataRow.Field<int>("Apr"), dataRow.Field<int>("May"), dataRow.Field<int>("Jun"), dataRow.Field<int>("Jul"), dataRow.Field<int>("Aug"), dataRow.Field<int>("Sep"), dataRow.Field<int>("Oct"), dataRow.Field<int>("Nov"), dataRow.Field<int>("Dec"), dataRow.Field<int>("yeardata") }).ToList();
                return testtrends;
            }
        }
        public IList GetVLLabValidTestingTrends(string LabCode)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetVLLabValidTestingTrends";

               
                cmd.Parameters.AddWithValue("@Lab", LabCode);
                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                //cn.Close();
                IList testtrends = ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<int>("Jan"), dataRow.Field<int>("Feb"), dataRow.Field<int>("Mar"), dataRow.Field<int>("Apr"), dataRow.Field<int>("May"), dataRow.Field<int>("Jun"), dataRow.Field<int>("Jul"), dataRow.Field<int>("Aug"), dataRow.Field<int>("Sep"), dataRow.Field<int>("Oct"), dataRow.Field<int>("Nov"), dataRow.Field<int>("Dec"), dataRow.Field<int>("yeardata") }).ToList();
                return testtrends;
            }
        }
        public IList GetVLLabPerfomaceRejectedTrends(string LabCode)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetVLLabPerfomaceRejectedTrends";

                
                cmd.Parameters.AddWithValue("@Lab", LabCode);
                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                //cn.Close();
                IList testtrends = ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<int>("Jan"), dataRow.Field<int>("Feb"), dataRow.Field<int>("Mar"), dataRow.Field<int>("Apr"), dataRow.Field<int>("May"), dataRow.Field<int>("Jun"), dataRow.Field<int>("Jul"), dataRow.Field<int>("Aug"), dataRow.Field<int>("Sep"), dataRow.Field<int>("Oct"), dataRow.Field<int>("Nov"), dataRow.Field<int>("Dec"), dataRow.Field<int>("yeardata") }).ToList();
                return testtrends;
            }
        }

        public IList GetVLTurnAroundTimeByLab(string LabCode)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetVLTurnAroundTimeByLab";
                cmd.Parameters.AddWithValue("@Lab", LabCode);

                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                //cn.Close();
                IList testtrends;


                testtrends = ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<int>("Jan"), dataRow.Field<int>("Feb"), dataRow.Field<int>("Mar"), dataRow.Field<int>("Apr"), dataRow.Field<int>("May"), dataRow.Field<int>("Jun"), dataRow.Field<int>("Jul"), dataRow.Field<int>("Aug"), dataRow.Field<int>("Sep"), dataRow.Field<int>("Oct"), dataRow.Field<int>("Nov"), dataRow.Field<int>("Dec"), dataRow.Field<int>("Year") }).ToList();

                return testtrends;
            }
        }

        public IList GetVLLABRejectionReasonbyLab(string datefrom, string dateto, string LabCode)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetVLLABRejectionReasonbyLab";

                if (datefrom != "")
                {
                    cmd.Parameters.AddWithValue("@DateFrom", datefrom);
                }
                if (dateto != "")
                {
                    cmd.Parameters.AddWithValue("@DateTo", dateto);
                }
                cmd.Parameters.AddWithValue("@Lab", LabCode);
                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                //cn.Close();
                IList testtrends = ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<int>("NoofRejectedreason"), dataRow.Field<decimal>("RejectionRate"), dataRow.Field<string>("Reason") }).ToList();
                return testtrends;
            }
        }

        // Added by Zay Soe on 30_Jan_2019
        public IList GetVLLabByLabInstrument(int dateFrom, int dateTo, int user_id, string role, int labInstruId)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetVLLabByLabInstrument";               
                if (dateFrom != 0)
                {
                    cmd.Parameters.AddWithValue("@DateFrom", dateFrom);
                }
                if (dateTo != 0)
                {
                    cmd.Parameters.AddWithValue("@DateTo", dateTo);
                }
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@type", role);
                cmd.Parameters.AddWithValue("@labInstruId", labInstruId);

                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                //cn.Close();

                IList testtrends = ds.Tables[0].AsEnumerable().Select(
                    dataRow => new ArrayList {
                        dataRow.Field<int>("Q1"),
                        dataRow.Field<int>("Q2"),
                        dataRow.Field<int>("Q3"),
                        dataRow.Field<int>("Q4"),
                        dataRow.Field<string>("Lab") }).ToList();
                return testtrends;
            }
        }

        public IList GetVLLabByLabInstrument(string labCode, int dateFrom, int dateTo, int user_id, string role, int labInstruId)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetVLLabByLabInstrumentForLab";
                cmd.Parameters.AddWithValue("@LabCode", labCode);
                if (dateFrom != 0)
                {
                    cmd.Parameters.AddWithValue("@DateFrom", dateFrom);
                }
                if (dateTo != 0)
                {
                    cmd.Parameters.AddWithValue("@DateTo", dateTo);
                }
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@type", role);
                cmd.Parameters.AddWithValue("@labInstruId", labInstruId);
                cmd.CommandTimeout = 0;                

                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                cn.Close();                

                IList testtrends = ds.Tables[0].AsEnumerable().Select(
                    dataRow => new ArrayList {
                        dataRow.Field<int>("Q1"),
                        dataRow.Field<int>("Q2"),
                        dataRow.Field<int>("Q3"),
                        dataRow.Field<int>("Q4"),                        
                        dataRow.Field<string>("Lab") }).ToList();
                return testtrends;
            }
        }
        
        public IList GetVLLabByLabInstrumentComparison(int dateFrom, int dateTo, int user_id, string role)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetVLLabByLabInstrumentComparison";                
                if (dateFrom != 0)
                {
                    cmd.Parameters.AddWithValue("@DateFrom", dateFrom);
                }
                if (dateTo != 0)
                {
                    cmd.Parameters.AddWithValue("@DateTo", dateTo);
                }
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@type", role);                

                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                //cn.Close();

                IList testtrends = ds.Tables[0].AsEnumerable().Select(
                    dataRow => new ArrayList {
                        dataRow.Field<int>("Q1"),
                        dataRow.Field<int>("Q2"),
                        dataRow.Field<int>("Q3"),
                        dataRow.Field<int>("Q4"),
                        dataRow.Field<string>("LabInstrumentname") }).ToList();
                return testtrends;
            }
        }

        public IList GetVLLabByLabInstrumentComparisonForLab(string labCode, int dateFrom, int dateTo, int user_id, string role)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetVLLabByLabInstrumentComparisonForLab";
                cmd.Parameters.AddWithValue("@LabCode", labCode);
                if (dateFrom != 0)
                {
                    cmd.Parameters.AddWithValue("@DateFrom", dateFrom);
                }
                if (dateTo != 0)
                {
                    cmd.Parameters.AddWithValue("@DateTo", dateTo);
                }
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@type", role);
                cmd.CommandTimeout = 0;

                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                cn.Close();

                IList testtrends = ds.Tables[0].AsEnumerable().Select(
                    dataRow => new ArrayList {
                        dataRow.Field<int>("Q1"),
                        dataRow.Field<int>("Q2"),
                        dataRow.Field<int>("Q3"),
                        dataRow.Field<int>("Q4"),
                        dataRow.Field<string>("LabInstrumentname") }).ToList();
                return testtrends;
            }
        }

        public IList GetVLTestByStateRegionFacility(string labCode, int dateFrom, int dateTo, int user_id, string role)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetVLTestByStateRegionFacility";
                cmd.Parameters.AddWithValue("@LabCode", labCode);
                if (dateFrom != 0)
                {
                    cmd.Parameters.AddWithValue("@DateFrom", dateFrom);
                }
                if (dateTo != 0)
                {
                    cmd.Parameters.AddWithValue("@DateTo", dateTo);
                }
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@type", role);
                cmd.CommandTimeout = 0;

                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                //cn.Close();
                var testResult = ds.Tables[0].AsEnumerable().Select(
                    dataRow => new ArrayList {
                        dataRow.Field<int>("Tot_Tests"),
                        dataRow.Field<string>("Name"),
                        dataRow.Field<int>("NoOfFacilities"),
                        dataRow.Field<string>("Facilities"),
                        dataRow.Field<string>("Tot_by_Fac"),
                    }).ToList();
                return testResult;
            }
        }

        public IList GetVLTestByLab(int province, int dateFrom, int dateTo, int user_id, string role, int labInstruId)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetVLTestReason";
                cmd.Parameters.AddWithValue("@Province", province);
                if (dateFrom != 0)
                {
                    cmd.Parameters.AddWithValue("@DateFrom", dateFrom);
                }
                if (dateTo != 0)
                {
                    cmd.Parameters.AddWithValue("@DateTo", dateTo);
                }
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@type", role);
                cmd.Parameters.AddWithValue("@labInstruId", labInstruId);

                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                //cn.Close();
                var testResult = ds.Tables[0].AsEnumerable().Select(
                    dataRow => new ArrayList {
                        dataRow.Field<int>("NotMentionedOnForm"),
                        dataRow.Field<int>("Other"),
                        dataRow.Field<int>("Repeated"),
                        dataRow.Field<int>("Routine"),
                        dataRow.Field<int>("Targeted"),
                        dataRow.Field<int>("VLforPregnantWoman"),
                        dataRow.Field<string>("Lab")
                    }).ToList();
                return testResult;
            }
        }

        public IList GetVLTestByLab(string labCode, int dateFrom, int dateTo, int user_id, string role, int labInstruId)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetVLTestReasonByLab";
                cmd.Parameters.AddWithValue("@LabCode", labCode);
                if (dateFrom != 0)
                {
                    cmd.Parameters.AddWithValue("@DateFrom", dateFrom);
                }
                if (dateTo != 0)
                {
                    cmd.Parameters.AddWithValue("@DateTo", dateTo);
                }
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@type", role);
                cmd.Parameters.AddWithValue("@labInstruId", labInstruId);
                cmd.CommandTimeout = 0;             

                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                cn.Close();
                var testResult = ds.Tables[0].AsEnumerable().Select(
                    dataRow => new ArrayList {
                        dataRow.Field<int>("NotMentionedOnForm"),
                        dataRow.Field<int>("Other"),
                        dataRow.Field<int>("Repeated"),
                        dataRow.Field<int>("Routine"),
                        dataRow.Field<int>("Targeted"),
                        dataRow.Field<int>("VLforPregnantWoman"),
                        dataRow.Field<string>("Lab")
                    }).ToList();
                return testResult;
            }
        }

        public IList GetVLTestAllInstrumentsByLab(int province, int dateFrom, int dateTo, int user_id, string role)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetVLTestReasonAllInstruments";
                cmd.Parameters.AddWithValue("@Province", province);
                if (dateFrom != 0)
                {
                    cmd.Parameters.AddWithValue("@DateFrom", dateFrom);
                }
                if (dateTo != 0)
                {
                    cmd.Parameters.AddWithValue("@DateTo", dateTo);
                }
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@type", role);                

                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                //cn.Close();
                var testResult = ds.Tables[0].AsEnumerable().Select(
                    dataRow => new ArrayList {
                        dataRow.Field<int>("NotMentionedOnForm"),
                        dataRow.Field<int>("Other"),
                        dataRow.Field<int>("Repeated"),
                        dataRow.Field<int>("Routine"),
                        dataRow.Field<int>("Targeted"),
                        dataRow.Field<int>("VLforPregnantWoman"),
                        dataRow.Field<string>("LabInstrumentname")
                    }).ToList();
                return testResult;
            }
        }

        public IList GetVLTestAllInstrumentsByLab(string labCode, int dateFrom, int dateTo, int user_id, string role)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetVLTestReasonAllInstrumentsByLab";
                cmd.Parameters.AddWithValue("@LabCode", labCode);
                if (dateFrom != 0)
                {
                    cmd.Parameters.AddWithValue("@DateFrom", dateFrom);
                }
                if (dateTo != 0)
                {
                    cmd.Parameters.AddWithValue("@DateTo", dateTo);
                }
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@type", role);
                cmd.CommandTimeout = 0;

                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                cn.Close();
                var testResult = ds.Tables[0].AsEnumerable().Select(
                    dataRow => new ArrayList {
                        dataRow.Field<int>("NotMentionedOnForm"),
                        dataRow.Field<int>("Other"),
                        dataRow.Field<int>("Repeated"),
                        dataRow.Field<int>("Routine"),
                        dataRow.Field<int>("Targeted"),
                        dataRow.Field<int>("VLforPregnantWoman"),
                        dataRow.Field<string>("LabInstrumentname")
                    }).ToList();
                return testResult;
            }
        }

        public IList GetVLTurnaroundbyYear(string labCode, int dateFrom, int dateTo, int user_id, string role)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetVLTurnaroundTimebyYear";
                cmd.Parameters.AddWithValue("@LabCode", labCode);
                cmd.Parameters.AddWithValue("@dateFrom", dateFrom);
                cmd.Parameters.AddWithValue("@dateTo", dateTo);
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@type", role);
                // cmd.Parameters.AddWithValue("@Fromdate", datefrom);
                // cmd.Parameters.AddWithValue("@Todate", dateto);
                cmd.CommandTimeout = 0;
                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();                
                da.Fill(ds);
                cn.Close();
                //IList eidEIDTurnaroundbyYear;// = null;
                //if (season == 0)
                //    eidEIDTurnaroundbyYear = ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<int>("Jan"), dataRow.Field<int>("Feb"), dataRow.Field<int>("Mar"), dataRow.Field<int>("Apr"), dataRow.Field<int>("May"), dataRow.Field<int>("Jun"), dataRow.Field<int>("Jul"), dataRow.Field<int>("Aug"), dataRow.Field<int>("Sep"), dataRow.Field<int>("Oct"), dataRow.Field<int>("Nov"), dataRow.Field<int>("Dec"), dataRow.Field<int>("Year") }).ToList();
                //else
                //    eidEIDTurnaroundbyYear = ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<int>("Q1"), dataRow.Field<int>("Q2"), dataRow.Field<int>("Q3"), dataRow.Field<int>("Q4"), dataRow.Field<int>("Year") }).ToList();

                IList eidEIDTurnaroundbyYear = ds.Tables[0].AsEnumerable().Select(
                    dataRow => new ArrayList {
                        dataRow.Field<int>("ToShipmentSpan"), dataRow.Field<int>("ToReceivedSpan"),
                        dataRow.Field<int>("ToTestedSpan"), dataRow.Field<int>("ToDispatchedSpan"),
                    dataRow.Field<int>("YearData")}).ToList();
                return eidEIDTurnaroundbyYear;
            }
        }

        public IList GetVLTurnaroundbyQuarter(string labCode, int dateFrom, int dateTo, int user_id, string role)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetVLTurnaroundTimebyQuarter";
                cmd.Parameters.AddWithValue("@LabCode", labCode);
                cmd.Parameters.AddWithValue("@dateFrom", dateFrom);
                cmd.Parameters.AddWithValue("@dateTo", dateTo);
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@type", role);
                // cmd.Parameters.AddWithValue("@Fromdate", datefrom);
                // cmd.Parameters.AddWithValue("@Todate", dateto);
                cmd.CommandTimeout = 0;
                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                cn.Close();
                //IList eidEIDTurnaroundbyYear;// = null;
                //if (season == 0)
                //    eidEIDTurnaroundbyYear = ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<int>("Jan"), dataRow.Field<int>("Feb"), dataRow.Field<int>("Mar"), dataRow.Field<int>("Apr"), dataRow.Field<int>("May"), dataRow.Field<int>("Jun"), dataRow.Field<int>("Jul"), dataRow.Field<int>("Aug"), dataRow.Field<int>("Sep"), dataRow.Field<int>("Oct"), dataRow.Field<int>("Nov"), dataRow.Field<int>("Dec"), dataRow.Field<int>("Year") }).ToList();
                //else
                //    eidEIDTurnaroundbyYear = ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<int>("Q1"), dataRow.Field<int>("Q2"), dataRow.Field<int>("Q3"), dataRow.Field<int>("Q4"), dataRow.Field<int>("Year") }).ToList();

                IList eidEIDTurnaroundbyYear = ds.Tables[0].AsEnumerable().Select(
                    dataRow => new ArrayList {
                        dataRow.Field<int>("ToShipmentSpan"), dataRow.Field<int>("ToReceivedSpan"),
                        dataRow.Field<int>("ToTestedSpan"), dataRow.Field<int>("ToDispatchedSpan"),
                    dataRow.Field<int>("YearData"), dataRow.Field<string>("ResultData")}).ToList();
                return eidEIDTurnaroundbyYear;
            }
        }
        #endregion

        #region Facilities

        public IList GetVLFacilityTestYearly(int facility, int user_id, string role, string provinceIDs, string facilityTypes)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetVLFacilityTestYearly";
                cmd.Parameters.AddWithValue("@facility", facility);
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@type", role);
                cmd.Parameters.AddWithValue("@provinceIDs", provinceIDs);
                cmd.Parameters.AddWithValue("@facilityTypes", facilityTypes);

                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                //cn.Close();
                var testResult = ds.Tables[0].AsEnumerable().Select(
                    dataRow => new ArrayList {
                        dataRow.Field<int>("LE_1000"),
                        dataRow.Field<int>("G_1000"),
                        dataRow.Field<decimal>("Suppression_Rate"),
                        dataRow.Field<int>("ResultDate") }).ToList();
                return testResult;
            }
        }

        public IList GetVLFacilityTestQuarterly(int facility, int dateFrom, int dateTo, int user_id, string role, string provinceIDs, string facilityTypes)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetVLFacilityTestQuarterly";
                cmd.Parameters.AddWithValue("@facility", facility);
                if (dateFrom != 0)
                {
                    cmd.Parameters.AddWithValue("@DateFrom", dateFrom);
                }
                if (dateTo != 0)
                {
                    cmd.Parameters.AddWithValue("@DateTo", dateTo);
                }
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@type", role);
                cmd.Parameters.AddWithValue("@provinceIDs", provinceIDs);
                cmd.Parameters.AddWithValue("@facilityTypes", facilityTypes);

                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                //cn.Close();

                var testResult = ds.Tables[0].AsEnumerable().Select(
                    dataRow => new ArrayList {
                        dataRow.Field<int>("LE_1000"),
                        dataRow.Field<int>("G_1000"),
                        dataRow.Field<decimal>("Suppression_Rate"),
                        dataRow.Field<string>("ResultDate") }).ToList();
                return testResult;
            }
        }

        public IList GetVLFacilityTestMonthly(int facility, int dateFrom, int dateTo, int user_id, string role, string provinceIDs, string facilityTypes)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetVLFacilityTestMonthly";
                cmd.Parameters.AddWithValue("@facility", facility);
                if (dateFrom != 0)
                {
                    cmd.Parameters.AddWithValue("@DateFrom", dateFrom);
                }
                if (dateTo != 0)
                {
                    cmd.Parameters.AddWithValue("@DateTo", dateTo);
                }
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@type", role);
                cmd.Parameters.AddWithValue("@provinceIDs", provinceIDs);
                cmd.Parameters.AddWithValue("@facilityTypes", facilityTypes);

                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                //cn.Close();
                var testResult = ds.Tables[0].AsEnumerable().Select(
                    dataRow => new ArrayList {
                        dataRow.Field<int>("LE_1000"),
                        dataRow.Field<int>("G_1000"),
                        dataRow.Field<decimal>("Suppression_Rate"),
                        dataRow.Field<string>("ResultDate") }).ToList();
                return testResult;
            }
        }

        public IList GetVLFacilityTestByAgeYearly(int facility, int dateFrom, int dateTo, int user_id, string role, string provinceIDs, string facilityTypes)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetVLFacilityTestByAgeOutcome";
                cmd.Parameters.AddWithValue("@facility", facility);
                if (dateFrom != 0)
                {
                    cmd.Parameters.AddWithValue("@DateFrom", dateFrom);
                }
                if (dateTo != 0)
                {
                    cmd.Parameters.AddWithValue("@DateTo", dateTo);
                }
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@type", role);
                cmd.Parameters.AddWithValue("@provinceIDs", provinceIDs);
                cmd.Parameters.AddWithValue("@facilityTypes", facilityTypes);

                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                //cn.Close();
                var testResult = ds.Tables[0].AsEnumerable().Select(
                    dataRow => new ArrayList {
                        dataRow.Field<int>("LE_1000"),
                        dataRow.Field<int>("G_1000"),
                        dataRow.Field<decimal>("Suppression_Rate"),
                        dataRow.Field<string>("Age_Range")
                        //,dataRow.Field<int>("ResultDate")
                    }).ToList();
                return testResult;
            }
        }

        public IList GetVLFacilityTestByGenderOutcome(int facility, int dateFrom, int dateTo, int user_id, string role, string provinceIDs, string facilityTypes)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetVLFacilityTestByGenderOutcome";
                cmd.Parameters.AddWithValue("@facility", facility);
                if (dateFrom != 0)
                {
                    cmd.Parameters.AddWithValue("@DateFrom", dateFrom);
                }
                if (dateTo != 0)
                {
                    cmd.Parameters.AddWithValue("@DateTo", dateTo);
                }
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@type", role);
                cmd.Parameters.AddWithValue("@provinceIDs", provinceIDs);
                cmd.Parameters.AddWithValue("@facilityTypes", facilityTypes);

                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                //cn.Close();
                var testResult = ds.Tables[0].AsEnumerable().Select(
                    dataRow => new ArrayList {
                        dataRow.Field<int>("LE_1000"),
                        dataRow.Field<int>("G_1000"),
                        dataRow.Field<decimal>("Suppression_Rate"),
                        dataRow.Field<string>("Sex")
                    }).ToList();
                return testResult;
            }
        }

        public IList GetVLFacilityTestByProvince(int facility, int dateFrom, int dateTo, int user_id, string role, string provinceIDs, string facilityTypes)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetVLFacilityTest";
                cmd.Parameters.AddWithValue("@facility", facility);
                if (dateFrom != 0)
                {
                    cmd.Parameters.AddWithValue("@DateFrom", dateFrom);
                }
                if (dateTo != 0)
                {
                    cmd.Parameters.AddWithValue("@DateTo", dateTo);
                }
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@type", role);
                cmd.Parameters.AddWithValue("@provinceIDs", provinceIDs);
                cmd.Parameters.AddWithValue("@facilityTypes", facilityTypes);

                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                //cn.Close();
                var testResult = ds.Tables[0].AsEnumerable().Select(
                    dataRow => new ArrayList {
                        dataRow.Field<int>("LE_1000"),
                        dataRow.Field<int>("G_1000"),
                        dataRow.Field<decimal>("Suppression_Rate"),
                        dataRow.Field<string>("Name")
                    }).ToList();
                return testResult;
            }
        }

        public VLStat VLFacilitySummaryStat(string dateFrom, string dateTo, int facility, int user_id, string role, string provinceIDs, string facilityTypes)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetVLFacilitySummaryStat";
                cmd.Parameters.AddWithValue("@Facility", facility);
                if (dateFrom != "")
                {
                    cmd.Parameters.AddWithValue("@DateFrom", dateFrom);
                }
                if (dateTo != "")
                {
                    cmd.Parameters.AddWithValue("@DateTo", dateTo);
                }
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@type", role);
                cmd.Parameters.AddWithValue("@provinceIDs", provinceIDs);
                cmd.Parameters.AddWithValue("@facilityTypes", facilityTypes);

                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                //cn.Close();
                VLStat vl = new VLStat();
                vl.Tot_Tests = ds.Tables[0].Rows[0].Field<int>("Tot_Tests");
                vl.RejectedSamples = ds.Tables[0].Rows[0].Field<decimal>("RejectedSamples");
                vl.Tot_Detected_LE_1000 = ds.Tables[0].Rows[0].Field<int>("Tot_Detected_LE_1000");
                vl.Tot_Detected_G_1000 = ds.Tables[0].Rows[0].Field<int>("Tot_Detected_G_1000");
                vl.Total_Suppressed = ds.Tables[0].Rows[0].Field<decimal>("Total_Suppressed");
                vl.Rate_Detected_LE_1000 = ds.Tables[0].Rows[0].Field<decimal>("Rate_Detected_LE_1000");
                vl.Rate_Detected_G_1000 = ds.Tables[0].Rows[0].Field<decimal>("Rate_Detected_G_1000");
                vl.Rate_Error = ds.Tables[0].Rows[0].Field<decimal>("Rate_Error");
                vl.Error = ds.Tables[0].Rows[0].Field<int>("Invalid_Error_Noresult");

                //ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<int>("Tot_Tests"), dataRow.Field<decimal>("RejectedSamples"), dataRow.Field<int>("Tot_Detected_LE_1000"), dataRow.Field<int>("Tot_Detected_G_1000"), dataRow.Field<decimal>("Total_Suppressed"), dataRow.Field<int>("Invalid_Error_Noresult") }).ToList();
                return vl;
            }
        }

        public IList GetVLFacilitySummary(int facility, int dateFrom, int dateTo, int user_id, string role, string provinceIDs, string facilityTypes)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetVLFacilitySummary";
                cmd.Parameters.AddWithValue("@facility", facility);
                cmd.Parameters.AddWithValue("@dateFrom", dateFrom);
                cmd.Parameters.AddWithValue("@dateTo", dateTo);
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@type", role);
                cmd.Parameters.AddWithValue("@provinceIDs", provinceIDs);
                cmd.Parameters.AddWithValue("@facilityTypes", facilityTypes);
                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                //cn.Close();
                var eidIntialPCRbyYear = ds.Tables[0].AsEnumerable().Select(
                    dataRow => new ArrayList {
                        dataRow.Field<int>("Total_Received"),
                        dataRow.Field<int>("Total_Tested"),
                        dataRow.Field<int>("Not_Suppressed"),
                        dataRow.Field<int>("Suppressed"),
                        dataRow.Field<int>("LDL"),
                        dataRow.Field<int>("Rejected"),
                        dataRow.Field<decimal>("Rejected_Rate"),
                        dataRow.Field<int>("Error")
                    }).ToList();
                return eidIntialPCRbyYear;
            }
        }

        public IList GetVLTestAgeGroupByProvince(int province, int dateFrom, int dateTo, int user_id, string role)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetVLTestByAgeGroup";
                cmd.Parameters.AddWithValue("@prov", province);
                if (dateFrom != 0)
                {
                    cmd.Parameters.AddWithValue("@DateFrom", dateFrom);
                }
                if (dateTo != 0)
                {
                    cmd.Parameters.AddWithValue("@DateTo", dateTo);
                }
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@type", role);

                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                //cn.Close();
                var testResult = ds.Tables[0].AsEnumerable().Select(
                    dataRow => new ArrayList {
                        dataRow.Field<int>("LE_1000"),
                        dataRow.Field<int>("G_1000"),
                        dataRow.Field<decimal>("Suppression_Rate"),
                        dataRow.Field<string>("Age_Range"),
                        //dataRow.Field<string>("Name")
                    }).ToList();
                return testResult;
            }
        }

        public IList GetVLTestAgeGroupByProvinceForLab(string labCode, int dateFrom, int dateTo, int user_id, string role)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetVLTestByAgeGroupForLab";
                cmd.Parameters.AddWithValue("@LabCode", labCode);
                if (dateFrom != 0)
                {
                    cmd.Parameters.AddWithValue("@DateFrom", dateFrom);
                }
                if (dateTo != 0)
                {
                    cmd.Parameters.AddWithValue("@DateTo", dateTo);
                }
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@type", role);

                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                //cn.Close();
                var testResult = ds.Tables[0].AsEnumerable().Select(
                    dataRow => new ArrayList {
                        dataRow.Field<int>("LE_1000"),
                        dataRow.Field<int>("G_1000"),
                        dataRow.Field<decimal>("Suppression_Rate"),
                        dataRow.Field<string>("Age_Range"),
                        //dataRow.Field<string>("Name")
                    }).ToList();
                return testResult;
            }
        }

        public IList GetVLTestAgeGroupByProvinceForFacility(int facility, int dateFrom, int dateTo, int user_id, string role, string provinceIDs, string facilityTypes)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetVLTestByAgeGroupForFacility";
                cmd.Parameters.AddWithValue("@facility", facility);
                if (dateFrom != 0)
                {
                    cmd.Parameters.AddWithValue("@DateFrom", dateFrom);
                }
                if (dateTo != 0)
                {
                    cmd.Parameters.AddWithValue("@DateTo", dateTo);
                }
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@type", role);
                cmd.Parameters.AddWithValue("@provinceIDs", provinceIDs);
                cmd.Parameters.AddWithValue("@facilityTypes", facilityTypes);

                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                //cn.Close();
                var testResult = ds.Tables[0].AsEnumerable().Select(
                    dataRow => new ArrayList {
                        dataRow.Field<int>("LE_1000"),
                        dataRow.Field<int>("G_1000"),
                        dataRow.Field<decimal>("Suppression_Rate"),
                        dataRow.Field<string>("Age_Range"),
                        //dataRow.Field<string>("Name")
                    }).ToList();
                return testResult;
            }
        }

        public IList GetVLTestRejectByProvince(int province, int dateFrom, int dateTo, int user_id, string role)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetVLTestRejectByProvince";
                cmd.Parameters.AddWithValue("@prov", province);
                if (dateFrom != 0)
                {
                    cmd.Parameters.AddWithValue("@DateFrom", dateFrom);
                }
                if (dateTo != 0)
                {
                    cmd.Parameters.AddWithValue("@DateTo", dateTo);
                }
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@type", role);

                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                //cn.Close();
                var testResult = ds.Tables[0].AsEnumerable().Select(
                    dataRow => new ArrayList {
                        dataRow.Field<int>("Tot_Received"),
                        dataRow.Field<int>("Tot_Rejected"),
                        dataRow.Field<decimal>("Rejected_Rate"),
                        dataRow.Field<string>("Name")
                    }).ToList();
                return testResult;
            }
        }

        public IList GetVLTestRejectByProvinceForLab(string labCode, int dateFrom, int dateTo, int user_id, string role)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetVLTestRejectByProvinceForLab";                
                cmd.Parameters.AddWithValue("@LabCode", labCode);
                if (dateFrom != 0)
                {
                    cmd.Parameters.AddWithValue("@DateFrom", dateFrom);
                }
                if (dateTo != 0)
                {
                    cmd.Parameters.AddWithValue("@DateTo", dateTo);
                }
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@type", role);
                cmd.CommandTimeout = 0;

                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                cn.Close();
                var testResult = ds.Tables[0].AsEnumerable().Select(
                    dataRow => new ArrayList {
                        dataRow.Field<int>("Tot_Received"),
                        dataRow.Field<int>("Tot_Rejected"),
                        dataRow.Field<decimal>("Rejected_Rate"),
                        dataRow.Field<string>("Name")
                    }).ToList();
                return testResult;
            }
        }

        public IList GetVLTestRejectByProvinceForFacility(int facility, int dateFrom, int dateTo, int user_id, string role, string provinceIDs, string facilityTypes)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetVLTestRejectByProvinceForFacility";
                cmd.Parameters.AddWithValue("@facility", facility);
                if (dateFrom != 0)
                {
                    cmd.Parameters.AddWithValue("@DateFrom", dateFrom);
                }
                if (dateTo != 0)
                {
                    cmd.Parameters.AddWithValue("@DateTo", dateTo);
                }
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@type", role);
                cmd.Parameters.AddWithValue("@provinceIDs", provinceIDs);
                cmd.Parameters.AddWithValue("@facilityTypes", facilityTypes);

                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                //cn.Close();
                var testResult = ds.Tables[0].AsEnumerable().Select(
                    dataRow => new ArrayList {
                        dataRow.Field<int>("Tot_Received"),
                        dataRow.Field<int>("Tot_Rejected"),
                        dataRow.Field<decimal>("Rejected_Rate"),
                        dataRow.Field<string>("Name")
                    }).ToList();
                return testResult;
            }
        }

        // VL Sample Drainage by Lab
        public IList GetVLTestLabAndFacility(int facility, int dateFrom, int dateTo, int user_id, string role, string provinceIDs, string facilityTypes)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetVLTestLabAndFacility";
                cmd.Parameters.AddWithValue("@facility", facility);
                if (dateFrom != 0)
                {
                    cmd.Parameters.AddWithValue("@DateFrom", dateFrom);
                }
                if (dateTo != 0)
                {
                    cmd.Parameters.AddWithValue("@DateTo", dateTo);
                }
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@type", role);
                cmd.Parameters.AddWithValue("@provinceIDs", provinceIDs);
                cmd.Parameters.AddWithValue("@facilityTypes", facilityTypes);

                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                //cn.Close();
                var testResult = ds.Tables[0].AsEnumerable().Select(
                    dataRow => new ArrayList {
                        dataRow.Field<int>("TotalValidTest"),
                        dataRow.Field<int>("LabId"),
                        dataRow.Field<string>("LaboratoryName"),                        
                        dataRow.Field<string>("FacilityName"),
                        dataRow.Field<int>("FacilityId"),
                        dataRow.Field<string>("ProvinceName"),
                        dataRow.Field<int>("ProvinceId"),
                    }).ToList();
                return testResult;
            }
        }

        #endregion
    }
}
