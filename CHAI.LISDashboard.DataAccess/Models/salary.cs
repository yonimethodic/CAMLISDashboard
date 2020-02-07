using System;
using System.Collections.Generic;

namespace SKDH.AssociationManagment.DataAccess.Models
{
    public partial class salary
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public int Employee_Id { get; set; }
        public decimal NoDays { get; set; }
        public decimal TotalDed { get; set; }
        public decimal Net { get; set; }
        public Nullable<System.DateTime> AMDate { get; set; }
    }
}
