// Copyright Information
// ==================================
// EFCoreExamples - 01_PerformanceEfCore - VSalesPersonSalesByFiscalYear.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/07/18
// ==================================

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PerformanceEfCore.Entities;

[Keyless]
public partial class VSalesPersonSalesByFiscalYear
{
    [Column("SalesPersonID")]
    public int? SalesPersonId { get; set; }

    [StringLength(152)]
    public string FullName { get; set; }

    [Required]
    [StringLength(50)]
    public string JobTitle { get; set; }

    [Required]
    [StringLength(50)]
    public string SalesTerritory { get; set; }

    [Column("2002", TypeName = "money")]
    public decimal? _2002 { get; set; }

    [Column("2003", TypeName = "money")]
    public decimal? _2003 { get; set; }

    [Column("2004", TypeName = "money")]
    public decimal? _2004 { get; set; }
}
