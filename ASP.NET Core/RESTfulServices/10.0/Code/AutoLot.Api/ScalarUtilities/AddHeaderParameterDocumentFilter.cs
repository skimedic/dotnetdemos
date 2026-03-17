namespace AutoLot.Api.ScalarUtilities;

public class AddHeaderParameterDocumentFilter : IOpenApiOperationTransformer
{
    public Task TransformAsync(
        OpenApiOperation operation,
        OpenApiOperationTransformerContext context,
        CancellationToken cancellationToken)
    {
        operation.Parameters ??= [];
        operation.Parameters.Add(new OpenApiParameter
        {
            Name = "Accept",
            In = ParameterLocation.Header,
            Required = false,
            Description = "Specifies the desired response format.",
            AllowEmptyValue = true,
            Schema = new OpenApiSchema
            {
                Type = JsonSchemaType.String
            }
        });

        return Task.CompletedTask;
    }
}