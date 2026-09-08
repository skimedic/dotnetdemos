// Copyright Information
// ==================================
// AutoLot-APIs - AutoLot.Api - CarDriversController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/09/07
// ==================================

namespace AutoLot.Api.Controllers;

[ApiVersion(1.0)]
public class CarDriversController(
    IAppLogger appLogger,
    ICarDriverRepo carDriverRepo) : BaseCrudController<CarDriver>(
    appLogger,
    carDriverRepo);