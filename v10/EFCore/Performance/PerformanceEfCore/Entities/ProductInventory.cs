// Copyright Information
// ==================================
// EFCoreExamples - 01_PerformanceEfCore - ProductInventory.cs
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
/// Product inventory information.
/// </summary>
[PrimaryKey("ProductId", "LocationId")]
[Table("ProductInventory", Schema = "Production")]
public partial class ProductInventory
{
    /// <summary>
    /// Product identification number. Foreign key to Product.ProductID.
    /// </summary>
    [Key]
    [Column("ProductID")]
    public int ProductId { get; set; }

    /// <summary>
    /// Inventory location identification number. Foreign key to Location.LocationID. 
    /// </summary>
    [Key]
    [Column("LocationID")]
    public short LocationId { get; set; }

    /// <summary>
    /// Storage compartment within an inventory location.
    /// </summary>
    [Required]
    [StringLength(10)]
    public string Shelf { get; set; }

    /// <summary>
    /// Storage container on a shelf in an inventory location.
    /// </summary>
    public byte Bin { get; set; }

    /// <summary>
    /// Quantity of products in the inventory location.
    /// </summary>
    public short Quantity { get; set; }

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

    [ForeignKey("LocationId")]
    [InverseProperty("ProductInventories")]
    public virtual Location Location { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("ProductInventories")]
    public virtual Product Product { get; set; }
}
