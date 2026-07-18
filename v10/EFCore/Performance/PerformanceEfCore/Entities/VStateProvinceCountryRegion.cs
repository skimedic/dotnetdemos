// Copyright Information
// ==================================
// EFCoreExamples - 01_PerformanceEfCore - VStateProvinceCountryRegion.cs
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
public partial class VStateProvinceCountryRegion
{
    [Column("StateProvinceID")]
    public int StateProvinceId { get; set; }

    [Required]
    [StringLength(3)]
    public string StateProvinceCode { get; set; }

    public bool IsOnlyStateProvinceFlag { get; set; }

    [Required]
    [StringLength(50)]
    public string StateProvinceName { get; set; }

    [Column("TerritoryID")]
    public int TerritoryId { get; set; }

    [Required]
    [StringLength(3)]
    public string CountryRegionCode { get; set; }

    [Required]
    [StringLength(50)]
    public string CountryRegionName { get; set; }
}
