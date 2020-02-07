using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace SKDH.AssociationManagment.DataAccess.Models.Mapping
{
    public class TaskPanNodeMap : EntityTypeConfiguration<TaskPanNode>
    {
        public TaskPanNodeMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("TaskPanNodes");
            this.Property(t => t.TaskPan_Id).HasColumnName("TaskPan_Id");
            this.Property(t => t.Node_Id).HasColumnName("Node_Id");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Position).HasColumnName("Position");

            // Relationships
            this.HasRequired(t => t.Node)
                .WithMany(t => t.TaskPanNodes)
                .HasForeignKey(d => d.Node_Id);
            this.HasRequired(t => t.TaskPan)
                .WithMany(t => t.TaskPanNodes)
                .HasForeignKey(d => d.TaskPan_Id);

        }
    }
}
