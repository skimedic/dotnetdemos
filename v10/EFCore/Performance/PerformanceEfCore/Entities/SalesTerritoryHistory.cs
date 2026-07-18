// Copyright Information
// ==================================
// EFCoreExamples - 01_PerformanceEfCore - SalesTerritoryHistory.cs
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
/// Sales representative transfers to other sales territories.
/// </summary>
[PrimaryKey("BusinessEntityId", "StartDate", "TerritoryId")]
[Table("SalesTerritoryHistory", Schema = "Sales")]
[Index("Rowguid", Name = "AK_SalesTerritoryHistory_rowguid", IsUnique = true)]
public partial class SalesTerritoryHistory
{
    /// <summary>
    /// Primary key. The sales rep.  Foreign key to SalesPerson.BusinessEntityID.
    /// </summary>
    [Key]
    [Column("BusinessEntityID")]
    public int BusinessEntityId { get; set; }

    /// <summary>
    /// Primary key. Territory identification number. Foreign key to SalesTerritory.SalesTerritoryID.
    /// </summary>
    [Key]
    [Column("TerritoryID")]
    public int TerritoryId { get; set; }

    /// <summary>
    /// Primary key. Date the sales representive started work in the territory.
    /// </summary>
    [Key]
    [Column(TypeName = "datetime")]
    public DateTime StartDate { get; set; }

    /// <summary>
    /// Date the sales representative left work in the territory.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime? EndDate { get; set; }

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
    [InverseProperty("SalesTerritoryHistories")]
    public virtual SalesPerson BusinessEntity { get; set; }

    [ForeignKey("TerritoryId")]
    [InverseProperty("SalesTerritoryHistories")]
    public virtual SalesTerritory Territory { get; set; }
}
