using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace SKDH.AssociationManagment.DataAccess.Models.Mapping
{
    public class EmployeeDebitMap : EntityTypeConfiguration<EmployeeDebit>
    {
        public EmployeeDebitMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("EmployeeDebits");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Employee_Id).HasColumnName("Employee_Id");
            this.Property(t => t.Debit).HasColumnName("Debit");
        }
    }
}
