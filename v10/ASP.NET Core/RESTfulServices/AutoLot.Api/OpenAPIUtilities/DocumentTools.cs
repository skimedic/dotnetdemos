// Copyright Information
// ==================================
// AutoLot - AutoLot.Api - OpenApiUtilities.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/07/12
// ==================================

namespace AutoLot.Api.OpenAPIUtilities;

public static class DocumentTools
{
    static OpenApiInfo BuildDocumentInfo(
        string version,
        bool isDeprecated)
    {
        var description = "API for AutoLot Car Dealership.";
        if (isDeprecated)
        {
            description += "<p><font color='red'>This API version has been deprecated.</font></p>";
        }

        return new()
        {
            Title = "AutoLot API",
            Version = version,
            Description = description,
            Contact =
                new OpenApiContact()
                {
                    Name = "Phil Japikse",
                    Email = "skimedic@outlook.com"
                },
            TermsOfService = new System.Uri("https://www.linktotermsofservice.com"),
            License =
                new OpenApiLicense()
                {
                    Name = "MIT",
                    Url = new Uri("https://opensource.org/licenses/MIT")
                }
        };
    }

    static void AddDeprecated(
        OpenApiDocument openApiDocument,
        List<string> controllerNames)
    {
        foreach (var path in openApiDocument.Paths.Where(x => x.Value?.Operations != null))
        {
            foreach (var op in path.Value.Operations!)
            {
                if (controllerNames is
                    {
                        Count: > 0
                    })
                {
                    controllerNames
                        .Where(controllerName =>
                            path.Key.Contains($"/{controllerName}", StringComparison.OrdinalIgnoreCase))
                        .ToList()
                        .ForEach(controllerName => op.Value.Deprecated = true);
                }
                else
                {
                    op.Value.Deprecated = true;
                }
            }
        }
    }

    internal static void ConfigureOptions(
        OpenApiOptions openApiOptions,
        string documentName,
        bool includeBlankGroups = false,
        bool isDeprecated = false,
        List<string> controllerNamesToDeprecate = null)
    {
        openApiOptions.AddDocumentTransformer((
            document,
            context,
            cancellationToken) =>
        {
            document.Info = BuildDocumentInfo(documentName, isDeprecated);
            if (isDeprecated)
            {
                AddDeprecated(document, controllerNamesToDeprecate);
            }

            return Task.CompletedTask;
        });

        openApiOptions.AddOperationTransformer<AddHeaderParameterDocumentFilter>();
        openApiOptions.OpenApiVersion = OpenApiSpecVersion.OpenApi3_1;
        if (includeBlankGroups)
        {
            openApiOptions.ShouldInclude =
            (
                description) => description.GroupName == null || description.GroupName == openApiOptions.DocumentName;
        }
        else
        {
            openApiOptions.ShouldInclude =
            (
                description) => description.GroupName == openApiOptions.DocumentName;
        }
    }
}