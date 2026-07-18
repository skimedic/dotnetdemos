// Copyright Information
// ==================================
// AutoLot - AutoLot.Api - MakesController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/12/03
// ==================================

namespace AutoLot.Api.Controllers;

[ApiVersion(1.0)]
public class MakesController(
    IAppLogging appLogging,
    IMakeRepo makeRepo) : BaseCrudController<Make>(appLogging, makeRepo);
