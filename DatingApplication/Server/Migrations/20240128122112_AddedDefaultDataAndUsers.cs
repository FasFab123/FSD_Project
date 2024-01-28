using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DatingApplication.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddedDefaultDataAndUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                values: new object[] { "3781efa7-66dc-47f0-860f-e506d04102e4", 0, "e052d0aa-4a8d-48e4-a378-89b805edabd9", "admin@localhost.com", false, "Admin", "User", false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEAtgT7As/F0/CAuWcoxxRefs0rDDasBEKRMjF80Jbiqzvd+5Qfk6Wl+dXbDCwaUNEw==", null, false, "c5508b6b-41da-4ce8-a159-cd8821f507a9", false, "admin@localhost.com" });

            migrationBuilder.InsertData(
                table: "DatingAppUsers",
                columns: new[] { "Id", "Age", "CreatedBy", "DateCreated", "DateUpdated", "Email", "Gender", "Password", "UpdatedBy", "Username" },
                values: new object[,]
                {
                    { 1, 18, "System", new DateTime(2024, 1, 28, 20, 21, 11, 720, DateTimeKind.Local).AddTicks(9741), new DateTime(2024, 1, 28, 20, 21, 11, 720, DateTimeKind.Local).AddTicks(9754), "Felicia@gmail.com", "Female", "fel123", "System", "Felicia" },
                    { 2, 21, "System", new DateTime(2024, 1, 28, 20, 21, 11, 720, DateTimeKind.Local).AddTicks(9758), new DateTime(2024, 1, 28, 20, 21, 11, 720, DateTimeKind.Local).AddTicks(9759), "Jacob@gmail.com", "Male", "Jac123", "System", "Jacob" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ad2bcf0c-20db-474f-8407-5a6b159518ba", "3781efa7-66dc-47f0-860f-e506d04102e4" });

            migrationBuilder.InsertData(
                table: "Matches",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "DatingAppUserId", "DatingAppUserInitiatorId", "DatingAppUserRecieverId", "UpdatedBy" },
                values: new object[] { 1, "System", new DateTime(2024, 1, 28, 20, 21, 11, 721, DateTimeKind.Local).AddTicks(310), new DateTime(2024, 1, 28, 20, 21, 11, 721, DateTimeKind.Local).AddTicks(312), null, 1, 2, "System" });
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
        }
    }
}
