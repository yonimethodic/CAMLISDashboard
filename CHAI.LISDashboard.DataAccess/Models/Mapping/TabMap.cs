using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace SKDH.AssociationManagment.DataAccess.Models.Mapping
{
    public class TabMap : EntityTypeConfiguration<Tab>
    {
        public TabMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.TabName)
                .IsRequired()
                .HasMaxLength(64);

            this.Property(t => t.Description)
                .HasMaxLength(156);

            // Table & Column Mappings
            this.ToTable("Tabs");
            this.Property(t => t.PocModule_Id).HasColumnName("PocModule_Id");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.TabName).HasColumnName("TabName");
            this.Property(t => t.Position).HasColumnName("Position");
            this.Property(t => t.Description).HasColumnName("Description");
        }
    }
}
