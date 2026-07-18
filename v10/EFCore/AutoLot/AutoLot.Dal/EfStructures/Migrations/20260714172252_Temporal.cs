using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoLot.Dal.EfStructures.Migrations
{
    /// <inheritdoc />
    public partial class Temporal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterTable(
                name: "Radios",
                schema: "dbo")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "RadiosAudit")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "dbo")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom");

            migrationBuilder.AlterTable(
                name: "Makes",
                schema: "dbo")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "MakesAudit")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "dbo")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom");

            migrationBuilder.AlterTable(
                name: "InventoryToDrivers",
                schema: "dbo")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "InventoryToDriversAudit")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "dbo")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom");

            migrationBuilder.AlterTable(
                name: "Inventory",
                schema: "dbo")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "InventoryAudit")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "dbo")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom");

            migrationBuilder.AlterTable(
                name: "Drivers",
                schema: "dbo")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "DriversAudit")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "dbo")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom");

            migrationBuilder.AddColumn<DateTime>(
                name: "ValidFrom",
                schema: "dbo",
                table: "Radios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .Annotation("SqlServer:TemporalIsPeriodStartColumn", true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ValidTo",
                schema: "dbo",
                table: "Radios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .Annotation("SqlServer:TemporalIsPeriodEndColumn", true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ValidFrom",
                schema: "dbo",
                table: "Makes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .Annotation("SqlServer:TemporalIsPeriodStartColumn", true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ValidTo",
                schema: "dbo",
                table: "Makes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .Annotation("SqlServer:TemporalIsPeriodEndColumn", true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ValidFrom",
                schema: "dbo",
                table: "InventoryToDrivers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .Annotation("SqlServer:TemporalIsPeriodStartColumn", true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ValidTo",
                schema: "dbo",
                table: "InventoryToDrivers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .Annotation("SqlServer:TemporalIsPeriodEndColumn", true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ValidFrom",
                schema: "dbo",
                table: "Inventory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .Annotation("SqlServer:TemporalIsPeriodStartColumn", true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ValidTo",
                schema: "dbo",
                table: "Inventory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .Annotation("SqlServer:TemporalIsPeriodEndColumn", true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ValidFrom",
                schema: "dbo",
                table: "Drivers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .Annotation("SqlServer:TemporalIsPeriodStartColumn", true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ValidTo",
                schema: "dbo",
                table: "Drivers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .Annotation("SqlServer:TemporalIsPeriodEndColumn", true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValidFrom",
                schema: "dbo",
                table: "Radios")
                .Annotation("SqlServer:TemporalIsPeriodStartColumn", true);

            migrationBuilder.DropColumn(
                name: "ValidTo",
                schema: "dbo",
                table: "Radios")
                .Annotation("SqlServer:TemporalIsPeriodEndColumn", true);

            migrationBuilder.DropColumn(
                name: "ValidFrom",
                schema: "dbo",
                table: "Makes")
                .Annotation("SqlServer:TemporalIsPeriodStartColumn", true);

            migrationBuilder.DropColumn(
                name: "ValidTo",
                schema: "dbo",
                table: "Makes")
                .Annotation("SqlServer:TemporalIsPeriodEndColumn", true);

            migrationBuilder.DropColumn(
                name: "ValidFrom",
                schema: "dbo",
                table: "InventoryToDrivers")
                .Annotation("SqlServer:TemporalIsPeriodStartColumn", true);

            migrationBuilder.DropColumn(
                name: "ValidTo",
                schema: "dbo",
                table: "InventoryToDrivers")
                .Annotation("SqlServer:TemporalIsPeriodEndColumn", true);

            migrationBuilder.DropColumn(
                name: "ValidFrom",
                schema: "dbo",
                table: "Inventory")
                .Annotation("SqlServer:TemporalIsPeriodStartColumn", true);

            migrationBuilder.DropColumn(
                name: "ValidTo",
                schema: "dbo",
                table: "Inventory")
                .Annotation("SqlServer:TemporalIsPeriodEndColumn", true);

            migrationBuilder.DropColumn(
                name: "ValidFrom",
                schema: "dbo",
                table: "Drivers")
                .Annotation("SqlServer:TemporalIsPeriodStartColumn", true);

            migrationBuilder.DropColumn(
                name: "ValidTo",
                schema: "dbo",
                table: "Drivers")
                .Annotation("SqlServer:TemporalIsPeriodEndColumn", true);

            migrationBuilder.AlterTable(
                name: "Radios",
                schema: "dbo")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "RadiosAudit")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", "dbo")
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom");

            migrationBuilder.AlterTable(
                name: "Makes",
                schema: "dbo")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "MakesAudit")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", "dbo")
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom");

            migrationBuilder.AlterTable(
                name: "InventoryToDrivers",
                schema: "dbo")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "InventoryToDriversAudit")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", "dbo")
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom");

            migrationBuilder.AlterTable(
                name: "Inventory",
                schema: "dbo")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "InventoryAudit")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", "dbo")
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom");

            migrationBuilder.AlterTable(
                name: "Drivers",
                schema: "dbo")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "DriversAudit")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", "dbo")
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom");
        }
    }
}
