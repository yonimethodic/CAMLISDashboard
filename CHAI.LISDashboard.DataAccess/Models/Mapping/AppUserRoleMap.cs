using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace SKDH.AssociationManagment.DataAccess.Models.Mapping
{
    public class AppUserRoleMap : EntityTypeConfiguration<AppUserRole>
    {
        public AppUserRoleMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("AppUserRoles");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.AppUser_Id).HasColumnName("AppUser_Id");
            this.Property(t => t.Role_Id).HasColumnName("Role_Id");

            // Relationships
            this.HasRequired(t => t.AppUser)
                .WithMany(t => t.AppUserRoles)
                .HasForeignKey(d => d.AppUser_Id);

        }
    }
}
