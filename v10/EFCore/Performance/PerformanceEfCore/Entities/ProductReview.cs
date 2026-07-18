// Copyright Information
// ==================================
// EFCoreExamples - 01_PerformanceEfCore - ProductReview.cs
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
/// Customer reviews of products they have purchased.
/// </summary>
[Table("ProductReview", Schema = "Production")]
[Index("ProductId", "ReviewerName", Name = "IX_ProductReview_ProductID_Name")]
public partial class ProductReview
{
    /// <summary>
    /// Primary key for ProductReview records.
    /// </summary>
    [Key]
    [Column("ProductReviewID")]
    public int ProductReviewId { get; set; }

    /// <summary>
    /// Product identification number. Foreign key to Product.ProductID.
    /// </summary>
    [Column("ProductID")]
    public int ProductId { get; set; }

    /// <summary>
    /// Name of the reviewer.
    /// </summary>
    [Required]
    [StringLength(50)]
    public string ReviewerName { get; set; }

    /// <summary>
    /// Date review was submitted.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime ReviewDate { get; set; }

    /// <summary>
    /// Reviewer&apos;s e-mail address.
    /// </summary>
    [Required]
    [StringLength(50)]
    public string EmailAddress { get; set; }

    /// <summary>
    /// Product rating given by the reviewer. Scale is 1 to 5 with 5 as the highest rating.
    /// </summary>
    public int Rating { get; set; }

    /// <summary>
    /// Reviewer&apos;s comments
    /// </summary>
    [StringLength(3850)]
    public string Comments { get; set; }

    /// <summary>
    /// Date and time the record was last updated.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("ProductReviews")]
    public virtual Product Product { get; set; }
}
