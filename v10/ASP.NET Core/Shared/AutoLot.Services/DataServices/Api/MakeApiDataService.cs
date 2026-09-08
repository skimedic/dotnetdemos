// Copyright Information
// ==================================
// AutoLot-WebApps - AutoLot.Services - MakeApiDataService.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/09/07
// ==================================

namespace AutoLot.Services.DataServices.Api;

public class MakeApiDataService(
    IAppLogger appLogger,
    IMakeApiServiceWrapper makeServiceWrapper) : ApiDataServiceBase<Make>(
        appLogger,
        makeServiceWrapper),
    IMakeDataService;