// Copyright Information
// ==================================
// AutoLot-WebApps - AutoLot.Services - MakeDalDataService.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/09/07
// ==================================

namespace AutoLot.Services.DataServices.Dal;

public class MakeDalDataService(
    IAppLogger appLogger,
    IMakeRepo makeRepo) : DalDataServiceBase<Make>(
        appLogger,
        makeRepo),
    IMakeDataService
{
}