using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using CHAI.LISDashboard.Shared;
using System.Configuration;
using CHAI.LISDashboard.Shared.Settings;

namespace CHAI.LISDashboard.CoreDomain.DataAccess
{
    public class ReportDao
    {
       
       // public DataSet DailyPaymentReport(string datefrom, string dateto)
       // {
       //     string connstring = ConfigurationManager.ConnectionStrings["SKDHBuildingManagementReportConnectionString"].ToString();
       //     using (SqlConnection cn = new SqlConnection(connstring))
       //     {
       //         cn.Open();
       //         SqlCommand cmd = new SqlCommand();
       //         cmd.Connection = cn;
       //         cmd.CommandType = CommandType.StoredProcedure;
       //         cmd.CommandText = "GetPayment";
       //         if (datefrom != "")
       //         {
       //             cmd.Parameters.AddWithValue("@DateFrom", Convert.ToDateTime(datefrom));
       //         }
       //         if (dateto != "")
       //         {
       //             cmd.Parameters.AddWithValue("@DateTo", Convert.ToDateTime(dateto));
       //         }
                
       //         var da = new SqlDataAdapter(cmd);
       //         var ds = new DataSet();
       //         da.Fill(ds);
       //         cn.Close();
       //         return ds;
       //     }
       // }
       //// public DataSet GetmembersPaymentatsite(DateTime TransactionDate)
       // public DataSet GetmembersPaymentatsite(DateTime TransactionDate,int regionid)
       // {
       //     string connstring = ConfigurationManager.ConnectionStrings["SKDHBuildingManagementReportConnectionString"].ToString();
       //     using (SqlConnection cn = new SqlConnection(connstring))
       //     {
       //         cn.Open();
       //         SqlCommand cmd = new SqlCommand();
       //         cmd.Connection = cn;
       //         cmd.CommandType = CommandType.TableDirect;
       //         cmd.CommandText = "GetmemberPaymentatsite";
       //         cmd.Parameters.AddWithValue("@TransactionDate", TransactionDate);
       //         cmd.Parameters.AddWithValue("@RegionId", regionid);

       //         var da = new SqlDataAdapter(cmd);
       //         var ds = new DataSet();
       //         da.Fill(ds);
       //         cn.Close();
       //         return ds;
       //     }
       // }
       // public DataSet GetMemberCustomer(int regionid)
       // {
       //     string connstring = ConfigurationManager.ConnectionStrings["SKDHBuildingManagementReportConnectionString"].ToString();
       //     using (SqlConnection cn = new SqlConnection(connstring))
       //     {
       //         cn.Open();
       //         SqlCommand cmd = new SqlCommand();
       //         cmd.Connection = cn;
       //         cmd.CommandType = CommandType.StoredProcedure;
       //         cmd.CommandText = "GetMembersCustomers";
       //         cmd.Parameters.AddWithValue("@RegionId", regionid);

       //         var da = new SqlDataAdapter(cmd);
       //         var ds = new DataSet();
       //         da.Fill(ds);
       //         cn.Close();
       //         return ds;
       //     }
       // }
        
       // public DataSet GetMemberPayment(DateTime TransactionDate, int regionid)
       // {
       //     string connstring = ConfigurationManager.ConnectionStrings["SKDHBuildingManagementReportConnectionString"].ToString();
       //     using (SqlConnection cn = new SqlConnection(connstring))
       //     {
       //         cn.Open();
       //         SqlCommand cmd = new SqlCommand();
       //         cmd.Connection = cn;
       //         cmd.CommandType = CommandType.StoredProcedure;
       //         cmd.CommandText = "[GetPaymentAssociation]";
       //         cmd.Parameters.AddWithValue("@TransactionDate", TransactionDate);
       //         cmd.Parameters.AddWithValue("@Region", regionid);


