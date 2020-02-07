using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace SKDH.AssociationManagment.DataAccess.Models.Mapping
{
    public class ExpenseTypeMap : EntityTypeConfiguration<ExpenseType>
    {
        public ExpenseTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.ExpenseTypeName)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("ExpenseTypes");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ExpenseTypeName).HasColumnName("ExpenseTypeName");
        }
    }
}
