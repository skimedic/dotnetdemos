// Copyright Information
// ==================================
// AutoLot - AutoLot.Api - HateoasController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/11/16
// ==================================

namespace AutoLot.Api.Controllers.Specials;

[ApiVersionNeutral]
public class HateoasController(
    IAppLogger appLogger) : BaseAppController(appLogger)
{
    [HttpGet("hateos")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [EndpointSummary("Returns a HATEOAS response")]
    [EndpointDescription("Returns a HATEOAS response with links to related resources.")]
    public IActionResult GetHateoasResponse()
    {
        var hateoasResponse = new
        {
            Message = "This is a HATEOAS response",
            Links = new[]
            {
                new { Type="GET", Rel = "self", Href = Url.Action(nameof(GetHateoasResponse)) },
                new { Type="GET", Rel = "problem", Href = Url.Action(nameof(ValuesController.Problem), nameof(ValuesController).RemoveControllerSuffix()) },
                new { Type="GET", Rel = "logging", Href = Url.Action(nameof(ValuesController.TestLogging), nameof(ValuesController).RemoveControllerSuffix()) },
                new { Type="GET", Rel = "error", Href = Url.Action(nameof(ValuesController.TestExceptionHandling), nameof(ValuesController).RemoveControllerSuffix()) }
            }
        };
        return Ok(hateoasResponse);
    }
}