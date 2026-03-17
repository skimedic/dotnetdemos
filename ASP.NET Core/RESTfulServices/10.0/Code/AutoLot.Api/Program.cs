// Copyright Information
// ==================================
// AutoLot - AutoLot.Api - Program.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/12/03
// ==================================

using JsonOptions = Microsoft.AspNetCore.Http.Json.JsonOptions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.ConfigureSerilog();
builder.Services.RegisterLoggingInterfaces();

builder.Services.AddControllers(config =>
        {
            config.Filters.Add(new CustomExceptionFilterAttribute(builder.Environment));
            config.RespectBrowserAcceptHeader = true;
            config.OutputFormatters.Add(new CustomCsvOutputFormatter());
        }
    )
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
        options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
        options.JsonSerializerOptions.WriteIndented = true;
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    })
    .AddControllersAsServices()
    .ConfigureApiBehaviorOptions(options =>
    {
        //suppress automatic model state binding errors
        options.SuppressModelStateInvalidFilter = true;
        //suppress all binding inference
        //options.SuppressInferBindingSourcesForParameters= true;
        //suppress multipart/form-data content type inference
        //options.SuppressConsumesConstraintForFormFileParameters = true;
        //Don't create a problem details error object if set to true
        options.SuppressMapClientErrors = false;
        options.ClientErrorMapping[StatusCodes.Status404NotFound].Link = "https://httpstatuses.com/404";
        options.ClientErrorMapping[StatusCodes.Status404NotFound].Title = "Invalid location";
    })
    .AddXmlSerializerFormatters();

builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    options.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    options.SerializerOptions.WriteIndented = true;
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddScoped<ICarDriverRepo, CarDriverRepo>();
builder.Services.AddScoped<ICarRepo, CarRepo>();
builder.Services.AddScoped<IDriverRepo, DriverRepo>();
builder.Services.AddScoped<IMakeRepo, MakeRepo>();
builder.Services.AddScoped<IRadioRepo, RadioRepo>();
builder.Services.AddScoped(typeof(IDataShaper<>), typeof(DataShaper<>));

var connectionString = builder.Configuration.GetConnectionString("AutoLot");
builder.Services.AddDbContextPool<ApplicationDbContext>(options =>
{
    options.ConfigureWarnings(wc => wc.Ignore(RelationalEventId.BoolWithDefaultWarning));
    options.UseSqlServer(connectionString,
        sqlOptions => sqlOptions.EnableRetryOnFailure().CommandTimeout(60));
});

builder.Host.UseDefaultServiceProvider(o =>
{
    o.ValidateOnBuild = true;
    o.ValidateScopes = true;
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", pb =>
    {
        pb
            .AllowAnyHeader()
            .AllowAnyMethod()
            //.AllowCredentials()
            .AllowAnyOrigin();
    });
});

builder.Services.AddProblemDetails();
/*
 * https://github.com/dotnet/aspnet-api-versioning/wiki/Error-Responses
 */
var defaultVersion = ApiVersion.Default;
builder.Services.AddApiVersioning(options =>
    {
        //Set Default version
        options.DefaultApiVersion = defaultVersion;
        options.AssumeDefaultVersionWhenUnspecified = true;
        // reporting api versions will return the headers "api-supported-versions"
        // and "api-deprecated-versions"
        options.ReportApiVersions = true;
        //This combines all available option and adds "v" and "api-version"
        // for query string, header, or media type versioning
        // NOTE: In a real application, pick one method, not all of them
        options.ApiVersionReader = ApiVersionReader.Combine(
            new UrlSegmentApiVersionReader(),
            new QueryStringApiVersionReader(), //defaults to "api-version"
            new QueryStringApiVersionReader("v"),
            new HeaderApiVersionReader("x-ms-api-version"),
            new HeaderApiVersionReader("x-ms-v"),
            new MediaTypeApiVersionReader(), //defaults to "v"
            new MediaTypeApiVersionReader("api-version")
        );
        options.ApiVersionSelector = new DefaultApiVersionSelector(options);
        //options.ApiVersionSelector =
        //    new CurrentImplementationApiVersionSelector(options);
        //options.ApiVersionSelector =
        //    new LowestImplementedApiVersionSelector(options);

        //This is the default and is used in route constraints
        options.RouteConstraintName = "apiVersion";

        options.UnsupportedApiVersionStatusCode = StatusCodes.Status400BadRequest;
        /*
         *Unsupported API Version Status Code
           This option allows you to configure the HTTP status code used when an unsupported API version is requested. The default value is 400 (Bad Request).
           
           While any HTTP status code can be used, the following are the most sensible:
           
           Status Code	Meaning	Description
           400	Bad Request	The API doesn't support this version
           404	Not Found	The API doesn't exist
           501	Not Implemented	The API isn't implemented
         */
    })
    .AddMvc(options =>
    {
        //options.Conventions.Controller<ValuesController>().HasApiVersion(1.0);
        //If using ApiVersion attribute, the following is not needed.
        //If both are used, result is the aggregate of both.
        //options.Conventions.Controller<ValuesController>()
        //           .HasDeprecatedApiVersion(1.0)
        //           .HasApiVersion(2.0)
        //           .Action(c => c.Problem()).MapToApiVersion(2.0)
        //           .Action(c => c.TestLogging()).MapToApiVersion(3.0);
        //options.Conventions.Controller<CarsBetaController>()
        //    .HasApiVersion(new ApiVersion(3, 0, "Beta"));
        //options.Conventions.Controller<CarsBetaController>()
        //    .HasApiVersion(new ApiVersion(2, 5, "Beta"));
    })
    .AddApiExplorer(options =>
    {
        //https://github.com/dotnet/aspnet-api-versioning/wiki/Version-Format#version-suffixes
        options.GroupNameFormat = "'v'VVV";
        options.SubstituteApiVersionInUrl = true;
        options.AddApiVersionParametersWhenVersionNeutral = true;
        //Following derives from the ApiVersioningOptions setup and should not be set differently
        //options.DefaultApiVersion = ApiVersion.Default;
        //The following is the default value
        //options.DefaultApiVersionParameterDescription = "The requested API version";
        //Following derives from the ApiVersioningOptions setup and should not be set differently
        //options.AssumeDefaultVersionWhenUnspecified = true;
    });

