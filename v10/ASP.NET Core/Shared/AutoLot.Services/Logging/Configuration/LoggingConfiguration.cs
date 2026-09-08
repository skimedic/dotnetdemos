// Copyright Information
// ==================================
// AutoLot-WebApps - AutoLot.Services - LoggingConfiguration.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/09/07
// ==================================

using Serilog.Debugging;

namespace AutoLot.Services.Logging.Configuration;

public static class LoggingConfiguration
{
    public static IServiceCollection RegisterLoggingInterfaces(
        this IServiceCollection services)
    {
        services.AddScoped<IAppLogger, AppLogger>();
        return services;
    }

    private static readonly string OutputTemplate =
        @"[{Timestamp:yy-MM-dd HH:mm:ss} {Level}]{ApplicationName}:{SourceContext}{NewLine}Message:{Message}{NewLine}in method {MemberName} at {FilePath}:{LineNumber}{NewLine}{Exception}{NewLine}";

    private static readonly ColumnOptions ColumnOptions =
        new()
        {
            AdditionalColumns =
                new List<SqlColumn>
                {
                    new()
                    {
                        DataType = SqlDbType.VarChar,
                        ColumnName = "ApplicationName"
                    },
                    new()
                    {
                        DataType = SqlDbType.VarChar,
                        ColumnName = "MachineName"
                    },
                    new()
                    {
                        DataType = SqlDbType.VarChar,
                        ColumnName = "MemberName"
                    },
                    new()
                    {
                        DataType = SqlDbType.VarChar,
                        ColumnName = "FilePath"
                    },
                    new()
                    {
                        DataType = SqlDbType.Int,
                        ColumnName = "LineNumber"
                    },
                    new()
                    {
                        DataType = SqlDbType.VarChar,
                        ColumnName = "SourceContext"
                    },
                    new()
                    {
                        DataType = SqlDbType.VarChar,
                        ColumnName = "RequestPath"
                    },
                    new()
                    {
                        DataType = SqlDbType.VarChar,
                        ColumnName = "ActionName"
                    }
                }
        };

    public static void ConfigureSerilog(
        this WebApplicationBuilder builder,
        IConfiguration configuration)
    {
        ConfigureSerilogInternal(
            builder,
            configuration);
    }

    public static void ConfigureSerilog(
        this HostApplicationBuilder builder,
        IConfiguration configuration)
    {
        ConfigureSerilogInternal(
            builder,
            configuration);
    }

    internal static void ConfigureSerilogInternal(
        IHostApplicationBuilder builder,
        IConfiguration configuration)
    {
        builder.Logging.ClearProviders();
        AppLoggerSettings settings =
            configuration.GetSection(nameof(AppLoggerSettings))
                .Get<AppLoggerSettings>();
        ValidateSettings(settings);

        string connectionStringName = settings.MsSqlServer.ConnectionStringName;
        string connectionString = configuration.GetConnectionString(connectionStringName);
        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new CustomException(
                $"Connection string '{connectionStringName}' referenced by " +
                $"'{nameof(AppLoggerSettings)}.{nameof(AppLoggerSettings.MsSqlServer)}.{nameof(AppLoggerSettings.SqlServerSettings.ConnectionStringName)}' is missing or empty.");
        }

        string tableName = settings.MsSqlServer.TableName;
        string schema = settings.MsSqlServer.Schema;
        string restrictedToMinimumLevel = settings.General.RestrictedToMinimumLevel;
        if (!Enum.TryParse<LogEventLevel>(
                restrictedToMinimumLevel,
                out LogEventLevel logLevel))
        {
            logLevel = LogEventLevel.Debug;
        }

        MSSqlServerSinkOptions sqlOptions =
            new()
            {
                AutoCreateSqlTable = false,
                SchemaName = schema,
                TableName = tableName
            };
        if (builder.Environment.IsDevelopment())
        {
            sqlOptions.BatchPeriod =
            new TimeSpan(
                0,
                0,
                0,
                1);
            sqlOptions.BatchPostingLimit = 1;
        }

        LoggerConfiguration log =
            new LoggerConfiguration().MinimumLevel
                .Is(logLevel)
                .MinimumLevel
                .Override(
                    "Microsoft",
                    LogEventLevel.Error)
                .Enrich
                .FromLogContext()
                .Enrich
                .With(
                    new PropertyEnricher(
                        "ApplicationName",
                        configuration.GetValue<string>("ApplicationName")))
                .Enrich
                .WithMachineName()
                .WriteTo
                .File(
                    builder.Environment.IsDevelopment()
                        ? settings.File.FileName
                        : settings.File.FullLogPathAndFileName, // "ErrorLog.txt",
                    rollingInterval: RollingInterval.Day,
                    restrictedToMinimumLevel: logLevel,
                    outputTemplate: OutputTemplate)
                .WriteTo
                .Console(logLevel)
                .WriteTo
                .MSSqlServer(
                    connectionString,
                    sqlOptions,
                    restrictedToMinimumLevel: logLevel,
                    columnOptions: ColumnOptions);
        if (builder.Environment.IsDevelopment())
        {
            SelfLog.Enable(msg =>
            {
                Debug.Print(msg);
                Debugger.Break();
            });
        }

        builder.Logging.AddSerilog(log.CreateLogger());
    }

    internal static void ValidateSettings(
        AppLoggerSettings settings)
    {
        if (settings is null)
        {
            throw new CustomException(
                $"Configuration section '{nameof(AppLoggerSettings)}' is missing or could not be bound.");
        }

        List<string> validationErrors =
        [
        ];
        ValidateObject(
            settings,
            nameof(AppLoggerSettings),
            validationErrors);

        if (settings.General is not null)
        {
            ValidateObject(
                settings.General,
                $"{nameof(AppLoggerSettings)}.{nameof(AppLoggerSettings.General)}",
                validationErrors);
        }

        if (settings.File is not null)
        {
            ValidateObject(
                settings.File,
                $"{nameof(AppLoggerSettings)}.{nameof(AppLoggerSettings.File)}",
                validationErrors);
        }

        if (settings.MsSqlServer is not null)
        {
            ValidateObject(
                settings.MsSqlServer,
                $"{nameof(AppLoggerSettings)}.{nameof(AppLoggerSettings.MsSqlServer)}",
                validationErrors);
        }

        if (validationErrors.Count > 0)
        {
            throw new CustomException(
                $"Configuration section '{nameof(AppLoggerSettings)}' is invalid: {string.Join("; ", validationErrors)}");
        }
    }

    internal static void ValidateObject(
        object instance,
        string propertyPath,
        List<string> validationErrors)
    {
        List<ValidationResult> validationResults =
        [
        ];
        Validator.TryValidateObject(
            instance,
            new ValidationContext(instance),
            validationResults,
            validateAllProperties: true);

        foreach (ValidationResult validationResult in validationResults)
        {
            bool hasMemberName = false;
            foreach (string memberName in validationResult.MemberNames)
            {
                validationErrors.Add($"{propertyPath}.{memberName}: {validationResult.ErrorMessage}");
                hasMemberName = true;
            }

            if (!hasMemberName)
            {
                validationErrors.Add($"{propertyPath}: {validationResult.ErrorMessage}");
            }
        }
    }
}