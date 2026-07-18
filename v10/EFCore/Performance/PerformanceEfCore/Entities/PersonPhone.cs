// Copyright Information
// ==================================
// EFCoreExamples - 01_PerformanceEfCore - PersonPhone.cs
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
/// Telephone number and type of a person.
/// </summary>
[PrimaryKey("BusinessEntityId", "PhoneNumber", "PhoneNumberTypeId")]
[Table("PersonPhone", Schema = "Person")]
[Index("PhoneNumber", Name = "IX_PersonPhone_PhoneNumber")]
public partial class PersonPhone
{
    /// <summary>
    /// Business entity identification number. Foreign key to Person.BusinessEntityID.
    /// </summary>
    [Key]
    [Column("BusinessEntityID")]
    public int BusinessEntityId { get; set; }

    /// <summary>
    /// Telephone number identification number.
    /// </summary>
    [Key]
    [StringLength(25)]
    public string PhoneNumber { get; set; }

    /// <summary>
    /// Kind of phone number. Foreign key to PhoneNumberType.PhoneNumberTypeID.
    /// </summary>
    [Key]
    [Column("PhoneNumberTypeID")]
    public int PhoneNumberTypeId { get; set; }

    /// <summary>
    /// Date and time the record was last updated.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [ForeignKey("BusinessEntityId")]
    [InverseProperty("PersonPhones")]
    public virtual Person BusinessEntity { get; set; }

    [ForeignKey("PhoneNumberTypeId")]
    [InverseProperty("PersonPhones")]
    public virtual PhoneNumberType PhoneNumberType { get; set; }
}
