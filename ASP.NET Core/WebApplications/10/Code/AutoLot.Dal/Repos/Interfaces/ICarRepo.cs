// Copyright Information
// ==================================
// AutoLot-Temp - AutoLot.Dal - ICarRepo.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/11/23
// ==================================

namespace AutoLot.Dal.Repos.Interfaces;

public interface ICarRepo : ITemporalTableBaseRepo<Car>
{
    IQueryable<Car> GetAllBy(int makeId);
    string GetPetName(int id);
    int SetAllDrivableCarsColorAndMakeId(string color, int makeId);
    int DeleteNonDrivableCars();
}
