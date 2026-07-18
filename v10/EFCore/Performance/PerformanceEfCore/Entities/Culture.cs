// Copyright Information
// ==================================
// EFCoreExamples - 01_PerformanceEfCore - Culture.cs
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
/// Lookup table containing the languages in which some AdventureWorks data is stored.
/// </summary>
[Table("Culture", Schema = "Production")]
[Index("Name", Name = "AK_Culture_Name", IsUnique = true)]
public partial class Culture
{
    /// <summary>
    /// Primary key for Culture records.
    /// </summary>
    [Key]
    [Column("CultureID")]
    [StringLength(6)]
    public string CultureId { get; set; }

    /// <summary>
    /// Culture description.
    /// </summary>
    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    /// <summary>
    /// Date and time the record was last updated.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [InverseProperty("Culture")]
    public virtual ICollection<ProductModelProductDescriptionCulture> ProductModelProductDescriptionCultures { get; set; } = new List<ProductModelProductDescriptionCulture>();
}
