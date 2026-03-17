// Copyright Information
// ==================================
// AutoLot - AutoLot.Models - Radio.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/11/23
// ==================================

namespace AutoLot.Models.Entities;

/// <summary>
/// Represents a radio installed in a car.
/// </summary>
/// <remarks>
/// Contains radio features and car relationship.
/// </remarks>
[Serializable]
[Table("Radios", Schema = "dbo")]
[EntityTypeConfiguration(typeof(RadioConfiguration))]
public class Radio : BaseEntity
{
    /// <summary>
    /// Indicates if the radio has tweeters.
    /// </summary>
    /// <remarks>
    /// True if tweeters are present.
    /// </remarks>
    public bool HasTweeters { get; set; }

    /// <summary>
    /// Indicates if the radio has subwoofers.
    /// </summary>
    /// <remarks>
    /// True if subwoofers are present.
    /// </remarks>
    public bool HasSubWoofers { get; set; }

    /// <summary>
    /// The identifier for the radio.
    /// </summary>
    /// <remarks>
    /// Required, maximum length 50.
    /// </remarks>
    [Required, MaxLength(50)]
    public string RadioId { get; set; }

    /// <summary>
    /// The foreign key to the car.
    /// </summary>
    /// <remarks>
    /// References the car entity.
    /// </remarks>
    [Column("InventoryId")]
    public int CarId { get; set; }

    /// <summary>
    /// Navigation property to the car entity.
    /// </summary>
    /// <remarks>
    /// References the car associated with this radio.
    /// </remarks>
    [XmlIgnore]
    [ForeignKey(nameof(CarId))]
    [InverseProperty(nameof(Car.RadioNavigation))]
    public Car CarNavigation { get; set; }
}