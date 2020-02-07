using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

using CHAI.LISDashboard.Enums;
using CHAI.LISDashboard.CoreDomain;

namespace CHAI.LISDashboard.CoreDomain.Setting
{
    public partial class TrackingOption:IEntity
    {
        public int Id { get; set; }
        public string TestType { get; set; }
        public string TrackingCode { get; set; }
        public string TrackingCodeDescription { get; set; }
    }
}
