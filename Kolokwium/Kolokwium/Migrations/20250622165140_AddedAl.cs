using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kolokwium.Migrations
{
    /// <inheritdoc />
    public partial class AddedAl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Nurseries",
                keyColumn: "NurseryId",
                keyValue: 1,
                column: "EstablishedDate",
                value: new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Nurseries",
                keyColumn: "NurseryId",
                keyValue: 2,
                column: "EstablishedDate",
                value: new DateTime(2010, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Seedling_Batches",
                keyColumn: "BatchId",
                keyValue: 1,
                columns: new[] { "Quantity", "ReadyDate", "SownDate" },
                values: new object[] { 100, new DateTime(2016, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Seedling_Batches",
                keyColumn: "BatchId",
                keyValue: 2,
                columns: new[] { "Quantity", "ReadyDate", "SownDate" },
                values: new object[] { 200, new DateTime(2025, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Nurseries",
                keyColumn: "NurseryId",
                keyValue: 1,
                column: "EstablishedDate",
                value: new DateTime(2005, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Nurseries",
                keyColumn: "NurseryId",
                keyValue: 2,
                column: "EstablishedDate",
                value: new DateTime(2010, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Seedling_Batches",
                keyColumn: "BatchId",
                keyValue: 1,
                columns: new[] { "Quantity", "ReadyDate", "SownDate" },
                values: new object[] { 500, new DateTime(2029, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Seedling_Batches",
                keyColumn: "BatchId",
                keyValue: 2,
                columns: new[] { "Quantity", "ReadyDate", "SownDate" },
                values: new object[] { 300, new DateTime(2027, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
