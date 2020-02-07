using System;
using System.Collections.Generic;

namespace SKDH.AssociationManagment.DataAccess.Models
{
    public partial class PopupMenu
    {
        public int Tab_Id { get; set; }
        public int Node_Id { get; set; }
        public int Id { get; set; }
        public int Position { get; set; }
        public virtual Node Node { get; set; }
        public virtual Tab Tab { get; set; }
    }
}
