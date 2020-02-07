using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace SKDH.AssociationManagment.DataAccess.Models.Mapping
{
    public class MemeberCustomerMap : EntityTypeConfiguration<MemeberCustomer>
    {
        public MemeberCustomerMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("MemeberCustomer");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.member_Id).HasColumnName("member_Id");
            this.Property(t => t.customer_Id).HasColumnName("customer_Id");
        }
    }
}
