// Copyright Information
// ==================================
// AutoLot-APIs - AutoLot.Api - Version2Controller.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/09/07
// ==================================

namespace AutoLot.Api.Controllers.Versions;

[ApiVersion(2.0)]
public class Version2Controller : Version1Controller
{
    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType<string>(StatusCodes.Status200OK)]
    [EndpointSummary("Gets controller name and API version (v2).")]
    [EndpointDescription(
        "Returns the controller name and API version for v2. Example: GET /api/version2. No request body required.")]
    public override ActionResult<string> Get(
        ApiVersion apiVersion) =>
        $"Controller = {GetType().Name}{Environment.NewLine}Version = {apiVersion}";

    [HttpGet("{id}")]
    [Produces("application/json")]
    [ProducesResponseType<string>(StatusCodes.Status200OK)]
    [EndpointSummary("Gets controller name, API version, and ID (v2).")]
    [EndpointDescription(
        "Returns the controller name, API version, and ID for v2. Example: GET /api/version2/1. No request body required.")]
    public override ActionResult<string> Get(
        [Description("The unique identifier. Required.")]
        int id)
    {
        ApiVersion version = HttpContext.GetRequestedApiVersion();
        var newLine = Environment.NewLine;
        return $"Controller = {GetType().Name}{newLine}Version = {version}{newLine}id = {id}";
    }
}