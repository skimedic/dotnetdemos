// Copyright Information
// ==================================
// EFCoreExamples - 01_PerformanceEfCore - Department.cs
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
/// Lookup table containing the departments within the Adventure Works Cycles company.
/// </summary>
[Table("Department", Schema = "HumanResources")]
[Index("Name", Name = "AK_Department_Name", IsUnique = true)]
public partial class Department
{
    /// <summary>
    /// Primary key for Department records.
    /// </summary>
    [Key]
    [Column("DepartmentID")]
    public short DepartmentId { get; set; }

    /// <summary>
    /// Name of the department.
    /// </summary>
    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    /// <summary>
    /// Name of the group to which the department belongs.
    /// </summary>
    [Required]
    [StringLength(50)]
    public string GroupName { get; set; }

    /// <summary>
    /// Date and time the record was last updated.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [InverseProperty("Department")]
    public virtual ICollection<EmployeeDepartmentHistory> EmployeeDepartmentHistories { get; set; } = new List<EmployeeDepartmentHistory>();
}
