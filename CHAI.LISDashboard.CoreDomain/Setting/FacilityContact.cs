using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

using CHAI.LISDashboard.Enums;
using CHAI.LISDashboard.CoreDomain;

namespace CHAI.LISDashboard.CoreDomain.Setting
{
    public partial class FacilityContact:IEntity
    {
        public int Id { get; set; }
        public Nullable<int> FacilityId { get; set; }
        public string ContactName { get; set; }
        public string Position { get; set; }
        public Nullable<int> WardId { get; set; }
        public string Telephone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
    }
}
