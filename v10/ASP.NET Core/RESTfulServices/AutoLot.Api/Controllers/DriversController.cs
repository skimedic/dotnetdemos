// Copyright Information
// ==================================
// AutoLot - AutoLot.Api - DriversController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/12/03
// ==================================

namespace AutoLot.Api.Controllers;

[ApiVersion(1.0)]
public class DriversController(
    IAppLogging appLogging,
    IDriverRepo driverRepo) : BaseCrudController<Driver>(appLogging, driverRepo);
