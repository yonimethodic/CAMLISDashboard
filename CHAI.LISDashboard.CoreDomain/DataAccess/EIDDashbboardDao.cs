using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using CHAI.LISDashboard.Shared;
using System.Configuration;
using CHAI.LISDashboard.CoreDomain.Setting;
using CHAI.LISDashboard.CoreDomain.Report;
using CHAI.LISDashboard.Shared.Settings;

namespace CHAI.LISDashboard.CoreDomain.DataAccess
{
    public class EIDDashboardDao
    {
        public IList GetEIDIntialPCRbyProvince(int province, DateTime datefrom, DateTime dateto)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetEIDIntialPCRbyProvince";
                cmd.Parameters.AddWithValue("@prov", province);
                cmd.Parameters.AddWithValue("@Fromdate", datefrom);
                cmd.Parameters.AddWithValue("@Todate", dateto);
                cmd.CommandTimeout = 0;
                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                cn.Close();
                var eidIntialPCR = ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<int>("No_Positive"), dataRow.Field<int>("No_Negative"), dataRow.Field<decimal>("Positivity"), dataRow.Field<string>("Location") }).ToList();
                return eidIntialPCR;
            }
        }
        public IList GetEIDIntialPCR(int province, DateTime datefrom, DateTime dateto)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetEIDIntialPCR";
                cmd.Parameters.AddWithValue("@prov", province);
                cmd.Parameters.AddWithValue("@Fromdate", datefrom);
                cmd.Parameters.AddWithValue("@Todate", dateto);
                cmd.CommandTimeout = 0;
                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                cn.Close();
                var eidIntialPCR = ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<int>("No_Positive"), dataRow.Field<int>("No_Negative"), dataRow.Field<decimal>("Positivity"), dataRow.Field<string>("ResultDate") }).ToList();
                return eidIntialPCR;
            }
        }

        public IList GetEIDOutcomes(int province, DateTime datefrom, DateTime dateto)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetEIDOutcomes";
                cmd.Parameters.AddWithValue("@prov", province);
                cmd.Parameters.AddWithValue("@Fromdate", datefrom);
                cmd.Parameters.AddWithValue("@Todate", dateto);
                cmd.CommandTimeout = 0;
                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                cn.Close();
                var eidOutcomes = ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<int>("No_Positive"), dataRow.Field<int>("No_Negative") }).ToList();
                return eidOutcomes;
            }
        }

        public IList GetEIDModeofDelivery(int province, DateTime datefrom, DateTime dateto)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetEIDModeofDelivery";
                cmd.Parameters.AddWithValue("@prov", province);
                cmd.Parameters.AddWithValue("@Fromdate", datefrom);
                cmd.Parameters.AddWithValue("@Todate", dateto);
                cmd.CommandTimeout = 0;
                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                cn.Close();

                var eidModeofDelivery = ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<int>("No_Positive"), dataRow.Field<int>("No_Negative"), dataRow.Field<string>("ModeOfDelivery") }).ToList();
                return eidModeofDelivery;
            }
        }

        public IList GetEIDOutcomesbyAge(int province, DateTime datefrom, DateTime dateto)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetEIDOutcomesbyAge";
                cmd.Parameters.AddWithValue("@prov", province);
                cmd.Parameters.AddWithValue("@Fromdate", datefrom);
                cmd.Parameters.AddWithValue("@Todate", dateto);
                cmd.CommandTimeout = 0;
                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                cn.Close();
                //var eidOutcomesbyAge =  ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<int>("No_Positive"), dataRow.Field<int>("No_Negative"), dataRow.Field<int>("< 2 Month"), dataRow.Field<int>("2-9 Month"), dataRow.Field<int>("9-12 Month"), dataRow.Field<int>("12-24 Month"), dataRow.Field<int>(">24 Month"), dataRow.Field<int>("Year"), dataRow.Field<string>("Month") }).ToList();
                var eidOutcomesbyAge = ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<int>("No_Positive"), dataRow.Field<int>("No_Negative"), dataRow.Field<string>("Age") }).ToList();
                return eidOutcomesbyAge;
            }
        }

        public IList GetInfantFeeding(int province, DateTime datefrom, DateTime dateto)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetEIDInfantFeeding";
                cmd.Parameters.AddWithValue("@prov", province);
                cmd.Parameters.AddWithValue("@Fromdate", datefrom);
                cmd.Parameters.AddWithValue("@Todate", dateto);
                cmd.CommandTimeout = 0;
                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                cn.Close();
                //var eidOutcomesbyAge =  ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<int>("No_Positive"), dataRow.Field<int>("No_Negative"), dataRow.Field<int>("< 2 Month"), dataRow.Field<int>("2-9 Month"), dataRow.Field<int>("9-12 Month"), dataRow.Field<int>("12-24 Month"), dataRow.Field<int>(">24 Month"), dataRow.Field<int>("Year"), dataRow.Field<string>("Month") }).ToList();
                var eidInfantFeeding = ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<int>("No_Positive"), dataRow.Field<int>("Tested"), dataRow.Field<string>("InfantFeeding") }).ToList();
                return eidInfantFeeding;
            }
        }

        //Trend
        //EID Testing Trend Yearly
        public IList GetEIDIntialPCRbyYear(int province, int user_id, string role)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetEIDIntialPCRbyYear";
                cmd.Parameters.AddWithValue("@prov", province);
                // cmd.Parameters.AddWithValue("@Fromdate", datefrom);
                // cmd.Parameters.AddWithValue("@Todate", dateto);
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@type", role);
                cmd.CommandTimeout = 0;
                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                cn.Close();
                var eidIntialPCRbyYear = ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<int>("No_Positive"), dataRow.Field<int>("No_Negative"), dataRow.Field<decimal>("Positivity"), dataRow.Field<int>("ResultDate") }).ToList();
                return eidIntialPCRbyYear;
            }
        }

        public IList GetEIDIntialPCRbyYearForLab(string labCode, int dateFrom, int dateTo, int user_id, string role)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetEIDIntialPCRbyYearForLab";
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
                var eidIntialPCRbyYear = ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<int>("No_Positive"), dataRow.Field<int>("No_Negative"), dataRow.Field<decimal>("Positivity"), dataRow.Field<int>("ResultDate") }).ToList();
                return eidIntialPCRbyYear;
            }
        }

        //EID Testing Trend Quarterly
        public IList GetEIDIntialPCRbyQuarter(int province, int dateFrom, int dateTo, int user_id, string role)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetEIDIntialPCRbyQuarter";
                cmd.Parameters.AddWithValue("@prov", province);
                cmd.Parameters.AddWithValue("@dateFrom", dateFrom);
                cmd.Parameters.AddWithValue("@dateTo", dateTo);
                // cmd.Parameters.AddWithValue("@Fromdate", datefrom);
                // cmd.Parameters.AddWithValue("@Todate", dateto);
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@type", role);
                cmd.CommandTimeout = 0;
                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                cn.Close();
                var eidIntialPCRbyYear = ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<int>("No_Positive"), dataRow.Field<int>("No_Negative"), dataRow.Field<decimal>("Positivity"), dataRow.Field<string>("ResultDate") }).ToList();
                return eidIntialPCRbyYear;
            }
        }

        public IList GetEIDIntialPCRbyQuarterForLab(string labCode, int dateFrom, int dateTo, int user_id, string role)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetEIDIntialPCRbyQuarterForLab";
                cmd.Parameters.AddWithValue("@LabCode", labCode);
                cmd.Parameters.AddWithValue("@dateFrom", dateFrom);
                cmd.Parameters.AddWithValue("@dateTo", dateTo);
                // cmd.Parameters.AddWithValue("@Fromdate", datefrom);
                // cmd.Parameters.AddWithValue("@Todate", dateto);
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@type", role);
                cmd.CommandTimeout = 0;
                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                cn.Close();
                var eidIntialPCRbyYear = ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<int>("No_Positive"), dataRow.Field<int>("No_Negative"), dataRow.Field<decimal>("Positivity"), dataRow.Field<string>("ResultDate") }).ToList();
                return eidIntialPCRbyYear;
            }
        }

        //Added by Zay Soe on 9_Jan_2019
        //EID Testing Trend Monthly
        public IList GetEIDIntialPCRbyMonth(int province, int dateFrom, int dateTo, int user_id, string role)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetEIDIntialPCRbyMonth";
                cmd.Parameters.AddWithValue("@prov", province);
                cmd.Parameters.AddWithValue("@dateFrom", dateFrom);
                cmd.Parameters.AddWithValue("@dateTo", dateTo);
                // cmd.Parameters.AddWithValue("@Fromdate", datefrom);
                // cmd.Parameters.AddWithValue("@Todate", dateto);
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@type", role);
                cmd.CommandTimeout = 0;
                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                cn.Close();
                var eidIntialPCRbyYear = ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<int>("No_Positive"), dataRow.Field<int>("No_Negative"), dataRow.Field<decimal>("Positivity"), dataRow.Field<string>("ResultDate") }).ToList();
                return eidIntialPCRbyYear;
            }
        }

        public IList GetEIDIntialPCRbyMonthForLab(string labCode, int dateFrom, int dateTo, int user_id, string role)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetEIDIntialPCRbyMonthForLab";
                cmd.Parameters.AddWithValue("@LabCode", labCode);
                cmd.Parameters.AddWithValue("@dateFrom", dateFrom);
                cmd.Parameters.AddWithValue("@dateTo", dateTo);
                // cmd.Parameters.AddWithValue("@Fromdate", datefrom);
                // cmd.Parameters.AddWithValue("@Todate", dateto);
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@type", role);
                cmd.CommandTimeout = 0;
                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                cn.Close();
                var eidIntialPCRbyYear = ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<int>("No_Positive"), dataRow.Field<int>("No_Negative"), dataRow.Field<decimal>("Positivity"), dataRow.Field<string>("ResultDate") }).ToList();
                return eidIntialPCRbyYear;
            }
        }

        public IList GetEIDAllTestInfant2MbyYear(int province)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetEIDAllTestInfant2MbyYearQ";
                cmd.Parameters.AddWithValue("@prov", province);
                // cmd.Parameters.AddWithValue("@Fromdate", datefrom);
                // cmd.Parameters.AddWithValue("@Todate", dateto);
                cmd.CommandTimeout = 0;
                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                cn.Close();
                var eidIntialPCRbyYear = ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<int>("No_Positive"), dataRow.Field<int>("No_Negative"), dataRow.Field<decimal>("Positivity"), dataRow.Field<string>("ResultDate") }).ToList();
                return eidIntialPCRbyYear;
            }
        }

        public IList GetEIDIntialPCRAgeYear(int province)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetEIDOutcomesbyAgeYearQ";
                cmd.Parameters.AddWithValue("@prov", province);
                // cmd.Parameters.AddWithValue("@Fromdate", datefrom);
                // cmd.Parameters.AddWithValue("@Todate", dateto);
                cmd.CommandTimeout = 0;
                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                cn.Close();
                var eidIntialPCRbyAgeYear = ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<int>("less2month"), dataRow.Field<int>("between2and9month"), dataRow.Field<int>("between9and12month"), dataRow.Field<int>("between12and24month"), dataRow.Field<int>("greaterthan24month"), dataRow.Field<int>("NoData"), dataRow.Field<decimal>("less2monthContribution"), dataRow.Field<string>("ResultDate") }).ToList();
                return eidIntialPCRbyAgeYear;
            }
        }

        //Added by ZaySoe on 09_Jan_2019
        //EID Age Group by Yearly
        public IList GetEIDIntialPCRAgeByYearly(int province, int user_id, string role)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetEIDInitialPCRAgeByYearly";
                cmd.Parameters.AddWithValue("@prov", province);
                // cmd.Parameters.AddWithValue("@Fromdate", datefrom);
                // cmd.Parameters.AddWithValue("@Todate", dateto);
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@type", role);
                cmd.CommandTimeout = 0;
                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                cn.Close();
                var eidIntialPCRbyAgeYear = ds.Tables[0].AsEnumerable().Select(
                    dataRow => new ArrayList {
                        dataRow.Field<int>("nodata"),
                        dataRow.Field<int>("less2month"),
                        dataRow.Field<int>("between2and6month"),
                        dataRow.Field<int>("between6and9month"),
                        dataRow.Field<int>("between9and18month"),
                        dataRow.Field<int>("greaterthan18month"),
                        //dataRow.Field<int>("NoData"),
                        dataRow.Field<decimal>("lessthan_2months_rate"),
                        dataRow.Field<int>("ResultDate") }).ToList();
                return eidIntialPCRbyAgeYear;
            }
        }

        public IList GetEIDIntialPCRAgeByYearForLab(string labCode, int dateFrom, int dateTo, int user_id, string role)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetEIDInitialPCRAgeByYearForLab";
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
                var eidIntialPCRbyAgeYear = ds.Tables[0].AsEnumerable().Select(
                    dataRow => new ArrayList {
                        dataRow.Field<int>("nodata"),
                        dataRow.Field<int>("less2month"),
                        dataRow.Field<int>("between2and6month"),
                        dataRow.Field<int>("between6and9month"),
                        dataRow.Field<int>("between9and18month"),
                        dataRow.Field<int>("greaterthan18month"),
                        //dataRow.Field<int>("NoData"),
                        dataRow.Field<decimal>("lessthan_2months_rate"),
                        dataRow.Field<int>("ResultDate") }).ToList();
                return eidIntialPCRbyAgeYear;
            }
        }

        //EID Age Group by Quarterly
        public IList GetEIDIntialPCRAgeByQuarterly(int province, int dateFrom, int dateTo, int user_id, string role)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetEIDInitialPCRAgeByQuarterly";
                cmd.Parameters.AddWithValue("@prov", province);
                cmd.Parameters.AddWithValue("@dateFrom", dateFrom);
                cmd.Parameters.AddWithValue("@dateTo", dateTo);
                // cmd.Parameters.AddWithValue("@Fromdate", datefrom);
                // cmd.Parameters.AddWithValue("@Todate", dateto);
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@type", role);
                cmd.CommandTimeout = 0;
                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                cn.Close();
                var eidIntialPCRbyAgeYear = ds.Tables[0].AsEnumerable().Select(
                    dataRow => new ArrayList {
                        dataRow.Field<int>("nodata"),
                        dataRow.Field<int>("less2month"),
                        dataRow.Field<int>("between2and6month"),
                        dataRow.Field<int>("between6and9month"),
                        dataRow.Field<int>("between9and18month"),
                        dataRow.Field<int>("greaterthan18month"),
                        //dataRow.Field<int>("NoData"),
                        dataRow.Field<decimal>("lessthan_2months_rate"),
                        dataRow.Field<string>("ResultDate") }).ToList();
                return eidIntialPCRbyAgeYear;
            }
        }

        public IList GetEIDIntialPCRAgeByQuarterForLab(string labCode, int dateFrom, int dateTo, int user_id, string role)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetEIDInitialPCRAgeByQuarterForLab";
                cmd.Parameters.AddWithValue("@LabCode", labCode);
                cmd.Parameters.AddWithValue("@dateFrom", dateFrom);
                cmd.Parameters.AddWithValue("@dateTo", dateTo);
                // cmd.Parameters.AddWithValue("@Fromdate", datefrom);
                // cmd.Parameters.AddWithValue("@Todate", dateto);
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@type", role);
                cmd.CommandTimeout = 0;
                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                cn.Close();
                var eidIntialPCRbyAgeYear = ds.Tables[0].AsEnumerable().Select(
                    dataRow => new ArrayList {
                        dataRow.Field<int>("nodata"),
                        dataRow.Field<int>("less2month"),
                        dataRow.Field<int>("between2and6month"),
                        dataRow.Field<int>("between6and9month"),
                        dataRow.Field<int>("between9and18month"),
                        dataRow.Field<int>("greaterthan18month"),
                        //dataRow.Field<int>("NoData"),
                        dataRow.Field<decimal>("lessthan_2months_rate"),
                        dataRow.Field<string>("ResultDate") }).ToList();
                return eidIntialPCRbyAgeYear;
            }
        }

        //EID Age Group by Monthly
        public IList GetEIDIntialPCRAgeByMonthly(int province, int dateFrom, int dateTo, int user_id, string role)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetEIDInitialPCRAgeByMonthly";
                cmd.Parameters.AddWithValue("@prov", province);
                cmd.Parameters.AddWithValue("@dateFrom", dateFrom);
                cmd.Parameters.AddWithValue("@dateTo", dateTo);
                // cmd.Parameters.AddWithValue("@Fromdate", datefrom);
                // cmd.Parameters.AddWithValue("@Todate", dateto);
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@type", role);
                cmd.CommandTimeout = 0;
                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                cn.Close();
                var eidIntialPCRbyAgeYear = ds.Tables[0].AsEnumerable().Select(
                    dataRow => new ArrayList {
                        dataRow.Field<int>("nodata"),
                        dataRow.Field<int>("less2month"),
                        dataRow.Field<int>("between2and6month"),
                        dataRow.Field<int>("between6and9month"),
                        dataRow.Field<int>("between9and18month"),
                        dataRow.Field<int>("greaterthan18month"),
                        //dataRow.Field<int>("NoData"),
                        dataRow.Field<decimal>("lessthan_2months_rate"),
                        dataRow.Field<string>("ResultDate") }).ToList();
                return eidIntialPCRbyAgeYear;
            }
        }

        public IList GetEIDIntialPCRAgeByMonthForLab(string labCode, int dateFrom, int dateTo, int user_id, string role)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetEIDInitialPCRAgeByMonthForLab";
                cmd.Parameters.AddWithValue("@LabCode", labCode);
                cmd.Parameters.AddWithValue("@dateFrom", dateFrom);
                cmd.Parameters.AddWithValue("@dateTo", dateTo);
                // cmd.Parameters.AddWithValue("@Fromdate", datefrom);
                // cmd.Parameters.AddWithValue("@Todate", dateto);
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@type", role);
                cmd.CommandTimeout = 0;
                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                cn.Close();
                var eidIntialPCRbyAgeYear = ds.Tables[0].AsEnumerable().Select(
                    dataRow => new ArrayList {
                        dataRow.Field<int>("nodata"),
                        dataRow.Field<int>("less2month"),
                        dataRow.Field<int>("between2and6month"),
                        dataRow.Field<int>("between6and9month"),
                        dataRow.Field<int>("between9and18month"),
                        dataRow.Field<int>("greaterthan18month"),
                        //dataRow.Field<int>("NoData"),
                        dataRow.Field<decimal>("lessthan_2months_rate"),
                        dataRow.Field<string>("ResultDate") }).ToList();
                return eidIntialPCRbyAgeYear;
            }
        }

        public IList GetEIDPCRbyFacility(int province, int dateFrom, int dateTo, int user_id, string role)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetEIDPCRbyFacility";
                cmd.Parameters.AddWithValue("@prov", province);
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
                        dataRow.Field<int>("Total_Tested"),
                        dataRow.Field<int>("No_Positive"),
                        //dataRow.Field<int>("No_Negative"),
                        //dataRow.Field<int>("less2month_positive"),
                        //dataRow.Field<int>("less2month_initial_positive"),
                        dataRow.Field<decimal>("Positivity"),
                        dataRow.Field<decimal>("Less2month_Rate"),
                        dataRow.Field<string>("Name") }).ToList();
                return eidIntialPCRbyYear;
            }
        }

        public IList GetEIDPCRbyFacilityForLab(string labCode, int dateFrom, int dateTo, int user_id, string role)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetEIDPCRbyFacilityForLab";
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
                        dataRow.Field<int>("Total_Tested"),
                        dataRow.Field<int>("No_Positive"),
                        //dataRow.Field<int>("No_Negative"),
                        //dataRow.Field<int>("less2month_positive"),
                        //dataRow.Field<int>("less2month_initial_positive"),
                        dataRow.Field<decimal>("Positivity"),
                        dataRow.Field<decimal>("Less2month_Rate"),
                        dataRow.Field<string>("Name") }).ToList();
                return eidIntialPCRbyYear;
            }
        }

        // Added by Zay Soe on 30_Jan_2019
        public IList GetEIDLabByLabInstrument(int province, int dateFrom, int dateTo, int user_id, string role, int labInstruId)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetEIDLabByLabInstrument";
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

        public IList GetEIDLabByLabInstrumentForLab(string labCode, int dateFrom, int dateTo, int user_id, string role, int labInstruId)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetEIDLabByLabInstrumentForLab";
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

        public IList GetEIDLabByLabInstrumentComparison(int province, int dateFrom, int dateTo, int user_id, string role)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetEIDLabByLabInstrumentComparison";
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

        public IList GetEIDLabByLabInstrumentComparisonForLab(string labCode, int dateFrom, int dateTo, int user_id, string role)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetEIDLabByLabInstrumentComparisonForLab";
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

        public IList GetEIDTestByLab(int province, int dateFrom, int dateTo, int user_id, string role, int labInstruId)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetEIDTestReason";
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
                cmd.Parameters.AddWithValue("@labInstruId", labInstruId);
                cmd.CommandTimeout = 0;
                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                cn.Close();
                var testResult = ds.Tables[0].AsEnumerable().Select(
                    dataRow => new ArrayList {
                        //dataRow.Field<int>("NotMentionedOnForm"),
                        //dataRow.Field<int>("Other"),
                        //dataRow.Field<int>("Repeated"),
                        //dataRow.Field<int>("Routine"),
                        //dataRow.Field<int>("Targeted"),
                        //dataRow.Field<int>("VLforPregnantWoman"),
                        dataRow.Field<int>("InitialFirstTime"),
                        dataRow.Field<int>("RepeatConfirmatory"),
                        dataRow.Field<string>("Lab")
                    }).ToList();
                return testResult;
            }
        }

        public IList GetEIDTestByLab(string labCode, int dateFrom, int dateTo, int user_id, string role, int labInstruId)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetEIDTestReasonByLab";
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
                        //dataRow.Field<int>("NotMentionedOnForm"),
                        //dataRow.Field<int>("Other"),
                        //dataRow.Field<int>("Repeated"),
                        //dataRow.Field<int>("Routine"),
                        //dataRow.Field<int>("Targeted"),
                        //dataRow.Field<int>("VLforPregnantWoman"),
                        dataRow.Field<int>("InitialFirstTime"),
                        dataRow.Field<int>("RepeatConfirmatory"),
                        dataRow.Field<string>("Lab")
                    }).ToList();
                return testResult;
            }
        }

        public IList GetEIDTestAllInstrumentsByLab(int province, int dateFrom, int dateTo, int user_id, string role)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetEIDTestReasonAllInstruments";
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
                cmd.CommandTimeout = 0;
                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                cn.Close();
                var testResult = ds.Tables[0].AsEnumerable().Select(
                    dataRow => new ArrayList {
                        //dataRow.Field<int>("NotMentionedOnForm"),
                        //dataRow.Field<int>("Other"),
                        //dataRow.Field<int>("Repeated"),
                        //dataRow.Field<int>("Routine"),
                        //dataRow.Field<int>("Targeted"),
                        //dataRow.Field<int>("VLforPregnantWoman"),
                        dataRow.Field<int>("InitialFirstTime"),
                        dataRow.Field<int>("RepeatConfirmatory"),
                        dataRow.Field<string>("LabInstrumentname")
                    }).ToList();
                return testResult;
            }
        }

        public IList GetEIDTestAllInstrumentsByLab(string labCode, int dateFrom, int dateTo, int user_id, string role)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetEIDTestReasonAllInstrumentsByLab";
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
                        //dataRow.Field<int>("NotMentionedOnForm"),
                        //dataRow.Field<int>("Other"),
                        //dataRow.Field<int>("Repeated"),
                        //dataRow.Field<int>("Routine"),
                        //dataRow.Field<int>("Targeted"),
                        //dataRow.Field<int>("VLforPregnantWoman"),
                        dataRow.Field<int>("InitialFirstTime"),
                        dataRow.Field<int>("RepeatConfirmatory"),
                        dataRow.Field<string>("LabInstrumentname")
                    }).ToList();
                return testResult;
            }
        }

        public IList GetEIDTestByStateRegionFacility(string labCode, int dateFrom, int dateTo, int user_id, string role)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetEIDTestByStateRegionFacility";
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
                        dataRow.Field<int>("Tot_Tests"),
                        dataRow.Field<string>("Name"),
                        dataRow.Field<int>("NoOfFacilities"),
                        dataRow.Field<string>("Facilities"),
                        dataRow.Field<string>("Tot_by_Fac"),
                    }).ToList();
                return testResult;
            }
        }

        //public IList GetEIDTestByStateRegionFacility(string labCode, int dateFrom, int dateTo, int user_id, string role)
        //{
        //    string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
        //    using (SqlConnection cn = new SqlConnection(connstring))
        //    {
        //        cn.Open();
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.Connection = cn;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = "GetEIDTestByStateRegionFacilityForLab";
        //        cmd.Parameters.AddWithValue("@LabCode", labCode);
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
        //                dataRow.Field<int>("Tot_Tests"),
        //                dataRow.Field<string>("Name"),
        //                dataRow.Field<int>("NoOfFacilities")
        //            }).ToList();
        //        return testResult;
        //    }
        //}

        public IList GetEIDRejectionbyYear(int province, int season)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetEIDRejectionbyMonthYear";
                cmd.Parameters.AddWithValue("@prov", province);
                cmd.Parameters.AddWithValue("@season", season);
                // cmd.Parameters.AddWithValue("@Fromdate", datefrom);
                // cmd.Parameters.AddWithValue("@Todate", dateto);
                cmd.CommandTimeout = 0;
                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                cn.Close();
                IList eidEIDRejectionbyYear;
                if (season == 0)
                    eidEIDRejectionbyYear = ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<int>("Jan"), dataRow.Field<int>("Feb"), dataRow.Field<int>("Mar"), dataRow.Field<int>("Apr"), dataRow.Field<int>("May"), dataRow.Field<int>("Jun"), dataRow.Field<int>("Jul"), dataRow.Field<int>("Aug"), dataRow.Field<int>("Sep"), dataRow.Field<int>("Oct"), dataRow.Field<int>("Nov"), dataRow.Field<int>("Dec"), dataRow.Field<int>("Year") }).ToList();
                else
                    eidEIDRejectionbyYear = ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<int>("Q1"), dataRow.Field<int>("Q2"), dataRow.Field<int>("Q3"), dataRow.Field<int>("Q4"), dataRow.Field<int>("Year") }).ToList();
                return eidEIDRejectionbyYear;
            }
        }
        //public IList GetEIDTurnaroundbyYear(int province, int dateFrom, int dateTo, int user_id, string role)
        //{
        //    string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
        //    using (SqlConnection cn = new SqlConnection(connstring))
        //    {
        //        cn.Open();
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.Connection = cn;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = "GetEIDTurnaroundTimebyYear";
        //        cmd.Parameters.AddWithValue("@prov", province);
        //        cmd.Parameters.AddWithValue("@dateFrom", dateFrom);
        //        cmd.Parameters.AddWithValue("@dateTo", dateTo);
        //        cmd.Parameters.AddWithValue("@user_id", user_id);
        //        cmd.Parameters.AddWithValue("@type", role);
        //        // cmd.Parameters.AddWithValue("@Fromdate", datefrom);
        //        // cmd.Parameters.AddWithValue("@Todate", dateto);
        //        var da = new SqlDataAdapter(cmd);
        //        var ds = new DataSet();
        //        da.Fill(ds);
        //        cn.Close();
        //        //IList eidEIDTurnaroundbyYear;// = null;
        //        //if (season == 0)
        //        //    eidEIDTurnaroundbyYear = ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<int>("Jan"), dataRow.Field<int>("Feb"), dataRow.Field<int>("Mar"), dataRow.Field<int>("Apr"), dataRow.Field<int>("May"), dataRow.Field<int>("Jun"), dataRow.Field<int>("Jul"), dataRow.Field<int>("Aug"), dataRow.Field<int>("Sep"), dataRow.Field<int>("Oct"), dataRow.Field<int>("Nov"), dataRow.Field<int>("Dec"), dataRow.Field<int>("Year") }).ToList();
        //        //else
        //        //    eidEIDTurnaroundbyYear = ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<int>("Q1"), dataRow.Field<int>("Q2"), dataRow.Field<int>("Q3"), dataRow.Field<int>("Q4"), dataRow.Field<int>("Year") }).ToList();

        //        IList eidEIDTurnaroundbyYear = ds.Tables[0].AsEnumerable().Select(
        //            dataRow => new ArrayList {
        //                dataRow.Field<int>("ToShipmentSpan"), dataRow.Field<int>("ToReceivedSpan"),
        //                dataRow.Field<int>("ToTestedSpan"), dataRow.Field<int>("ToDispatchedSpan"),
        //            dataRow.Field<int>("YearData")}).ToList();
        //        return eidEIDTurnaroundbyYear;
        //    }
        //}

        public IList GetEIDTurnaroundbyYear(string labCode, int dateFrom, int dateTo, int user_id, string role)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetEIDTurnaroundTimebyYearForLab";
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

        //public IList GetEIDTurnaroundbyQuarter(int province, int dateFrom, int dateTo, int user_id, string role)
        //{
        //    string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
        //    using (SqlConnection cn = new SqlConnection(connstring))
        //    {
        //        cn.Open();
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.Connection = cn;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = "GetEIDTurnaroundTimebyQuarter";
        //        cmd.Parameters.AddWithValue("@prov", province);
        //        cmd.Parameters.AddWithValue("@dateFrom", dateFrom);
        //        cmd.Parameters.AddWithValue("@dateTo", dateTo);
        //        cmd.Parameters.AddWithValue("@user_id", user_id);
        //        cmd.Parameters.AddWithValue("@type", role);
        //        // cmd.Parameters.AddWithValue("@Fromdate", datefrom);
        //        // cmd.Parameters.AddWithValue("@Todate", dateto);
        //        var da = new SqlDataAdapter(cmd);
        //        var ds = new DataSet();
        //        da.Fill(ds);
        //        cn.Close();
        //        //IList eidEIDTurnaroundbyYear;// = null;
        //        //if (season == 0)
        //        //    eidEIDTurnaroundbyYear = ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<int>("Jan"), dataRow.Field<int>("Feb"), dataRow.Field<int>("Mar"), dataRow.Field<int>("Apr"), dataRow.Field<int>("May"), dataRow.Field<int>("Jun"), dataRow.Field<int>("Jul"), dataRow.Field<int>("Aug"), dataRow.Field<int>("Sep"), dataRow.Field<int>("Oct"), dataRow.Field<int>("Nov"), dataRow.Field<int>("Dec"), dataRow.Field<int>("Year") }).ToList();
        //        //else
        //        //    eidEIDTurnaroundbyYear = ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<int>("Q1"), dataRow.Field<int>("Q2"), dataRow.Field<int>("Q3"), dataRow.Field<int>("Q4"), dataRow.Field<int>("Year") }).ToList();

        //        IList eidEIDTurnaroundbyYear = ds.Tables[0].AsEnumerable().Select(
        //            dataRow => new ArrayList {
        //                dataRow.Field<int>("ToShipmentSpan"), dataRow.Field<int>("ToReceivedSpan"),
        //                dataRow.Field<int>("ToTestedSpan"), dataRow.Field<int>("ToDispatchedSpan"),
        //            dataRow.Field<int>("YearData"), dataRow.Field<string>("ResultData")}).ToList();
        //        return eidEIDTurnaroundbyYear;
        //    }
        //}

        public IList GetEIDTurnaroundbyQuarter(string labCode, int dateFrom, int dateTo, int user_id, string role)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetEIDTurnaroundTimebyQuarterForLab";
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

        public IList GetEIDSummary(int province, int dateFrom, int dateTo, int user_id, string role)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetEIDSummary";
                cmd.Parameters.AddWithValue("@prov", province);
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
                        dataRow.Field<int>("No_Positive"),
                        dataRow.Field<int>("No_Negative"),
                        dataRow.Field<int>("Initial"),
                        dataRow.Field<int>("Initial_Positive"),
                        dataRow.Field<int>("Initial_Less2M"),
                        dataRow.Field<int>("Initial_Less2M_Positive"),
                        //dataRow.Field<int>("Initial_Above2Y"),
                        //dataRow.Field<int>("Initial_Above2Y_Positive"),
                        dataRow.Field<int>("Rejected"),
                        dataRow.Field<decimal>("Rejected_Rate"),
                        dataRow.Field<int>("Error")
                    }).ToList();
                return eidIntialPCRbyYear;
            }
        }

        public IList GetEIDSummaryForLab(string labCode, int dateFrom, int dateTo, int user_id, string role)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetEIDSummaryForLab";
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
                        dataRow.Field<int>("No_Positive"),
                        dataRow.Field<int>("No_Negative"),
                        dataRow.Field<int>("Initial"),
                        dataRow.Field<int>("Initial_Positive"),
                        dataRow.Field<int>("Initial_Less2M"),
                        dataRow.Field<int>("Initial_Less2M_Positive"),
                        dataRow.Field<int>("Initial_Above2Y"),
                        dataRow.Field<int>("Initial_Above2Y_Positive"),
                        dataRow.Field<int>("Rejected"),
                        dataRow.Field<decimal>("Rejected_Rate"),
                        dataRow.Field<int>("Error")
                    }).ToList();
                return eidIntialPCRbyYear;
            }
        }

        public IList GetEIDAllTestInfant2MbyYear(int province, int season)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetEID2MInfantTestbyMonthYear";
                cmd.Parameters.AddWithValue("@prov", province);
                cmd.Parameters.AddWithValue("@season", season);
                // cmd.Parameters.AddWithValue("@Fromdate", datefrom);
                // cmd.Parameters.AddWithValue("@Todate", dateto);
                cmd.CommandTimeout = 0;
                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                cn.Close();
                IList eidInfantTest2MbyYear;
                if (season == 0)
                    eidInfantTest2MbyYear = ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<int>("Jan"), dataRow.Field<int>("Feb"), dataRow.Field<int>("Mar"), dataRow.Field<int>("Apr"), dataRow.Field<int>("May"), dataRow.Field<int>("Jun"), dataRow.Field<int>("Jul"), dataRow.Field<int>("Aug"), dataRow.Field<int>("Sep"), dataRow.Field<int>("Oct"), dataRow.Field<int>("Nov"), dataRow.Field<int>("Dec"), dataRow.Field<int>("Year") }).ToList();
                else
                    eidInfantTest2MbyYear = ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<int>("Q1"), dataRow.Field<int>("Q2"), dataRow.Field<int>("Q3"), dataRow.Field<int>("Q4"), dataRow.Field<int>("Year") }).ToList();
                return eidInfantTest2MbyYear;
            }
        }
        public IList GetEIDPoitivityTrendbyYear(int province, int season)
        {            
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetEIDPoitivityTrendbyYear";
                cmd.Parameters.AddWithValue("@prov", province);
                cmd.Parameters.AddWithValue("@season", season);
                // cmd.Parameters.AddWithValue("@Fromdate", datefrom);
                // cmd.Parameters.AddWithValue("@Todate", dateto);
                cmd.CommandTimeout = 0;
                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                cn.Close();
                IList eidEIDPoitivityTrendbyYear;//=null;
                if (season == 0)
                    eidEIDPoitivityTrendbyYear = ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<decimal>("Jan"), dataRow.Field<decimal>("Feb"), dataRow.Field<decimal>("Mar"), dataRow.Field<decimal>("Apr"), dataRow.Field<decimal>("May"), dataRow.Field<decimal>("Jun"), dataRow.Field<decimal>("Jul"), dataRow.Field<decimal>("Aug"), dataRow.Field<decimal>("Sep"), dataRow.Field<decimal>("Oct"), dataRow.Field<decimal>("Nov"), dataRow.Field<decimal>("Dec"), dataRow.Field<int>("Year") }).ToList();
                else
                    eidEIDPoitivityTrendbyYear = ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<decimal>("Q1"), dataRow.Field<decimal>("Q2"), dataRow.Field<decimal>("Q3"), dataRow.Field<decimal>("Q4"), dataRow.Field<int>("Year") }).ToList();
                return eidEIDPoitivityTrendbyYear;
            }
        }

        //Added by ZaySoe on 19_Dec_2018
        public IList<Year> GetYears()
        {
            string strQuery = "select distinct YEAR(FinalReportDate) as Year From RequestSamples order by YEAR(FinalReportDate) DESC";

            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            IList<Year> obj = new List<Year>();
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strQuery;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr != null)
                    {
                        while (dr.Read())
                        {
                            Year year = new Year();
                            year.YearName = dr.GetInt32(0); //Convert.ToInt32(dr.GetSqlValue(3));
                            //Dl.NoTestedSamples = Convert.ToInt32(dr.GetSqlValue(4))
                            obj.Add(year);
                        }
                    }
                }
            }         
            return obj;
        }

        public IList GetEIDFacility(string datefrom, string dateto)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetEIDFacilityTestResult";

                if (datefrom != "")
                {
                    cmd.Parameters.AddWithValue("@DateFrom", datefrom);
                }
                if (dateto != "")
                {
                    cmd.Parameters.AddWithValue("@DateTo", dateto);
                }
                cmd.CommandTimeout = 0;

                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                cn.Close();
                IList testtrends = ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<int>("Jan"), dataRow.Field<int>("Feb"), dataRow.Field<int>("Mar"), dataRow.Field<int>("Apr"), dataRow.Field<int>("May"), dataRow.Field<int>("Jun"), dataRow.Field<int>("Jul"), dataRow.Field<int>("Aug"), dataRow.Field<int>("Sep"), dataRow.Field<int>("Oct"), dataRow.Field<int>("Nov"), dataRow.Field<int>("Dec"), dataRow.Field<string>("LaboratoryName") }).ToList();
                return testtrends;
            }
        }

        // Added by Zay Soe on Dec_2018
        public IList GetLabPerformanceByDateRange(string datefrom, string dateto)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetLabPerformanceByDateRange";

                if (datefrom != "")
                {
                    cmd.Parameters.AddWithValue("@DateFrom", datefrom);
                }
                if (dateto != "")
                {
                    cmd.Parameters.AddWithValue("@DateTo", dateto);
                }
                cmd.CommandTimeout = 0;
                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                cn.Close();
                IList testtrends = ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<int>("0-7"), dataRow.Field<int>("8-14"), dataRow.Field<int>("15-30"), dataRow.Field<int>(">30"), dataRow.Field<string>("LaboratoryName") }).ToList();
                return testtrends;
            }
        }

        // Added by Zay Soe on 03_Jan_2019
        public IList GetLabPerformanceHistory(int year)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetLabPerformanceHistoryByDateRange";
                if (year > 0)                
                    cmd.Parameters.AddWithValue("@Year", year);                

                //if (datefrom != "")
                //{
                //    cmd.Parameters.AddWithValue("@DateFrom", datefrom);
                //}
                //if (dateto != "")
                //{
                //    cmd.Parameters.AddWithValue("@DateTo", dateto);
                //}

                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                cn.Close();

                //int colCount = ds.Tables[0].Columns.Count;
                //IList testtrends = new ArrayList();
                //foreach (DataRow dr in ds.Tables[0].Rows)
                //{
                //    ArrayList row = new ArrayList();
                //    for (int i = 0; i < colCount - 1; i++)
                //    {
                //        if (!Convert.IsDBNull(dr[i]))
                //            row.Add(dr[i]);
                //        else
                //            row.Add(0);
                //    }                    

                //    row.Add(dr[colCount-1]);

                //    testtrends.Add(row);
                //}

                //IList testtrends = ds.Tables[0].AsEnumerable().Select(
                //    dataRow => new ArrayList {
                //        dataRow.Field<int>(1),
                //        dataRow.Field<int>(2),                        
                //        dataRow.Field<string>(0) }).ToList();

                IList testtrends = ds.Tables[0].AsEnumerable().Select(
                    dataRow => new ArrayList {
                        dataRow.Field<int>("Jan"),
                        dataRow.Field<int>("Feb"),
                        dataRow.Field<int>("Mar"),
                        dataRow.Field<int>("Apr"),
                        dataRow.Field<int>("May"),
                        dataRow.Field<int>("Jun"),
                        dataRow.Field<int>("Jul"),
                        dataRow.Field<int>("Aug"),
                        dataRow.Field<int>("Sep"),
                        dataRow.Field<int>("Oct"),
                        dataRow.Field<int>("Nov"),
                        dataRow.Field<int>("Dec"),                        
                        //dataRow.Field<string>("LaboratoryName"),
                        dataRow.Field<string>("Category") }).ToList();
                return testtrends;
            }
        }

        // Added by Zay Soe on 06_Mar_2019
        //public IList GetLabOnlineHistory(int year)
        //{
        //    string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
        //    using (SqlConnection cn = new SqlConnection(connstring))
        //    {
        //        cn.Open();
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.Connection = cn;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = "GetLabOnlineHistory";
        //        if (year > 0)
        //            cmd.Parameters.AddWithValue("@Year", year);

        //        var da = new SqlDataAdapter(cmd);
        //        var ds = new DataSet();
        //        da.Fill(ds);
        //        cn.Close();                

        //        IList testtrends = ds.Tables[0].AsEnumerable().Select(
        //            dataRow => new ArrayList {
        //                dataRow.Field<int>("cat1"),
        //                dataRow.Field<int>("cat2"),
        //                dataRow.Field<int>("cat3"),
        //                dataRow.Field<int>("cat4"),
        //                dataRow.Field<int>("week_no"),
        //                dataRow.Field<string>("days_in_week"),
        //                dataRow.Field<string>("Category") }).ToList();
        //        return testtrends;
        //    }
        //}

        // Added by Zay Soe on 06_Mar_2019
        public IList GetLabDataEntryPerformanceDaily(int year, int month, string labCode)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandText = "GetLabDataEntryPerformanceWeekly";
                cmd.CommandText = "GetLabDataEntryPerformanceDaily";
                if (year > 0)
                    cmd.Parameters.AddWithValue("@Year", year);
                cmd.Parameters.AddWithValue("@Month", month);
                cmd.Parameters.AddWithValue("@LabCode", labCode);

                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                cn.Close();

                IList testtrends = ds.Tables[0].AsEnumerable().Select(
                    //dataRow => new ArrayList {
                    //    dataRow.Field<int>("total_records"),                        
                    //    dataRow.Field<int>("week_no"),
                    //    dataRow.Field<string>("days_in_week"),
                    //    dataRow.Field<string>("Category") }).ToList();
                    dataRow => new ArrayList {
                        dataRow.Field<int>("total_records"),
                        dataRow.Field<string>("FormCreatedDate"),
                        dataRow.Field<string>("Category") }).ToList();
                return testtrends;
            }
        }
        
        public IList GetLabTestingPerformanceDaily(int year, int month, string labCode)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;                
                cmd.CommandText = "GetLabTestingPerformanceDaily";
                if (year > 0)
                    cmd.Parameters.AddWithValue("@Year", year);
                cmd.Parameters.AddWithValue("@Month", month);
                cmd.Parameters.AddWithValue("@LabCode", labCode);

                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                cn.Close();

                IList testtrends = ds.Tables[0].AsEnumerable().Select(
                    //dataRow => new ArrayList {
                    //    dataRow.Field<int>("total_records"),                        
                    //    dataRow.Field<int>("week_no"),
                    //    dataRow.Field<string>("days_in_week"),
                    //    dataRow.Field<string>("Category") }).ToList();
                    dataRow => new ArrayList {
                        dataRow.Field<int>("total_records"),
                        dataRow.Field<string>("FinalReportDate"),
                        dataRow.Field<string>("Category") }).ToList();
                return testtrends;
            }
        }

        #region EID Summary
        public EIDStat EIDSummaryStat(string dateFrom, string dateTo, int province, int user_id, string role)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetEIDSummaryStat";
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
                cn.Close();
                EIDStat stat = new EIDStat();
                stat.Tot_Initial = ds.Tables[0].Rows[0].Field<int>("Total_Initial");
                stat.Tot_Initial_Positive = ds.Tables[0].Rows[0].Field<int>("Total_Initial_Positive");
                stat.Total_Initial_lt2month = ds.Tables[0].Rows[0].Field<int>("Total_Initial_lt2month");

                stat.No_Sample_Recieved = ds.Tables[0].Rows[0].Field<int>("No_Sample_Recieved");
                stat.No_Rejected_Sample = ds.Tables[0].Rows[0].Field<int>("No_Rejected_Sample");
                stat.Tot_Tests = ds.Tables[0].Rows[0].Field<int>("Tot_Tests");
                stat.No_Positive = ds.Tables[0].Rows[0].Field<int>("No_Positive");
                stat.No_Negative = ds.Tables[0].Rows[0].Field<int>("No_Negative");

                //stat.RejectedSamples = ds.Tables[0].Rows[0].Field<decimal>("RejectedSamples");
                //stat.Tot_Detected_LE_1000 = ds.Tables[0].Rows[0].Field<int>("Tot_Detected_LE_1000");
                //stat.Tot_Detected_G_1000 = ds.Tables[0].Rows[0].Field<int>("Tot_Detected_G_1000");
                //stat.Total_Suppressed = ds.Tables[0].Rows[0].Field<decimal>("Total_Suppressed");

                //stat.No_Positive = ds.Tables[0].Rows[0].Field<int>("No_Positive");
                //stat.No_Negative = ds.Tables[0].Rows[0].Field<int>("No_Negative");
                //stat.Positivity_Rate = ds.Tables[0].Rows[0].Field<decimal>("Positivity_Rate");
                //stat.No_Indeterminate = ds.Tables[0].Rows[0].Field<int>("No_Indeterminate");

                stat.Initial_Rate = ds.Tables[0].Rows[0].Field<decimal>("Initial_Rate");
                stat.Initial_Positive_Rate = ds.Tables[0].Rows[0].Field<decimal>("Initial_Positive_Rate");
                stat.Initial_lt2months_Rate = ds.Tables[0].Rows[0].Field<decimal>("Initial_lt2months_Rate");
                
                stat.Error = ds.Tables[0].Rows[0].Field<int>("Invalid_Error_Noresult");
                
                //ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<int>("Tot_Tests"), dataRow.Field<decimal>("RejectedSamples"), dataRow.Field<int>("Tot_Detected_LE_1000"), dataRow.Field<int>("Tot_Detected_G_1000"), dataRow.Field<decimal>("Total_Suppressed"), dataRow.Field<int>("Invalid_Error_Noresult") }).ToList();
                return stat;
            }
        }

        public EIDStat EIDSummaryStatForLab(string dateFrom, string dateTo, string labCode, int user_id, string role)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetEIDSummaryStatForLab";
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
                cn.Close();
                EIDStat stat = new EIDStat();
                stat.Tot_Initial = ds.Tables[0].Rows[0].Field<int>("Total_Initial");
                stat.Tot_Initial_Positive = ds.Tables[0].Rows[0].Field<int>("Total_Initial_Positive");
                stat.Total_Initial_lt2month = ds.Tables[0].Rows[0].Field<int>("Total_Initial_lt2month");

                stat.No_Sample_Recieved = ds.Tables[0].Rows[0].Field<int>("No_Sample_Recieved");
                stat.No_Rejected_Sample = ds.Tables[0].Rows[0].Field<int>("No_Rejected_Sample");
                stat.Tot_Tests = ds.Tables[0].Rows[0].Field<int>("Tot_Tests");
                stat.No_Positive = ds.Tables[0].Rows[0].Field<int>("No_Positive");
                stat.No_Negative = ds.Tables[0].Rows[0].Field<int>("No_Negative");

                //stat.RejectedSamples = ds.Tables[0].Rows[0].Field<decimal>("RejectedSamples");
                //stat.Tot_Detected_LE_1000 = ds.Tables[0].Rows[0].Field<int>("Tot_Detected_LE_1000");
                //stat.Tot_Detected_G_1000 = ds.Tables[0].Rows[0].Field<int>("Tot_Detected_G_1000");
                //stat.Total_Suppressed = ds.Tables[0].Rows[0].Field<decimal>("Total_Suppressed");

                //stat.No_Positive = ds.Tables[0].Rows[0].Field<int>("No_Positive");
                //stat.No_Negative = ds.Tables[0].Rows[0].Field<int>("No_Negative");
                //stat.Positivity_Rate = ds.Tables[0].Rows[0].Field<decimal>("Positivity_Rate");
                //stat.No_Indeterminate = ds.Tables[0].Rows[0].Field<int>("No_Indeterminate");

                stat.Initial_Rate = ds.Tables[0].Rows[0].Field<decimal>("Initial_Rate");
                stat.Initial_Positive_Rate = ds.Tables[0].Rows[0].Field<decimal>("Initial_Positive_Rate");
                stat.Initial_lt2months_Rate = ds.Tables[0].Rows[0].Field<decimal>("Initial_lt2months_Rate");

                stat.Error = ds.Tables[0].Rows[0].Field<int>("Invalid_Error_Noresult");

                //ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<int>("Tot_Tests"), dataRow.Field<decimal>("RejectedSamples"), dataRow.Field<int>("Tot_Detected_LE_1000"), dataRow.Field<int>("Tot_Detected_G_1000"), dataRow.Field<decimal>("Total_Suppressed"), dataRow.Field<int>("Invalid_Error_Noresult") }).ToList();
                return stat;
            }
        }

        #endregion        

        public IList GetLabEIDRejectionbyYear(string lab, DateTime datefrom, DateTime dateto)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetLabEIDRejectionbyYear";
                cmd.Parameters.AddWithValue("@lab", lab);
                cmd.Parameters.AddWithValue("@Fromdate", datefrom);
                cmd.Parameters.AddWithValue("@Todate", dateto);
                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                cn.Close();
                var labEIDRejectionbyYear = ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<int>("Jan"), dataRow.Field<int>("Feb"), dataRow.Field<int>("Mar"), dataRow.Field<int>("Apr"), dataRow.Field<int>("May"), dataRow.Field<int>("Jun"), dataRow.Field<int>("Jul"), dataRow.Field<int>("Aug"), dataRow.Field<int>("Sep"), dataRow.Field<int>("Oct"), dataRow.Field<int>("Nov"), dataRow.Field<int>("Dec"), dataRow.Field<string>("LaboratoryName") }).ToList();
                //else
                //    eidEIDPoitivityTrendbyYear = ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<decimal>("Q1"), dataRow.Field<decimal>("Q2"), dataRow.Field<decimal>("Q3"), dataRow.Field<decimal>("Q4"), dataRow.Field<int>("Year") }).ToList();
                return labEIDRejectionbyYear;
            }
        }
        public IList GetLabEIDPoitivityTrendbyYear(string lab, DateTime datefrom, DateTime dateto)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetLabEIDPoitivityTrendbyYear";
                cmd.Parameters.AddWithValue("@lab", lab);
                cmd.Parameters.AddWithValue("@Fromdate", datefrom);
                cmd.Parameters.AddWithValue("@Todate", dateto);
                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                cn.Close();
                var labEIDPoitivityTrendbyYear = ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<decimal>("Jan"), dataRow.Field<decimal>("Feb"), dataRow.Field<decimal>("Mar"), dataRow.Field<decimal>("Apr"), dataRow.Field<decimal>("May"), dataRow.Field<decimal>("Jun"), dataRow.Field<decimal>("Jul"), dataRow.Field<decimal>("Aug"), dataRow.Field<decimal>("Sep"), dataRow.Field<decimal>("Oct"), dataRow.Field<decimal>("Nov"), dataRow.Field<decimal>("Dec"), dataRow.Field<string>("LaboratoryName") }).ToList();
                //else
                //    eidEIDPoitivityTrendbyYear = ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<decimal>("Q1"), dataRow.Field<decimal>("Q2"), dataRow.Field<decimal>("Q3"), dataRow.Field<decimal>("Q4"), dataRow.Field<int>("Year") }).ToList();
                return labEIDPoitivityTrendbyYear;
            }
        }
        public IList GetLabEIDValidOutcome(string lab, DateTime datefrom, DateTime dateto)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetLabEIDIntialPCR";
                cmd.Parameters.AddWithValue("@lab", lab);
                cmd.Parameters.AddWithValue("@Fromdate", datefrom);
                cmd.Parameters.AddWithValue("@Todate", dateto);
                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                cn.Close();
                var labEIDValidOutcome = ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<int>("No_Positive"), dataRow.Field<int>("No_Negative"), dataRow.Field<string>("Laboratory") }).ToList();
                //else
                //    eidEIDPoitivityTrendbyYear = ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<decimal>("Q1"), dataRow.Field<decimal>("Q2"), dataRow.Field<decimal>("Q3"), dataRow.Field<decimal>("Q4"), dataRow.Field<int>("Year") }).ToList();
                return labEIDValidOutcome;
            }
        }

        public IList GetLabEIDTestTrendbyYear(string lab, DateTime datefrom, DateTime dateto)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetLabEIDTestTrendbyYear";
                cmd.Parameters.AddWithValue("@lab", lab);
                cmd.Parameters.AddWithValue("@Fromdate", datefrom);
                cmd.Parameters.AddWithValue("@Todate", dateto);
                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                cn.Close();
                var labEIDTestTrendbyYear = ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<decimal>("Jan"), dataRow.Field<decimal>("Feb"), dataRow.Field<decimal>("Mar"), dataRow.Field<decimal>("Apr"), dataRow.Field<decimal>("May"), dataRow.Field<decimal>("Jun"), dataRow.Field<decimal>("Jul"), dataRow.Field<decimal>("Aug"), dataRow.Field<decimal>("Sep"), dataRow.Field<decimal>("Oct"), dataRow.Field<decimal>("Nov"), dataRow.Field<decimal>("Dec"), dataRow.Field<string>("LaboratoryName") }).ToList();
                //else
                //    labEIDTestTrendbyYear = ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<decimal>("Q1"), dataRow.Field<decimal>("Q2"), dataRow.Field<decimal>("Q3"), dataRow.Field<decimal>("Q4"), dataRow.Field<int>("Year") }).ToList();
                return labEIDTestTrendbyYear;
            }
        }

        public IList GetLabRejectedSamplebyCountry(string lab, DateTime datefrom, DateTime dateto)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetLabRejectedSamplebyCountry";
                cmd.Parameters.AddWithValue("@lab", lab);
                cmd.Parameters.AddWithValue("@Fromdate", datefrom);
                cmd.Parameters.AddWithValue("@Todate", dateto);
                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                cn.Close();
                var labRejectedSamplebyCountry = ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<int>("RejectedSamples"), dataRow.Field<decimal>("Rejected"), dataRow.Field<string>("Reason") }).ToList();
                return labRejectedSamplebyCountry;
            }
        }
        public DataSet GetLabPerformance(string lab, DateTime datefrom, DateTime dateto)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetLabPerformance";
                //cmd.Parameters.AddWithValue("@lab", lab);
                cmd.Parameters.AddWithValue("@Fromdate", datefrom);
                cmd.Parameters.AddWithValue("@Todate", dateto);
                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                cn.Close();
                // var labRejectedSamplebyCountry = ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<int>("RejectedSamples"), dataRow.Field<decimal>("Rejected"), dataRow.Field<string>("Reason") }).ToList();
                return ds;
            }
        }

        //public DataSet GetTurnaroundTime(int province, int dateFrom, int dateTo, int user_id, string role)
        //{
        //    string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
        //    using (SqlConnection cn = new SqlConnection(connstring))
        //    {
        //        cn.Open();
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.Connection = cn;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = "GetTurnaroundTime";
        //        cmd.Parameters.AddWithValue("@province", province);
        //        cmd.Parameters.AddWithValue("@Fromdate", dateFrom);
        //        cmd.Parameters.AddWithValue("@Todate", dateTo);
        //        cmd.Parameters.AddWithValue("@user_id", user_id);
        //        cmd.Parameters.AddWithValue("@type", role);
        //        var da = new SqlDataAdapter(cmd);
        //        var ds = new DataSet();
        //        da.Fill(ds);
        //        cn.Close();                
        //        return ds;
        //    }
        //}        

        #region Facilities

        public IList GetEIDFacilityIntialPCRbyYear(int facility, int user_id, string role, string provinceIDs, string facilityTypes)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetEIDFacilityIntialPCRbyYear";
                cmd.Parameters.AddWithValue("@facility", facility);
                // cmd.Parameters.AddWithValue("@Fromdate", datefrom);
                // cmd.Parameters.AddWithValue("@Todate", dateto);
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@type", role);
                cmd.Parameters.AddWithValue("@provinceIDs", provinceIDs);
                cmd.Parameters.AddWithValue("@facilityTypes", facilityTypes);
                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                cn.Close();
                var eidIntialPCRbyYear = ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<int>("No_Positive"), dataRow.Field<int>("No_Negative"), dataRow.Field<decimal>("Positivity"), dataRow.Field<int>("ResultDate") }).ToList();
                return eidIntialPCRbyYear;
            }
        }

        //EID Testing Trend Quarterly
        public IList GetEIDFacilityAllTestbyYear(int facility, int dateFrom, int dateTo, int user_id, string role, string provinceIDs, string facilityTypes)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetEIDFacilityIntialPCRbyQuarter";
                cmd.Parameters.AddWithValue("@facility", facility);
                cmd.Parameters.AddWithValue("@dateFrom", dateFrom);
                cmd.Parameters.AddWithValue("@dateTo", dateTo);
                // cmd.Parameters.AddWithValue("@Fromdate", datefrom);
                // cmd.Parameters.AddWithValue("@Todate", dateto);
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@type", role);
                cmd.Parameters.AddWithValue("@provinceIDs", provinceIDs);
                cmd.Parameters.AddWithValue("@facilityTypes", facilityTypes);
                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                cn.Close();
                var eidIntialPCRbyYear = ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<int>("No_Positive"), dataRow.Field<int>("No_Negative"), dataRow.Field<decimal>("Positivity"), dataRow.Field<string>("ResultDate") }).ToList();
                return eidIntialPCRbyYear;
            }
        }

        //Added by Zay Soe on 9_Jan_2019
        //EID Testing Trend Monthly
        public IList GetEIDFacilityIntialPCRbyMonth(int facility, int dateFrom, int dateTo, int user_id, string role, string provinceIDs, string facilityTypes)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetEIDFacilityIntialPCRbyMonth";
                cmd.Parameters.AddWithValue("@facility", facility);
                cmd.Parameters.AddWithValue("@dateFrom", dateFrom);
                cmd.Parameters.AddWithValue("@dateTo", dateTo);
                // cmd.Parameters.AddWithValue("@Fromdate", datefrom);
                // cmd.Parameters.AddWithValue("@Todate", dateto);
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@type", role);
                cmd.Parameters.AddWithValue("@provinceIDs", provinceIDs);
                cmd.Parameters.AddWithValue("@facilityTypes", facilityTypes);
                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                cn.Close();
                var eidIntialPCRbyYear = ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<int>("No_Positive"), dataRow.Field<int>("No_Negative"), dataRow.Field<decimal>("Positivity"), dataRow.Field<string>("ResultDate") }).ToList();
                return eidIntialPCRbyYear;
            }
        }

        //Added by ZaySoe on 09_Jan_2019
        //EID Age Group by Yearly
        public IList GetEIDFacilityIntialPCRAgeByYearly(int facility, int user_id, string role, string provinceIDs, string facilityTypes)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetEIDFacilityInitialPCRAgeByYearly";
                cmd.Parameters.AddWithValue("@facility", facility);
                // cmd.Parameters.AddWithValue("@Fromdate", datefrom);
                // cmd.Parameters.AddWithValue("@Todate", dateto);
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@type", role);
                cmd.Parameters.AddWithValue("@provinceIDs", provinceIDs);
                cmd.Parameters.AddWithValue("@facilityTypes", facilityTypes);
                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                cn.Close();
                var eidIntialPCRbyAgeYear = ds.Tables[0].AsEnumerable().Select(
                    dataRow => new ArrayList {
                        dataRow.Field<int>("nodata"),
                        dataRow.Field<int>("less2month"),
                        dataRow.Field<int>("between2and6month"),
                        dataRow.Field<int>("between6and9month"),
                        dataRow.Field<int>("between9and18month"),
                        dataRow.Field<int>("greaterthan18month"),
                        //dataRow.Field<int>("NoData"),
                        dataRow.Field<decimal>("lessthan_2months_rate"),
                        dataRow.Field<int>("ResultDate") }).ToList();
                return eidIntialPCRbyAgeYear;
            }
        }

        //EID Age Group by Quarterly
        public IList GetEIDFacilityIntialPCRAgeByQuarterly(int facility, int dateFrom, int dateTo, int user_id, string role, string provinceIDs, string facilityTypes)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetEIDFacilityInitialPCRAgeByQuarterly";
                cmd.Parameters.AddWithValue("@facility", facility);
                cmd.Parameters.AddWithValue("@dateFrom", dateFrom);
                cmd.Parameters.AddWithValue("@dateTo", dateTo);
                // cmd.Parameters.AddWithValue("@Fromdate", datefrom);
                // cmd.Parameters.AddWithValue("@Todate", dateto);
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@type", role);
                cmd.Parameters.AddWithValue("@provinceIDs", provinceIDs);
                cmd.Parameters.AddWithValue("@facilityTypes", facilityTypes);
                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                cn.Close();
                var eidIntialPCRbyAgeYear = ds.Tables[0].AsEnumerable().Select(
                    dataRow => new ArrayList {
                        dataRow.Field<int>("nodata"),
                        dataRow.Field<int>("less2month"),
                        dataRow.Field<int>("between2and6month"),
                        dataRow.Field<int>("between6and9month"),
                        dataRow.Field<int>("between9and18month"),
                        dataRow.Field<int>("greaterthan18month"),
                        //dataRow.Field<int>("NoData"),
                        dataRow.Field<decimal>("lessthan_2months_rate"),
                        dataRow.Field<string>("ResultDate") }).ToList();
                return eidIntialPCRbyAgeYear;
            }
        }

        //EID Age Group by Monthly
        public IList GetEIDFacilityIntialPCRAgeByMonthly(int facility, int dateFrom, int dateTo, int user_id, string role, string provinceIDs, string facilityTypes)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetEIDFacilityInitialPCRAgeByMonthly";
                cmd.Parameters.AddWithValue("@facility", facility);
                cmd.Parameters.AddWithValue("@dateFrom", dateFrom);
                cmd.Parameters.AddWithValue("@dateTo", dateTo);
                // cmd.Parameters.AddWithValue("@Fromdate", datefrom);
                // cmd.Parameters.AddWithValue("@Todate", dateto);
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@type", role);
                cmd.Parameters.AddWithValue("@provinceIDs", provinceIDs);
                cmd.Parameters.AddWithValue("@facilityTypes", facilityTypes);
                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                cn.Close();
                var eidIntialPCRbyAgeYear = ds.Tables[0].AsEnumerable().Select(
                    dataRow => new ArrayList {
                        dataRow.Field<int>("nodata"),
                        dataRow.Field<int>("less2month"),
                        dataRow.Field<int>("between2and6month"),
                        dataRow.Field<int>("between6and9month"),
                        dataRow.Field<int>("between9and18month"),
                        dataRow.Field<int>("greaterthan18month"),
                        //dataRow.Field<int>("NoData"),
                        dataRow.Field<decimal>("lessthan_2months_rate"),
                        dataRow.Field<string>("ResultDate") }).ToList();
                return eidIntialPCRbyAgeYear;
            }
        }

        public IList GetEIDFacilityPCR(int facility, int dateFrom, int dateTo, int user_id, string role, string provinceIDs, string facilityTypes)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetEIDFacilityPCR";
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
                cn.Close();
                var eidIntialPCRbyYear = ds.Tables[0].AsEnumerable().Select(
                    dataRow => new ArrayList {
                        dataRow.Field<int>("Total_Tested"),
                        dataRow.Field<int>("No_Positive"),
                        //dataRow.Field<int>("No_Negative"),
                        //dataRow.Field<int>("less2month_positive"),
                        //dataRow.Field<int>("less2month_initial_positive"),
                        dataRow.Field<decimal>("Positivity"),
                        dataRow.Field<decimal>("Less2month_Rate"),
                        dataRow.Field<string>("Name") }).ToList();
                return eidIntialPCRbyYear;
            }
        }

        public EIDStat EIDFacilitySummaryStat(string dateFrom, string dateTo, int facility, int user_id, string role, string provinceIDs, string facilityTypes)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetEIDFacilitySummaryStat";
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
                cn.Close();
                EIDStat stat = new EIDStat();
                stat.Tot_Initial = ds.Tables[0].Rows[0].Field<int>("Total_Initial");
                stat.Tot_Initial_Positive = ds.Tables[0].Rows[0].Field<int>("Total_Initial_Positive");
                stat.Total_Initial_lt2month = ds.Tables[0].Rows[0].Field<int>("Total_Initial_lt2month");

                stat.No_Sample_Recieved = ds.Tables[0].Rows[0].Field<int>("No_Sample_Recieved");
                stat.No_Rejected_Sample = ds.Tables[0].Rows[0].Field<int>("No_Rejected_Sample");
                stat.Tot_Tests = ds.Tables[0].Rows[0].Field<int>("Tot_Tests");
                stat.No_Positive = ds.Tables[0].Rows[0].Field<int>("No_Positive");
                stat.No_Negative = ds.Tables[0].Rows[0].Field<int>("No_Negative");

                //stat.RejectedSamples = ds.Tables[0].Rows[0].Field<decimal>("RejectedSamples");
                //stat.Tot_Detected_LE_1000 = ds.Tables[0].Rows[0].Field<int>("Tot_Detected_LE_1000");
                //stat.Tot_Detected_G_1000 = ds.Tables[0].Rows[0].Field<int>("Tot_Detected_G_1000");
                //stat.Total_Suppressed = ds.Tables[0].Rows[0].Field<decimal>("Total_Suppressed");

                //stat.No_Positive = ds.Tables[0].Rows[0].Field<int>("No_Positive");
                //stat.No_Negative = ds.Tables[0].Rows[0].Field<int>("No_Negative");
                //stat.Positivity_Rate = ds.Tables[0].Rows[0].Field<decimal>("Positivity_Rate");
                //stat.No_Indeterminate = ds.Tables[0].Rows[0].Field<int>("No_Indeterminate");

                stat.Initial_Rate = ds.Tables[0].Rows[0].Field<decimal>("Initial_Rate");
                stat.Initial_Positive_Rate = ds.Tables[0].Rows[0].Field<decimal>("Initial_Positive_Rate");
                stat.Initial_lt2months_Rate = ds.Tables[0].Rows[0].Field<decimal>("Initial_lt2months_Rate");

                stat.Error = ds.Tables[0].Rows[0].Field<int>("Invalid_Error_Noresult");

                //ds.Tables[0].AsEnumerable().Select(dataRow => new ArrayList { dataRow.Field<int>("Tot_Tests"), dataRow.Field<decimal>("RejectedSamples"), dataRow.Field<int>("Tot_Detected_LE_1000"), dataRow.Field<int>("Tot_Detected_G_1000"), dataRow.Field<decimal>("Total_Suppressed"), dataRow.Field<int>("Invalid_Error_Noresult") }).ToList();
                return stat;
            }
        }

        public IList GetEIDFacilitySummary(int facility, int dateFrom, int dateTo, int user_id, string role, string provinceIDs, string facilityTypes)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetEIDFacilitySummary";
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
                cn.Close();
                var eidIntialPCRbyYear = ds.Tables[0].AsEnumerable().Select(
                    dataRow => new ArrayList {
                        dataRow.Field<int>("Total_Received"),
                        dataRow.Field<int>("Total_Tested"),
                        dataRow.Field<int>("No_Positive"),
                        dataRow.Field<int>("No_Negative"),
                        dataRow.Field<int>("Initial"),
                        dataRow.Field<int>("Initial_Positive"),
                        dataRow.Field<int>("Initial_Less2M"),
                        dataRow.Field<int>("Initial_Less2M_Positive"),
                        dataRow.Field<int>("Initial_Above2Y"),
                        dataRow.Field<int>("Initial_Above2Y_Positive"),
                        dataRow.Field<int>("Rejected"),
                        dataRow.Field<decimal>("Rejected_Rate"),
                        dataRow.Field<int>("Error")
                    }).ToList();
                return eidIntialPCRbyYear;
            }
        }

        public IList GetEIDTestByGenderOutcome(int province, int dateFrom, int dateTo, int user_id, string role)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetEIDTestByGenderOutcome";
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
                cn.Close();
                var testResult = ds.Tables[0].AsEnumerable().Select(
                    dataRow => new ArrayList {
                        dataRow.Field<int>("No_Positive"),
                        dataRow.Field<int>("No_Negative"),
                        dataRow.Field<decimal>("Positivity"),
                        dataRow.Field<string>("Sex")
                    }).ToList();
                return testResult;
            }
        }

        public IList GetEIDTestByGenderOutcomeForLab(string labCode, int dateFrom, int dateTo, int user_id, string role)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetEIDTestByGenderOutcomeForLab";
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
                cn.Close();
                var testResult = ds.Tables[0].AsEnumerable().Select(
                    dataRow => new ArrayList {
                        dataRow.Field<int>("No_Positive"),
                        dataRow.Field<int>("No_Negative"),
                        dataRow.Field<decimal>("Positivity"),
                        dataRow.Field<string>("Sex")
                    }).ToList();
                return testResult;
            }
        }

        public IList GetEIDFacilityTestByGenderOutcome(int facility, int dateFrom, int dateTo, int user_id, string role, string provinceIDs, string facilityTypes)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetEIDFacilityTestByGenderOutcome";
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
                cn.Close();
                var testResult = ds.Tables[0].AsEnumerable().Select(
                    dataRow => new ArrayList {
                        dataRow.Field<int>("No_Positive"),
                        dataRow.Field<int>("No_Negative"),
                        dataRow.Field<decimal>("Positivity"),
                        dataRow.Field<string>("Sex")
                    }).ToList();
                return testResult;
            }
        }

        public IList GetEIDTestRejectByProvince(int province, int dateFrom, int dateTo, int user_id, string role)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetEIDTestRejectByProvince";
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

        public IList GetEIDTestRejectByProvinceForLab(string labCode, int dateFrom, int dateTo, int user_id, string role)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetEIDTestRejectByProvinceForLab";
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
                        dataRow.Field<int>("Tot_Received"),
                        dataRow.Field<int>("Tot_Rejected"),
                        dataRow.Field<decimal>("Rejected_Rate"),
                        dataRow.Field<string>("Name")
                    }).ToList();
                return testResult;
            }
        }

        public IList GetEIDTestRejectByProvinceForFacility(int facility, int dateFrom, int dateTo, int user_id, string role, string provinceIDs, string facilityTypes)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetEIDTestRejectByProvinceForFacility";
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

        public IList GetEIDTestByAgeOutcome(int province, int dateFrom, int dateTo, int user_id, string role)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetEIDTestByAgeOutcome";
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
                        dataRow.Field<int>("No_Positive"),
                        dataRow.Field<int>("No_Negative"),
                        dataRow.Field<decimal>("Positivity"),
                        dataRow.Field<string>("Age_Range")
                        //,dataRow.Field<int>("ResultDate")
                    }).ToList();
                return testResult;
            }
        }

        public IList GetEIDTestByAgeOutcomeForLab(string labCode, int dateFrom, int dateTo, int user_id, string role)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetEIDTestByAgeOutcomeForLab";
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
                        dataRow.Field<int>("No_Positive"),
                        dataRow.Field<int>("No_Negative"),
                        dataRow.Field<decimal>("Positivity"),
                        dataRow.Field<string>("Age_Range")
                        //,dataRow.Field<int>("ResultDate")
                    }).ToList();
                return testResult;
            }
        }

        public IList GetEIDTestByAgeOutcomeForFacility(int facility, int dateFrom, int dateTo, int user_id, string role, string provinceIDs, string facilityTypes)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetEIDTestByAgeOutcomeForFacility";
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
                        dataRow.Field<int>("No_Positive"),
                        dataRow.Field<int>("No_Negative"),
                        dataRow.Field<decimal>("Positivity"),
                        dataRow.Field<string>("Age_Range")
                        //,dataRow.Field<int>("ResultDate")
                    }).ToList();
                return testResult;
            }
        }

        public IList GetEIDTestLabAndFacility(int facility, int dateFrom, int dateTo, int user_id, string role, string provinceIDs, string facilityTypes)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetEIDTestLabAndFacility";
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

        //public IList GetEIDPCRAgeGroupByProvince(int province, int dateFrom, int dateTo, int user_id, string role)
        //{
        //    string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
        //    using (SqlConnection cn = new SqlConnection(connstring))
        //    {
        //        cn.Open();
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.Connection = cn;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = "GetEIDPCRbyFacility";
        //        cmd.Parameters.AddWithValue("@prov", province);
        //        cmd.Parameters.AddWithValue("@dateFrom", dateFrom);
        //        cmd.Parameters.AddWithValue("@dateTo", dateTo);
        //        cmd.Parameters.AddWithValue("@user_id", user_id);
        //        cmd.Parameters.AddWithValue("@type", role);
        //        var da = new SqlDataAdapter(cmd);
        //        var ds = new DataSet();
        //        da.Fill(ds);
        //        cn.Close();
        //        var eidIntialPCRbyYear = ds.Tables[0].AsEnumerable().Select(
        //            dataRow => new ArrayList {
        //                dataRow.Field<int>("Total_Tested"),
        //                dataRow.Field<int>("No_Positive"),
        //                //dataRow.Field<int>("No_Negative"),
        //                //dataRow.Field<int>("less2month_positive"),
        //                //dataRow.Field<int>("less2month_initial_positive"),
        //                dataRow.Field<decimal>("Positivity"),
        //                dataRow.Field<decimal>("Less2month_Rate"),
        //                dataRow.Field<string>("Name") }).ToList();
        //        return eidIntialPCRbyYear;
        //    }
        //}

        //public IList GetEIDPCRAgeGroupByProvinceForFacility(int facility, int dateFrom, int dateTo, int user_id, string role, string provinceIDs, string facilityTypes)
        //{
        //    string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
        //    using (SqlConnection cn = new SqlConnection(connstring))
        //    {
        //        cn.Open();
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.Connection = cn;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = "GetEIDPCRAgeGroupByProvinceForFacility";
        //        cmd.Parameters.AddWithValue("@facility", facility);
        //        cmd.Parameters.AddWithValue("@dateFrom", dateFrom);
        //        cmd.Parameters.AddWithValue("@dateTo", dateTo);
        //        cmd.Parameters.AddWithValue("@user_id", user_id);
        //        cmd.Parameters.AddWithValue("@type", role);
        //        cmd.Parameters.AddWithValue("@provinceIDs", provinceIDs);
        //        cmd.Parameters.AddWithValue("@facilityTypes", facilityTypes);
        //        var da = new SqlDataAdapter(cmd);
        //        var ds = new DataSet();
        //        da.Fill(ds);
        //        cn.Close();
        //        var eidIntialPCRbyYear = ds.Tables[0].AsEnumerable().Select(
        //            dataRow => new ArrayList {
        //                dataRow.Field<int>("Total_Tested"),
        //                dataRow.Field<int>("No_Positive"),
        //                //dataRow.Field<int>("No_Negative"),
        //                //dataRow.Field<int>("less2month_positive"),
        //                //dataRow.Field<int>("less2month_initial_positive"),
        //                dataRow.Field<decimal>("Positivity"),
        //                dataRow.Field<decimal>("Less2month_Rate"),
        //                //dataRow.Field<string>("Name"),
        //                dataRow.Field<string>("Age_Range")
        //            }).ToList();
        //        return eidIntialPCRbyYear;
        //    }
        //}

        #endregion
    }
}