// Copyright Information
// ==================================
// AutoLot - AutoLot.Models - Car.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/11/23
// ==================================

namespace AutoLot.Models.Entities;

/// <summary>
/// Represents a car in the inventory.
/// </summary>
/// <remarks>
/// Contains details about the car, its make, drivers, and radio.
/// </remarks>
[Serializable]
[Table("Inventory", Schema = "dbo")]
[EntityTypeConfiguration(typeof(CarConfiguration))]
[Index(nameof(MakeId), Name = "IX_Inventory_MakeId")]
public class Car : BaseEntity
{
    /// <summary>
    /// The color of the car.
    /// </summary>
    /// <remarks>
    /// Required, maximum length 50.
    /// </remarks>
    [Required, MaxLength(50)]
    public string Color { get; set; }

    /// <summary>
    /// The price of the car.
    /// </summary>
    /// <remarks>
    /// May be null or empty if not set.
    /// </remarks>
    public string Price { get; set; }

    /// <summary>
    /// Indicates if the car is drivable.
    /// </summary>
    /// <remarks>
    /// Defaults to true.
    /// </remarks>
    [DisplayName("Is Drivable")]
    public bool IsDrivable { get; set; } = true;

    /// <summary>
    /// The date the car was built.
    /// </summary>
    /// <remarks>
    /// Nullable; may not be set for all cars.
    /// </remarks>
    public DateTime? DateBuilt { get; set; }

    /// <summary>
    /// The display string for the car.
    /// </summary>
    /// <remarks>
    /// Computed by the database.
    /// </remarks>
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public string Display { get; set; }

    /// <summary>
    /// The pet name of the car.
    /// </summary>
    /// <remarks>
    /// Required, maximum length 50.
    /// </remarks>
    [Required, MaxLength(50), DisplayName("Pet Name")]
    public string PetName { get; set; }

    /// <summary>
    /// The foreign key to the make of the car.
    /// </summary>
    /// <remarks>
    /// Required.
    /// </remarks>
    [Required, DisplayName("Make")]
    public int MakeId { get; set; }

    /// <summary>
    /// Navigation property to the make entity.
    /// </summary>
    /// <remarks>
    /// References the make of the car.
    /// </remarks>
    [XmlIgnore]
    [ForeignKey(nameof(MakeId))]
    [InverseProperty(nameof(Make.Cars))]
    public Make MakeNavigation { get; set; }

    /// <summary>
    /// Navigation property to the radio entity.
    /// </summary>
    /// <remarks>
    /// References the radio installed in the car.
    /// </remarks>
    [XmlIgnore]
    [InverseProperty(nameof(Radio.CarNavigation))]
    public Radio RadioNavigation { get; set; }

    /// <summary>
    /// Navigation property to the drivers of the car.
    /// </summary>
    /// <remarks>
    /// Collection of drivers associated with the car.
    /// </remarks>
    [XmlIgnore]
    [InverseProperty(nameof(Driver.Cars))]
    public ICollection<Driver> Drivers { get; set; } = new List<Driver>();

    /// <summary>
    /// Navigation property to the car-driver relationships.
    /// </summary>
    /// <remarks>
    /// Collection of car-driver entities.
    /// </remarks>
    [XmlIgnore]
    [InverseProperty(nameof(CarDriver.CarNavigation))]
    public ICollection<CarDriver> CarDrivers { get; set; } = new List<CarDriver>();

    /// <summary>
    /// The name of the make for this car.
    /// </summary>
    /// <remarks>
    /// Returns "Unknown" if the make is not set.
    /// </remarks>
    [NotMapped]
    public string MakeName => MakeNavigation?.Name ?? "Unknown";

    /// <summary>
    /// Returns a string representation of the car.
    /// </summary>
    /// <remarks>
    /// Includes pet name, color, make, and ID.
    /// </remarks>
    public override string ToString() => $"{PetName ?? "**No Name**"} is a {Color} {MakeNavigation?.Name} with ID {Id}.";
}