using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

using CHAI.LISDashboard.Enums;
using CHAI.LISDashboard.CoreDomain;

namespace CHAI.LISDashboard.CoreDomain.Setting
{
    public partial class RejectedReason:IEntity
    {
        public int Id { get; set; }
        public string Reason { get; set; }
        public string TestType { get; set; }
    }
}
