// Copyright Information
// ==================================
// EFCoreExamples - 01_PerformanceEfCore - SpecialOffer.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/07/18
// ==================================

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PerformanceEfCore.Entities;

/// <summary>
/// Sale discounts lookup table.
/// </summary>
[Table("SpecialOffer", Schema = "Sales")]
[Index("Rowguid", Name = "AK_SpecialOffer_rowguid", IsUnique = true)]
public partial class SpecialOffer
{
    /// <summary>
    /// Primary key for SpecialOffer records.
    /// </summary>
    [Key]
    [Column("SpecialOfferID")]
    public int SpecialOfferId { get; set; }

    /// <summary>
    /// Discount description.
    /// </summary>
    [Required]
    [StringLength(255)]
    public string Description { get; set; }

    /// <summary>
    /// Discount precentage.
    /// </summary>
    [Column(TypeName = "smallmoney")]
    public decimal DiscountPct { get; set; }

    /// <summary>
    /// Discount type category.
    /// </summary>
    [Required]
    [StringLength(50)]
    public string Type { get; set; }

    /// <summary>
    /// Group the discount applies to such as Reseller or Customer.
    /// </summary>
    [Required]
    [StringLength(50)]
    public string Category { get; set; }

    /// <summary>
    /// Discount start date.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime StartDate { get; set; }

    /// <summary>
    /// Discount end date.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime EndDate { get; set; }

    /// <summary>
    /// Minimum discount percent allowed.
    /// </summary>
    public int MinQty { get; set; }

    /// <summary>
    /// Maximum discount percent allowed.
    /// </summary>
    public int? MaxQty { get; set; }

    /// <summary>
    /// ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.
    /// </summary>
    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    /// <summary>
    /// Date and time the record was last updated.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [InverseProperty("SpecialOffer")]
    public virtual ICollection<SpecialOfferProduct> SpecialOfferProducts { get; set; } = new List<SpecialOfferProduct>();
}
