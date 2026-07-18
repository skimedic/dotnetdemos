// Copyright Information
// ==================================
// EFCoreExamples - 01_PerformanceEfCore - Vendor.cs
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
/// Companies from whom Adventure Works Cycles purchases parts or other goods.
/// </summary>
[Table("Vendor", Schema = "Purchasing")]
[Index("AccountNumber", Name = "AK_Vendor_AccountNumber", IsUnique = true)]
public partial class Vendor
{
    /// <summary>
    /// Primary key for Vendor records.  Foreign key to BusinessEntity.BusinessEntityID
    /// </summary>
    [Key]
    [Column("BusinessEntityID")]
    public int BusinessEntityId { get; set; }

    /// <summary>
    /// Vendor account (identification) number.
    /// </summary>
    [Required]
    [StringLength(15)]
    public string AccountNumber { get; set; }

    /// <summary>
    /// Company name.
    /// </summary>
    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    /// <summary>
    /// 1 = Superior, 2 = Excellent, 3 = Above average, 4 = Average, 5 = Below average
    /// </summary>
    public byte CreditRating { get; set; }

    /// <summary>
    /// 0 = Do not use if another vendor is available. 1 = Preferred over other vendors supplying the same product.
    /// </summary>
    public bool PreferredVendorStatus { get; set; }

    /// <summary>
    /// 0 = Vendor no longer used. 1 = Vendor is actively used.
    /// </summary>
    public bool ActiveFlag { get; set; }

    /// <summary>
    /// Vendor URL.
    /// </summary>
    [Column("PurchasingWebServiceURL")]
    [StringLength(1024)]
    public string PurchasingWebServiceUrl { get; set; }

    /// <summary>
    /// Date and time the record was last updated.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [ForeignKey("BusinessEntityId")]
    [InverseProperty("Vendor")]
    public virtual BusinessEntity BusinessEntity { get; set; }

    [InverseProperty("BusinessEntity")]
    public virtual ICollection<ProductVendor> ProductVendors { get; set; } = new List<ProductVendor>();

    [InverseProperty("Vendor")]
    public virtual ICollection<PurchaseOrderHeader> PurchaseOrderHeaders { get; set; } = new List<PurchaseOrderHeader>();
}
