using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

using CHAI.LISDashboard.Enums;
using CHAI.LISDashboard.CoreDomain;

namespace CHAI.LISDashboard.CoreDomain.Setting
{
    public partial class Laboratory:IEntity
    {
        public int Id { get; set; }
        public string LaboratoryName { get; set; }
        public Nullable<int> ProvinceId { get; set; }
        public string Telephone { get; set; }
        public string Description { get; set; }
        public string SMSPhoneNumber { get; set; }
        public string LabCode { get; set; }
        public string Email { get; set; }
        public string Emailpassword { get; set; }
    }
}
