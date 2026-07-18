// Copyright Information
// ==================================
// EFCoreExamples - 01_PerformanceEfCore - UnitMeasure.cs
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
/// Unit of measure lookup table.
/// </summary>
[Table("UnitMeasure", Schema = "Production")]
[Index("Name", Name = "AK_UnitMeasure_Name", IsUnique = true)]
public partial class UnitMeasure
{
    /// <summary>
    /// Primary key.
    /// </summary>
    [Key]
    [StringLength(3)]
    public string UnitMeasureCode { get; set; }

    /// <summary>
    /// Unit of measure description.
    /// </summary>
    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    /// <summary>
    /// Date and time the record was last updated.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [InverseProperty("UnitMeasureCodeNavigation")]
    public virtual ICollection<BillOfMaterial> BillOfMaterials { get; set; } = new List<BillOfMaterial>();

    [InverseProperty("SizeUnitMeasureCodeNavigation")]
    public virtual ICollection<Product> ProductSizeUnitMeasureCodeNavigations { get; set; } = new List<Product>();

    [InverseProperty("UnitMeasureCodeNavigation")]
    public virtual ICollection<ProductVendor> ProductVendors { get; set; } = new List<ProductVendor>();

    [InverseProperty("WeightUnitMeasureCodeNavigation")]
    public virtual ICollection<Product> ProductWeightUnitMeasureCodeNavigations { get; set; } = new List<Product>();
}
