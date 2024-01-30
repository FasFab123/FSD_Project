using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DatingApplication.Server.Migrations
{
    /// <inheritdoc />
    public partial class seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "profile_picture_url",
                table: "DatingAppUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ad2bcf0c-20db-474f-8407-5a6b159518ba", null, "Administrator", "ADMINISTRATOR" },
                    { "bd2bcf0c-20db-474f-8407-5a6b159518bb", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3781efa7-66dc-47f0-860f-e506d04102e4", 0, "b19592aa-675f-4e24-86fa-c00e937d42aa", "admin@localhost.com", false, "Admin", "User", false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEKxSmZuOws3W95x3HT7VvquD66RB6679OQL7d0HWrjw9GH6hs42lG/dK/2oBwUf3GQ==", null, false, "6d4ffa9f-c67b-40d9-b277-17ddc77a13d8", false, "admin@localhost.com" });

            migrationBuilder.InsertData(
                table: "DatingAppUsers",
                columns: new[] { "Id", "Age", "CreatedBy", "DateCreated", "DateUpdated", "Email", "Gender", "Password", "UpdatedBy", "Username", "profile_picture_url" },
                values: new object[,]
                {
                    { 1, 18, "System", new DateTime(2024, 1, 31, 0, 3, 41, 729, DateTimeKind.Local).AddTicks(179), new DateTime(2024, 1, 31, 0, 3, 41, 729, DateTimeKind.Local).AddTicks(190), "Felicia@gmail.com", "Female", "fel123", "System", "Felicia", null },
                    { 2, 21, "System", new DateTime(2024, 1, 31, 0, 3, 41, 729, DateTimeKind.Local).AddTicks(193), new DateTime(2024, 1, 31, 0, 3, 41, 729, DateTimeKind.Local).AddTicks(193), "Jacob@gmail.com", "Male", "Jac123", "System", "Jacob", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ad2bcf0c-20db-474f-8407-5a6b159518ba", "3781efa7-66dc-47f0-860f-e506d04102e4" });

            migrationBuilder.InsertData(
                table: "Matches",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "DatingAppUserId", "DatingAppUserInitiatorId", "DatingAppUserRecieverId", "UpdatedBy" },
                values: new object[] { 1, "System", new DateTime(2024, 1, 31, 0, 3, 41, 729, DateTimeKind.Local).AddTicks(646), new DateTime(2024, 1, 31, 0, 3, 41, 729, DateTimeKind.Local).AddTicks(647), null, 1, 2, "System" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd2bcf0c-20db-474f-8407-5a6b159518bb");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ad2bcf0c-20db-474f-8407-5a6b159518ba", "3781efa7-66dc-47f0-860f-e506d04102e4" });

            migrationBuilder.DeleteData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad2bcf0c-20db-474f-8407-5a6b159518ba");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4");

            migrationBuilder.DeleteData(
                table: "DatingAppUsers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DatingAppUsers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<string>(
                name: "profile_picture_url",
                table: "DatingAppUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
