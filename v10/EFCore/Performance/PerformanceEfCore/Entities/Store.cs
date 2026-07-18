// Copyright Information
// ==================================
// EFCoreExamples - 01_PerformanceEfCore - Store.cs
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
/// Customers (resellers) of Adventure Works products.
/// </summary>
[Table("Store", Schema = "Sales")]
[Index("Rowguid", Name = "AK_Store_rowguid", IsUnique = true)]
[Index("SalesPersonId", Name = "IX_Store_SalesPersonID")]
[Index("Demographics", Name = "PXML_Store_Demographics")]
public partial class Store
{
    /// <summary>
    /// Primary key. Foreign key to Customer.BusinessEntityID.
    /// </summary>
    [Key]
    [Column("BusinessEntityID")]
    public int BusinessEntityId { get; set; }

    /// <summary>
    /// Name of the store.
    /// </summary>
    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    /// <summary>
    /// ID of the sales person assigned to the customer. Foreign key to SalesPerson.BusinessEntityID.
    /// </summary>
    [Column("SalesPersonID")]
    public int? SalesPersonId { get; set; }

    /// <summary>
    /// Demographic informationg about the store such as the number of employees, annual sales and store type.
    /// </summary>
    [Column(TypeName = "xml")]
    public string Demographics { get; set; }

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

    [ForeignKey("BusinessEntityId")]
    [InverseProperty("Store")]
    public virtual BusinessEntity BusinessEntity { get; set; }

    [InverseProperty("Store")]
    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    [ForeignKey("SalesPersonId")]
    [InverseProperty("Stores")]
    public virtual SalesPerson SalesPerson { get; set; }
}
