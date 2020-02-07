using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace SKDH.AssociationManagment.DataAccess.Models.Mapping
{
    public class MoneyCollectionMap : EntityTypeConfiguration<MoneyCollection>
    {
        public MoneyCollectionMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Date)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("MoneyCollections");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.member_Id).HasColumnName("member_Id");
            this.Property(t => t.Date).HasColumnName("Date");
            this.Property(t => t.Amount).HasColumnName("Amount");
            this.Property(t => t.AmountDeduct).HasColumnName("AmountDeduct");
            this.Property(t => t.RemainingBalance).HasColumnName("RemainingBalance");
        }
    }
}
