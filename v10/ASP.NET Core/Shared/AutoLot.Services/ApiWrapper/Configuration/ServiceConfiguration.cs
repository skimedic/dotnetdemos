// Copyright Information
// ==================================
// AutoLot-WebApps - AutoLot.Services - ServiceConfiguration.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/09/07
// ==================================

namespace AutoLot.Services.ApiWrapper.Configuration;

public static class ServiceConfiguration
{
    public static IServiceCollection ConfigureApiServiceWrapper(
        this IServiceCollection services,
        IConfiguration config)
    {
        services.AddOptions<ApiServiceSettings>()
            .BindConfiguration(nameof(ApiServiceSettings))
            .ValidateDataAnnotations()
            .ValidateOnStart();
        services.AddHttpClient<ICarApiServiceWrapper, CarApiServiceWrapper>();
        services.AddHttpClient<IMakeApiServiceWrapper, MakeApiServiceWrapper>();
        return services;
    }
}