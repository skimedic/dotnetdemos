// Copyright Information
// ==================================
// AutoLot9 - AutoLot.Api - RadiosController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/07/13
// ==================================

namespace AutoLot.Api.Controllers;

[ApiVersion(1.0)]
public class RadiosController(IAppLogging<RadiosController> logger, IRadioRepo repo)
    : BaseCrudController<Radio, RadiosController>(logger, repo);