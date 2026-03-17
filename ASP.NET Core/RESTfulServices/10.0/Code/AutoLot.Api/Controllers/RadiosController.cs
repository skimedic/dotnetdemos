// Copyright Information
// ==================================
// AutoLot - AutoLot.Api - RadiosController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/12/03
// ==================================

namespace AutoLot.Api.Controllers;

[ApiVersion(1.0)]
public class RadiosController(IAppLogging appLogging, IRadioRepo repo)
    : BaseCrudController<Radio>(appLogging, repo);
