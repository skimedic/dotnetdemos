// Copyright Information
// ==================================
// EFCoreExamples - 01_PerformanceEf6 - PhoneNumberType.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/07/18
// ==================================

namespace PerformanceEf6.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

[Table("Person.PhoneNumberType")]
public partial class PhoneNumberType
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public PhoneNumberType()
    {
        PersonPhones = new HashSet<PersonPhone>();
    }

    public int PhoneNumberTypeID { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    public DateTime ModifiedDate { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<PersonPhone> PersonPhones { get; set; }
}