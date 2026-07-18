// Copyright Information
// ==================================
// EFCoreExamples - 01_PerformanceEfCore - ProductCostHistory.cs
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
/// Changes in the cost of a product over time.
/// </summary>
[PrimaryKey("ProductId", "StartDate")]
[Table("ProductCostHistory", Schema = "Production")]
public partial class ProductCostHistory
{
    /// <summary>
    /// Product identification number. Foreign key to Product.ProductID
    /// </summary>
    [Key]
    [Column("ProductID")]
    public int ProductId { get; set; }

    /// <summary>
    /// Product cost start date.
    /// </summary>
    [Key]
    [Column(TypeName = "datetime")]
    public DateTime StartDate { get; set; }

    /// <summary>
    /// Product cost end date.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime? EndDate { get; set; }

    /// <summary>
    /// Standard cost of the product.
    /// </summary>
    [Column(TypeName = "money")]
    public decimal StandardCost { get; set; }

    /// <summary>
    /// Date and time the record was last updated.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("ProductCostHistories")]
    public virtual Product Product { get; set; }
}
