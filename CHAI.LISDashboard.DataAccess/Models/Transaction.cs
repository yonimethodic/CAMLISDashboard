using System;
using System.Collections.Generic;

namespace SKDH.AssociationManagment.DataAccess.Models
{
    public partial class Transaction
    {
        public int Id { get; set; }
        public Nullable<System.DateTime> TransactionDate { get; set; }
        public string TransactionNo { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateUpdated { get; set; }
    }
}
