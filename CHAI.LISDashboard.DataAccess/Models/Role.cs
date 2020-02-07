using System;
using System.Collections.Generic;

namespace SKDH.AssociationManagment.DataAccess.Models
{
    public partial class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> PermissionLevel { get; set; }
    }
}