builder.Services.TryAddEnumerable(
    ServiceDescriptor.Transient<IApiControllerSpecification, ApiBehaviorSpecification>());

builder.Services.AddOpenApi("v1", options => ConfigureOptions(options, "v1", includeBlankGroups: true));
//builder.Services.AddOpenApi("v1.5",
//    options => ConfigureOptions(options, "v1.5", isDeprecated: true));
builder.Services.AddOpenApi("v1.5",
    options => ConfigureOptions(options, "v1.5", isDeprecated: true, controllerNamesToDeprecate: ["Cars"]));
builder.Services.AddOpenApi("v2", options => ConfigureOptions(options, "v2"));
builder.Services.AddOpenApi("v2.5-Beta", options => ConfigureOptions(options, "v2.5-Beta"));
builder.Services.AddOpenApi("v3-Beta", options => ConfigureOptions(options, "v3-Beta"));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors("AllowAll");

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
    app.MapScalarApiReference(options =>
    {
        var docs = new List<ScalarDocument>();
        foreach (var versionDescription in provider.ApiVersionDescriptions)
        {
            var isDeprecated = versionDescription.IsDeprecated ? " (Deprecated)":"";
            var name =
                $"AutoLot API Version {versionDescription.ApiVersion.ToString()}{isDeprecated}";
            docs.Add(new ScalarDocument(versionDescription.GroupName, name));
        }
        options.AddDocuments(docs);
    });
    app.UseSwaggerUI(options =>
    {
        foreach (var versionDescription in provider.ApiVersionDescriptions)
        {
            var groupName = versionDescription.GroupName;
            var url = $"/openapi/{groupName}.json";
            var name = $"AutoLot API: {groupName}";
            options.SwaggerEndpoint(url, name);
        }
    });
    //Initialize the database
    if (app.Configuration.GetValue<bool>("RebuildDataBase"))
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        SampleDataInitializer.ClearAndReseedDatabase(dbContext);
    }
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

OpenApiInfo BuildDocumentInfo(
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
        Contact = new OpenApiContact() { Name = "Phil Japikse", Email = "skimedic@outlook.com" },
        TermsOfService = new System.Uri("https://www.linktotermsofservice.com"),
        License = new OpenApiLicense()
        {
            Name = "MIT",
            Url = new Uri("https://opensource.org/licenses/MIT")
        }
    };
}

void AddDeprecated(
    OpenApiDocument openApiDocument,
    List<string> controllerNames)
{
    foreach (var path in openApiDocument.Paths.Where(x => x.Value?.Operations != null))
    {
        foreach (var op in path.Value.Operations!)
        {
            if (controllerNames is { Count: > 0 })
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

void ConfigureOptions(
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
        document.Info = BuildDocumentInfo("v1.5", isDeprecated);
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
        openApiOptions.ShouldInclude = (
            description) => description.GroupName == null || description.GroupName == openApiOptions.DocumentName;
    }
    else
    {
        openApiOptions.ShouldInclude = (
            description) => description.GroupName == openApiOptions.DocumentName;
    }
}
