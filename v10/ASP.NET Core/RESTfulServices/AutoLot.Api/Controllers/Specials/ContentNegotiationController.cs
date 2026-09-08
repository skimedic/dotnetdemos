// Copyright Information
// ==================================
// AutoLot-APIs - AutoLot.Api - ContentNegotiationController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/09/07
// ==================================

namespace AutoLot.Api.Controllers.Specials;

[ApiVersionNeutral]
public class ContentNegotiationController : BaseAppController
{
    [HttpGet]
    [Produces(
        "application/json",
        "application/xml",
        "text/csv")]
    [ProducesResponseType<IEnumerable<Driver>>(StatusCodes.Status200OK)]
    [EndpointSummary("Gets all drivers with content negotiation.")]
    [EndpointDescription(
        "Returns all drivers in the requested format (JSON, XML, CSV). Example: GET /api/contentnegotiation. No request body required.")]
    public ActionResult<IEnumerable<Driver>> Get(
        [FromServices]
        IDriverRepo driverRepo) =>
        driverRepo.GetAllAsList();
}