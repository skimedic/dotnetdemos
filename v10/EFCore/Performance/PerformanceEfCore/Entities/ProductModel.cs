// Copyright Information
// ==================================
// EFCoreExamples - 01_PerformanceEfCore - ProductModel.cs
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
/// Product model classification.
/// </summary>
[Table("ProductModel", Schema = "Production")]
[Index("Name", Name = "AK_ProductModel_Name", IsUnique = true)]
[Index("Rowguid", Name = "AK_ProductModel_rowguid", IsUnique = true)]
[Index("CatalogDescription", Name = "PXML_ProductModel_CatalogDescription")]
[Index("Instructions", Name = "PXML_ProductModel_Instructions")]
public partial class ProductModel
{
    /// <summary>
    /// Primary key for ProductModel records.
    /// </summary>
    [Key]
    [Column("ProductModelID")]
    public int ProductModelId { get; set; }

    /// <summary>
    /// Product model description.
    /// </summary>
    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    /// <summary>
    /// Detailed product catalog information in xml format.
    /// </summary>
    [Column(TypeName = "xml")]
    public string CatalogDescription { get; set; }

    /// <summary>
    /// Manufacturing instructions in xml format.
    /// </summary>
    [Column(TypeName = "xml")]
    public string Instructions { get; set; }

    /// <summary>
    /// ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.
    /// </summary>
    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    /// <summary>
    /// Date and time the record was last updated.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [InverseProperty("ProductModel")]
    public virtual ICollection<ProductModelIllustration> ProductModelIllustrations { get; set; } = new List<ProductModelIllustration>();

    [InverseProperty("ProductModel")]
    public virtual ICollection<ProductModelProductDescriptionCulture> ProductModelProductDescriptionCultures { get; set; } = new List<ProductModelProductDescriptionCulture>();

    [InverseProperty("ProductModel")]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
