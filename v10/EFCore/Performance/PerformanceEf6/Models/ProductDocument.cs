// Copyright Information
// ==================================
// EFCoreExamples - 01_PerformanceEf6 - ProductDocument.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/07/18
// ==================================

namespace PerformanceEf6.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

[Table("Production.ProductDocument")]
public partial class ProductDocument
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int ProductID { get; set; }

    public DateTime ModifiedDate { get; set; }

    public virtual Product Product { get; set; }
}