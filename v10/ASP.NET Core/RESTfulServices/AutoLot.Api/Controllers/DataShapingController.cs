// Copyright Information
// ==================================
// AutoLot - AutoLot.Api - DataShapingController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/12/03
// ==================================



namespace AutoLot.Api.Controllers;

[ApiController]
[ApiVersionNeutral]
[Route("api/[controller]")]
[Route("api/v{version:apiVersion}/[controller]")]
public class DataShapingController(
    IDriverRepo driverRepo,
    IDataShaper<Driver> dataShaper) : ControllerBase
{
    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest, "application/problem+json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [EndpointSummary("Gets shaped driver data")]
    [EndpointDescription("Returns driver data shaped to include only the requested fields from the query string.")]
    public IActionResult GetFromQuery(
        [FromQuery]
        [Description("Comma-separated list of fields to include in the response.")]
        string fields) =>
        Ok(dataShaper.ShapeData(driverRepo.GetAllAsList(), fields));

    [HttpPost("{id}")]
    [Produces("application/json")]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest, "application/problem+json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [EndpointSummary("Updates a driver from shaped values")]
    [EndpointDescription("Updates an existing driver by applying field/value pairs provided as JSON in the query string.")]
    public IActionResult UpdateDriverFromValues(
        [Description("The unique identifier of the driver. Required.")]
        int id,
        [FromQuery]
        [Description("A JSON object containing field/value pairs to apply.")]
        string values)
    {
        if (string.IsNullOrWhiteSpace(values))
        {
            return BadRequest("values query parameter is required.");
        }

        Dictionary<string, string> convertedValues;
        try
        {
            convertedValues = JsonSerializer.Deserialize<Dictionary<string, string>>(values);
        }
        catch (JsonException)
        {
            return BadRequest("values must be a valid JSON object.");
        }

        var driver = driverRepo.Find(id);
        if (driver == null)
        {
            return NoContent();
        }

        dataShaper.UpdateData(driver, convertedValues);
        driverRepo.Update(driver);
        return Ok(driver);
    }
}