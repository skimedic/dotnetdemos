// Copyright Information
// ==================================
// EFCoreExamples - 01_PerformanceEf6 - vVendorWithAddress.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/07/18
// ==================================

namespace PerformanceEf6.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

[Table("Purchasing.vVendorWithAddresses")]
public partial class vVendorWithAddress
{
    [Key]
    [Column(Order = 0)]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int BusinessEntityID { get; set; }

    [Key]
    [Column(Order = 1)]
    [StringLength(50)]
    public string Name { get; set; }

    [Key]
    [Column(Order = 2)]
    [StringLength(50)]
    public string AddressType { get; set; }

    [Key]
    [Column(Order = 3)]
    [StringLength(60)]
    public string AddressLine1 { get; set; }

    [StringLength(60)]
    public string AddressLine2 { get; set; }

    [Key]
    [Column(Order = 4)]
    [StringLength(30)]
    public string City { get; set; }

    [Key]
    [Column(Order = 5)]
    [StringLength(50)]
    public string StateProvinceName { get; set; }

    [Key]
    [Column(Order = 6)]
    [StringLength(15)]
    public string PostalCode { get; set; }

    [Key]
    [Column(Order = 7)]
    [StringLength(50)]
    public string CountryRegionName { get; set; }
}