using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace SKDH.AssociationManagment.DataAccess.Models.Mapping
{
    public class ComplainMap : EntityTypeConfiguration<Complain>
    {
        public ComplainMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.LostKG)
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.LostBy)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Complains");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Transaction_Id).HasColumnName("Transaction_Id");
            this.Property(t => t.Reason).HasColumnName("Reason");
            this.Property(t => t.member_Id).HasColumnName("member_Id");
            this.Property(t => t.LostKG).HasColumnName("LostKG");
            this.Property(t => t.LostAmount).HasColumnName("LostAmount");
            this.Property(t => t.LostBy).HasColumnName("LostBy");
        }
    }
}
