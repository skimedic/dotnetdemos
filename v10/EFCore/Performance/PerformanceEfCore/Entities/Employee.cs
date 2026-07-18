// Copyright Information
// ==================================
// EFCoreExamples - 01_PerformanceEfCore - Employee.cs
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
/// Employee information such as salary, department, and title.
/// </summary>
[Table("Employee", Schema = "HumanResources")]
[Index("LoginId", Name = "AK_Employee_LoginID", IsUnique = true)]
[Index("NationalIdnumber", Name = "AK_Employee_NationalIDNumber", IsUnique = true)]
[Index("Rowguid", Name = "AK_Employee_rowguid", IsUnique = true)]
public partial class Employee
{
    /// <summary>
    /// Primary key for Employee records.  Foreign key to BusinessEntity.BusinessEntityID.
    /// </summary>
    [Key]
    [Column("BusinessEntityID")]
    public int BusinessEntityId { get; set; }

    /// <summary>
    /// Unique national identification number such as a social security number.
    /// </summary>
    [Required]
    [Column("NationalIDNumber")]
    [StringLength(15)]
    public string NationalIdnumber { get; set; }

    /// <summary>
    /// Network login.
    /// </summary>
    [Required]
    [Column("LoginID")]
    [StringLength(256)]
    public string LoginId { get; set; }

    /// <summary>
    /// The depth of the employee in the corporate hierarchy.
    /// </summary>
    public short? OrganizationLevel { get; set; }

    /// <summary>
    /// Work title such as Buyer or Sales Representative.
    /// </summary>
    [Required]
    [StringLength(50)]
    public string JobTitle { get; set; }

    /// <summary>
    /// Date of birth.
    /// </summary>
    public DateOnly BirthDate { get; set; }

    /// <summary>
    /// M = Married, S = Single
    /// </summary>
    [Required]
    [StringLength(1)]
    public string MaritalStatus { get; set; }

    /// <summary>
    /// M = Male, F = Female
    /// </summary>
    [Required]
    [StringLength(1)]
    public string Gender { get; set; }

    /// <summary>
    /// Employee hired on this date.
    /// </summary>
    public DateOnly HireDate { get; set; }

    /// <summary>
    /// Job classification. 0 = Hourly, not exempt from collective bargaining. 1 = Salaried, exempt from collective bargaining.
    /// </summary>
    public bool SalariedFlag { get; set; }

    /// <summary>
    /// Number of available vacation hours.
    /// </summary>
    public short VacationHours { get; set; }

    /// <summary>
    /// Number of available sick leave hours.
    /// </summary>
    public short SickLeaveHours { get; set; }

    /// <summary>
    /// 0 = Inactive, 1 = Active
    /// </summary>
    public bool CurrentFlag { get; set; }

    /// <summary>
    /// ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.
    /// </summary>
    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    /// <summary>
    /// Date and time the record was last updated.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [ForeignKey("BusinessEntityId")]
    [InverseProperty("Employee")]
    public virtual Person BusinessEntity { get; set; }

    [InverseProperty("BusinessEntity")]
    public virtual ICollection<EmployeeDepartmentHistory> EmployeeDepartmentHistories { get; set; } = new List<EmployeeDepartmentHistory>();

    [InverseProperty("BusinessEntity")]
    public virtual ICollection<EmployeePayHistory> EmployeePayHistories { get; set; } = new List<EmployeePayHistory>();

    [InverseProperty("BusinessEntity")]
    public virtual ICollection<JobCandidate> JobCandidates { get; set; } = new List<JobCandidate>();

    [InverseProperty("Employee")]
    public virtual ICollection<PurchaseOrderHeader> PurchaseOrderHeaders { get; set; } = new List<PurchaseOrderHeader>();

    [InverseProperty("BusinessEntity")]
    public virtual SalesPerson SalesPerson { get; set; }
}
