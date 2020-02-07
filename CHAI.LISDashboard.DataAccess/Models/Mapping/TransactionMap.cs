using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace SKDH.AssociationManagment.DataAccess.Models.Mapping
{
    public class TransactionMap : EntityTypeConfiguration<Transaction>
    {
        public TransactionMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.TransactionNo)
                .HasMaxLength(50);

            this.Property(t => t.Status)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Transactions");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.TransactionDate).HasColumnName("TransactionDate");
            this.Property(t => t.TransactionNo).HasColumnName("TransactionNo");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.DateUpdated).HasColumnName("DateUpdated");
        }
    }
}
