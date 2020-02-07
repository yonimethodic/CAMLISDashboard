using System;
using System.Collections.Generic;

namespace SKDH.AssociationManagment.DataAccess.Models
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string EmpFullName { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public Nullable<decimal> salary { get; set; }
        public string EmployeeType { get; set; }
    }
}
