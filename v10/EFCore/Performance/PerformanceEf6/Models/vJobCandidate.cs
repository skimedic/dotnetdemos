// Copyright Information
// ==================================
// EFCoreExamples - 01_PerformanceEf6 - vJobCandidate.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/07/18
// ==================================

namespace PerformanceEf6.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

[Table("HumanResources.vJobCandidate")]
public partial class vJobCandidate
{
    [Key]
    [Column(Order = 0)]
    public int JobCandidateID { get; set; }

    public int? BusinessEntityID { get; set; }

    [Column("Name.Prefix")]
    [StringLength(30)]
    public string Name_Prefix { get; set; }

    [Column("Name.First")]
    [StringLength(30)]
    public string Name_First { get; set; }

    [Column("Name.Middle")]
    [StringLength(30)]
    public string Name_Middle { get; set; }

    [Column("Name.Last")]
    [StringLength(30)]
    public string Name_Last { get; set; }

    [Column("Name.Suffix")]
    [StringLength(30)]
    public string Name_Suffix { get; set; }

    public string Skills { get; set; }

    [Column("Addr.Type")]
    [StringLength(30)]
    public string Addr_Type { get; set; }

    [Column("Addr.Loc.CountryRegion")]
    [StringLength(100)]
    public string Addr_Loc_CountryRegion { get; set; }

    [Column("Addr.Loc.State")]
    [StringLength(100)]
    public string Addr_Loc_State { get; set; }

    [Column("Addr.Loc.City")]
    [StringLength(100)]
    public string Addr_Loc_City { get; set; }

    [Column("Addr.PostalCode")]
    [StringLength(20)]
    public string Addr_PostalCode { get; set; }

    public string EMail { get; set; }

    public string WebSite { get; set; }

    [Key]
    [Column(Order = 1)]
    public DateTime ModifiedDate { get; set; }
}