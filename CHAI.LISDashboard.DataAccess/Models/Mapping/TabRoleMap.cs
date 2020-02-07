using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace SKDH.AssociationManagment.DataAccess.Models.Mapping
{
    public class TabRoleMap : EntityTypeConfiguration<TabRole>
    {
        public TabRoleMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("TabRoles");
            this.Property(t => t.Tab_Id).HasColumnName("Tab_Id");
            this.Property(t => t.Role_Id).HasColumnName("Role_Id");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ViewAllowed).HasColumnName("ViewAllowed");

            // Relationships
            this.HasRequired(t => t.Tab)
                .WithMany(t => t.TabRoles)
                .HasForeignKey(d => d.Tab_Id);

        }
    }
}
