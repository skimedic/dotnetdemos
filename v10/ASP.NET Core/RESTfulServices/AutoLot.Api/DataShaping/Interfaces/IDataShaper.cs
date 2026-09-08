// Copyright Information
// ==================================
// AutoLot-APIs - AutoLot.Api - IDataShaper.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/09/07
// ==================================

namespace AutoLot.Api.DataShaping.Interfaces;

public interface IDataShaper<in TEntity>
{
    IEnumerable<ShapedEntity> ShapeData(
        IEnumerable<TEntity> entities,
        string fieldsString);

    ShapedEntity ShapeData(
        TEntity entity,
        string fieldsString);

    void UpdateData(
        TEntity entity,
        Dictionary<string, string> values);
}