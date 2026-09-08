// Copyright Information
// ==================================
// AutoLot-APIs - AutoLot.Api - MakesController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/09/07
// ==================================

namespace AutoLot.Api.Controllers;

[ApiVersion(1.0)]
public class MakesController(
    IAppLogger appLogger,
    IMakeRepo makeRepo) : BaseCrudController<Make>(
    appLogger,
    makeRepo);