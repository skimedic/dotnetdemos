using Asp.Versioning;
using Asp.Versioning.Builder;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
var defaultVersion = ApiVersion.Default;

builder.Services
    .AddApiVersioning(options =>
    {
        options.DefaultApiVersion = defaultVersion;
        options.AssumeDefaultVersionWhenUnspecified = true;
        options.ReportApiVersions = true;
        // NOTE: In a real application, pick one method, not all of them
        options.ApiVersionReader =
            ApiVersionReader.Combine(new UrlSegmentApiVersionReader(),
                new QueryStringApiVersionReader(), //defaults to "api-version"
                new QueryStringApiVersionReader("v"),
                new HeaderApiVersionReader("x-ms-api-version"),
                new HeaderApiVersionReader("x-ms-v"),
                new MediaTypeApiVersionReader(), //defaults to "v"
                new MediaTypeApiVersionReader("api-version"));
        options.ApiVersionSelector = new DefaultApiVersionSelector(options);
        options.RouteConstraintName = "apiVersion";

        options.UnsupportedApiVersionStatusCode = StatusCodes.Status400BadRequest;
    })
    .AddOpenApi();
var app = builder.Build();
var usersApi = app.NewVersionedApi("Users");
// @formatter off
var usersv1 = usersApi.MapGroup("api/users").HasDeprecatedApiVersion(1, 0);
var usersv2 = usersApi.MapGroup("api/users").HasApiVersion(new ApiVersion(2, 0));
//var healthcheckv2 = usersApi.MapGroup("api/health");
usersv1.MapGet("", () =>
    TypedResults.Ok(new[] { new UserV1(1, "John Doe"), new UserV1(2, "Alice Dewett"), }));

usersv2.MapGet("", () =>
    TypedResults.Ok(new[] {
        new UserV2(1, "John Doe", new DateOnly(1990, 1, 1)),
        new UserV2(2, "Alice Dewett", new DateOnly(1992, 2, 2)),
    }));

usersApi.MapGet("api/health", (HttpContext context) =>
{
    ApiVersion? version = context.RequestedApiVersion;

    return TypedResults.Ok(new
    {
        Status = "Healthy",
        RequestedVersion = version?.ToString() ?? "Not specified"
    });
}).IsApiVersionNeutral();


ApiVersionSet versionSet = app.NewApiVersionSet()
    .HasDeprecatedApiVersion(new ApiVersion(1, 0))
    .HasApiVersion(new ApiVersion(2, 0))
    .ReportApiVersions()
    .Build();
var clientsv1 = app.MapGroup("api").WithApiVersionSet(versionSet);
clientsv1.MapGet("/client1", () =>
    TypedResults.Ok(new[] { new UserV1(1, "John Doe"), new UserV1(2, "Alice Dewett"), })).MapToApiVersion(1.0);

clientsv1.MapGet("/client2", () =>
    TypedResults.Ok(new[] {
        new UserV2(1, "John Doe", new DateOnly(1990, 1, 1)),
        new UserV2(2, "Alice Dewett", new DateOnly(1992, 2, 2)),
    })).MapToApiVersion(2.0);

// @formatter on

app.MapOpenApi()
    .WithDocumentPerVersion();
app.MapScalarApiReference(options =>
{
    options.ForceLightMode();
    var descriptions = app.DescribeApiVersions();

    for (var i = 0; i < descriptions.Count; i++)
    {
        var description = descriptions[i];
        var isDeprecated = description.IsDeprecated ? " (Deprecated)" : "";
        var name = $"Minimal API Version {description.ApiVersion.ToString()}{isDeprecated}";

        options.AddDocument(description.GroupName,
            name,
            isDefault: i == descriptions.Count - 1);
    }
});

app.Run();

record UserV1(int Id, string Name);

record UserV2(int Id, string Name, DateOnly BirthDate);