// Copyright Information
// ==================================
// EFCoreExamples - 01_PerformanceEfCore - Currency.cs
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
/// Lookup table containing standard ISO currencies.
/// </summary>
[Table("Currency", Schema = "Sales")]
[Index("Name", Name = "AK_Currency_Name", IsUnique = true)]
public partial class Currency
{
    /// <summary>
    /// The ISO code for the Currency.
    /// </summary>
    [Key]
    [StringLength(3)]
    public string CurrencyCode { get; set; }

    /// <summary>
    /// Currency name.
    /// </summary>
    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    /// <summary>
    /// Date and time the record was last updated.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [InverseProperty("CurrencyCodeNavigation")]
    public virtual ICollection<CountryRegionCurrency> CountryRegionCurrencies { get; set; } = new List<CountryRegionCurrency>();

    [InverseProperty("FromCurrencyCodeNavigation")]
    public virtual ICollection<CurrencyRate> CurrencyRateFromCurrencyCodeNavigations { get; set; } = new List<CurrencyRate>();

    [InverseProperty("ToCurrencyCodeNavigation")]
    public virtual ICollection<CurrencyRate> CurrencyRateToCurrencyCodeNavigations { get; set; } = new List<CurrencyRate>();
}
