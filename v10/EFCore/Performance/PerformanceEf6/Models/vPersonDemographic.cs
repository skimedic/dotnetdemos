// Copyright Information
// ==================================
// EFCoreExamples - 01_PerformanceEf6 - vPersonDemographic.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/07/18
// ==================================

namespace PerformanceEf6.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

[Table("Sales.vPersonDemographics")]
public partial class vPersonDemographic
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int BusinessEntityID { get; set; }

    [Column(TypeName = "money")]
    public decimal? TotalPurchaseYTD { get; set; }

    public DateTime? DateFirstPurchase { get; set; }

    public DateTime? BirthDate { get; set; }

    [StringLength(1)]
    public string MaritalStatus { get; set; }

    [StringLength(30)]
    public string YearlyIncome { get; set; }

    [StringLength(1)]
    public string Gender { get; set; }

    public int? TotalChildren { get; set; }

    public int? NumberChildrenAtHome { get; set; }

    [StringLength(30)]
    public string Education { get; set; }

    [StringLength(30)]
    public string Occupation { get; set; }

    public bool? HomeOwnerFlag { get; set; }

    public int? NumberCarsOwned { get; set; }
}