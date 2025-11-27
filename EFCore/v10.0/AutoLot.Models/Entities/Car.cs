// Copyright Information
// ==================================
// AutoLot - AutoLot.Models - Car.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/11/27
// ==================================

namespace AutoLot.Models.Entities;

[Table("Inventory", Schema = "dbo")]
[EntityTypeConfiguration(typeof(CarConfiguration))]
[Index(nameof(MakeId), Name = "IX_Inventory_MakeId")]
public class Car : BaseEntity
{
    [Required, MaxLength(50)]
    public string Color { get; set; }
    public string Price { get; set; }

    //EF  <=7
    //private bool? _isDrivable;
    //[DisplayName("Is Drivable")]
    //public bool IsDrivable
    //{
    //    get => _isDrivable ?? true;
    //    set => _isDrivable = value;
    //}
    //EF 8+
    [DisplayName("Is Drivable")]
    public bool IsDrivable { get; set; } = true;
    public DateTime? DateBuilt { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public string Display { get; set; }
    [Required, MaxLength(50), DisplayName("Pet Name")]
    public string PetName { get; set; }
    [Required, DisplayName("Make")]
    public int MakeId { get; set; }

    [ForeignKey(nameof(MakeId))]
    [InverseProperty(nameof(Make.Cars))]
    public Make MakeNavigation { get; set; }

    [InverseProperty(nameof(Radio.CarNavigation))]
    public Radio RadioNavigation { get; set; }

    [InverseProperty(nameof(Driver.Cars))]
    public ICollection<Driver> Drivers { get; set; } = new List<Driver>();

    [InverseProperty(nameof(CarDriver.CarNavigation))]
    public ICollection<CarDriver> CarDrivers { get; set; } = new List<CarDriver>();

    [NotMapped]
    public string MakeName => MakeNavigation?.Name ?? "Unknown";

    public override string ToString() => $"{PetName ?? "**No Name**"} is a {Color} {MakeNavigation?.Name} with ID {Id}.";
}