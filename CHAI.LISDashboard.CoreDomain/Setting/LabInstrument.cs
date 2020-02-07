using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

using CHAI.LISDashboard.Enums;
using CHAI.LISDashboard.CoreDomain;

namespace CHAI.LISDashboard.CoreDomain.Setting
{
    public partial class LabInstrument:IEntity
    {
        public int Id { get; set; }
        public string LabInstrumentname { get; set; }
        public Nullable<decimal> MinVLcopiesDetection { get; set; }
        public Nullable<decimal> MinVLlogsDetection { get; set; }
        public Nullable<decimal> DBSMinVLcopiesDetection { get; set; }
        public Nullable<decimal> DBSMinVLlogsDetection { get; set; }
        public Nullable<decimal> MaxVLcopiesDetection { get; set; }
        public Nullable<decimal> MaxVLlogsDetection { get; set; }
    }
}
