// Copyright Information
// ==================================
// EFCoreExamples - 01_PerformanceEfCore - ProductCategory.cs
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
/// High-level product categorization.
/// </summary>
[Table("ProductCategory", Schema = "Production")]
[Index("Name", Name = "AK_ProductCategory_Name", IsUnique = true)]
[Index("Rowguid", Name = "AK_ProductCategory_rowguid", IsUnique = true)]
public partial class ProductCategory
{
    /// <summary>
    /// Primary key for ProductCategory records.
    /// </summary>
    [Key]
    [Column("ProductCategoryID")]
    public int ProductCategoryId { get; set; }

    /// <summary>
    /// Category description.
    /// </summary>
    [Required]
    [StringLength(50)]
    public string Name { get; set; }

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

    [InverseProperty("ProductCategory")]
    public virtual ICollection<ProductSubcategory> ProductSubcategories { get; set; } = new List<ProductSubcategory>();
}
