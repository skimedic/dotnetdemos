// Copyright Information
// ==================================
// EFCoreExamples - 01_PerformanceEf6 - vEmployeeDepartmentHistory.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/07/18
// ==================================

namespace PerformanceEf6.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

[Table("HumanResources.vEmployeeDepartmentHistory")]
public partial class vEmployeeDepartmentHistory
{
    [Key]
    [Column(Order = 0)]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int BusinessEntityID { get; set; }

    [StringLength(8)]
    public string Title { get; set; }

    [Key]
    [Column(Order = 1)]
    [StringLength(50)]
    public string FirstName { get; set; }

    [StringLength(50)]
    public string MiddleName { get; set; }

    [Key]
    [Column(Order = 2)]
    [StringLength(50)]
    public string LastName { get; set; }

    [StringLength(10)]
    public string Suffix { get; set; }

    [Key]
    [Column(Order = 3)]
    [StringLength(50)]
    public string Shift { get; set; }

    [Key]
    [Column(Order = 4)]
    [StringLength(50)]
    public string Department { get; set; }

    [Key]
    [Column(Order = 5)]
    [StringLength(50)]
    public string GroupName { get; set; }

    [Key]
    [Column(Order = 6, TypeName = "date")]
    public DateTime StartDate { get; set; }

    [Column(TypeName = "date")]
    public DateTime? EndDate { get; set; }
}