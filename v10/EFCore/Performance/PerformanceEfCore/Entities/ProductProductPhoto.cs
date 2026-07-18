// Copyright Information
// ==================================
// EFCoreExamples - 01_PerformanceEfCore - ProductProductPhoto.cs
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
/// Cross-reference table mapping products and product photos.
/// </summary>
[PrimaryKey("ProductId", "ProductPhotoId")]
[Table("ProductProductPhoto", Schema = "Production")]
public partial class ProductProductPhoto
{
    /// <summary>
    /// Product identification number. Foreign key to Product.ProductID.
    /// </summary>
    [Key]
    [Column("ProductID")]
    public int ProductId { get; set; }

    /// <summary>
    /// Product photo identification number. Foreign key to ProductPhoto.ProductPhotoID.
    /// </summary>
    [Key]
    [Column("ProductPhotoID")]
    public int ProductPhotoId { get; set; }

    /// <summary>
    /// 0 = Photo is not the principal image. 1 = Photo is the principal image.
    /// </summary>
    public bool Primary { get; set; }

    /// <summary>
    /// Date and time the record was last updated.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("ProductProductPhotos")]
    public virtual Product Product { get; set; }

    [ForeignKey("ProductPhotoId")]
    [InverseProperty("ProductProductPhotos")]
    public virtual ProductPhoto ProductPhoto { get; set; }
}