       //         var da = new SqlDataAdapter(cmd);
       //         var ds = new DataSet();
       //         da.Fill(ds);
       //         cn.Close();
       //         return ds;
       //     }
       // }
       // public DataSet GetmemberHistory(int memberId)
       // {
       //     string connstring = ConfigurationManager.ConnectionStrings["SKDHBuildingManagementReportConnectionString"].ToString();
       //     using (SqlConnection cn = new SqlConnection(connstring))
       //     {
       //         cn.Open();
       //         SqlCommand cmd = new SqlCommand();
       //         cmd.Connection = cn;
       //         cmd.CommandType = CommandType.StoredProcedure;
       //         cmd.CommandText = "GetmemberHistory";
       //         cmd.Parameters.AddWithValue("@MemberId", memberId);

       //         var da = new SqlDataAdapter(cmd);
       //         var ds = new DataSet();
       //         da.Fill(ds);
       //         cn.Close();
       //         return ds;
       //     }
       // }
       // public DataSet GetKiloEnteredmembers(DateTime TransactionDate)
       // {
       //     string connstring = ConfigurationManager.ConnectionStrings["SKDHBuildingManagementReportConnectionString"].ToString();
       //     using (SqlConnection cn = new SqlConnection(connstring))
       //     {
       //         cn.Open();
       //         SqlCommand cmd = new SqlCommand();
       //         cmd.Connection = cn;
       //         cmd.CommandType = CommandType.StoredProcedure;
       //         cmd.CommandText = "GetKiloenteredmember";
       //         cmd.Parameters.AddWithValue("@TransactionDate", TransactionDate);


       //         var da = new SqlDataAdapter(cmd);
       //         var ds = new DataSet();
       //         da.Fill(ds);
       //         cn.Close();
       //         return ds;
       //     }
       // }
       // public DataSet GetLedgere(DateTime TransactionDate)
       // {
       //     string connstring = ConfigurationManager.ConnectionStrings["SKDHBuildingManagementReportConnectionString"].ToString();
       //     using (SqlConnection cn = new SqlConnection(connstring))
       //     {
       //         cn.Open();
       //         SqlCommand cmd = new SqlCommand();
       //         cmd.Connection = cn;
       //         cmd.CommandType = CommandType.StoredProcedure;
       //         cmd.CommandText = "GetLedgere";
       //         cmd.Parameters.AddWithValue("@TransactionDate", TransactionDate);


       //         var da = new SqlDataAdapter(cmd);
       //         var ds = new DataSet();
       //         da.Fill(ds);
       //         cn.Close();
       //         return ds;
       //     }
       // }
       // public DataSet MoneyCollectionReport(string datefrom, string dateto)
       // {
       //     string connstring = ConfigurationManager.ConnectionStrings["SKDHBuildingManagementReportConnectionString"].ToString();
       //     using (SqlConnection cn = new SqlConnection(connstring))
       //     {
       //         cn.Open();
       //         SqlCommand cmd = new SqlCommand();
       //         cmd.Connection = cn;
       //         cmd.CommandType = CommandType.StoredProcedure;
       //         cmd.CommandText = "GetMoneyCollection";
       //         if (datefrom != "")
       //         {
       //             cmd.Parameters.AddWithValue("@DateFrom", Convert.ToDateTime(datefrom));
       //         }
       //         if (dateto != "")
       //         {
       //             cmd.Parameters.AddWithValue("@DateTo", Convert.ToDateTime(dateto));
       //         }
               
       //         var da = new SqlDataAdapter(cmd);
       //         var ds = new DataSet();
       //         da.Fill(ds);
       //         cn.Close();
       //         return ds;
       //     }
       // }
       // public DataSet EmployeePerdimeReport(string datefrom, string dateto)
       // {
       //     string connstring = ConfigurationManager.ConnectionStrings["SKDHBuildingManagementReportConnectionString"].ToString();
       //     using (SqlConnection cn = new SqlConnection(connstring))
       //     {
       //         cn.Open();
       //         SqlCommand cmd = new SqlCommand();
       //         cmd.Connection = cn;
       //         cmd.CommandType = CommandType.StoredProcedure;
       //         cmd.CommandText = "GetEmployeePerdime";
       //         if (datefrom != "")
       //         {
       //             cmd.Parameters.AddWithValue("@DateFrom", Convert.ToDateTime(datefrom));
       //         }
       //         if (dateto != "")
       //         {
       //             cmd.Parameters.AddWithValue("@DateTo", Convert.ToDateTime(dateto));
       //         }
             
