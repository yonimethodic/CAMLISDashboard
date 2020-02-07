using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace SKDH.AssociationManagment.DataAccess.Models.Mapping
{
    public class PopupMenuMap : EntityTypeConfiguration<PopupMenu>
    {
        public PopupMenuMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("PopupMenus");
            this.Property(t => t.Tab_Id).HasColumnName("Tab_Id");
            this.Property(t => t.Node_Id).HasColumnName("Node_Id");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Position).HasColumnName("Position");

            // Relationships
            this.HasRequired(t => t.Node)
                .WithMany(t => t.PopupMenus)
                .HasForeignKey(d => d.Node_Id);
            this.HasRequired(t => t.Tab)
                .WithMany(t => t.PopupMenus)
                .HasForeignKey(d => d.Tab_Id);

        }
    }
}
