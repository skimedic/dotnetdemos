// Copyright Information
// ==================================
// EFCoreExamples - 01_PerformanceEfCore - ProductModelIllustration.cs
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
/// Cross-reference table mapping product models and illustrations.
/// </summary>
[PrimaryKey("ProductModelId", "IllustrationId")]
[Table("ProductModelIllustration", Schema = "Production")]
public partial class ProductModelIllustration
{
    /// <summary>
    /// Primary key. Foreign key to ProductModel.ProductModelID.
    /// </summary>
    [Key]
    [Column("ProductModelID")]
    public int ProductModelId { get; set; }

    /// <summary>
    /// Primary key. Foreign key to Illustration.IllustrationID.
    /// </summary>
    [Key]
    [Column("IllustrationID")]
    public int IllustrationId { get; set; }

    /// <summary>
    /// Date and time the record was last updated.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [ForeignKey("IllustrationId")]
    [InverseProperty("ProductModelIllustrations")]
    public virtual Illustration Illustration { get; set; }

    [ForeignKey("ProductModelId")]
    [InverseProperty("ProductModelIllustrations")]
    public virtual ProductModel ProductModel { get; set; }
}
