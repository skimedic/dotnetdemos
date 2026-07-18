// Copyright Information
// ==================================
// EFCoreExamples - 01_PerformanceEfCore - Customer.cs
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
/// Current customer information. Also see the Person and Store tables.
/// </summary>
[Table("Customer", Schema = "Sales")]
[Index("AccountNumber", Name = "AK_Customer_AccountNumber", IsUnique = true)]
[Index("Rowguid", Name = "AK_Customer_rowguid", IsUnique = true)]
[Index("TerritoryId", Name = "IX_Customer_TerritoryID")]
public partial class Customer
{
    /// <summary>
    /// Primary key.
    /// </summary>
    [Key]
    [Column("CustomerID")]
    public int CustomerId { get; set; }

    /// <summary>
    /// Foreign key to Person.BusinessEntityID
    /// </summary>
    [Column("PersonID")]
    public int? PersonId { get; set; }

    /// <summary>
    /// Foreign key to Store.BusinessEntityID
    /// </summary>
    [Column("StoreID")]
    public int? StoreId { get; set; }

    /// <summary>
    /// ID of the territory in which the customer is located. Foreign key to SalesTerritory.SalesTerritoryID.
    /// </summary>
    [Column("TerritoryID")]
    public int? TerritoryId { get; set; }

    /// <summary>
    /// Unique number identifying the customer assigned by the accounting system.
    /// </summary>
    [Required]
    [StringLength(10)]
    [Unicode(false)]
    public string AccountNumber { get; set; }

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

    [ForeignKey("PersonId")]
    [InverseProperty("Customers")]
    public virtual Person Person { get; set; }

    [InverseProperty("Customer")]
    public virtual ICollection<SalesOrderHeader> SalesOrderHeaders { get; set; } = new List<SalesOrderHeader>();

    [ForeignKey("StoreId")]
    [InverseProperty("Customers")]
    public virtual Store Store { get; set; }

    [ForeignKey("TerritoryId")]
    [InverseProperty("Customers")]
    public virtual SalesTerritory Territory { get; set; }
}
