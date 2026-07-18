// Copyright Information
// ==================================
// AutoLot - AutoLot.Dal - ICarRepo.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/07/18
// ==================================

namespace AutoLot.Dal.Repos.Interfaces;

public interface ICarRepo : ITemporalTableBaseRepo<Car>
{
    IList<Car> GetAllByAsList(
        int makeId);

    // Returns deferred IQueryable — DbContext must remain alive until materialized.
    IQueryable<Car> GetAllByAsQueryable(
        int makeId);

    string GetPetName(
        int id);

    int SetAllDrivableCarsColorAndMakeId(
        string color,
        int makeId);

    int DeleteNonDrivableCars();
}