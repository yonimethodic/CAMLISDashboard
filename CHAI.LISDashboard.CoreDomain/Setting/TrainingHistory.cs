using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

using CHAI.LISDashboard.Enums;
using CHAI.LISDashboard.CoreDomain;

namespace CHAI.LISDashboard.CoreDomain.Setting
{
    public partial class TrainingHistory:IEntity
    {
        public int Id { get; set; }
        public Nullable<int> FacilityId { get; set; }
        public string TrainingName { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string TrainerName { get; set; }
        public string Description { get; set; }
    }
}
