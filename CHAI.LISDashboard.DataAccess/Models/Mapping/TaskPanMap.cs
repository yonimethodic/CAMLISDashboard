using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace SKDH.AssociationManagment.DataAccess.Models.Mapping
{
    public class TaskPanMap : EntityTypeConfiguration<TaskPan>
    {
        public TaskPanMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(64);

            this.Property(t => t.ImagePath)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("TaskPans");
            this.Property(t => t.Tab_Id).HasColumnName("Tab_Id");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.Position).HasColumnName("Position");
            this.Property(t => t.ImagePath).HasColumnName("ImagePath");

            // Relationships
            this.HasRequired(t => t.Tab)
                .WithMany(t => t.TaskPans)
                .HasForeignKey(d => d.Tab_Id);

        }
    }
}
