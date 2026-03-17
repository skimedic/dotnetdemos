// Copyright Information
// ==================================
// AutoLot-Temp - AutoLot.Models - CarViewModelConfiguration.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/11/23
// ==================================

namespace AutoLot.Models.ViewModels.Configuration;

public class CarViewModelConfiguration : IEntityTypeConfiguration<CarViewModel>
{
    public void Configure(EntityTypeBuilder<CarViewModel> builder)
    {
        builder.ToTable(t => t.ExcludeFromMigrations());
        CultureInfo provider = new("en-us");
        NumberStyles style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
        builder.Property(p => p.Price)
               .HasConversion(
                    v => decimal.Parse(v, style, provider),
                    v => v.ToString("C2"));
    }
}
