// Copyright Information
// ==================================
// EFCoreExamples - 01_PerformanceEfCore - Location.cs
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
/// Product inventory and manufacturing locations.
/// </summary>
[Table("Location", Schema = "Production")]
[Index("Name", Name = "AK_Location_Name", IsUnique = true)]
public partial class Location
{
    /// <summary>
    /// Primary key for Location records.
    /// </summary>
    [Key]
    [Column("LocationID")]
    public short LocationId { get; set; }

    /// <summary>
    /// Location description.
    /// </summary>
    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    /// <summary>
    /// Standard hourly cost of the manufacturing location.
    /// </summary>
    [Column(TypeName = "smallmoney")]
    public decimal CostRate { get; set; }

    /// <summary>
    /// Work capacity (in hours) of the manufacturing location.
    /// </summary>
    [Column(TypeName = "decimal(8, 2)")]
    public decimal Availability { get; set; }

    /// <summary>
    /// Date and time the record was last updated.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [InverseProperty("Location")]
    public virtual ICollection<ProductInventory> ProductInventories { get; set; } = new List<ProductInventory>();

    [InverseProperty("Location")]
    public virtual ICollection<WorkOrderRouting> WorkOrderRoutings { get; set; } = new List<WorkOrderRouting>();
}
