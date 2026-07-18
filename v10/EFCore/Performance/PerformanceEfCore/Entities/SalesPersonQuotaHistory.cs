// Copyright Information
// ==================================
// EFCoreExamples - 01_PerformanceEfCore - SalesPersonQuotaHistory.cs
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
/// Sales performance tracking.
/// </summary>
[PrimaryKey("BusinessEntityId", "QuotaDate")]
[Table("SalesPersonQuotaHistory", Schema = "Sales")]
[Index("Rowguid", Name = "AK_SalesPersonQuotaHistory_rowguid", IsUnique = true)]
public partial class SalesPersonQuotaHistory
{
    /// <summary>
    /// Sales person identification number. Foreign key to SalesPerson.BusinessEntityID.
    /// </summary>
    [Key]
    [Column("BusinessEntityID")]
    public int BusinessEntityId { get; set; }

    /// <summary>
    /// Sales quota date.
    /// </summary>
    [Key]
    [Column(TypeName = "datetime")]
    public DateTime QuotaDate { get; set; }

    /// <summary>
    /// Sales quota amount.
    /// </summary>
    [Column(TypeName = "money")]
    public decimal SalesQuota { get; set; }

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
    [InverseProperty("SalesPersonQuotaHistories")]
    public virtual SalesPerson BusinessEntity { get; set; }
}
