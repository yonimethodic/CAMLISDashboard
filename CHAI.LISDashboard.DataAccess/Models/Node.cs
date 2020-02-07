using System;
using System.Collections.Generic;

namespace SKDH.AssociationManagment.DataAccess.Models
{
    public partial class Node
    {
        public Node()
        {
            this.NodeRoles = new List<NodeRole>();
            this.PopupMenus = new List<PopupMenu>();
            this.TaskPanNodes = new List<TaskPanNode>();
        }

        public int PocModule_Id { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string FilePath { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public string PageId { get; set; }
        public virtual ICollection<NodeRole> NodeRoles { get; set; }
        public virtual ICollection<PopupMenu> PopupMenus { get; set; }
        public virtual ICollection<TaskPanNode> TaskPanNodes { get; set; }
    }
}
