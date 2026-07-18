// Copyright Information
// ==================================
// EFCoreExamples - 01_PerformanceEfCore - AwbuildVersion.cs
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
/// Current version number of the AdventureWorks 2016 sample database. 
/// </summary>
[Table("AWBuildVersion")]
public partial class AwbuildVersion
{
    /// <summary>
    /// Primary key for AWBuildVersion records.
    /// </summary>
    [Key]
    [Column("SystemInformationID")]
    public byte SystemInformationId { get; set; }

    /// <summary>
    /// Version number of the database in 9.yy.mm.dd.00 format.
    /// </summary>
    [Required]
    [Column("Database Version")]
    [StringLength(25)]
    public string DatabaseVersion { get; set; }

    /// <summary>
    /// Date and time the record was last updated.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime VersionDate { get; set; }

    /// <summary>
    /// Date and time the record was last updated.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }
}