       //         var da = new SqlDataAdapter(cmd);
       //         var ds = new DataSet();
       //         da.Fill(ds);
       //         cn.Close();
       //         return ds;
       //     }
       // }

       // public DataSet MaxDebitReport()
       // {
       //     string connstring = ConfigurationManager.ConnectionStrings["SKDHBuildingManagementReportConnectionString"].ToString();
       //     using (SqlConnection cn = new SqlConnection(connstring))
       //     {
       //         cn.Open();
       //         SqlCommand cmd = new SqlCommand();
       //         cmd.Connection = cn;
       //         cmd.CommandType = CommandType.StoredProcedure;
       //         cmd.CommandText = "GetMemebrwithMaxDebt";
               

       //         var da = new SqlDataAdapter(cmd);
       //         var ds = new DataSet();
       //         da.Fill(ds);
       //         cn.Close();
       //         return ds;
       //     }
       // }
       // public DataSet DailyExpenseReport(string datefrom, string dateto)
       // {
       //     string connstring = ConfigurationManager.ConnectionStrings["SKDHBuildingManagementReportConnectionString"].ToString();
       //     using (SqlConnection cn = new SqlConnection(connstring))
       //     {
       //         cn.Open();
       //         SqlCommand cmd = new SqlCommand();
       //         cmd.Connection = cn;
       //         cmd.CommandType = CommandType.StoredProcedure;
       //         cmd.CommandText = "GetExpenses";
       //         if (datefrom != "")
       //         {
       //             cmd.Parameters.AddWithValue("@DateFrom", Convert.ToDateTime(datefrom));
       //         }
       //         if (dateto != "")
       //         {
       //             cmd.Parameters.AddWithValue("@DateTo", Convert.ToDateTime(dateto));
       //         }
       //         var da = new SqlDataAdapter(cmd);
       //         var ds = new DataSet();
       //         da.Fill(ds);
       //         cn.Close();
       //         return ds;
       //     }
       // }

       // public DataSet TOTReport(string datefrom, string dateto)
       // {
       //     string connstring = ConfigurationManager.ConnectionStrings["SKDHBuildingManagementReportConnectionString"].ToString();
       //     using (SqlConnection cn = new SqlConnection(connstring))
       //     {
       //         cn.Open();
       //         SqlCommand cmd = new SqlCommand();
       //         cmd.Connection = cn;
       //         cmd.CommandType = CommandType.StoredProcedure;
       //         cmd.CommandText = "GetTOTSum";
       //         if (datefrom != "")
       //         {
       //             cmd.Parameters.AddWithValue("@DateFrom", Convert.ToDateTime(datefrom));
       //         }
       //         if (dateto != "")
       //         {
       //             cmd.Parameters.AddWithValue("@DateTo", Convert.ToDateTime(dateto));
       //         }

       //         var da = new SqlDataAdapter(cmd);
       //         var ds = new DataSet();
       //         da.Fill(ds);
       //         cn.Close();
       //         return ds;
       //     }
       // }

