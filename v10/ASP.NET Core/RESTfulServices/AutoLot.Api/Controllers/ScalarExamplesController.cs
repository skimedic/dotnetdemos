using Microsoft.AspNetCore.Mvc;

namespace AutoLot.Api.Controllers;

[ApiVersionNeutral]
public class ScalarExamplesController : BaseAppController
{
    [HttpGet("internal-status1")]
    [ExcludeFromApiReference]
    public IActionResult ExcludedFromScalarUIEndpoint()
    {
        return Ok("Running");
    }
    [HttpGet("internal-status2")]
    [ExcludeFromDescription]
    public IActionResult ExcludedFromDocumentEndpoint()
    {
        return Ok("Running");
    }
    [HttpGet("documents-stable")]
    [Stability(Stability.Stable)]
    [CodeSample("curl -X GET https://api.example.com/documents", ScalarTarget.Shell)]
    public IActionResult StableDocuments()
    {
        return Ok();
    }

    [HttpGet("documents-experimental")]
    [Stability(Stability.Experimental)]
    public IActionResult ExperimentalDocuments()
    {
        return Ok();
    }

    [HttpGet("documents-deprecated")]
    [Stability(Stability.Deprecated)]
    public IActionResult DeprecatedDocuments()
    {
        return Ok();
    }

    [HttpGet("documents-badge")]
    [Badge("New")]
    [Badge("V2", BadgePosition.After, "#007bff")]
    public IActionResult BadgeDocuments()
    {
        return Ok();
    }
}
