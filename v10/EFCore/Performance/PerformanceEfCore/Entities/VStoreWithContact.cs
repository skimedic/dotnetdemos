// Copyright Information
// ==================================
// EFCoreExamples - 01_PerformanceEfCore - VStoreWithContact.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/07/18
// ==================================

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PerformanceEfCore.Entities;

[Keyless]
public partial class VStoreWithContact
{
    [Column("BusinessEntityID")]
    public int BusinessEntityId { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    [Required]
    [StringLength(50)]
    public string ContactType { get; set; }

    [StringLength(8)]
    public string Title { get; set; }

    [Required]
    [StringLength(50)]
    public string FirstName { get; set; }

    [StringLength(50)]
    public string MiddleName { get; set; }

    [Required]
    [StringLength(50)]
    public string LastName { get; set; }

    [StringLength(10)]
    public string Suffix { get; set; }

    [StringLength(25)]
    public string PhoneNumber { get; set; }

    [StringLength(50)]
    public string PhoneNumberType { get; set; }

    [StringLength(50)]
    public string EmailAddress { get; set; }

    public int EmailPromotion { get; set; }
}
