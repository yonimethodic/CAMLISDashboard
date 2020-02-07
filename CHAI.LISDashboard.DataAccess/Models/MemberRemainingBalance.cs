using System;
using System.Collections.Generic;

namespace SKDH.AssociationManagment.DataAccess.Models
{
    public partial class MemberRemainingBalance
    {
        public int Id { get; set; }
        public Nullable<int> member_Id { get; set; }
        public Nullable<decimal> RemainingBalance { get; set; }
    }
}
