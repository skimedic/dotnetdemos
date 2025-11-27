// Copyright Information
// ==================================
// AutoLot - AutoLot.Models - CarDriver.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/11/27
// ==================================

namespace AutoLot.Models.Entities;

[Table("InventoryToDrivers", Schema = "dbo")]
[EntityTypeConfiguration(typeof(CarDriverConfiguration))]
[Index(nameof(DriverId), nameof(CarId), IsUnique = true, Name = "IX_InventoryToDrivers_DriverId_CarId")]
public class CarDriver : BaseEntity
{
    public int DriverId { get; set; }
    [ForeignKey(nameof(DriverId))]
    [InverseProperty(nameof(Driver.CarDrivers))]
    public Driver DriverNavigation { get; set; }
    [Column("InventoryId")]
    public int CarId { get; set; }

    [ForeignKey(nameof(CarId))]
    [InverseProperty(nameof(Car.CarDrivers))]
    public Car CarNavigation { get; set; }

}