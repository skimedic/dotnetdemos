// Copyright Information
// ==================================
// AutoLot - AutoLot.Models - Make.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/11/23
// ==================================

namespace AutoLot.Models.Entities;

/// <summary>
/// Represents a car make.
/// </summary>
/// <remarks>
/// Contains the name and related cars.
/// </remarks>
[Serializable]
[Table("Makes", Schema = "dbo")]
[EntityTypeConfiguration(typeof(MakeConfiguration))]
public class Make : BaseEntity
{
    /// <summary>
    /// The name of the make.
    /// </summary>
    /// <remarks>
    /// Required, maximum length 50.
    /// </remarks>
    [Required, MaxLength(50)]
    public string Name { get; set; }

    /// <summary>
    /// Navigation property to cars of this make.
    /// </summary>
    /// <remarks>
    /// Collection of cars associated with this make.
    /// </remarks>
    [XmlIgnore]
    [InverseProperty(nameof(Car.MakeNavigation))]
    public ICollection<Car> Cars { get; set; } = new List<Car>();
}