// Copyright Information
// ==================================
// EFCoreExamples - 01_PerformanceEfCore - PurchaseOrderDetail.cs
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
/// Individual products associated with a specific purchase order. See PurchaseOrderHeader.
/// </summary>
[PrimaryKey("PurchaseOrderId", "PurchaseOrderDetailId")]
[Table("PurchaseOrderDetail", Schema = "Purchasing")]
[Index("ProductId", Name = "IX_PurchaseOrderDetail_ProductID")]
public partial class PurchaseOrderDetail
{
    /// <summary>
    /// Primary key. Foreign key to PurchaseOrderHeader.PurchaseOrderID.
    /// </summary>
    [Key]
    [Column("PurchaseOrderID")]
    public int PurchaseOrderId { get; set; }

    /// <summary>
    /// Primary key. One line number per purchased product.
    /// </summary>
    [Key]
    [Column("PurchaseOrderDetailID")]
    public int PurchaseOrderDetailId { get; set; }

    /// <summary>
    /// Date the product is expected to be received.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime DueDate { get; set; }

    /// <summary>
    /// Quantity ordered.
    /// </summary>
    public short OrderQty { get; set; }

    /// <summary>
    /// Product identification number. Foreign key to Product.ProductID.
    /// </summary>
    [Column("ProductID")]
    public int ProductId { get; set; }

    /// <summary>
    /// Vendor&apos;s selling price of a single product.
    /// </summary>
    [Column(TypeName = "money")]
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Per product subtotal. Computed as OrderQty * UnitPrice.
    /// </summary>
    [Column(TypeName = "money")]
    public decimal LineTotal { get; set; }

    /// <summary>
    /// Quantity actually received from the vendor.
    /// </summary>
    [Column(TypeName = "decimal(8, 2)")]
    public decimal ReceivedQty { get; set; }

    /// <summary>
    /// Quantity rejected during inspection.
    /// </summary>
    [Column(TypeName = "decimal(8, 2)")]
    public decimal RejectedQty { get; set; }

    /// <summary>
    /// Quantity accepted into inventory. Computed as ReceivedQty - RejectedQty.
    /// </summary>
    [Column(TypeName = "decimal(9, 2)")]
    public decimal StockedQty { get; set; }

    /// <summary>
    /// Date and time the record was last updated.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("PurchaseOrderDetails")]
    public virtual Product Product { get; set; }

    [ForeignKey("PurchaseOrderId")]
    [InverseProperty("PurchaseOrderDetails")]
    public virtual PurchaseOrderHeader PurchaseOrder { get; set; }
}
