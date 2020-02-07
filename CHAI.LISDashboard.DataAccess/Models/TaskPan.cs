using System;
using System.Collections.Generic;

namespace SKDH.AssociationManagment.DataAccess.Models
{
    public partial class TaskPan
    {
        public TaskPan()
        {
            this.TaskPanNodes = new List<TaskPanNode>();
        }

        public int Tab_Id { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public int Position { get; set; }
        public string ImagePath { get; set; }
        public virtual Tab Tab { get; set; }
        public virtual ICollection<TaskPanNode> TaskPanNodes { get; set; }
    }
}
