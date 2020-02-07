using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace SKDH.AssociationManagment.DataAccess.Models.Mapping
{
    public class PaymentMap : EntityTypeConfiguration<Payment>
    {
        public PaymentMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.PaymentPlaceType)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Payments");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Transaction_Id).HasColumnName("Transaction_Id");
            this.Property(t => t.member_Id).HasColumnName("member_Id");
            this.Property(t => t.KG).HasColumnName("KG");
            this.Property(t => t.AmountDate).HasColumnName("AmountDate");
            this.Property(t => t.AmountBack).HasColumnName("AmountBack");
            this.Property(t => t.TotalAmount).HasColumnName("TotalAmount");
            this.Property(t => t.Paid).HasColumnName("Paid");
            this.Property(t => t.Remaining).HasColumnName("Remaining");
            this.Property(t => t.PaymentPlaceType).HasColumnName("PaymentPlaceType");
            this.Property(t => t.Casher).HasColumnName("Casher");
        }
    }
}
