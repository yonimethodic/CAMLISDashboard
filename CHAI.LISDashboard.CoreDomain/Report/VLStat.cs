using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CHAI.LISDashboard.CoreDomain.Report
{
    public class VLStat
    {
        public int Tot_Tests { get; set; }
        public decimal RejectedSamples { get; set; }
        public int Tot_Detected_LE_1000 { get; set; }
        public int Tot_Detected_G_1000 { get; set; }
        public decimal Total_Suppressed { get; set; }
        public decimal Rate_Detected_LE_1000 { get; set; }
        public decimal Rate_Detected_G_1000 { get; set; }
        public decimal Rate_Error { get; set; }
        public int Error { get; set; }
    }
}
