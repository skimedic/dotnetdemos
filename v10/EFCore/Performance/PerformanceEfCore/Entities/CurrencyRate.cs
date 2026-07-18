// Copyright Information
// ==================================
// EFCoreExamples - 01_PerformanceEfCore - CurrencyRate.cs
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
/// Currency exchange rates.
/// </summary>
[Table("CurrencyRate", Schema = "Sales")]
[Index("CurrencyRateDate", "FromCurrencyCode", "ToCurrencyCode", Name = "AK_CurrencyRate_CurrencyRateDate_FromCurrencyCode_ToCurrencyCode", IsUnique = true)]
public partial class CurrencyRate
{
    /// <summary>
    /// Primary key for CurrencyRate records.
    /// </summary>
    [Key]
    [Column("CurrencyRateID")]
    public int CurrencyRateId { get; set; }

    /// <summary>
    /// Date and time the exchange rate was obtained.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime CurrencyRateDate { get; set; }

    /// <summary>
    /// Exchange rate was converted from this currency code.
    /// </summary>
    [Required]
    [StringLength(3)]
    public string FromCurrencyCode { get; set; }

    /// <summary>
    /// Exchange rate was converted to this currency code.
    /// </summary>
    [Required]
    [StringLength(3)]
    public string ToCurrencyCode { get; set; }

    /// <summary>
    /// Average exchange rate for the day.
    /// </summary>
    [Column(TypeName = "money")]
    public decimal AverageRate { get; set; }

    /// <summary>
    /// Final exchange rate for the day.
    /// </summary>
    [Column(TypeName = "money")]
    public decimal EndOfDayRate { get; set; }

    /// <summary>
    /// Date and time the record was last updated.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [ForeignKey("FromCurrencyCode")]
    [InverseProperty("CurrencyRateFromCurrencyCodeNavigations")]
    public virtual Currency FromCurrencyCodeNavigation { get; set; }

    [InverseProperty("CurrencyRate")]
    public virtual ICollection<SalesOrderHeader> SalesOrderHeaders { get; set; } = new List<SalesOrderHeader>();

    [ForeignKey("ToCurrencyCode")]
    [InverseProperty("CurrencyRateToCurrencyCodeNavigations")]
    public virtual Currency ToCurrencyCodeNavigation { get; set; }
}
