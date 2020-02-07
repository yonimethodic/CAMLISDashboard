using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CHAI.LISDashboard.CoreDomain.Report
{
    public class EIDStat
    {
        public int Tot_Initial { get; set; }
        public int Tot_Initial_Positive { get; set; }
        public int Total_Initial_lt2month { get; set; }
        public int No_Sample_Recieved { get; set; }
        public int No_Rejected_Sample { get; set; }
        public int Tot_Tests { get; set; }
        public int No_Positive { get; set; }
        public int No_Negative { get; set; }
        public decimal Initial_Rate { get; set; }
        public decimal Initial_Positive_Rate { get; set; }
        public decimal Initial_lt2months_Rate { get; set; }
        //public decimal RejectedSamples { get; set; }
        //public int Tot_Detected_LE_1000 { get; set; }
        //public int Tot_Detected_G_1000 { get; set; }
        //public decimal Total_Suppressed { get; set; }
        public int Error { get; set; }
    }
}
