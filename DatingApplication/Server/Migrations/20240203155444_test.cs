using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatingApplication.Server.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_DatingAppUsers_DatingAppUserRecieverId",
                table: "Matches");

            migrationBuilder.AlterColumn<int>(
                name: "DatingAppUserRecieverId",
                table: "Matches",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "05be037a-a64d-45d6-b325-3c9e89ee569f", "AQAAAAIAAYagAAAAEBbP975Gf4S01JWqewzgF80GuWoa7YULgO9fpDBu8ha4sBnh77Cv8u6GQE2djr93uQ==", "b5f8208a-63cc-46ce-85f7-f4d660806c9f" });

            migrationBuilder.UpdateData(
                table: "DatingAppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2024, 2, 3, 23, 54, 44, 545, DateTimeKind.Local).AddTicks(8248), new DateTime(2024, 2, 3, 23, 54, 44, 545, DateTimeKind.Local).AddTicks(8259) });

            migrationBuilder.UpdateData(
                table: "DatingAppUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2024, 2, 3, 23, 54, 44, 545, DateTimeKind.Local).AddTicks(8263), new DateTime(2024, 2, 3, 23, 54, 44, 545, DateTimeKind.Local).AddTicks(8263) });

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2024, 2, 3, 23, 54, 44, 545, DateTimeKind.Local).AddTicks(8717), new DateTime(2024, 2, 3, 23, 54, 44, 545, DateTimeKind.Local).AddTicks(8718) });

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_DatingAppUsers_DatingAppUserRecieverId",
                table: "Matches",
                column: "DatingAppUserRecieverId",
                principalTable: "DatingAppUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_DatingAppUsers_DatingAppUserRecieverId",
                table: "Matches");

            migrationBuilder.AlterColumn<int>(
                name: "DatingAppUserRecieverId",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "14e60535-c992-4c82-9b55-ff98d374257b", "AQAAAAIAAYagAAAAEMKjoj0+5Rsnz7KreU+2aTeyVq/g/YDDGagwdeLIOASh9qTQRR4JpomM0ilYVMEpHA==", "51e2bacc-4309-42ed-b13a-4f5522bd3091" });

            migrationBuilder.UpdateData(
                table: "DatingAppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2024, 2, 3, 23, 51, 28, 370, DateTimeKind.Local).AddTicks(1321), new DateTime(2024, 2, 3, 23, 51, 28, 370, DateTimeKind.Local).AddTicks(1334) });

            migrationBuilder.UpdateData(
                table: "DatingAppUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2024, 2, 3, 23, 51, 28, 370, DateTimeKind.Local).AddTicks(1336), new DateTime(2024, 2, 3, 23, 51, 28, 370, DateTimeKind.Local).AddTicks(1337) });

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2024, 2, 3, 23, 51, 28, 370, DateTimeKind.Local).AddTicks(1806), new DateTime(2024, 2, 3, 23, 51, 28, 370, DateTimeKind.Local).AddTicks(1806) });

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_DatingAppUsers_DatingAppUserRecieverId",
                table: "Matches",
                column: "DatingAppUserRecieverId",
                principalTable: "DatingAppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
