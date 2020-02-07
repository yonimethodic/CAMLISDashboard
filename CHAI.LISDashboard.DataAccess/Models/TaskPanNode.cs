using System;
using System.Collections.Generic;

namespace SKDH.AssociationManagment.DataAccess.Models
{
    public partial class TaskPanNode
    {
        public int TaskPan_Id { get; set; }
        public int Node_Id { get; set; }
        public int Id { get; set; }
        public int Position { get; set; }
        public virtual Node Node { get; set; }
        public virtual TaskPan TaskPan { get; set; }
    }
}
