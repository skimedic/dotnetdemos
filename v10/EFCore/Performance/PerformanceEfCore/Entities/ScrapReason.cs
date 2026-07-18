// Copyright Information
// ==================================
// EFCoreExamples - 01_PerformanceEfCore - ScrapReason.cs
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
/// Manufacturing failure reasons lookup table.
/// </summary>
[Table("ScrapReason", Schema = "Production")]
[Index("Name", Name = "AK_ScrapReason_Name", IsUnique = true)]
public partial class ScrapReason
{
    /// <summary>
    /// Primary key for ScrapReason records.
    /// </summary>
    [Key]
    [Column("ScrapReasonID")]
    public short ScrapReasonId { get; set; }

    /// <summary>
    /// Failure description.
    /// </summary>
    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    /// <summary>
    /// Date and time the record was last updated.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [InverseProperty("ScrapReason")]
    public virtual ICollection<WorkOrder> WorkOrders { get; set; } = new List<WorkOrder>();
}
