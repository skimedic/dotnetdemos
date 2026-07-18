// Copyright Information
// ==================================
// AutoLot - AutoLot.Dal - ServiceCollectionExtensions.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/07/18
// ==================================

namespace AutoLot.Dal.Extensions;

public static class ServiceCollectionExtensions
{
    extension(
        IServiceCollection services)
    {
        /// <summary>
        /// Registers all AutoLot DAL services: DbContext pool and all repo scoped registrations.
        /// Call once from each host's Program.cs instead of repeating the individual registrations.
        /// </summary>
        public IServiceCollection AddAutoLotDal(
            string connectionString)
        {
            services.AddDbContextPool<ApplicationDbContext>(options =>
            {
                options.ConfigureWarnings(wc => wc.Ignore(RelationalEventId.BoolWithDefaultWarning));
                options.UseSqlServer(connectionString, sqlOptions =>
                    sqlOptions.EnableRetryOnFailure()
                        .CommandTimeout(60));
            });

            services.AddScoped<ICarDriverRepo, CarDriverRepo>();
            services.AddScoped<ICarRepo, CarRepo>();
            services.AddScoped<IDriverRepo, DriverRepo>();
            services.AddScoped<IMakeRepo, MakeRepo>();
            services.AddScoped<IRadioRepo, RadioRepo>();

            return services;
        }
    }
}