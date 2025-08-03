// Copyright Information
// ==================================
// AutoLot9 - AutoLot.Api - MakesController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/07/13
// ==================================

namespace AutoLot.Api.Controllers;

[ApiVersion(1.0)]
public class MakesController(IAppLogging<MakesController> logger, IMakeRepo repo)
    : BaseCrudController<Make, MakesController>(logger, repo);