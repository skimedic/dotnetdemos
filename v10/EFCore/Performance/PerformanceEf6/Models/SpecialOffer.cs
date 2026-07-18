// Copyright Information
// ==================================
// EFCoreExamples - 01_PerformanceEf6 - SpecialOffer.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/07/18
// ==================================

namespace PerformanceEf6.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

[Table("Sales.SpecialOffer")]
public partial class SpecialOffer
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public SpecialOffer()
    {
        SpecialOfferProducts = new HashSet<SpecialOfferProduct>();
    }

    public int SpecialOfferID { get; set; }

    [Required]
    [StringLength(255)]
    public string Description { get; set; }

    [Column(TypeName = "smallmoney")]
    public decimal DiscountPct { get; set; }

    [Required]
    [StringLength(50)]
    public string Type { get; set; }

    [Required]
    [StringLength(50)]
    public string Category { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public int MinQty { get; set; }

    public int? MaxQty { get; set; }

    public Guid rowguid { get; set; }

    public DateTime ModifiedDate { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<SpecialOfferProduct> SpecialOfferProducts { get; set; }
}