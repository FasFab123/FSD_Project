using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatingApplication.Server.Migrations
{
    /// <inheritdoc />
    public partial class register : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4",
                columns: new[] { "Age", "ConcurrencyStamp", "Gender", "PasswordHash", "SecurityStamp" },
                values: new object[] { 0, "d9d160a4-3fcb-4216-bc0b-f9c64cb882e4", null, "AQAAAAIAAYagAAAAECi9FfpcBvu7BGayp4sa/wOaVme0hRhNhk2SVyO+IiZT5hDArH0U3OfaLvhSjIE1sQ==", "bf449c74-155e-4649-b569-1d6072a87f64" });

            migrationBuilder.UpdateData(
                table: "DatingAppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2024, 2, 4, 18, 33, 0, 304, DateTimeKind.Local).AddTicks(869), new DateTime(2024, 2, 4, 18, 33, 0, 304, DateTimeKind.Local).AddTicks(882) });

            migrationBuilder.UpdateData(
                table: "DatingAppUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2024, 2, 4, 18, 33, 0, 304, DateTimeKind.Local).AddTicks(886), new DateTime(2024, 2, 4, 18, 33, 0, 304, DateTimeKind.Local).AddTicks(887) });

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2024, 2, 4, 18, 33, 0, 304, DateTimeKind.Local).AddTicks(1539), new DateTime(2024, 2, 4, 18, 33, 0, 304, DateTimeKind.Local).AddTicks(1541) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "62aa577c-f793-499c-890f-0ee0c08d6b78", "AQAAAAIAAYagAAAAEDTuOWbtQHcSN3kFCHXU3AJZqaGUa9m4dc3izxStx/hKP6L2p2wDiuxYfrpiwx5ssw==", "8ba61016-1b37-4b78-bb1f-89fec40c962a" });

            migrationBuilder.UpdateData(
                table: "DatingAppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2024, 2, 4, 16, 56, 49, 641, DateTimeKind.Local).AddTicks(6481), new DateTime(2024, 2, 4, 16, 56, 49, 641, DateTimeKind.Local).AddTicks(6496) });

            migrationBuilder.UpdateData(
                table: "DatingAppUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2024, 2, 4, 16, 56, 49, 641, DateTimeKind.Local).AddTicks(6501), new DateTime(2024, 2, 4, 16, 56, 49, 641, DateTimeKind.Local).AddTicks(6502) });

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2024, 2, 4, 16, 56, 49, 641, DateTimeKind.Local).AddTicks(7409), new DateTime(2024, 2, 4, 16, 56, 49, 641, DateTimeKind.Local).AddTicks(7411) });
        }
    }
}
