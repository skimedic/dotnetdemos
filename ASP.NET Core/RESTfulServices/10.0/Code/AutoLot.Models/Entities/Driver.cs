// Copyright Information
// ==================================
// AutoLot-Temp - AutoLot.Models - Driver.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/11/23
// ==================================

namespace AutoLot.Models.Entities;

/// <summary>
/// Represents a driver in the system.
/// </summary>
/// <remarks>
/// Contains personal information and car relationships.
/// </remarks>
[Serializable]
[Table("Drivers", Schema = "dbo")]
[EntityTypeConfiguration(typeof(DriverConfiguration))]
public class Driver : BaseEntity
{
    /// <summary>
    /// The personal information of the driver.
    /// </summary>
    /// <remarks>
    /// Includes name and other details.
    /// </remarks>
    public Person PersonInformation { get; set; } = new();

    /// <summary>
    /// Navigation property to the cars driven by this driver.
    /// </summary>
    /// <remarks>
    /// Collection of cars associated with the driver.
    /// </remarks>
    [XmlIgnore]
    [InverseProperty(nameof(Car.Drivers))]
    public ICollection<Car> Cars { get; set; } = new List<Car>();

    /// <summary>
    /// Navigation property to car-driver relationships.
    /// </summary>
    /// <remarks>
    /// Collection of car-driver entities for this driver.
    /// </remarks>
    [XmlIgnore]
    [InverseProperty(nameof(CarDriver.DriverNavigation))]
    public ICollection<CarDriver> CarDrivers { get; set; } = new List<CarDriver>();
}