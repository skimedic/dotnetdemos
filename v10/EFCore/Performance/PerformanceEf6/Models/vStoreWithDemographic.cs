// Copyright Information
// ==================================
// EFCoreExamples - 01_PerformanceEf6 - vStoreWithDemographic.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/07/18
// ==================================

namespace PerformanceEf6.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

[Table("Sales.vStoreWithDemographics")]
public partial class vStoreWithDemographic
{
    [Key]
    [Column(Order = 0)]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int BusinessEntityID { get; set; }

    [Key]
    [Column(Order = 1)]
    [StringLength(50)]
    public string Name { get; set; }

    [Column(TypeName = "money")]
    public decimal? AnnualSales { get; set; }

    [Column(TypeName = "money")]
    public decimal? AnnualRevenue { get; set; }

    [StringLength(50)]
    public string BankName { get; set; }

    [StringLength(5)]
    public string BusinessType { get; set; }

    public int? YearOpened { get; set; }

    [StringLength(50)]
    public string Specialty { get; set; }

    public int? SquareFeet { get; set; }

    [StringLength(30)]
    public string Brands { get; set; }

    [StringLength(30)]
    public string Internet { get; set; }

    public int? NumberEmployees { get; set; }
}