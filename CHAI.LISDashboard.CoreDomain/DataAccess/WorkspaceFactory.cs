using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Globalization;

using CHAI.LISDashboard.CoreDomain.Infrastructure;
using CHAI.LISDashboard.Shared.Settings;

namespace CHAI.LISDashboard.CoreDomain.DataAccess
{
    public static class WorkspaceFactory
    {
        private static string _connectionString = TechnicalSettings.ConnectionString;

        static WorkspaceFactory()
        {
            Database.DefaultConnectionFactory = new SqlConnectionFactory(_connectionString);            
        }

        public static IWorkspace Create()
        {
            return new EFWorkspace(new LISDashboardDbContext(false));
        }

        public static IReadOnlyWorkspace CreateReadOnly()
        {
            return new ReadOnlyEFWorkspace(new LISDashboardDbContext(true));
        }
        
    }

}
