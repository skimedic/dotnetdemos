// Copyright Information
// ==================================
// EFCoreExamples - 01_PerformanceEfCore - BillOfMaterial.cs
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
/// Items required to make bicycles and bicycle subassemblies. It identifies the heirarchical relationship between a parent product and its components.
/// </summary>
[Table("BillOfMaterials", Schema = "Production")]
[Index("UnitMeasureCode", Name = "IX_BillOfMaterials_UnitMeasureCode")]
public partial class BillOfMaterial
{
    /// <summary>
    /// Primary key for BillOfMaterials records.
    /// </summary>
    [Key]
    [Column("BillOfMaterialsID")]
    public int BillOfMaterialsId { get; set; }

    /// <summary>
    /// Parent product identification number. Foreign key to Product.ProductID.
    /// </summary>
    [Column("ProductAssemblyID")]
    public int? ProductAssemblyId { get; set; }

    /// <summary>
    /// Component identification number. Foreign key to Product.ProductID.
    /// </summary>
    [Column("ComponentID")]
    public int ComponentId { get; set; }

    /// <summary>
    /// Date the component started being used in the assembly item.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime StartDate { get; set; }

    /// <summary>
    /// Date the component stopped being used in the assembly item.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime? EndDate { get; set; }

    /// <summary>
    /// Standard code identifying the unit of measure for the quantity.
    /// </summary>
    [Required]
    [StringLength(3)]
    public string UnitMeasureCode { get; set; }

    /// <summary>
    /// Indicates the depth the component is from its parent (AssemblyID).
    /// </summary>
    [Column("BOMLevel")]
    public short Bomlevel { get; set; }

    /// <summary>
    /// Quantity of the component needed to create the assembly.
    /// </summary>
    [Column(TypeName = "decimal(8, 2)")]
    public decimal PerAssemblyQty { get; set; }

    /// <summary>
    /// Date and time the record was last updated.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [ForeignKey("ComponentId")]
    [InverseProperty("BillOfMaterialComponents")]
    public virtual Product Component { get; set; }

    [ForeignKey("ProductAssemblyId")]
    [InverseProperty("BillOfMaterialProductAssemblies")]
    public virtual Product ProductAssembly { get; set; }

    [ForeignKey("UnitMeasureCode")]
    [InverseProperty("BillOfMaterials")]
    public virtual UnitMeasure UnitMeasureCodeNavigation { get; set; }
}
