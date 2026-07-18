// Copyright Information
// ==================================
// EFCoreExamples - 01_PerformanceEf6 - vSalesPersonSalesByFiscalYear.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/07/18
// ==================================

namespace PerformanceEf6.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

[Table("Sales.vSalesPersonSalesByFiscalYears")]
public partial class vSalesPersonSalesByFiscalYear
{
    public int? SalesPersonID { get; set; }

    [StringLength(152)]
    public string FullName { get; set; }

    [Key]
    [Column(Order = 0)]
    [StringLength(50)]
    public string JobTitle { get; set; }

    [Key]
    [Column(Order = 1)]
    [StringLength(50)]
    public string SalesTerritory { get; set; }

    [Column("2002", TypeName = "money")]
    public decimal? C2002 { get; set; }

    [Column("2003", TypeName = "money")]
    public decimal? C2003 { get; set; }

    [Column("2004", TypeName = "money")]
    public decimal? C2004 { get; set; }
}