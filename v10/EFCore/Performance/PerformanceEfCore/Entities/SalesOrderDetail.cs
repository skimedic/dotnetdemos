// Copyright Information
// ==================================
// EFCoreExamples - 01_PerformanceEfCore - SalesOrderDetail.cs
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
/// Individual products associated with a specific sales order. See SalesOrderHeader.
/// </summary>
[PrimaryKey("SalesOrderId", "SalesOrderDetailId")]
[Table("SalesOrderDetail", Schema = "Sales")]
[Index("Rowguid", Name = "AK_SalesOrderDetail_rowguid", IsUnique = true)]
[Index("ProductId", Name = "IX_SalesOrderDetail_ProductID")]
public partial class SalesOrderDetail
{
    /// <summary>
    /// Primary key. Foreign key to SalesOrderHeader.SalesOrderID.
    /// </summary>
    [Key]
    [Column("SalesOrderID")]
    public int SalesOrderId { get; set; }

    /// <summary>
    /// Primary key. One incremental unique number per product sold.
    /// </summary>
    [Key]
    [Column("SalesOrderDetailID")]
    public int SalesOrderDetailId { get; set; }

    /// <summary>
    /// Shipment tracking number supplied by the shipper.
    /// </summary>
    [StringLength(25)]
    public string CarrierTrackingNumber { get; set; }

    /// <summary>
    /// Quantity ordered per product.
    /// </summary>
    public short OrderQty { get; set; }

    /// <summary>
    /// Product sold to customer. Foreign key to Product.ProductID.
    /// </summary>
    [Column("ProductID")]
    public int ProductId { get; set; }

    /// <summary>
    /// Promotional code. Foreign key to SpecialOffer.SpecialOfferID.
    /// </summary>
    [Column("SpecialOfferID")]
    public int SpecialOfferId { get; set; }

    /// <summary>
    /// Selling price of a single product.
    /// </summary>
    [Column(TypeName = "money")]
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Discount amount.
    /// </summary>
    [Column(TypeName = "money")]
    public decimal UnitPriceDiscount { get; set; }

    /// <summary>
    /// Per product subtotal. Computed as UnitPrice * (1 - UnitPriceDiscount) * OrderQty.
    /// </summary>
    [Column(TypeName = "numeric(38, 6)")]
    public decimal LineTotal { get; set; }

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

    [ForeignKey("SalesOrderId")]
    [InverseProperty("SalesOrderDetails")]
    public virtual SalesOrderHeader SalesOrder { get; set; }

    [ForeignKey("SpecialOfferId, ProductId")]
    [InverseProperty("SalesOrderDetails")]
    public virtual SpecialOfferProduct SpecialOfferProduct { get; set; }
}
