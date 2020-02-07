
using System;
using System.Collections;
using CHAI.LISDashboard.CoreDomain.Users;

namespace CHAI.LISDashboard.CoreDomain.Admins
{
    public class TabRole : IEntity
	{
        public int Id { get; set; }
        public bool ViewAllowed { get; set; }

        public virtual Role Role { get; set; }
        public virtual Tab Tab { get; set; }
	}

}
