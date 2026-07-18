// Copyright Information
// ==================================
// AutoLot-Temp - AutoLot.Services - MakeApiDataService.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/12/04
// ==================================

namespace AutoLot.Services.DataServices.Api;

public class MakeApiDataService(
    IAppLogging appLogging,
    IMakeApiServiceWrapper makeServiceWrapper) : ApiDataServiceBase<Make>(appLogging, makeServiceWrapper),
    IMakeDataService;