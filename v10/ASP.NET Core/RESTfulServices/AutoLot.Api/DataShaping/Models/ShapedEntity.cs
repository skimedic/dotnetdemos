// Copyright Information
// ==================================
// AutoLot - AutoLot.Api - ShapedEntity.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/12/03
// ==================================

namespace AutoLot.Api.DataShaping.Models;

public class ShapedEntity
{
    public ExpandoObject Entity { get; set; }
    public int Id { get; set; }
}