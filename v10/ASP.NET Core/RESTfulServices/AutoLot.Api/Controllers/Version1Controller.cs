// Copyright Information
// ==================================
// AutoLot - AutoLot.Api - Version1Controller.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/12/03
// ==================================

namespace AutoLot.Api.Controllers;

[ApiController]
[ApiVersion(1.0)]
//[ApiVersion("6.0")]
[Route("api/[controller]")]
[Route("api/v{version:apiVersion}/[controller]")]
public class Version1Controller : ControllerBase
{
    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest, "application/problem+json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [EndpointSummary("Gets API version information")]
    [EndpointDescription("Returns the controller name and requested API version.")]
    public virtual string Get(
        [Description("The resolved API version for the current request.")]
        [FromServices]ApiVersion apiVersion) =>
        $"Controller = {GetType().Name}{Environment.NewLine}Version = {apiVersion}";

    [HttpGet("{id}")]
    [Produces("application/json")]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest, "application/problem+json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [EndpointSummary("Gets API version information with an ID")]
    [EndpointDescription("Returns the controller name, requested API version, and route ID.")]
    public virtual string Get(
        [Description("The route ID to include in the response.")]
        int id)
    {
        ApiVersion version = HttpContext.GetRequestedApiVersion();
        var newLine = Environment.NewLine;
        return $"Controller = {GetType().Name}{newLine}Version = {version}{newLine}id = {id}";
    }
}