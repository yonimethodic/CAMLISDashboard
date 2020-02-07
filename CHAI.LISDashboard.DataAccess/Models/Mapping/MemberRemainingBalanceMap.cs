using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace SKDH.AssociationManagment.DataAccess.Models.Mapping
{
    public class MemberRemainingBalanceMap : EntityTypeConfiguration<MemberRemainingBalance>
    {
        public MemberRemainingBalanceMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("MemberRemainingBalances");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.member_Id).HasColumnName("member_Id");
            this.Property(t => t.RemainingBalance).HasColumnName("RemainingBalance");
        }
    }
}
