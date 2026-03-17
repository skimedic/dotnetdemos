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
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest, "application/problem+json")]
    public IActionResult GetFromQuery(
        [Description("Comma-separated list of fields to shape the result. Optional.")] [FromQuery] string fields) => Ok(dataShaper.ShapeData(driverRepo.GetAll(), fields));

    [HttpPost("{id}")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest, "application/problem+json")]
    public IActionResult UpdateDriverFromValues(
        [Description("The unique identifier of the driver. Required.")] int id,
        [Description("JSON string of values to update. Optional.")] [FromQuery] string values)
    {
        var convertedValues = JsonSerializer.Deserialize<Dictionary<string, string>>(values);
        var driver = driverRepo.Find(id);
        dataShaper.UpdateData(driver, convertedValues);
        driverRepo.Update(driver);
        return Ok(driver);
    }
}