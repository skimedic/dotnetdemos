// Copyright Information
// ==================================
// EFCoreExamples - 01_PerformanceEfCore - ProductDescription.cs
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
/// Product descriptions in several languages.
/// </summary>
[Table("ProductDescription", Schema = "Production")]
[Index("Rowguid", Name = "AK_ProductDescription_rowguid", IsUnique = true)]
public partial class ProductDescription
{
    /// <summary>
    /// Primary key for ProductDescription records.
    /// </summary>
    [Key]
    [Column("ProductDescriptionID")]
    public int ProductDescriptionId { get; set; }

    /// <summary>
    /// Description of the product.
    /// </summary>
    [Required]
    [StringLength(400)]
    public string Description { get; set; }

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

    [InverseProperty("ProductDescription")]
    public virtual ICollection<ProductModelProductDescriptionCulture> ProductModelProductDescriptionCultures { get; set; } = new List<ProductModelProductDescriptionCulture>();
}
