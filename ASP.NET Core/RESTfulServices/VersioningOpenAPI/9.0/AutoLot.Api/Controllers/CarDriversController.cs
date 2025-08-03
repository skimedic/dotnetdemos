// Copyright Information
// ==================================
// AutoLot9 - AutoLot.Api - CarDriversController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/07/13
// ==================================

namespace AutoLot.Api.Controllers;

[ApiVersion(1.0)]
public class CarDriversController(IAppLogging<CarDriversController> logger, ICarDriverRepo repo)
    : BaseCrudController<CarDriver, CarDriversController>(logger, repo);

