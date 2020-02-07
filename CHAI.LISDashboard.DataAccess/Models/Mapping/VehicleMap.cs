using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace SKDH.AssociationManagment.DataAccess.Models.Mapping
{
    public class VehicleMap : EntityTypeConfiguration<Vehicle>
    {
        public VehicleMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.PlateNumber)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Vehicles");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.PlateNumber).HasColumnName("PlateNumber");
        }
    }
}
