IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260704211037_Initial'
)
BEGIN
    IF SCHEMA_ID(N'Logging') IS NULL EXEC(N'CREATE SCHEMA [Logging];');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260704211037_Initial'
)
BEGIN
    CREATE TABLE [dbo].[Drivers] (
        [Id] int NOT NULL IDENTITY,
        [FirstName] nvarchar(50) NOT NULL,
        [FullName] AS [LastName] + ', ' + [FirstName],
        [LastName] nvarchar(50) NOT NULL,
        [TimeStamp] rowversion NOT NULL,
        CONSTRAINT [PK_Drivers] PRIMARY KEY ([Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260704211037_Initial'
)
BEGIN
    CREATE TABLE [dbo].[Makes] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(50) NOT NULL,
        [TimeStamp] rowversion NOT NULL,
        CONSTRAINT [PK_Makes] PRIMARY KEY ([Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260704211037_Initial'
)
BEGIN
    CREATE TABLE [Logging].[SeriLogs] (
        [Id] int NOT NULL IDENTITY,
        [Message] nvarchar(max) NULL,
        [MessageTemplate] nvarchar(max) NULL,
        [Level] nvarchar(128) NULL,
        [TimeStamp] datetime2 NOT NULL DEFAULT (GetDate()),
        [Exception] nvarchar(max) NULL,
        [Properties] Xml NULL,
        [LogEvent] nvarchar(max) NULL,
        [SourceContext] nvarchar(max) NULL,
        [RequestPath] nvarchar(max) NULL,
        [ActionName] nvarchar(max) NULL,
        [ApplicationName] nvarchar(max) NULL,
        [MachineName] nvarchar(max) NULL,
        [FilePath] nvarchar(max) NULL,
        [MemberName] nvarchar(max) NULL,
        [LineNumber] int NULL DEFAULT 0,
        CONSTRAINT [PK_SeriLogs] PRIMARY KEY ([Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260704211037_Initial'
)
BEGIN
    CREATE TABLE [dbo].[Inventory] (
        [Id] int NOT NULL IDENTITY,
        [Color] nvarchar(50) NOT NULL,
        [Price] decimal(18,2) NULL,
        [IsDrivable] bit NOT NULL DEFAULT CAST(1 AS bit),
        [DateBuilt] datetime2 NULL DEFAULT (getdate()),
        [Display] AS [PetName] + ' (' + [Color] + ')' PERSISTED,
        [PetName] nvarchar(50) NOT NULL,
        [MakeId] int NOT NULL,
        [TimeStamp] rowversion NOT NULL,
        CONSTRAINT [PK_Inventory] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Inventory_Makes_MakeId] FOREIGN KEY ([MakeId]) REFERENCES [dbo].[Makes] ([Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260704211037_Initial'
)
BEGIN
    CREATE TABLE [dbo].[InventoryToDrivers] (
        [Id] int NOT NULL IDENTITY,
        [DriverId] int NOT NULL,
        [InventoryId] int NOT NULL,
        [TimeStamp] rowversion NOT NULL,
        CONSTRAINT [PK_InventoryToDrivers] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_InventoryDriver_Drivers_DriverId] FOREIGN KEY ([DriverId]) REFERENCES [dbo].[Drivers] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_InventoryDriver_Inventory_InventoryId] FOREIGN KEY ([InventoryId]) REFERENCES [dbo].[Inventory] ([Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260704211037_Initial'
)
BEGIN
    CREATE TABLE [dbo].[Radios] (
        [Id] int NOT NULL IDENTITY,
        [HasTweeters] bit NOT NULL,
        [HasSubWoofers] bit NOT NULL,
        [RadioId] nvarchar(50) NOT NULL,
        [InventoryId] int NOT NULL,
        [TimeStamp] rowversion NOT NULL,
        CONSTRAINT [PK_Radios] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Radios_Inventory_InventoryId] FOREIGN KEY ([InventoryId]) REFERENCES [dbo].[Inventory] ([Id]) ON DELETE CASCADE
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260704211037_Initial'
)
BEGIN
    CREATE INDEX [IX_Inventory_MakeId] ON [dbo].[Inventory] ([MakeId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260704211037_Initial'
)
BEGIN
    CREATE UNIQUE INDEX [IX_InventoryToDrivers_DriverId_CarId] ON [dbo].[InventoryToDrivers] ([DriverId], [InventoryId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260704211037_Initial'
)
BEGIN
    CREATE INDEX [IX_InventoryToDrivers_InventoryId] ON [dbo].[InventoryToDrivers] ([InventoryId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260704211037_Initial'
)
BEGIN
    CREATE UNIQUE INDEX [IX_Radios_InventoryId] ON [dbo].[Radios] ([InventoryId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260704211037_Initial'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260704211037_Initial', N'10.0.9');
END;

COMMIT;
GO

BEGIN TRANSACTION;
IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260705201959_CustomSql'
)
BEGIN
    exec (N' 
        CREATE PROCEDURE [dbo].[GetPetName] 
          @carID int, 
          @petName nvarchar(50) output
        AS
        SELECT @petName = PetName from dbo.Inventory where Id = @carID')
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260705201959_CustomSql'
)
BEGIN
    exec (N'
        CREATE FUNCTION [dbo].[udtf_GetCarsForMake] ( @makeId int )
        RETURNS TABLE 
        AS
        RETURN 
          (
            SELECT Id, IsDrivable, DateBuilt, Color, PetName, MakeId, TimeStamp, Display, Price
            FROM Inventory WHERE MakeId = @makeId
          )')
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260705201959_CustomSql'
)
BEGIN
    exec (N'
        CREATE FUNCTION [dbo].[udf_CountOfMakes] ( @makeid int )
        RETURNS int
        AS
        BEGIN
          DECLARE @Result int
          SELECT @Result = COUNT(makeid) FROM dbo.Inventory WHERE makeid = @makeid
          RETURN @Result
        END')
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260705201959_CustomSql'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260705201959_CustomSql', N'10.0.9');
END;

COMMIT;
GO

BEGIN TRANSACTION;
IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260714172252_Temporal'
)
BEGIN
    ALTER TABLE [dbo].[Radios] ADD [ValidFrom] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260714172252_Temporal'
)
BEGIN
    ALTER TABLE [dbo].[Radios] ADD [ValidTo] datetime2 NOT NULL DEFAULT '9999-12-31T23:59:59.9999999';
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260714172252_Temporal'
)
BEGIN
    ALTER TABLE [dbo].[Makes] ADD [ValidFrom] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260714172252_Temporal'
)
BEGIN
    ALTER TABLE [dbo].[Makes] ADD [ValidTo] datetime2 NOT NULL DEFAULT '9999-12-31T23:59:59.9999999';
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260714172252_Temporal'
)
BEGIN
    ALTER TABLE [dbo].[InventoryToDrivers] ADD [ValidFrom] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260714172252_Temporal'
)
BEGIN
    ALTER TABLE [dbo].[InventoryToDrivers] ADD [ValidTo] datetime2 NOT NULL DEFAULT '9999-12-31T23:59:59.9999999';
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260714172252_Temporal'
)
BEGIN
    ALTER TABLE [dbo].[Inventory] ADD [ValidFrom] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260714172252_Temporal'
)
BEGIN
    ALTER TABLE [dbo].[Inventory] ADD [ValidTo] datetime2 NOT NULL DEFAULT '9999-12-31T23:59:59.9999999';
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260714172252_Temporal'
)
BEGIN
    ALTER TABLE [dbo].[Drivers] ADD [ValidFrom] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260714172252_Temporal'
)
BEGIN
    ALTER TABLE [dbo].[Drivers] ADD [ValidTo] datetime2 NOT NULL DEFAULT '9999-12-31T23:59:59.9999999';
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260714172252_Temporal'
)
BEGIN
    EXEC(N'ALTER TABLE [dbo].[Radios] ADD PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])')
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260714172252_Temporal'
)
BEGIN
    ALTER TABLE [dbo].[Radios] ALTER COLUMN [ValidFrom] ADD HIDDEN
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260714172252_Temporal'
)
BEGIN
    ALTER TABLE [dbo].[Radios] ALTER COLUMN [ValidTo] ADD HIDDEN
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260714172252_Temporal'
)
BEGIN
    EXEC(N'ALTER TABLE [dbo].[Makes] ADD PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])')
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260714172252_Temporal'
)
BEGIN
    ALTER TABLE [dbo].[Makes] ALTER COLUMN [ValidFrom] ADD HIDDEN
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260714172252_Temporal'
)
BEGIN
    ALTER TABLE [dbo].[Makes] ALTER COLUMN [ValidTo] ADD HIDDEN
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260714172252_Temporal'
)
BEGIN
    EXEC(N'ALTER TABLE [dbo].[InventoryToDrivers] ADD PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])')
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260714172252_Temporal'
)
BEGIN
    ALTER TABLE [dbo].[InventoryToDrivers] ALTER COLUMN [ValidFrom] ADD HIDDEN
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260714172252_Temporal'
)
BEGIN
    ALTER TABLE [dbo].[InventoryToDrivers] ALTER COLUMN [ValidTo] ADD HIDDEN
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260714172252_Temporal'
)
BEGIN
    EXEC(N'ALTER TABLE [dbo].[Inventory] ADD PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])')
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260714172252_Temporal'
)
BEGIN
    ALTER TABLE [dbo].[Inventory] ALTER COLUMN [ValidFrom] ADD HIDDEN
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260714172252_Temporal'
)
BEGIN
    ALTER TABLE [dbo].[Inventory] ALTER COLUMN [ValidTo] ADD HIDDEN
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260714172252_Temporal'
)
BEGIN
    EXEC(N'ALTER TABLE [dbo].[Drivers] ADD PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])')
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260714172252_Temporal'
)
BEGIN
    ALTER TABLE [dbo].[Drivers] ALTER COLUMN [ValidFrom] ADD HIDDEN
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260714172252_Temporal'
)
BEGIN
    ALTER TABLE [dbo].[Drivers] ALTER COLUMN [ValidTo] ADD HIDDEN
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260714172252_Temporal'
)
BEGIN
    ALTER TABLE [dbo].[Radios] SET (SYSTEM_VERSIONING = ON (HISTORY_TABLE = [dbo].[RadiosAudit]))

END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260714172252_Temporal'
)
BEGIN
    ALTER TABLE [dbo].[Makes] SET (SYSTEM_VERSIONING = ON (HISTORY_TABLE = [dbo].[MakesAudit]))

END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260714172252_Temporal'
)
BEGIN
    ALTER TABLE [dbo].[InventoryToDrivers] SET (SYSTEM_VERSIONING = ON (HISTORY_TABLE = [dbo].[InventoryToDriversAudit]))

END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260714172252_Temporal'
)
BEGIN
    ALTER TABLE [dbo].[Inventory] SET (SYSTEM_VERSIONING = ON (HISTORY_TABLE = [dbo].[InventoryAudit]))

END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260714172252_Temporal'
)
BEGIN
    ALTER TABLE [dbo].[Drivers] SET (SYSTEM_VERSIONING = ON (HISTORY_TABLE = [dbo].[DriversAudit]))

END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260714172252_Temporal'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260714172252_Temporal', N'10.0.9');
END;

COMMIT;
GO

