// Copyright Information
// ==================================
// AutoLot-WebApps - AutoLot.Models - CarDriver.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/09/07
// ==================================

namespace AutoLot.Models.Entities;

/// <summary>
///     Represents the relationship between a car and a driver.
/// </summary>
/// <remarks>
///     Maps drivers to cars in the inventory.
/// </remarks>
[Serializable]
[Table(
    "InventoryToDrivers",
    Schema = "dbo")]
[EntityTypeConfiguration(typeof(CarDriverConfiguration))]
public class CarDriver : BaseEntity
{
    /// <summary>
    ///     The foreign key to the driver.
    /// </summary>
    /// <remarks>
    ///     References the driver entity.
    /// </remarks>
    public int DriverId { get; set; }

    /// <summary>
    ///     The foreign key to the car.
    /// </summary>
    /// <remarks>
    ///     References the car entity.
    /// </remarks>
    [Column("InventoryId")]
    public int CarId { get; set; }

    /// <summary>
    ///     Navigation property to the car entity.
    /// </summary>
    /// <remarks>
    ///     References the car associated with this relationship.
    /// </remarks>
    // XmlIgnore prevents circular reference stack overflow when serializing to XML
    // via the API's XmlFormatter, which has no built-in cycle detection.
    [ForeignKey(nameof(CarId))]
    [InverseProperty(nameof(Car.CarDrivers))]
    [XmlIgnore]
    public Car CarNavigation { get; set; }

    /// <summary>
    ///     Navigation property to the driver entity.
    /// </summary>
    /// <remarks>
    ///     References the driver associated with this relationship.
    /// </remarks>
    // XmlIgnore prevents circular reference stack overflow when serializing to XML
    // via the API's XmlFormatter, which has no built-in cycle detection.
    [ForeignKey(nameof(DriverId))]
    [InverseProperty(nameof(Driver.CarDrivers))]
    [XmlIgnore]
    public Driver DriverNavigation { get; set; }
}