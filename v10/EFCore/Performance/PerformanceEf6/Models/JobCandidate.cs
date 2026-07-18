// Copyright Information
// ==================================
// EFCoreExamples - 01_PerformanceEf6 - JobCandidate.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/07/18
// ==================================

namespace PerformanceEf6.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

[Table("HumanResources.JobCandidate")]
public partial class JobCandidate
{
    public int JobCandidateID { get; set; }

    public int? BusinessEntityID { get; set; }

    [Column(TypeName = "xml")]
    public string Resume { get; set; }

    public DateTime ModifiedDate { get; set; }

    public virtual Employee Employee { get; set; }
}