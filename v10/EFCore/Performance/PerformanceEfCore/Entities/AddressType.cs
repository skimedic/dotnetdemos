// Copyright Information
// ==================================
// EFCoreExamples - 01_PerformanceEfCore - AddressType.cs
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
/// Types of addresses stored in the Address table. 
/// </summary>
[Table("AddressType", Schema = "Person")]
[Index("Name", Name = "AK_AddressType_Name", IsUnique = true)]
[Index("Rowguid", Name = "AK_AddressType_rowguid", IsUnique = true)]
public partial class AddressType
{
    /// <summary>
    /// Primary key for AddressType records.
    /// </summary>
    [Key]
    [Column("AddressTypeID")]
    public int AddressTypeId { get; set; }

    /// <summary>
    /// Address type description. For example, Billing, Home, or Shipping.
    /// </summary>
    [Required]
    [StringLength(50)]
    public string Name { get; set; }

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

    [InverseProperty("AddressType")]
    public virtual ICollection<BusinessEntityAddress> BusinessEntityAddresses { get; set; } = new List<BusinessEntityAddress>();
}
