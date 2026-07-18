// Copyright Information
// ==================================
// EFCoreExamples - 01_PerformanceEfCore - ModelForTesting.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/07/18
// ==================================

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerformanceEfCore;

public class ModelForTesting
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int ProductId { get; set; }
    public string Class { get; set; }
    public DateTime ModifiedDate { get; set; }
    public string CategoryName { get; set; }
    public string Email { get; set; }

}