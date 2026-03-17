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
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest, "application/problem+json")]
    [EndpointSummary("Gets controller name and API version.")]
    [EndpointDescription("Returns the controller name and API version. Example: GET /api/version1. No request body required.")]
    public virtual string Get(
        ApiVersion apiVersion)
        => $"Controller = {GetType().Name}{Environment.NewLine}Version = {apiVersion}";
    
    [HttpGet("{id}")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest, "application/problem+json")]
    [EndpointSummary("Gets controller name, API version, and ID.")]
    [EndpointDescription("Returns the controller name, API version, and ID. Example: GET /api/version1/1. No request body required.")]
    public virtual string Get(
        [Description("The unique identifier. Required.")] int id)
    {
        ApiVersion version = HttpContext.GetRequestedApiVersion();
        var newLine = Environment.NewLine;
        return $"Controller = {GetType().Name}{newLine}Version = {version}{newLine}id = {id}";
    }
}