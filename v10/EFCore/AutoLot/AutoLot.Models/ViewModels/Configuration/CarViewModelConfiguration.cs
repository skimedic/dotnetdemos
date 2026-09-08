// Copyright Information
// ==================================
// AutoLot-WebApps - AutoLot.Models - CarViewModelConfiguration.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/09/07
// ==================================

namespace AutoLot.Models.ViewModels.Configuration;

public class CarViewModelConfiguration : IEntityTypeConfiguration<CarViewModel>
{
    public void Configure(
        EntityTypeBuilder<CarViewModel> builder)
    {
        builder.ToTable(t => t.ExcludeFromMigrations());
        CultureInfo provider = new("en-us");
        NumberStyles style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
        builder.Property(p => p.Price)
            .HasConversion(
                v =>
                string.IsNullOrEmpty(v)
                    ? (decimal?)null
                    : decimal.Parse(
                        v,
                        style,
                        provider),
                v =>
                v.HasValue
                    ? v.Value.ToString(
                        "C2",
                        provider)
                    : null);
    }
}