using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

using CHAI.LISDashboard.Enums;
using CHAI.LISDashboard.CoreDomain;

namespace CHAI.LISDashboard.CoreDomain.Setting
{
    public partial class Ward:IEntity
    {
        public int Id { get; set; }
        public Nullable<int> FacilityId { get; set; }
        public string WardName { get; set; }
    }
}
