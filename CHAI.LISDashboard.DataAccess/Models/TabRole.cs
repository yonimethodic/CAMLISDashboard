using System;
using System.Collections.Generic;

namespace SKDH.AssociationManagment.DataAccess.Models
{
    public partial class TabRole
    {
        public int Tab_Id { get; set; }
        public int Role_Id { get; set; }
        public int Id { get; set; }
        public bool ViewAllowed { get; set; }
        public virtual Tab Tab { get; set; }
    }
}
