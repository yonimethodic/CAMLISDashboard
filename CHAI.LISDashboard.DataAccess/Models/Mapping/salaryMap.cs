using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace SKDH.AssociationManagment.DataAccess.Models.Mapping
{
    public class salaryMap : EntityTypeConfiguration<salary>
    {
        public salaryMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Date)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("salaries");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Date).HasColumnName("Date");
            this.Property(t => t.Employee_Id).HasColumnName("Employee_Id");
            this.Property(t => t.NoDays).HasColumnName("NoDays");
            this.Property(t => t.TotalDed).HasColumnName("TotalDed");
            this.Property(t => t.Net).HasColumnName("Net");
            this.Property(t => t.AMDate).HasColumnName("AMDate");
        }
    }
}
