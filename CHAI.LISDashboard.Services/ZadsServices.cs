using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using CHAI.LISDashboard.CoreDomain;
using CHAI.LISDashboard.CoreDomain.Users;
using CHAI.LISDashboard.CoreDomain.Admins;
using CHAI.LISDashboard.CoreDomain.DataAccess;
using CHAI.LISDashboard.CoreDomain.Infrastructure;

namespace CHAI.LISDashboard.Services
{
    public static class ZadsServices
    {
        private static IWorkspace _workspace;
        public static IWorkspace Workspace
        {
            get { return _workspace ?? (_workspace = WorkspaceFactory.Create()); }
            set { _workspace = value; }
        }

        private static AdminServices _adminServices;
        public static AdminServices AdminServices
        {
            get { return _adminServices ?? (_adminServices = new AdminServices()); }
            set { _adminServices = value; }
        }
    }
}
