using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace SKDH.AssociationManagment.DataAccess.Models.Mapping
{
    public class memberMap : EntityTypeConfiguration<member>
    {
        public memberMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.FullName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Address)
                .IsRequired();

            this.Property(t => t.Phone)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("members");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.FullName).HasColumnName("FullName");
            this.Property(t => t.Region_Id).HasColumnName("Region_Id");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.Phone).HasColumnName("Phone");
            this.Property(t => t.PaymentForASS).HasColumnName("PaymentForASS");
        }
    }
}
