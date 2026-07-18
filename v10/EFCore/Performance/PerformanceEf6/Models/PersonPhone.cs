// Copyright Information
// ==================================
// EFCoreExamples - 01_PerformanceEf6 - PersonPhone.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/07/18
// ==================================

namespace PerformanceEf6.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

[Table("Person.PersonPhone")]
public partial class PersonPhone
{
    [Key]
    [Column(Order = 0)]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int BusinessEntityID { get; set; }

    [Key]
    [Column(Order = 1)]
    [StringLength(25)]
    public string PhoneNumber { get; set; }

    [Key]
    [Column(Order = 2)]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int PhoneNumberTypeID { get; set; }

    public DateTime ModifiedDate { get; set; }

    public virtual Person Person { get; set; }

    public virtual PhoneNumberType PhoneNumberType { get; set; }
}