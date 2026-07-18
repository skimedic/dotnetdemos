// Copyright Information
// ==================================
// EFCoreExamples - 01_PerformanceEf6 - AWBuildVersion.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/07/18
// ==================================

namespace PerformanceEf6.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

[Table("AWBuildVersion")]
public partial class AWBuildVersion
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public byte SystemInformationID { get; set; }

    [Column("Database Version")]
    [Required]
    [StringLength(25)]
    public string Database_Version { get; set; }

    public DateTime VersionDate { get; set; }

    public DateTime ModifiedDate { get; set; }
}