// Copyright Information
// ==================================
// EFCoreExamples - 01_PerformanceEf6 - vProductModelInstruction.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/07/18
// ==================================

namespace PerformanceEf6.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

[Table("Production.vProductModelInstructions")]
public partial class vProductModelInstruction
{
    [Key]
    [Column(Order = 0)]
    public int ProductModelID { get; set; }

    [Key]
    [Column(Order = 1)]
    [StringLength(50)]
    public string Name { get; set; }

    public string Instructions { get; set; }

    public int? LocationID { get; set; }

    public decimal? SetupHours { get; set; }

    public decimal? MachineHours { get; set; }

    public decimal? LaborHours { get; set; }

    public int? LotSize { get; set; }

    [StringLength(1024)]
    public string Step { get; set; }

    [Key]
    [Column(Order = 2)]
    public Guid rowguid { get; set; }

    [Key]
    [Column(Order = 3)]
    public DateTime ModifiedDate { get; set; }
}