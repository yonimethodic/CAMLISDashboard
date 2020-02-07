using System;
using System.Collections.Generic;

namespace SKDH.AssociationManagment.DataAccess.Models
{
    public partial class NodeRole
    {
        public int Node_Id { get; set; }
        public int Role_Id { get; set; }
        public int Id { get; set; }
        public bool ViewAllowed { get; set; }
        public bool EditAllowed { get; set; }
        public virtual Node Node { get; set; }
    }
}
