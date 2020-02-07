using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

using CHAI.LISDashboard.Enums;
using CHAI.LISDashboard.CoreDomain;

namespace CHAI.LISDashboard.CoreDomain.Setting
{
    public partial class VLTherapy:IEntity
    {
        public int Id { get; set; }
        public string Treatment { get; set; }
        public string Drug { get; set; }
    }
}
