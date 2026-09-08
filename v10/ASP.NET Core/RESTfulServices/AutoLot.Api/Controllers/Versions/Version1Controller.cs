// Copyright Information
// ==================================
// AutoLot-APIs - AutoLot.Api - Version1Controller.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/09/07
// ==================================

using AutoLot.Api.Controllers.Versions.Base;

namespace AutoLot.Api.Controllers.Versions;

[ApiVersion(1.0)]
//[AdvertiseApiVersions(2.0)]
public class Version1Controller : VersionControllerBase
{
    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType<string>(StatusCodes.Status200OK)]
    [EndpointSummary("Gets API version information")]
    [EndpointDescription("Returns the controller name and requested API version.")]
    public virtual ActionResult<string> Get(
        [Description("The resolved API version for the current request.")] [FromServices]
        ApiVersion apiVersion) =>
        $"Controller = {GetType().Name}{Environment.NewLine}Version = {apiVersion}";

    [HttpGet("{id}")]
    [Produces("application/json")]
    [ProducesResponseType<string>(StatusCodes.Status200OK)]
    [EndpointSummary("Gets API version information with an ID")]
    [EndpointDescription("Returns the controller name, requested API version, and route ID.")]
    public virtual ActionResult<string> Get(
        [Description("The route ID to include in the response.")]
        int id)
    {
        ApiVersion version = HttpContext.GetRequestedApiVersion();
        var newLine = Environment.NewLine;
        return $"Controller = {GetType().Name}{newLine}Version = {version}{newLine}id = {id}";
    }
}