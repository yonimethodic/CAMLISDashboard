using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;

using CHAI.LISDashboard.CoreDomain.Admins;
using CHAI.LISDashboard.CoreDomain.Users;
using CHAI.LISDashboard.CoreDomain.Infrastructure;
using CHAI.LISDashboard.CoreDomain.Setting;
using CHAI.LISDashboard.CoreDomain.ViralLoad;
using CHAI.LISDashboard.CoreDomain.EID;




namespace CHAI.LISDashboard.CoreDomain.DataAccess
{
    public class LISDashboardDbContext : BaseDbContext
    {
        public LISDashboardDbContext(bool disableProxy)
            : base("LISDashboard")
        {
            if (disableProxy)
                ObjContext().ContextOptions.ProxyCreationEnabled = false;

        }

        //Admin
        public DbSet<AppUser> AppUsers { get; set; }
        
        public DbSet<Node> Nodes { get; set; }
        public DbSet<NodeRole> NodeRoles { get; set; }
        public DbSet<PocModule> PocModules { get; set; }
        public DbSet<PopupMenu> PopupMenus { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Tab> Tabs { get; set; }
        public DbSet<TabRole> TabRoles { get; set; }
        public DbSet<TaskPan> TaskPans { get; set; }
        public DbSet<TaskPanNode> TaskPanNodes { get; set; }
        public DbSet<AppUserRole> AppUserRoles { get; set; }
        //Setting
        public DbSet<ARVRegiman> ARVRegimen { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<FacilityContact> FacilityContacts { get; set; }
        public DbSet<FacilityDoctor> FacilityDoctors { get; set; }
        public DbSet<FacilityType> FacilityTypes { get; set; }
        public DbSet<LabInstrument> LabInstruments { get; set; }
        public DbSet<Laboratory> Laboratories { get; set; }
        public DbSet<LabTrackingOption> LabTrackingOptions { get; set; }
        public DbSet<LLG> LLGs { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<RejectedReason> RejectedReasons { get; set; }        
        public DbSet<SpecimenType> SpecimenTypes { get; set; }
        public DbSet<TrackingOption> TrackingOptions { get; set; }
        public DbSet<TrainingHistory> TrainingHistories { get; set; }
        
        public DbSet<VLTestReason> VLTestReasons { get; set; }
        public DbSet<VLTherapy> VLTherapies { get; set; }
        public DbSet<Ward> Wards { get; set; }
        public DbSet<UserLocation> UserLocations { get; set; }

        //EID
        public DbSet<RequestRejectedReason> RequestRejectedReasons { get; set; }
        //ViralLoad
         public DbSet<VLRequestRejectedReason> VLRequestRejectedReasons { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<AppUser>().HasMany(p => p.AppUserRoles).WithMany();
            //modelBuilder.Entity<Node>().HasMany(p => p.NodeRoles).WithMany();
            //modelBuilder.Entity<Tab>().HasMany(p => p.TabRoles).WithMany();
            //modelBuilder.Entity<Tab>().HasMany(p => p.TaskPans).WithMany();
            //modelBuilder.Entity<TaskPan>().HasMany(p => p.TaskPanNodes).WithMany();


            base.OnModelCreating(modelBuilder);
        }
    }
}