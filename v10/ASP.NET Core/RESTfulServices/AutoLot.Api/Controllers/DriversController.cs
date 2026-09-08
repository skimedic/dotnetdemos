// Copyright Information
// ==================================
// AutoLot-APIs - AutoLot.Api - DriversController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/09/07
// ==================================

namespace AutoLot.Api.Controllers;

[ApiVersion(1.0)]
public class DriversController(
    IAppLogger appLogger,
    IDriverRepo driverRepo) : BaseCrudController<Driver>(
    appLogger,
    driverRepo);