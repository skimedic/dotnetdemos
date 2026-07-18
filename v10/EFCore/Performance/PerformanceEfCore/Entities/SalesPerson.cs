// Copyright Information
// ==================================
// EFCoreExamples - 01_PerformanceEfCore - SalesPerson.cs
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
/// Sales representative current information.
/// </summary>
[Table("SalesPerson", Schema = "Sales")]
[Index("Rowguid", Name = "AK_SalesPerson_rowguid", IsUnique = true)]
public partial class SalesPerson
{
    /// <summary>
    /// Primary key for SalesPerson records. Foreign key to Employee.BusinessEntityID
    /// </summary>
    [Key]
    [Column("BusinessEntityID")]
    public int BusinessEntityId { get; set; }

    /// <summary>
    /// Territory currently assigned to. Foreign key to SalesTerritory.SalesTerritoryID.
    /// </summary>
    [Column("TerritoryID")]
    public int? TerritoryId { get; set; }

    /// <summary>
    /// Projected yearly sales.
    /// </summary>
    [Column(TypeName = "money")]
    public decimal? SalesQuota { get; set; }

    /// <summary>
    /// Bonus due if quota is met.
    /// </summary>
    [Column(TypeName = "money")]
    public decimal Bonus { get; set; }

    /// <summary>
    /// Commision percent received per sale.
    /// </summary>
    [Column(TypeName = "smallmoney")]
    public decimal CommissionPct { get; set; }

    /// <summary>
    /// Sales total year to date.
    /// </summary>
    [Column("SalesYTD", TypeName = "money")]
    public decimal SalesYtd { get; set; }

    /// <summary>
    /// Sales total of previous year.
    /// </summary>
    [Column(TypeName = "money")]
    public decimal SalesLastYear { get; set; }

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
    [InverseProperty("SalesPerson")]
    public virtual Employee BusinessEntity { get; set; }

    [InverseProperty("SalesPerson")]
    public virtual ICollection<SalesOrderHeader> SalesOrderHeaders { get; set; } = new List<SalesOrderHeader>();

    [InverseProperty("BusinessEntity")]
    public virtual ICollection<SalesPersonQuotaHistory> SalesPersonQuotaHistories { get; set; } = new List<SalesPersonQuotaHistory>();

    [InverseProperty("BusinessEntity")]
    public virtual ICollection<SalesTerritoryHistory> SalesTerritoryHistories { get; set; } = new List<SalesTerritoryHistory>();

    [InverseProperty("SalesPerson")]
    public virtual ICollection<Store> Stores { get; set; } = new List<Store>();

    [ForeignKey("TerritoryId")]
    [InverseProperty("SalesPeople")]
    public virtual SalesTerritory Territory { get; set; }
}
