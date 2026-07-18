// Copyright Information
// ==================================
// EFCoreExamples - 01_PerformanceEfCore - PersonCreditCard.cs
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
/// Cross-reference table mapping people to their credit card information in the CreditCard table. 
/// </summary>
[PrimaryKey("BusinessEntityId", "CreditCardId")]
[Table("PersonCreditCard", Schema = "Sales")]
public partial class PersonCreditCard
{
    /// <summary>
    /// Business entity identification number. Foreign key to Person.BusinessEntityID.
    /// </summary>
    [Key]
    [Column("BusinessEntityID")]
    public int BusinessEntityId { get; set; }

    /// <summary>
    /// Credit card identification number. Foreign key to CreditCard.CreditCardID.
    /// </summary>
    [Key]
    [Column("CreditCardID")]
    public int CreditCardId { get; set; }

    /// <summary>
    /// Date and time the record was last updated.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [ForeignKey("BusinessEntityId")]
    [InverseProperty("PersonCreditCards")]
    public virtual Person BusinessEntity { get; set; }

    [ForeignKey("CreditCardId")]
    [InverseProperty("PersonCreditCards")]
    public virtual CreditCard CreditCard { get; set; }
}
