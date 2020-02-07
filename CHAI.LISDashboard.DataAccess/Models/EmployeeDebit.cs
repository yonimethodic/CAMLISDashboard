using System;
using System.Collections.Generic;

namespace SKDH.AssociationManagment.DataAccess.Models
{
    public partial class EmployeeDebit
    {
        public int Id { get; set; }
        public Nullable<int> Employee_Id { get; set; }
        public Nullable<decimal> Debit { get; set; }
    }
}
