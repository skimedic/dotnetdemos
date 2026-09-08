// Copyright Information
// ==================================
// AutoLot-APIs - AutoLot.Api - BaseAppController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/09/07
// ==================================

namespace AutoLot.Api.Controllers.Base;

[ApiController]
[ProducesResponseType<ValidationProblemDetails>(
    StatusCodes.Status400BadRequest,
    "application/problem+json")]
[ProducesResponseType<ProblemDetails>(
    StatusCodes.Status500InternalServerError,
    "application/problem+json")]
[Route("api/[controller]")]
[Route("api/v{version:apiVersion}/[controller]")]
public class BaseAppController : ControllerBase
{
}