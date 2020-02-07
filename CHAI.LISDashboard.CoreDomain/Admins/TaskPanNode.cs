
using System;
using System.Collections.Generic;

namespace CHAI.LISDashboard.CoreDomain.Admins
{
    public class TaskPanNode : IEntity
    {
        public int Id { get; set; }
        public int Position { get; set; }

        public virtual Node Node { get; set; }
        public virtual TaskPan TaskPan { get; set; }
    }

}
