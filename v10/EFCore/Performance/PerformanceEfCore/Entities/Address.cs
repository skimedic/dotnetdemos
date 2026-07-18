// Copyright Information
// ==================================
// EFCoreExamples - 01_PerformanceEfCore - Address.cs
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
/// Street address information for customers, employees, and vendors.
/// </summary>
[Table("Address", Schema = "Person")]
[Index("Rowguid", Name = "AK_Address_rowguid", IsUnique = true)]
[Index("AddressLine1", "AddressLine2", "City", "StateProvinceId", "PostalCode", Name = "IX_Address_AddressLine1_AddressLine2_City_StateProvinceID_PostalCode", IsUnique = true)]
[Index("StateProvinceId", Name = "IX_Address_StateProvinceID")]
public partial class Address
{
    /// <summary>
    /// Primary key for Address records.
    /// </summary>
    [Key]
    [Column("AddressID")]
    public int AddressId { get; set; }

    /// <summary>
    /// First street address line.
    /// </summary>
    [Required]
    [StringLength(60)]
    public string AddressLine1 { get; set; }

    /// <summary>
    /// Second street address line.
    /// </summary>
    [StringLength(60)]
    public string AddressLine2 { get; set; }

    /// <summary>
    /// Name of the city.
    /// </summary>
    [Required]
    [StringLength(30)]
    public string City { get; set; }

    /// <summary>
    /// Unique identification number for the state or province. Foreign key to StateProvince table.
    /// </summary>
    [Column("StateProvinceID")]
    public int StateProvinceId { get; set; }

    /// <summary>
    /// Postal code for the street address.
    /// </summary>
    [Required]
    [StringLength(15)]
    public string PostalCode { get; set; }

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

    [InverseProperty("Address")]
    public virtual ICollection<BusinessEntityAddress> BusinessEntityAddresses { get; set; } = new List<BusinessEntityAddress>();

    [InverseProperty("BillToAddress")]
    public virtual ICollection<SalesOrderHeader> SalesOrderHeaderBillToAddresses { get; set; } = new List<SalesOrderHeader>();

    [InverseProperty("ShipToAddress")]
    public virtual ICollection<SalesOrderHeader> SalesOrderHeaderShipToAddresses { get; set; } = new List<SalesOrderHeader>();

    [ForeignKey("StateProvinceId")]
    [InverseProperty("Addresses")]
    public virtual StateProvince StateProvince { get; set; }
}
