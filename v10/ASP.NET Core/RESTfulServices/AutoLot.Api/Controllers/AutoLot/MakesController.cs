// Copyright Information
// ==================================
// AutoLot - AutoLot.Api - MakesController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/11/16
// ==================================

namespace AutoLot.Api.Controllers.AutoLot;

[ApiVersion(1.0)]
public class MakesController(
    IAppLogger appLogger,
    IMakeRepo makeRepo) : BaseCrudController<Make>(appLogger,
    makeRepo);