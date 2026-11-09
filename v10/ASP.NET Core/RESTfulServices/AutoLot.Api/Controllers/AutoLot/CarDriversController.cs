// Copyright Information
// ==================================
// AutoLot - AutoLot.Api - CarDriversController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/09/05
// ==================================

namespace AutoLot.Api.Controllers.AutoLot;

[ApiVersion(1.0)]
public class CarDriversController(
    IAppLogger appLogger,
    ICarDriverRepo carDriverRepo) : BaseCrudController<CarDriver>(
    appLogger,
    carDriverRepo);