// Copyright Information
// ==================================
// AutoLot - AutoLot.Api - DriversController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/09/05
// ==================================

namespace AutoLot.Api.Controllers.AutoLot;

[ApiVersion(1.0)]
public class DriversController(
    IAppLogger appLogger,
    IDriverRepo driverRepo) : BaseCrudController<Driver>(
    appLogger,
    driverRepo);