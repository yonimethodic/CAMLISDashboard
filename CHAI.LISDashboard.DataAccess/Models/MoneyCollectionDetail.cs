using System;
using System.Collections.Generic;

namespace SKDH.AssociationManagment.DataAccess.Models
{
    public partial class MoneyCollectionDetail
    {
        public int Id { get; set; }
        public Nullable<int> MoneyCollection_Id { get; set; }
        public Nullable<int> Customer_Id { get; set; }
        public Nullable<decimal> Amount { get; set; }
    }
}
