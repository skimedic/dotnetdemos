// Copyright Information
// ==================================
// AutoLot-APIs - AutoLot.Api - RadiosController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/09/07
// ==================================

namespace AutoLot.Api.Controllers;

[ApiVersion(1.0)]
public class RadiosController(
    IAppLogger appLogger,
    IRadioRepo radioRepo) : BaseCrudController<Radio>(
    appLogger,
    radioRepo);