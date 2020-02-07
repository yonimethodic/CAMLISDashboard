using System;
using System.Collections.Generic;

namespace SKDH.AssociationManagment.DataAccess.Models
{
    public partial class Tab
    {
        public Tab()
        {
            this.PopupMenus = new List<PopupMenu>();
            this.TabRoles = new List<TabRole>();
            this.TaskPans = new List<TaskPan>();
        }

        public int PocModule_Id { get; set; }
        public int Id { get; set; }
        public string TabName { get; set; }
        public int Position { get; set; }
        public string Description { get; set; }
        public virtual ICollection<PopupMenu> PopupMenus { get; set; }
        public virtual ICollection<TabRole> TabRoles { get; set; }
        public virtual ICollection<TaskPan> TaskPans { get; set; }
    }
}
