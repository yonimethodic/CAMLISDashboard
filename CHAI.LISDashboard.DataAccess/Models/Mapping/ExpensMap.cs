using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace SKDH.AssociationManagment.DataAccess.Models.Mapping
{
    public class ExpensMap : EntityTypeConfiguration<Expens>
    {
        public ExpensMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Description)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Expenses");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Transaction_Id).HasColumnName("Transaction_Id");
            this.Property(t => t.TypeId).HasColumnName("TypeId");
            this.Property(t => t.Amount).HasColumnName("Amount");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Casher).HasColumnName("Casher");

            // Relationships
            this.HasRequired(t => t.ExpenseType)
                .WithMany(t => t.Expenses)
                .HasForeignKey(d => d.TypeId);

        }
    }
}
