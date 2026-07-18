// Copyright Information
// ==================================
// EFCoreExamples - 01_PerformanceEfCore - TransactionHistoryArchive.cs
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
/// Transactions for previous years.
/// </summary>
[Table("TransactionHistoryArchive", Schema = "Production")]
[Index("ProductId", Name = "IX_TransactionHistoryArchive_ProductID")]
[Index("ReferenceOrderId", "ReferenceOrderLineId", Name = "IX_TransactionHistoryArchive_ReferenceOrderID_ReferenceOrderLineID")]
public partial class TransactionHistoryArchive
{
    /// <summary>
    /// Primary key for TransactionHistoryArchive records.
    /// </summary>
    [Key]
    [Column("TransactionID")]
    public int TransactionId { get; set; }

    /// <summary>
    /// Product identification number. Foreign key to Product.ProductID.
    /// </summary>
    [Column("ProductID")]
    public int ProductId { get; set; }

    /// <summary>
    /// Purchase order, sales order, or work order identification number.
    /// </summary>
    [Column("ReferenceOrderID")]
    public int ReferenceOrderId { get; set; }

    /// <summary>
    /// Line number associated with the purchase order, sales order, or work order.
    /// </summary>
    [Column("ReferenceOrderLineID")]
    public int ReferenceOrderLineId { get; set; }

    /// <summary>
    /// Date and time of the transaction.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime TransactionDate { get; set; }

    /// <summary>
    /// W = Work Order, S = Sales Order, P = Purchase Order
    /// </summary>
    [Required]
    [StringLength(1)]
    public string TransactionType { get; set; }

    /// <summary>
    /// Product quantity.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Product cost.
    /// </summary>
    [Column(TypeName = "money")]
    public decimal ActualCost { get; set; }

    /// <summary>
    /// Date and time the record was last updated.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }
}
