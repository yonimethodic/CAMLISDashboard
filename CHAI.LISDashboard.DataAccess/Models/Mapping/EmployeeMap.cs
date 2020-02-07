using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace SKDH.AssociationManagment.DataAccess.Models.Mapping
{
    public class EmployeeMap : EntityTypeConfiguration<Employee>
    {
        public EmployeeMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.phone)
                .HasMaxLength(50);

            this.Property(t => t.EmployeeType)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Employees");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.EmpFullName).HasColumnName("EmpFullName");
            this.Property(t => t.phone).HasColumnName("phone");
            this.Property(t => t.address).HasColumnName("address");
            this.Property(t => t.salary).HasColumnName("salary");
            this.Property(t => t.EmployeeType).HasColumnName("EmployeeType");
        }
    }
}
