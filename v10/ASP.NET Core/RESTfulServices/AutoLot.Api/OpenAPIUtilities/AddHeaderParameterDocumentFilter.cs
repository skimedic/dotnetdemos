// Copyright Information
// ==================================
// AutoLot-APIs - AutoLot.Api - AddHeaderParameterDocumentFilter.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/09/07
// ==================================

namespace AutoLot.Api.OpenAPIUtilities;

public class AddHeaderParameterDocumentFilter : IOpenApiOperationTransformer
{
    public Task TransformAsync(
        OpenApiOperation operation,
        OpenApiOperationTransformerContext context,
        CancellationToken cancellationToken)
    {
        operation.Parameters ??=
        [
        ];
        operation.Parameters.Add(
            new OpenApiParameter
            {
                Name = "Accept",
                In = ParameterLocation.Header,
                Required = false,
                Description = "Specifies the desired response format.",
                Schema = new OpenApiSchema { Type = JsonSchemaType.String }
            });

        return Task.CompletedTask;
    }
}