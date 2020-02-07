using System;
using System.Collections.Generic;

namespace SKDH.AssociationManagment.DataAccess.Models
{
    public partial class MoneyCollection
    {
        public int Id { get; set; }
        public Nullable<int> member_Id { get; set; }
        public string Date { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<decimal> AmountDeduct { get; set; }
        public Nullable<decimal> RemainingBalance { get; set; }
    }
}
