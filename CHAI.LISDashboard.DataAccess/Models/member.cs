using System;
using System.Collections.Generic;

namespace SKDH.AssociationManagment.DataAccess.Models
{
    public partial class member
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Region_Id { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public decimal PaymentForASS { get; set; }
    }
}
