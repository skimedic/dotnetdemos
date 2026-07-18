// Copyright Information
// ==================================
// EFCoreExamples - 01_PerformanceEfCore - Password.cs
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
/// One way hashed authentication information
/// </summary>
[Table("Password", Schema = "Person")]
public partial class Password
{
    [Key]
    [Column("BusinessEntityID")]
    public int BusinessEntityId { get; set; }

    /// <summary>
    /// Password for the e-mail account.
    /// </summary>
    [Required]
    [StringLength(128)]
    [Unicode(false)]
    public string PasswordHash { get; set; }

    /// <summary>
    /// Random value concatenated with the password string before the password is hashed.
    /// </summary>
    [Required]
    [StringLength(10)]
    [Unicode(false)]
    public string PasswordSalt { get; set; }

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
    [InverseProperty("Password")]
    public virtual Person BusinessEntity { get; set; }
}
