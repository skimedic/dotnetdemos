// Copyright Information
// ==================================
// EFCoreExamples - 01_PerformanceEfCore - CreditCard.cs
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
/// Customer credit card information.
/// </summary>
[Table("CreditCard", Schema = "Sales")]
[Index("CardNumber", Name = "AK_CreditCard_CardNumber", IsUnique = true)]
public partial class CreditCard
{
    /// <summary>
    /// Primary key for CreditCard records.
    /// </summary>
    [Key]
    [Column("CreditCardID")]
    public int CreditCardId { get; set; }

    /// <summary>
    /// Credit card name.
    /// </summary>
    [Required]
    [StringLength(50)]
    public string CardType { get; set; }

    /// <summary>
    /// Credit card number.
    /// </summary>
    [Required]
    [StringLength(25)]
    public string CardNumber { get; set; }

    /// <summary>
    /// Credit card expiration month.
    /// </summary>
    public byte ExpMonth { get; set; }

    /// <summary>
    /// Credit card expiration year.
    /// </summary>
    public short ExpYear { get; set; }

    /// <summary>
    /// Date and time the record was last updated.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [InverseProperty("CreditCard")]
    public virtual ICollection<PersonCreditCard> PersonCreditCards { get; set; } = new List<PersonCreditCard>();

    [InverseProperty("CreditCard")]
    public virtual ICollection<SalesOrderHeader> SalesOrderHeaders { get; set; } = new List<SalesOrderHeader>();
}
