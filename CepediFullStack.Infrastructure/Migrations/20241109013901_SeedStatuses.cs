using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CepediFullStack.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedStatuses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("126a33b9-ec50-4a5a-8049-b32db8830d5d"), new DateTimeOffset(new DateTime(2024, 11, 9, 1, 39, 1, 176, DateTimeKind.Unspecified).AddTicks(4649), new TimeSpan(0, 0, 0, 0, 0)), null, "Aprovado", null },
                    { new Guid("4bb6f96a-f3a8-4682-98e1-f6664b13e513"), new DateTimeOffset(new DateTime(2024, 11, 9, 1, 39, 1, 176, DateTimeKind.Unspecified).AddTicks(4646), new TimeSpan(0, 0, 0, 0, 0)), null, "Pendente", null },
                    { new Guid("c6d5a084-c3b7-4245-9641-31ab84d1cb12"), new DateTimeOffset(new DateTime(2024, 11, 9, 1, 39, 1, 176, DateTimeKind.Unspecified).AddTicks(4651), new TimeSpan(0, 0, 0, 0, 0)), null, "Entregue", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("126a33b9-ec50-4a5a-8049-b32db8830d5d"));

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("4bb6f96a-f3a8-4682-98e1-f6664b13e513"));

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("c6d5a084-c3b7-4245-9641-31ab84d1cb12"));
        }
    }
}
