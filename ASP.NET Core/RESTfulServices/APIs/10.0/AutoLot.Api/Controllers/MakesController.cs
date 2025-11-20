// Copyright Information
// ==================================
// AutoLot - AutoLot.Api - MakesController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/11/20
// ==================================

namespace AutoLot.Api.Controllers;

[ApiVersion("1.0")]
public class MakesController(IAppLogging logger, IMakeRepo repo)
    : BaseCrudController<Make>(logger, repo);