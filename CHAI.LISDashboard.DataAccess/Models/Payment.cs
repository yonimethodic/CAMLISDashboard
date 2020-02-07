using System;
using System.Collections.Generic;

namespace SKDH.AssociationManagment.DataAccess.Models
{
    public partial class Payment
    {
        public int Id { get; set; }
        public Nullable<int> Transaction_Id { get; set; }
        public int member_Id { get; set; }
        public decimal KG { get; set; }
        public decimal AmountDate { get; set; }
        public decimal AmountBack { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Paid { get; set; }
        public decimal Remaining { get; set; }
        public string PaymentPlaceType { get; set; }
        public Nullable<int> Casher { get; set; }
    }
}
