// Copyright Information
// ==================================
// EFCoreExamples - 01_PerformanceEfCore - EmployeePayHistory.cs
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
/// Employee pay history.
/// </summary>
[PrimaryKey("BusinessEntityId", "RateChangeDate")]
[Table("EmployeePayHistory", Schema = "HumanResources")]
public partial class EmployeePayHistory
{
    /// <summary>
    /// Employee identification number. Foreign key to Employee.BusinessEntityID.
    /// </summary>
    [Key]
    [Column("BusinessEntityID")]
    public int BusinessEntityId { get; set; }

    /// <summary>
    /// Date the change in pay is effective
    /// </summary>
    [Key]
    [Column(TypeName = "datetime")]
    public DateTime RateChangeDate { get; set; }

    /// <summary>
    /// Salary hourly rate.
    /// </summary>
    [Column(TypeName = "money")]
    public decimal Rate { get; set; }

    /// <summary>
    /// 1 = Salary received monthly, 2 = Salary received biweekly
    /// </summary>
    public byte PayFrequency { get; set; }

    /// <summary>
    /// Date and time the record was last updated.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [ForeignKey("BusinessEntityId")]
    [InverseProperty("EmployeePayHistories")]
    public virtual Employee BusinessEntity { get; set; }
}
