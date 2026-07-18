// Copyright Information
// ==================================
// AutoLot - AutoLot.Models - CarConfiguration.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/07/18
// ==================================

namespace AutoLot.Models.Entities.Configuration;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public const string IsNewQueryFilterName = "IsNew";
    public const string IsDriveableFilterName = "IsDriveable";

    public void Configure(
        EntityTypeBuilder<Car> builder)
    {
        builder.Property(e => e.TimeStamp).IsRowVersion().HasConversion<byte[]>();
        builder.HasQueryFilter(IsDriveableFilterName, c => c.IsDrivable);
        builder.HasQueryFilter(IsNewQueryFilterName, c => c.DateBuilt > new DateTime(2020, 1, 1));
        builder.Property(p => p.IsDrivable).HasDefaultValue(true);
        builder.Property(e => e.DateBuilt).HasDefaultValueSql("getdate()");
        builder.Property(e => e.Display).HasComputedColumnSql("[PetName] + ' (' + [Color] + ')'", stored: true);
        CultureInfo provider = new("en-us");
        NumberStyles style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
        builder.Property(p => p.Price).HasConversion(
            v => string.IsNullOrEmpty(v) ? (decimal?)null : decimal.Parse(v, style, provider),
            v => v.HasValue ? v.Value.ToString("C2", provider) : null);
        builder.HasOne(d => d.MakeNavigation).WithMany(p => p.Cars).HasForeignKey(d => d.MakeId)
            .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Inventory_Makes_MakeId");
        builder.HasMany(p => p.Drivers).WithMany(p => p.Cars).UsingEntity<CarDriver>(
            j =>
                j.HasOne(cd => cd.DriverNavigation).WithMany(d => d.CarDrivers)
                    .HasForeignKey(nameof(CarDriver.DriverId)).HasConstraintName("FK_InventoryDriver_Drivers_DriverId")
                    .OnDelete(DeleteBehavior.Cascade),
            j =>
                j.HasOne(cd => cd.CarNavigation).WithMany(c => c.CarDrivers).HasForeignKey(nameof(CarDriver.CarId))
                    .HasConstraintName("FK_InventoryDriver_Inventory_InventoryId")
                    .OnDelete(DeleteBehavior.ClientCascade), j => { j.HasKey(x => x.Id); });
        builder.ToTable(tb =>
            tb.IsTemporal(ttb =>
            {
                ttb.HasPeriodStart("ValidFrom");
                ttb.HasPeriodEnd("ValidTo");
                ttb.UseHistoryTable("InventoryAudit", "dbo");
            }));
    }
}