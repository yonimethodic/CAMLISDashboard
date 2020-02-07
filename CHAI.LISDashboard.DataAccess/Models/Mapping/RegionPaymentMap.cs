using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace SKDH.AssociationManagment.DataAccess.Models.Mapping
{
    public class RegionPaymentMap : EntityTypeConfiguration<RegionPayment>
    {
        public RegionPaymentMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("RegionPayments");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Region_Id).HasColumnName("Region_Id");
            this.Property(t => t.paymentSetting_Id).HasColumnName("paymentSetting_Id");
        }
    }
}
