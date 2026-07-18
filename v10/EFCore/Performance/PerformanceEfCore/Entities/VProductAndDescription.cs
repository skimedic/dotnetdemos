// Copyright Information
// ==================================
// EFCoreExamples - 01_PerformanceEfCore - VProductAndDescription.cs
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
public partial class VProductAndDescription
{
    [Column("ProductID")]
    public int ProductId { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    [Required]
    [StringLength(50)]
    public string ProductModel { get; set; }

    [Required]
    [Column("CultureID")]
    [StringLength(6)]
    public string CultureId { get; set; }

    [Required]
    [StringLength(400)]
    public string Description { get; set; }
}
