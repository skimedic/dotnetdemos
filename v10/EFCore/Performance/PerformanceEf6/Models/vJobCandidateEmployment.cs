// Copyright Information
// ==================================
// EFCoreExamples - 01_PerformanceEf6 - vJobCandidateEmployment.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/07/18
// ==================================

namespace PerformanceEf6.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

[Table("HumanResources.vJobCandidateEmployment")]
public partial class vJobCandidateEmployment
{
    [Key]
    public int JobCandidateID { get; set; }

    [Column("Emp.StartDate")]
    public DateTime? Emp_StartDate { get; set; }

    [Column("Emp.EndDate")]
    public DateTime? Emp_EndDate { get; set; }

    [Column("Emp.OrgName")]
    [StringLength(100)]
    public string Emp_OrgName { get; set; }

    [Column("Emp.JobTitle")]
    [StringLength(100)]
    public string Emp_JobTitle { get; set; }

    [Column("Emp.Responsibility")]
    public string Emp_Responsibility { get; set; }

    [Column("Emp.FunctionCategory")]
    public string Emp_FunctionCategory { get; set; }

    [Column("Emp.IndustryCategory")]
    public string Emp_IndustryCategory { get; set; }

    [Column("Emp.Loc.CountryRegion")]
    public string Emp_Loc_CountryRegion { get; set; }

    [Column("Emp.Loc.State")]
    public string Emp_Loc_State { get; set; }

    [Column("Emp.Loc.City")]
    public string Emp_Loc_City { get; set; }
}