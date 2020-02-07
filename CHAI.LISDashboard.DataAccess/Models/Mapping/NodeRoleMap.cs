using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace SKDH.AssociationManagment.DataAccess.Models.Mapping
{
    public class NodeRoleMap : EntityTypeConfiguration<NodeRole>
    {
        public NodeRoleMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("NodeRoles");
            this.Property(t => t.Node_Id).HasColumnName("Node_Id");
            this.Property(t => t.Role_Id).HasColumnName("Role_Id");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ViewAllowed).HasColumnName("ViewAllowed");
            this.Property(t => t.EditAllowed).HasColumnName("EditAllowed");

            // Relationships
            this.HasRequired(t => t.Node)
                .WithMany(t => t.NodeRoles)
                .HasForeignKey(d => d.Node_Id);

        }
    }
}
