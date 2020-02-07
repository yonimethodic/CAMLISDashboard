using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace SKDH.AssociationManagment.DataAccess.Models.Mapping
{
    public class MoneyCollectionDetailMap : EntityTypeConfiguration<MoneyCollectionDetail>
    {
        public MoneyCollectionDetailMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("MoneyCollectionDetail");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.MoneyCollection_Id).HasColumnName("MoneyCollection_Id");
            this.Property(t => t.Customer_Id).HasColumnName("Customer_Id");
            this.Property(t => t.Amount).HasColumnName("Amount");
        }
    }
}
