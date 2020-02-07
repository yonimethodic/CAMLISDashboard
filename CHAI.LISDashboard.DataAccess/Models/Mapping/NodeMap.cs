using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace SKDH.AssociationManagment.DataAccess.Models.Mapping
{
    public class NodeMap : EntityTypeConfiguration<Node>
    {
        public NodeMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(64);

            this.Property(t => t.FilePath)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.ImagePath)
                .HasMaxLength(255);

            this.Property(t => t.Description)
                .HasMaxLength(255);

            this.Property(t => t.PageId)
                .HasMaxLength(64);

            // Table & Column Mappings
            this.ToTable("Nodes");
            this.Property(t => t.PocModule_Id).HasColumnName("PocModule_Id");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.FilePath).HasColumnName("FilePath");
            this.Property(t => t.ImagePath).HasColumnName("ImagePath");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.PageId).HasColumnName("PageId");
        }
    }
}
