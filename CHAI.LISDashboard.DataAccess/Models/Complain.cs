using System;
using System.Collections.Generic;

namespace SKDH.AssociationManagment.DataAccess.Models
{
    public partial class Complain
    {
        public int Id { get; set; }
        public Nullable<int> Transaction_Id { get; set; }
        public string Reason { get; set; }
        public Nullable<int> member_Id { get; set; }
        public string LostKG { get; set; }
        public Nullable<decimal> LostAmount { get; set; }
        public string LostBy { get; set; }
    }
}