        public DataSet EIDReport()
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "EIDGetAllListforDetail";

                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                cn.Close();
                return ds;
            }
        }

        //Added by ZaySoe on 19_Dec_2018
        public DataSet EIDReport(int ProvinceId, int FacilityId, string Test, 
            string CollectedDateFrom, string CollectedDateTo, string ReceivedDateFrom, string ReceivedDateTo, 
            string specimenStatus, int NumberOfTests, string LabNumber, string LabNumberTo, string PatientCode, int Year, string labCode)
        {            
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "EIDGetAllListforDetailByCriteria";
                cmd.Parameters.AddWithValue("@ProvinceId", ProvinceId);
                cmd.Parameters.AddWithValue("@FacilityId", FacilityId);
                cmd.Parameters.AddWithValue("@Test", Test);
                cmd.Parameters.AddWithValue("@CollectedDateFrom", CollectedDateFrom);
                cmd.Parameters.AddWithValue("@CollectedDateTo", CollectedDateTo);
                cmd.Parameters.AddWithValue("@RecievedDateFrom", ReceivedDateFrom);
                cmd.Parameters.AddWithValue("@RecievedDateTo", ReceivedDateTo);                
                cmd.Parameters.AddWithValue("@SpecimenStatus", specimenStatus);
                cmd.Parameters.AddWithValue("@NumberOfTests", NumberOfTests);
                cmd.Parameters.AddWithValue("@LabNumber", LabNumber);
                cmd.Parameters.AddWithValue("@LabNumberTo", LabNumberTo);
                cmd.Parameters.AddWithValue("@PatientCode", PatientCode);
                cmd.Parameters.AddWithValue("@Year", Year);
                cmd.Parameters.AddWithValue("@LabCode", labCode);
                
                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();                
                da.Fill(ds);
                int rows = ds.Tables[0].Rows.Count;
                cn.Close();
                return ds;                
            }
        }

        public DataSet VLReport()
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "VLGetAllListforDetail";

                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                cn.Close();
                return ds;
            }
        }

        //Added by ZaySoe on 19_Dec_2018
        public DataSet VLReport(int ProvinceId, int FacilityId, string Test,
            string CollectedDateFrom, string CollectedDateTo, string ReceivedDateFrom, string ReceivedDateTo,
            string specimenStatus, int NumberOfTests, string LabNumber, string LabNumberTo, string PatientCode, int Year,
            string ARTNumber, string patientType, string labCode)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "VLGetAllListforDetailByCriteria";
                cmd.Parameters.AddWithValue("@ProvinceId", ProvinceId);
                cmd.Parameters.AddWithValue("@FacilityId", FacilityId);
                cmd.Parameters.AddWithValue("@Test", Test);
                cmd.Parameters.AddWithValue("@CollectedDateFrom", CollectedDateFrom);
                cmd.Parameters.AddWithValue("@CollectedDateTo", CollectedDateTo);
                cmd.Parameters.AddWithValue("@RecievedDateFrom", ReceivedDateFrom);
                cmd.Parameters.AddWithValue("@RecievedDateTo", ReceivedDateTo);
                cmd.Parameters.AddWithValue("@SpecimenStatus", specimenStatus);
                cmd.Parameters.AddWithValue("@NumberOfTests", NumberOfTests);
                cmd.Parameters.AddWithValue("@LabNumber", LabNumber);
                cmd.Parameters.AddWithValue("@LabNumberTo", LabNumberTo);
                cmd.Parameters.AddWithValue("@PatientCode", PatientCode);
                cmd.Parameters.AddWithValue("@Year", Year);
                cmd.Parameters.AddWithValue("@ARTNumber", ARTNumber);
                cmd.Parameters.AddWithValue("@PatientType", patientType);
                cmd.Parameters.AddWithValue("@LabCode", labCode);

                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                int rows = ds.Tables[0].Rows.Count;
                cn.Close();
                return ds;
            }
        }

        public DataSet GetSyncTotal()
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetSyncTotal";

                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                cn.Close();
                return ds;
            }
        }

        public DataSet GetDataEntryPerformance()
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetDataEntryPerformance";

                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                cn.Close();
                return ds;
            }
        }

        public DataSet MembersReport()
        {
            string connstring = (ConfigurationManager.ConnectionStrings["SKDHBuildingManagementReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetMembers";
               
                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                cn.Close();
                return ds;
            }
        }

        public DataSet GetUserLocationsInfo(int userId)
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetUserLocationInfo";
                cmd.Parameters.AddWithValue("@user_id", userId);
                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                cn.Close();
                //var eidIntialPCR = ds.Tables[0].AsEnumerable().Select(
                //    dataRow => new ArrayList {
                //        dataRow.Field<int>("UserId"),
                //        dataRow.Field<string>("UserName"),
                //        //dataRow.Field<int>("ProvinceId"),
                //        //dataRow.Field<string>("ProvinceName"),
                //        //dataRow.Field<int>("DistrictId"),
                //        //dataRow.Field<string>("DistrictName"),
                //        //dataRow.Field<int>("LLGId"),
                //        //dataRow.Field<string>("LLGName"),
                //        //dataRow.Field<int>("FacilityId"),
                //        //dataRow.Field<string>("FacilityName"),
                //        //dataRow.Field<int>("LabId"),
                //        //dataRow.Field<string>("LaboratoryName"),                        
                //        //dataRow.Field<bool>("IsFacility")
                //    }).ToList();
                //return eidIntialPCR;
                return ds;
            }
        }        

        public IList GetLaboratories()
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetLaboratories";

                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                cn.Close();

                var testResult = ds.Tables[0].AsEnumerable().Select(
                    dataRow => new ArrayList {
                        dataRow.Field<int>("Id"),
                        dataRow.Field<string>("LabCode"),
                        dataRow.Field<string>("LaboratoryName"),
                        dataRow.Field<string>("Description") }).ToList();
                return testResult;
            }
        }

        public DataSet GetLabDataEntryPerformanceList()
        {
            string connstring = TechnicalSettings.Decrypt(ConfigurationManager.ConnectionStrings["LISReportConnectionString"].ToString());
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetLabDataEntryPerformanceList";

                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                cn.Close();
                return ds;
            }
        }



        #region "VL Report"
        public DataSet VLLabSummary(int facility, int user_id, string role, string DateFrom, string DateTo, string CollectionFrom, string CollectionTo, string ProvinceId, string FacilityType1,string LabCode)
        {
            string connstring = TechnicalSettings.Decrypt(TechnicalConfig.GetConfiguration()["ConnectionString"].ToString());

            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "VLLabSummary";

                cmd.Parameters.AddWithValue("@facility", facility);
                cmd.Parameters.AddWithValue("@type", role);
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@DateFrom", DateFrom);
                cmd.Parameters.AddWithValue("@DateTo", DateTo);
                cmd.Parameters.AddWithValue("@CollectionFrom", CollectionFrom);
                cmd.Parameters.AddWithValue("@CollectionTo", CollectionTo);
                cmd.Parameters.AddWithValue("@ProvincesId", ProvinceId);
                cmd.Parameters.AddWithValue("@FacilityType1", FacilityType1);
                cmd.Parameters.AddWithValue("@LabCode", LabCode);
                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                cn.Close();
                return ds;
            }
        }

        public DataSet VLTestedSummary(int facility, int user_id, string role, string ReceiveFrom, string ReceiveTo, string CollectFrom, string CollectTo, string TestedFrom, string TestedTo, string ProvinceId, string FacilityType1, string LabCode)
        {
            string connstring = TechnicalSettings.Decrypt(TechnicalConfig.GetConfiguration()["ConnectionString"].ToString());

            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetRptVLTestedSummary";
                cmd.Parameters.AddWithValue("@facility", facility);
                cmd.Parameters.AddWithValue("@type", role);
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@provinceIDs", ProvinceId);
                cmd.Parameters.AddWithValue("@facilityTypes", FacilityType1);
                cmd.Parameters.AddWithValue("@ReceiveFrom", ReceiveFrom);
                cmd.Parameters.AddWithValue("@ReceiveTo", ReceiveTo);
                cmd.Parameters.AddWithValue("@CollectFrom", CollectFrom);
                cmd.Parameters.AddWithValue("@CollectTo", CollectTo);
                cmd.Parameters.AddWithValue("@TestedFrom", TestedFrom);
                cmd.Parameters.AddWithValue("@TestedTo", TestedTo);
                cmd.Parameters.AddWithValue("@LabCode", LabCode);
                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                cn.Close();
                return ds;
            }
        }

        public DataSet VLTestByAgeOutcome(int facility, int user_id, string role, string DateFrom, string DateTo, string CollectFrom, string CollectTo, string ProvinceId, string FacilityType1, string LabCode)
        {
            string connstring = TechnicalSettings.Decrypt(TechnicalConfig.GetConfiguration()["ConnectionString"].ToString());

            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetRptVLTestByAgeOutcome";
                cmd.Parameters.AddWithValue("@facility", facility);
                cmd.Parameters.AddWithValue("@type", role);
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@provinceIDs", ProvinceId);
                cmd.Parameters.AddWithValue("@facilityTypes", FacilityType1);
                cmd.Parameters.AddWithValue("@CollectFrom", CollectFrom);
                cmd.Parameters.AddWithValue("@CollectTo", CollectTo);
                cmd.Parameters.AddWithValue("@DateFrom", DateFrom);
                cmd.Parameters.AddWithValue("@DateTo", DateTo);
                cmd.Parameters.AddWithValue("@LabCode", LabCode);
                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                cn.Close();
                return ds;
            }
        }

        public DataSet VLPatientTestedByAge(int facility, int user_id, string role, string ReceiveFrom, string ReceiveTo, string CollectFrom, string CollectTo, string ProvinceId, string FacilityType1, string LabCode, string filter, string resultFormat)
        {
            string connstring = TechnicalSettings.Decrypt(TechnicalConfig.GetConfiguration()["ConnectionString"].ToString());

            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "VLPatientTestedByAge_" + resultFormat;
                cmd.Parameters.AddWithValue("@facility", facility);
                cmd.Parameters.AddWithValue("@type", role);
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@provinceIDs", ProvinceId);
                cmd.Parameters.AddWithValue("@facilityTypes", FacilityType1);                
                cmd.Parameters.AddWithValue("@ReceiveFrom", ReceiveFrom);
                cmd.Parameters.AddWithValue("@ReceiveTo", ReceiveTo);
                cmd.Parameters.AddWithValue("@CollectFrom", CollectFrom);
                cmd.Parameters.AddWithValue("@CollectTo", CollectTo);
                cmd.Parameters.AddWithValue("@LabCode", LabCode);
                cmd.Parameters.AddWithValue("@filter", filter);
                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                cn.Close();
                return ds;
            }
        }

        public DataSet VLPatientTestedByGender(int facility, int user_id, string role, string ReceiveFrom, string ReceiveTo, string CollectFrom, string CollectTo, string ProvinceId, string FacilityType1, string LabCode, string filter, string resultFormat)
        {
            string connstring = TechnicalSettings.Decrypt(TechnicalConfig.GetConfiguration()["ConnectionString"].ToString());

            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "VLPatientTestedByGender_" + resultFormat;
                cmd.Parameters.AddWithValue("@facility", facility);
                cmd.Parameters.AddWithValue("@type", role);
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@provinceIDs", ProvinceId);
                cmd.Parameters.AddWithValue("@facilityTypes", FacilityType1);                
                cmd.Parameters.AddWithValue("@ReceiveFrom", ReceiveFrom);
                cmd.Parameters.AddWithValue("@ReceiveTo", ReceiveTo);
                cmd.Parameters.AddWithValue("@CollectFrom", CollectFrom);
                cmd.Parameters.AddWithValue("@CollectTo", CollectTo);
                cmd.Parameters.AddWithValue("@LabCode", LabCode);
                cmd.Parameters.AddWithValue("@filter", filter);
                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                cn.Close();
                return ds;
            }
        }

        public DataSet VLPatientTestedByReason(int facility, int user_id, string role, string ReceiveFrom, string ReceiveTo, string CollectFrom, string CollectTo, string ProvinceId, string FacilityType1, string LabCode, string filter, string resultFormat)
        {
            string connstring = TechnicalSettings.Decrypt(TechnicalConfig.GetConfiguration()["ConnectionString"].ToString());

            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "VLPatientTestedByReasonForTest_" + resultFormat;
                cmd.Parameters.AddWithValue("@facility", facility);
                cmd.Parameters.AddWithValue("@type", role);
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@provinceIDs", ProvinceId);
                cmd.Parameters.AddWithValue("@facilityTypes", FacilityType1);                
                cmd.Parameters.AddWithValue("@ReceiveFrom", ReceiveFrom);
                cmd.Parameters.AddWithValue("@ReceiveTo", ReceiveTo);
                cmd.Parameters.AddWithValue("@CollectFrom", CollectFrom);
                cmd.Parameters.AddWithValue("@CollectTo", CollectTo);
                cmd.Parameters.AddWithValue("@LabCode", LabCode);
                cmd.Parameters.AddWithValue("@filter", filter);
                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                cn.Close();
                return ds;
            }
        }

        public DataSet GetRptARTMonthly(int user_id, string role, int year, int month, string ProvinceId, string FacilityType1, string LabCode, string ReportSerial)
        {
            string connstring = TechnicalSettings.Decrypt(TechnicalConfig.GetConfiguration()["ConnectionString"].ToString());

            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetRptARTMonthly";                
                cmd.Parameters.AddWithValue("@type", role);
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@provinceIDs", ProvinceId);
                cmd.Parameters.AddWithValue("@facilityTypes", FacilityType1);
                cmd.Parameters.AddWithValue("@Year", year);
                cmd.Parameters.AddWithValue("@Month", month);                
                cmd.Parameters.AddWithValue("@LabCode", LabCode);
                cmd.Parameters.AddWithValue("@ReportSerial", ReportSerial);
                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                cn.Close();
                return ds;
            }
        }

        public DataSet GetRptARTMonthlyByIndicators(int user_id, string role, int year, int month, string ProvinceId, string FacilityType1, string LabCode)
        {
            string connstring = TechnicalSettings.Decrypt(TechnicalConfig.GetConfiguration()["ConnectionString"].ToString());

            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetRptARTMonthlyByIndicators";
                cmd.Parameters.AddWithValue("@type", role);
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@provinceIDs", ProvinceId);
                cmd.Parameters.AddWithValue("@facilityTypes", FacilityType1);
                cmd.Parameters.AddWithValue("@Year", year);
                cmd.Parameters.AddWithValue("@Month", month);
                cmd.Parameters.AddWithValue("@LabCode", LabCode);                
                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                cn.Close();
                return ds;
            }
        }

        #endregion

        #region "EID Report"

        public DataSet EIDSummary(int facility, int user_id, string role, string ReceiveFrom, string ReceiveTo, string CollectFrom, string CollectTo, string ProvinceId, string FacilityType1, string LabCode)
        {
            string connstring = TechnicalSettings.Decrypt(TechnicalConfig.GetConfiguration()["ConnectionString"].ToString());

            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetRptEIDLabSummary";
                cmd.Parameters.AddWithValue("@facility", facility);
                cmd.Parameters.AddWithValue("@type", role);
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@provinceIDs", ProvinceId);
                cmd.Parameters.AddWithValue("@facilityTypes", FacilityType1);
                cmd.Parameters.AddWithValue("@ReceiveFrom", ReceiveFrom);
                cmd.Parameters.AddWithValue("@ReceiveTo", ReceiveTo);
                cmd.Parameters.AddWithValue("@CollectFrom", CollectFrom);
                cmd.Parameters.AddWithValue("@CollectTo", CollectTo);                
                cmd.Parameters.AddWithValue("@LabCode", LabCode);
                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                cn.Close();
                return ds;
            }
        }

        public DataSet EIDTestedSummary(int facility, int user_id, string role, string ReceiveFrom, string ReceiveTo, string CollectFrom, string CollectTo, string TestedFrom, string TestedTo, string ProvinceId, string FacilityType1, string LabCode)
        {
            string connstring = TechnicalSettings.Decrypt(TechnicalConfig.GetConfiguration()["ConnectionString"].ToString());

            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetRptEIDTestedSummary";
                cmd.Parameters.AddWithValue("@facility", facility);
                cmd.Parameters.AddWithValue("@type", role);
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@provinceIDs", ProvinceId);
                cmd.Parameters.AddWithValue("@facilityTypes", FacilityType1);
                cmd.Parameters.AddWithValue("@ReceiveFrom", ReceiveFrom);
                cmd.Parameters.AddWithValue("@ReceiveTo", ReceiveTo);
                cmd.Parameters.AddWithValue("@CollectFrom", CollectFrom);
                cmd.Parameters.AddWithValue("@CollectTo", CollectTo);
                cmd.Parameters.AddWithValue("@TestedFrom", TestedFrom);
                cmd.Parameters.AddWithValue("@TestedTo", TestedTo);
                cmd.Parameters.AddWithValue("@LabCode", LabCode);
                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                cn.Close();
                return ds;
            }
        }

        #endregion
    }
}
