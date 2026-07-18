// Copyright Information
// ==================================
// EFCoreExamples - 01_PerformanceEfCore - ProductVendor.cs
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
/// Cross-reference table mapping vendors with the products they supply.
/// </summary>
[PrimaryKey("ProductId", "BusinessEntityId")]
[Table("ProductVendor", Schema = "Purchasing")]
[Index("BusinessEntityId", Name = "IX_ProductVendor_BusinessEntityID")]
[Index("UnitMeasureCode", Name = "IX_ProductVendor_UnitMeasureCode")]
public partial class ProductVendor
{
    /// <summary>
    /// Primary key. Foreign key to Product.ProductID.
    /// </summary>
    [Key]
    [Column("ProductID")]
    public int ProductId { get; set; }

    /// <summary>
    /// Primary key. Foreign key to Vendor.BusinessEntityID.
    /// </summary>
    [Key]
    [Column("BusinessEntityID")]
    public int BusinessEntityId { get; set; }

    /// <summary>
    /// The average span of time (in days) between placing an order with the vendor and receiving the purchased product.
    /// </summary>
    public int AverageLeadTime { get; set; }

    /// <summary>
    /// The vendor&apos;s usual selling price.
    /// </summary>
    [Column(TypeName = "money")]
    public decimal StandardPrice { get; set; }

    /// <summary>
    /// The selling price when last purchased.
    /// </summary>
    [Column(TypeName = "money")]
    public decimal? LastReceiptCost { get; set; }

    /// <summary>
    /// Date the product was last received by the vendor.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime? LastReceiptDate { get; set; }

    /// <summary>
    /// The maximum quantity that should be ordered.
    /// </summary>
    public int MinOrderQty { get; set; }

    /// <summary>
    /// The minimum quantity that should be ordered.
    /// </summary>
    public int MaxOrderQty { get; set; }

    /// <summary>
    /// The quantity currently on order.
    /// </summary>
    public int? OnOrderQty { get; set; }

    /// <summary>
    /// The product&apos;s unit of measure.
    /// </summary>
    [Required]
    [StringLength(3)]
    public string UnitMeasureCode { get; set; }

    /// <summary>
    /// Date and time the record was last updated.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [ForeignKey("BusinessEntityId")]
    [InverseProperty("ProductVendors")]
    public virtual Vendor BusinessEntity { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("ProductVendors")]
    public virtual Product Product { get; set; }

    [ForeignKey("UnitMeasureCode")]
    [InverseProperty("ProductVendors")]
    public virtual UnitMeasure UnitMeasureCodeNavigation { get; set; }
}
