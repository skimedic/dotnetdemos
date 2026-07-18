// Copyright Information
// ==================================
// EFCoreExamples - 01_PerformanceEfCore - ProductPhoto.cs
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
/// Product images.
/// </summary>
[Table("ProductPhoto", Schema = "Production")]
public partial class ProductPhoto
{
    /// <summary>
    /// Primary key for ProductPhoto records.
    /// </summary>
    [Key]
    [Column("ProductPhotoID")]
    public int ProductPhotoId { get; set; }

    /// <summary>
    /// Small image of the product.
    /// </summary>
    public byte[] ThumbNailPhoto { get; set; }

    /// <summary>
    /// Small image file name.
    /// </summary>
    [StringLength(50)]
    public string ThumbnailPhotoFileName { get; set; }

    /// <summary>
    /// Large image of the product.
    /// </summary>
    public byte[] LargePhoto { get; set; }

    /// <summary>
    /// Large image file name.
    /// </summary>
    [StringLength(50)]
    public string LargePhotoFileName { get; set; }

    /// <summary>
    /// Date and time the record was last updated.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [InverseProperty("ProductPhoto")]
    public virtual ICollection<ProductProductPhoto> ProductProductPhotos { get; set; } = new List<ProductProductPhoto>();
}
