// Copyright Information
// ==================================
// AutoLot - AutoLot.Models - CarDriverConfiguration.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/11/27
// ==================================

namespace AutoLot.Models.Entities.Configuration;

public class CarDriverConfiguration : IEntityTypeConfiguration<CarDriver>
{
    public void Configure(EntityTypeBuilder<CarDriver> builder)
    {
        builder.HasIndex(e => new { e.DriverId, e.CarId })
            .IsUnique()
            .HasDatabaseName("IX_InventoryToDrivers_DriverId_CarId");
        builder.Property(e => e.TimeStamp)
            .IsRowVersion()
            .HasConversion<byte[]>();

        builder.HasOne(e => e.DriverNavigation)
            .WithMany(d => d.CarDrivers)
            .HasForeignKey(e => e.DriverId);
        builder.HasOne(e => e.CarNavigation)
            .WithMany(c => c.CarDrivers)
            .HasForeignKey(e => e.CarId);
        builder.HasQueryFilter(CarConfiguration.IsDriveableFilterName, c => c.CarNavigation.IsDrivable);
        builder.HasQueryFilter(CarConfiguration.IsNewQueryFilterName, c => c.CarNavigation.DateBuilt > new DateTime(2020, 1, 1));
    }
}