// Copyright Information
// ==================================
// AutoLot - AutoLot.Api - CarDriversController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/12/03
// ==================================

namespace AutoLot.Api.Controllers;

[ApiVersion(1.0)]
public class CarDriversController(IAppLogging appLogging, ICarDriverRepo repo)
    : BaseCrudController<CarDriver>(appLogging, repo);
