using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

using CHAI.LISDashboard.Enums;
using CHAI.LISDashboard.CoreDomain;

namespace CHAI.LISDashboard.CoreDomain.EID
{
    public partial class RequestRejectedReason :IEntity
    {
        public int Id { get; set; }
        public Nullable<int> RejectedReasonId { get; set; }
        public Nullable<int> RequestId { get; set; }
    }
}
