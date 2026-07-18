// Copyright Information
// ==================================
// AutoLot-Temp - AutoLot.Services - ICarApiServiceWrapper.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/12/04
// ==================================

namespace AutoLot.Services.ApiWrapper.Interfaces;

public interface ICarApiServiceWrapper : IApiServiceWrapperBase<Car>
{
    Task<IList<Car>> GetCarsByMakeAsync(
        int id);
}