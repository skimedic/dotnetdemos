// Copyright Information
// ==================================
// AutoLot - AutoLot.Models - TemporalViewModel.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/07/18
// ==================================

namespace AutoLot.Models.ViewModels;

public class TemporalViewModel<TEntity> where TEntity : BaseEntity, new()
{
    public TEntity Entity { get; set; }
    public DateTime ValidFrom { get; set; }
    public DateTime ValidTo { get; set; }
}