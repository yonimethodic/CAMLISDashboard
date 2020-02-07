using System;
using System.Collections.Generic;

namespace SKDH.AssociationManagment.DataAccess.Models
{
    public partial class AssignedEmployeeVehicle
    {
        public int Id { get; set; }
        public Nullable<int> Transaction_Id { get; set; }
        public Nullable<int> Employee_Id { get; set; }
        public Nullable<int> Vehicle_Id { get; set; }
    }
}
