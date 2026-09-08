// Copyright Information
// ==================================
// AutoLot-WebApps - AutoLot.Dal - SampleDataInitializer.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/09/07
// ==================================

namespace AutoLot.Dal.Initialization;

public static class SampleDataInitializer
{
    internal static IModel GetDesignTimeModel(
        ApplicationDbContext context)
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddDbContextDesignTimeServices(context);
        var serviceProvider = serviceCollection.BuildServiceProvider();
        return serviceProvider.GetService<IModel>();
    }

    internal static void ClearHistoryTable(
        ApplicationDbContext context,
        IModel designTimeModel,
        (string SchemaName, string TableName, string EntityName) entityInfo)
    {
        var alterTable = $"ALTER TABLE {entityInfo.SchemaName}.{entityInfo.TableName} ";
        var setVersioningOff = $"SET (SYSTEM_VERSIONING = OFF)";
        var strategy = context.Database.CreateExecutionStrategy();
        strategy.Execute(() =>
        {
            var designTimeEntity = designTimeModel.FindEntityType(entityInfo.EntityName);
            var historySchema = designTimeEntity.GetHistoryTableSchema();
            var historyTable = designTimeEntity.GetHistoryTableName();
            var setVersioningOn = $"SET (SYSTEM_VERSIONING = ON (HISTORY_TABLE={historySchema}.{historyTable}))";
#pragma warning disable EF1002 // Risk of vulnerability to SQL injection.
            context.Database.ExecuteSqlRaw($"{alterTable}{setVersioningOff}");
            context.Database.ExecuteSqlRaw($"DELETE FROM {historySchema}.{historyTable}");
            context.Database.ExecuteSqlRaw($"{alterTable}{setVersioningOn}");
#pragma warning restore EF1002 // Risk of vulnerability to SQL injection.
        });
    }

    internal static void ClearData(
        ApplicationDbContext context)
    {
        var entities =
            new[]
            {
                typeof(CarDriver).FullName,
                typeof(Driver).FullName,
                typeof(Radio).FullName,
                typeof(Car).FullName,
                typeof(Make).FullName,
                typeof(SeriLogEntry).FullName
            };
        IModel designTimeModel = GetDesignTimeModel(context);
        IExecutionStrategy strategy = context.Database.CreateExecutionStrategy();
        strategy.Execute(() =>
        {
            using var transaction = context.Database.BeginTransaction();
            try
            {
                foreach (var entityName in entities)
                {
                    var entity = context.Model.FindEntityType(entityName);
                    var tableName = entity.GetTableName();
                    var schemaName = entity.GetSchema();
#pragma warning disable EF1002 // Risk of vulnerability to SQL injection.
                    context.Database.ExecuteSqlRaw($"DELETE FROM {schemaName}.{tableName}");
                    context.Database.ExecuteSqlRaw($"DBCC CHECKIDENT (\"{schemaName}.{tableName}\", RESEED, 1);");
#pragma warning restore EF1002 // Risk of vulnerability to SQL injection.
                    if (entity.IsTemporal())
                    {
                        ClearHistoryTable(
                            context,
                            designTimeModel,
                            (schemaName, tableName, entityName));
                    }
                }

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        });
    }

    internal static void SeedData(
        ApplicationDbContext context)
    {
        IExecutionStrategy strategy = context.Database.CreateExecutionStrategy();
        strategy.Execute(() =>
        {
            using var transaction = context.Database.BeginTransaction();
            try
            {
                ProcessInsert(
                    context,
                    context.Makes,
                    SampleData.Makes);
                ProcessInsert(
                    context,
                    context.Drivers,
                    SampleData.Drivers);
                ProcessInsert(
                    context,
                    context.Cars,
                    SampleData.Inventory);
                ProcessInsert(
                    context,
                    context.Radios,
                    SampleData.Radios);
                ProcessInsert(
                    context,
                    context.CarDrivers,
                    SampleData.CarsAndDrivers);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        });

        static void ProcessInsert<TEntity>(
            ApplicationDbContext context,
            DbSet<TEntity> table,
            List<TEntity> records) where TEntity : BaseEntity
        {
            if (table.Any())
            {
                return;
            }

            var metaData = context.Model.FindEntityType(typeof(TEntity).FullName);
            var identityInsertSql = $"SET IDENTITY_INSERT {metaData.GetSchema()}.{metaData.GetTableName()}";
            try
            {
#pragma warning disable EF1002 // Risk of vulnerability to SQL injection.
                context.Database.ExecuteSqlRaw($"{identityInsertSql} ON");
                table.AddRange(records);
                context.SaveChanges();
            }
            finally
            {
                // Ensure IDENTITY_INSERT is always turned off, even on failure.
                context.Database.ExecuteSqlRaw($"{identityInsertSql} OFF");
#pragma warning restore EF1002 // Risk of vulnerability to SQL injection.
            }
        }
    }

    public static void ClearAndReseedDatabase(
        ApplicationDbContext context)
    {
        ClearData(context);
        SeedData(context);
    }
}