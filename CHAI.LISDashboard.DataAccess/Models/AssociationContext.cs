using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using SKDH.AssociationManagment.DataAccess.Models.Mapping;

namespace SKDH.AssociationManagment.DataAccess.Models
{
    public partial class AssociationContext : DbContext
    {
        static AssociationContext()
        {
            Database.SetInitializer<AssociationContext>(null);
        }

        public AssociationContext()
            : base("Name=AssociationContext")
        {
        }

        public DbSet<AppUserRole> AppUserRoles { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AssignedEmployeeVehicle> AssignedEmployeeVehicles { get; set; }
        public DbSet<Complain> Complains { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<EmployeeDebit> EmployeeDebits { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmplyeePerdime> EmplyeePerdimes { get; set; }
        public DbSet<Expens> Expenses { get; set; }
        public DbSet<ExpenseType> ExpenseTypes { get; set; }
        public DbSet<MemberRemainingBalance> MemberRemainingBalances { get; set; }
        public DbSet<member> members { get; set; }
        public DbSet<MemeberCustomer> MemeberCustomers { get; set; }
        public DbSet<MoneyCollectionDetail> MoneyCollectionDetails { get; set; }
        public DbSet<MoneyCollection> MoneyCollections { get; set; }
        public DbSet<NodeRole> NodeRoles { get; set; }
        public DbSet<Node> Nodes { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentSetting> PaymentSettings { get; set; }
        public DbSet<PocModule> PocModules { get; set; }
        public DbSet<PopupMenu> PopupMenus { get; set; }
        public DbSet<RegionPayment> RegionPayments { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<salary> salaries { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<TabRole> TabRoles { get; set; }
        public DbSet<Tab> Tabs { get; set; }
        public DbSet<TaskPanNode> TaskPanNodes { get; set; }
        public DbSet<TaskPan> TaskPans { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AppUserRoleMap());
            modelBuilder.Configurations.Add(new AppUserMap());
            modelBuilder.Configurations.Add(new AssignedEmployeeVehicleMap());
            modelBuilder.Configurations.Add(new ComplainMap());
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new EmployeeDebitMap());
            modelBuilder.Configurations.Add(new EmployeeMap());
            modelBuilder.Configurations.Add(new EmplyeePerdimeMap());
            modelBuilder.Configurations.Add(new ExpensMap());
            modelBuilder.Configurations.Add(new ExpenseTypeMap());
            modelBuilder.Configurations.Add(new MemberRemainingBalanceMap());
            modelBuilder.Configurations.Add(new memberMap());
            modelBuilder.Configurations.Add(new MemeberCustomerMap());
            modelBuilder.Configurations.Add(new MoneyCollectionDetailMap());
            modelBuilder.Configurations.Add(new MoneyCollectionMap());
            modelBuilder.Configurations.Add(new NodeRoleMap());
            modelBuilder.Configurations.Add(new NodeMap());
            modelBuilder.Configurations.Add(new PaymentMap());
            modelBuilder.Configurations.Add(new PaymentSettingMap());
            modelBuilder.Configurations.Add(new PocModuleMap());
            modelBuilder.Configurations.Add(new PopupMenuMap());
            modelBuilder.Configurations.Add(new RegionPaymentMap());
            modelBuilder.Configurations.Add(new RegionMap());
            modelBuilder.Configurations.Add(new RoleMap());
            modelBuilder.Configurations.Add(new salaryMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
            modelBuilder.Configurations.Add(new TabRoleMap());
            modelBuilder.Configurations.Add(new TabMap());
            modelBuilder.Configurations.Add(new TaskPanNodeMap());
            modelBuilder.Configurations.Add(new TaskPanMap());
            modelBuilder.Configurations.Add(new TransactionMap());
            modelBuilder.Configurations.Add(new VehicleMap());
        }
    }
}
