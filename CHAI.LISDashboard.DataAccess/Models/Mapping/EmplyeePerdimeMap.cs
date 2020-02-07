using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace SKDH.AssociationManagment.DataAccess.Models.Mapping
{
    public class EmplyeePerdimeMap : EntityTypeConfiguration<EmplyeePerdime>
    {
        public EmplyeePerdimeMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("EmplyeePerdimes");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Transaction_Id).HasColumnName("Transaction_Id");
            this.Property(t => t.Employee_Id).HasColumnName("Employee_Id");
            this.Property(t => t.Perdime).HasColumnName("Perdime");
        }
    }
}
