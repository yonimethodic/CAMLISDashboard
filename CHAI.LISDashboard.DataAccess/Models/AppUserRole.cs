using System;
using System.Collections.Generic;

namespace SKDH.AssociationManagment.DataAccess.Models
{
    public partial class AppUserRole
    {
        public int Id { get; set; }
        public int AppUser_Id { get; set; }
        public int Role_Id { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}
