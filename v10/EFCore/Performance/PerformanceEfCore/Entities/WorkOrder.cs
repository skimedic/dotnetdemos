// Copyright Information
// ==================================
// EFCoreExamples - 01_PerformanceEfCore - WorkOrder.cs
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
/// Manufacturing work orders.
/// </summary>
[Table("WorkOrder", Schema = "Production")]
[Index("ProductId", Name = "IX_WorkOrder_ProductID")]
[Index("ScrapReasonId", Name = "IX_WorkOrder_ScrapReasonID")]
public partial class WorkOrder
{
    /// <summary>
    /// Primary key for WorkOrder records.
    /// </summary>
    [Key]
    [Column("WorkOrderID")]
    public int WorkOrderId { get; set; }

    /// <summary>
    /// Product identification number. Foreign key to Product.ProductID.
    /// </summary>
    [Column("ProductID")]
    public int ProductId { get; set; }

    /// <summary>
    /// Product quantity to build.
    /// </summary>
    public int OrderQty { get; set; }

    /// <summary>
    /// Quantity built and put in inventory.
    /// </summary>
    public int StockedQty { get; set; }

    /// <summary>
    /// Quantity that failed inspection.
    /// </summary>
    public short ScrappedQty { get; set; }

    /// <summary>
    /// Work order start date.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime StartDate { get; set; }

    /// <summary>
    /// Work order end date.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime? EndDate { get; set; }

    /// <summary>
    /// Work order due date.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime DueDate { get; set; }

    /// <summary>
    /// Reason for inspection failure.
    /// </summary>
    [Column("ScrapReasonID")]
    public short? ScrapReasonId { get; set; }

    /// <summary>
    /// Date and time the record was last updated.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("WorkOrders")]
    public virtual Product Product { get; set; }

    [ForeignKey("ScrapReasonId")]
    [InverseProperty("WorkOrders")]
    public virtual ScrapReason ScrapReason { get; set; }

    [InverseProperty("WorkOrder")]
    public virtual ICollection<WorkOrderRouting> WorkOrderRoutings { get; set; } = new List<WorkOrderRouting>();
}
