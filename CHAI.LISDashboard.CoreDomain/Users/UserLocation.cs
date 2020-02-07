using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using CHAI.LISDashboard.Enums;
using CHAI.LISDashboard.Shared;
using CHAI.LISDashboard.CoreDomain.Admins;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using CHAI.LISDashboard.CoreDomain.Setting;

namespace CHAI.LISDashboard.CoreDomain.Users
{
    public class UserLocation : IEntity
    {

        public int Id { get; set; }
        public string LabCode { get; set; }
        public virtual AppUser User { get; set; }
        public virtual Province province {get;set;}
        public virtual District District { get; set; }
        public virtual LLG LLG { get; set; }
        public virtual Facility Facility { get; set; }

        //Added by Zay Soe on 15_Jan_2019
        //public virtual Laboratory Laboratory { get; set; }
    }
}
