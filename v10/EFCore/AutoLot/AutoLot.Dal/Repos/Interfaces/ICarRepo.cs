// Copyright Information
// ==================================
// AutoLot-WebApps - AutoLot.Dal - ICarRepo.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/09/07
// ==================================

namespace AutoLot.Dal.Repos.Interfaces;

public interface ICarRepo : ITemporalTableBaseRepo<Car>
{
    List<Car> GetAllByAsList(
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