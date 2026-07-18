// Copyright Information
// ==================================
// AutoLot - AutoLot.Api - HealthCheckController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/12/03
// ==================================

namespace AutoLot.Api.Controllers;

[ApiVersionNeutral]
[ApiController]
[Route("api/[controller]")]
[Route("api/v{version:apiVersion}/[controller]")]
public class HealthCheckController : ControllerBase
{
    [HttpOptions]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest, "application/problem+json")]
    [EndpointSummary("Returns allowed HTTP methods and API version.")]
    [EndpointDescription(
        "Returns allowed HTTP methods and API version for the HealthCheck endpoint. Example: OPTIONS /api/healthcheck. No request body required.")]
    public IActionResult Options(
        [FromServices]
        IApiVersionDescriptionProvider provider)
    {
        Response.Headers["Allow"] = "GET, POST, PUT, DELETE, OPTIONS";
        //Get all versions supported
        var supportedVersions =
            provider.ApiVersionDescriptions
                .Where(d => !d.IsDeprecated)
                .Select(d => d.ApiVersion.ToString())
                .Distinct()
                .OrderBy(v => v)
                .ToArray();
        var deprecatedVersions =
            provider.ApiVersionDescriptions
                .Where(d => d.IsDeprecated)
                .Select(d => d.ApiVersion.ToString())
                .Distinct()
                .OrderBy(v => v)
                .ToArray();
        Response.Headers["api-supported-versions"] = string.Join(", ", supportedVersions);
        if (deprecatedVersions.Length > 0)
        {
            Response.Headers["api-deprecated-versions"] = string.Join(", ", deprecatedVersions);
        }

        return Ok("Worked");
    }
}