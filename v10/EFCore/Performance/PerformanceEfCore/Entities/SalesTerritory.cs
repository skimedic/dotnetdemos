// Copyright Information
// ==================================
// EFCoreExamples - 01_PerformanceEfCore - SalesTerritory.cs
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
/// Sales territory lookup table.
/// </summary>
[Table("SalesTerritory", Schema = "Sales")]
[Index("Name", Name = "AK_SalesTerritory_Name", IsUnique = true)]
[Index("Rowguid", Name = "AK_SalesTerritory_rowguid", IsUnique = true)]
public partial class SalesTerritory
{
    /// <summary>
    /// Primary key for SalesTerritory records.
    /// </summary>
    [Key]
    [Column("TerritoryID")]
    public int TerritoryId { get; set; }

    /// <summary>
    /// Sales territory description
    /// </summary>
    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    /// <summary>
    /// ISO standard country or region code. Foreign key to CountryRegion.CountryRegionCode. 
    /// </summary>
    [Required]
    [StringLength(3)]
    public string CountryRegionCode { get; set; }

    /// <summary>
    /// Geographic area to which the sales territory belong.
    /// </summary>
    [Required]
    [StringLength(50)]
    public string Group { get; set; }

    /// <summary>
    /// Sales in the territory year to date.
    /// </summary>
    [Column("SalesYTD", TypeName = "money")]
    public decimal SalesYtd { get; set; }

    /// <summary>
    /// Sales in the territory the previous year.
    /// </summary>
    [Column(TypeName = "money")]
    public decimal SalesLastYear { get; set; }

    /// <summary>
    /// Business costs in the territory year to date.
    /// </summary>
    [Column("CostYTD", TypeName = "money")]
    public decimal CostYtd { get; set; }

    /// <summary>
    /// Business costs in the territory the previous year.
    /// </summary>
    [Column(TypeName = "money")]
    public decimal CostLastYear { get; set; }

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

    [ForeignKey("CountryRegionCode")]
    [InverseProperty("SalesTerritories")]
    public virtual CountryRegion CountryRegionCodeNavigation { get; set; }

    [InverseProperty("Territory")]
    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    [InverseProperty("Territory")]
    public virtual ICollection<SalesOrderHeader> SalesOrderHeaders { get; set; } = new List<SalesOrderHeader>();

    [InverseProperty("Territory")]
    public virtual ICollection<SalesPerson> SalesPeople { get; set; } = new List<SalesPerson>();

    [InverseProperty("Territory")]
    public virtual ICollection<SalesTerritoryHistory> SalesTerritoryHistories { get; set; } = new List<SalesTerritoryHistory>();

    [InverseProperty("Territory")]
    public virtual ICollection<StateProvince> StateProvinces { get; set; } = new List<StateProvince>();
}
