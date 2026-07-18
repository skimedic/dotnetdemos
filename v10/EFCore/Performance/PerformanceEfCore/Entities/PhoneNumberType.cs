// Copyright Information
// ==================================
// EFCoreExamples - 01_PerformanceEfCore - PhoneNumberType.cs
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
/// Type of phone number of a person.
/// </summary>
[Table("PhoneNumberType", Schema = "Person")]
public partial class PhoneNumberType
{
    /// <summary>
    /// Primary key for telephone number type records.
    /// </summary>
    [Key]
    [Column("PhoneNumberTypeID")]
    public int PhoneNumberTypeId { get; set; }

    /// <summary>
    /// Name of the telephone number type
    /// </summary>
    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    /// <summary>
    /// Date and time the record was last updated.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [InverseProperty("PhoneNumberType")]
    public virtual ICollection<PersonPhone> PersonPhones { get; set; } = new List<PersonPhone>();
}
