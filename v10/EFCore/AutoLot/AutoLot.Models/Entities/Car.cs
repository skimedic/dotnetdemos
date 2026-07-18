// Copyright Information
// ==================================
// AutoLot - AutoLot.Models - Car.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/07/18
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
    [Required]
    [MaxLength(50)]
    public string Color { get; set; }

    /// <summary>
    /// The price of the car.
    /// </summary>
    /// <remarks>
    /// May be null or empty if not set.
    /// </remarks>
    public string Price { get; set; }

    //EF  <=7
    //private bool? _isDrivable;
    //[DisplayName("Is Drivable")]
    //public bool IsDrivable
    //{
    //    get => _isDrivable ?? true;
    //    set => _isDrivable = value;
    //}

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
    [XmlIgnore]
	[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public string Display { get; private set; }

    /// <summary>
    /// The pet name of the car.
    /// </summary>
    /// <remarks>
    /// Required, maximum length 50.
    /// </remarks>
    [Required]
    [MaxLength(50)]
    [DisplayName("Pet Name")]
    public string PetName { get; set; }

    /// <summary>
    /// The foreign key to the make of the car.
    /// </summary>
    /// <remarks>
    /// Required.
    /// </remarks>
    [Required]
    [DisplayName("Make")]
    public int MakeId { get; set; }

    /// <summary>
    /// Navigation property to the make entity.
    /// </summary>
    /// <remarks>
    /// References the make of the car.
    /// </remarks>
    // XmlIgnore prevents circular reference stack overflow when serializing to XML
    // via the API's XmlFormatter, which has no built-in cycle detection.
    [ForeignKey(nameof(MakeId))]
    [InverseProperty(nameof(Make.Cars))]
    [XmlIgnore]
    public Make MakeNavigation { get; set; }

    /// <summary>
    /// Navigation property to the radio entity.
    /// </summary>
    /// <remarks>
    /// References the radio installed in the car.
    /// </remarks>
    // XmlIgnore prevents circular reference stack overflow when serializing to XML
    // via the API's XmlFormatter, which has no built-in cycle detection.
    [InverseProperty(nameof(Radio.CarNavigation))]
    [XmlIgnore]
    public Radio RadioNavigation { get; set; }

    /// <summary>
    /// Navigation property to the car-driver relationships.
    /// </summary>
    /// <remarks>
    /// Collection of car-driver entities.
    /// </remarks>
    // XmlIgnore prevents circular reference stack overflow when serializing to XML
    // via the API's XmlFormatter, which has no built-in cycle detection.
    [InverseProperty(nameof(CarDriver.CarNavigation))]
    [XmlIgnore]
    public ICollection<CarDriver> CarDrivers { get; set; } = new List<CarDriver>();

    /// <summary>
    /// Navigation property to the drivers of the car.
    /// </summary>
    /// <remarks>
    /// Collection of drivers associated with the car.
    /// </remarks>
    // XmlIgnore prevents circular reference stack overflow when serializing to XML
    // via the API's XmlFormatter, which has no built-in cycle detection.
    [InverseProperty(nameof(Driver.Cars))]
    [XmlIgnore]
    public ICollection<Driver> Drivers { get; set; } = new List<Driver>();

    /// <summary>
    /// The name of the make for this car.
    /// </summary>
    /// <remarks>
    /// Returns "Unknown" if the make is not set.
    /// </remarks>
    [XmlIgnore]
	[NotMapped]
    public string MakeName => MakeNavigation?.Name ?? "Unknown";

    /// <summary>
    /// Returns a string representation of the car.
    /// </summary>
    /// <remarks>
    /// Includes pet name, color, make, and ID.
    /// </remarks>
    public override string ToString() =>
        $"{PetName ?? "**No Name**"} is a {Color} {MakeNavigation?.Name} with ID {Id}.";
}