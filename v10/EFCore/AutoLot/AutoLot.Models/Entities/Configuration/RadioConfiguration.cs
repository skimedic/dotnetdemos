// Copyright Information
// ==================================
// AutoLot-WebApps - AutoLot.Models - RadioConfiguration.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/09/07
// ==================================

namespace AutoLot.Models.Entities.Configuration;

public class RadioConfiguration : IEntityTypeConfiguration<Radio>
{
    public void Configure(
        EntityTypeBuilder<Radio> builder)
    {
        builder.Property(e => e.TimeStamp)
            .IsRowVersion()
            .HasConversion<byte[]>();
        builder.HasQueryFilter(e => e.CarNavigation.IsDrivable);
        builder.HasOne(d => d.CarNavigation)
            .WithOne(p => p.RadioNavigation)
            .HasForeignKey<Radio>(d => d.CarId);

        builder.ToTable(tb =>
            tb.IsTemporal(ttb =>
            {
                ttb.HasPeriodStart("ValidFrom");
                ttb.HasPeriodEnd("ValidTo");
                ttb.UseHistoryTable(
                    "RadiosAudit",
                    "dbo");
            }));
    }
}