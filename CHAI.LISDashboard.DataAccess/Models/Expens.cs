using System;
using System.Collections.Generic;

namespace SKDH.AssociationManagment.DataAccess.Models
{
    public partial class Expens
    {
        public int Id { get; set; }
        public Nullable<int> Transaction_Id { get; set; }
        public int TypeId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public Nullable<int> Casher { get; set; }
        public virtual ExpenseType ExpenseType { get; set; }
    }
}
