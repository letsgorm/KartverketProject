using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KartverketProject.Migrations
{
    /// <inheritdoc />
    public partial class DoesItBreak : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0c4abffe-e542-42df-93ce-b52088163b42", "609e2f47-1d3e-4c0d-833f-472ab0bc80e6" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1d1e3dc2-8b05-4d5c-bb2e-757be34153e0", "6155a463-dd5f-4b4e-84e0-eaf342405f26" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ee335a58-4c0c-481e-9d35-f65e98177375", "f8daf892-95fa-43b3-bb10-bccb8658636f" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0c4abffe-e542-42df-93ce-b52088163b42");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1d1e3dc2-8b05-4d5c-bb2e-757be34153e0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee335a58-4c0c-481e-9d35-f65e98177375");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "609e2f47-1d3e-4c0d-833f-472ab0bc80e6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6155a463-dd5f-4b4e-84e0-eaf342405f26");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f8daf892-95fa-43b3-bb10-bccb8658636f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3960ead6-fd90-45a8-befd-553274ae75eb", "3960ead6-fd90-45a8-befd-553274ae75eb", "admin", "ADMIN" },
                    { "bdc96db9-c30a-4ab6-8ede-d51eae1515fb", "bdc96db9-c30a-4ab6-8ede-d51eae1515fb", "reviewer", "REVIEWER" },
                    { "d5433837-8221-4cf0-919c-60ea210e3285", "d5433837-8221-4cf0-919c-60ea210e3285", "user", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Active", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "ObstacleId", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "11b152a5-3487-43a7-b296-13834de767b8", 0, true, "b87d0062-7f14-4a4e-8a9a-8d7be755f99b", "reviewer@gorm.no", false, "Jane", "Doe", false, null, "REVIEWER@GORM.NO", "REVIEWER@GORM.NO", null, "AQAAAAIAAYagAAAAEJ2MtEwlRUFW7pyUj95imiaft0kFZl0m2GxVCLZFrHYUrrlIWAvMvcMBnFkHspnPKA==", null, false, "c9aef6e9-c9e9-4364-8b6a-3d124178cc92", false, "reviewer@gorm.no" },
                    { "1960dcea-fb8b-45d7-b793-8c66016dc206", 0, true, "34c1987d-f040-4b67-ad0f-72d762370fc2", "user@gorm.no", false, "Bob", "Smith", false, null, "USER@GORM.NO", "USER@GORM.NO", null, "AQAAAAIAAYagAAAAEOS0A98ecL3v3E7fi8w2zupfGMZeuvP2E3z+Rga5FmIC7uNrOp9p1S8o02bGbMGq3w==", null, false, "51a71a2b-7b72-454c-9c94-dd8697460a38", false, "user@gorm.no" },
                    { "dc969c07-8c9f-4d13-83cf-9652cb2f2f6a", 0, true, "7133b2f5-d9e1-4bc9-a431-b8b2de7e0327", "admin@gorm.no", false, "John", "Doe", false, null, "ADMIN@GORM.NO", "ADMIN@GORM.NO", null, "AQAAAAIAAYagAAAAEGHsPIM3djXJi6cv47IyweGHxw3aW38vTdhXF/yV8rs3dXQsLbvK1iQG3YNec5AW5A==", null, false, "d1ddc0a5-6760-440d-afbc-93e6b789364e", false, "admin@gorm.no" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "bdc96db9-c30a-4ab6-8ede-d51eae1515fb", "11b152a5-3487-43a7-b296-13834de767b8" },
                    { "d5433837-8221-4cf0-919c-60ea210e3285", "1960dcea-fb8b-45d7-b793-8c66016dc206" },
                    { "3960ead6-fd90-45a8-befd-553274ae75eb", "dc969c07-8c9f-4d13-83cf-9652cb2f2f6a" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bdc96db9-c30a-4ab6-8ede-d51eae1515fb", "11b152a5-3487-43a7-b296-13834de767b8" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d5433837-8221-4cf0-919c-60ea210e3285", "1960dcea-fb8b-45d7-b793-8c66016dc206" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3960ead6-fd90-45a8-befd-553274ae75eb", "dc969c07-8c9f-4d13-83cf-9652cb2f2f6a" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3960ead6-fd90-45a8-befd-553274ae75eb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bdc96db9-c30a-4ab6-8ede-d51eae1515fb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5433837-8221-4cf0-919c-60ea210e3285");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11b152a5-3487-43a7-b296-13834de767b8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1960dcea-fb8b-45d7-b793-8c66016dc206");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dc969c07-8c9f-4d13-83cf-9652cb2f2f6a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0c4abffe-e542-42df-93ce-b52088163b42", "0c4abffe-e542-42df-93ce-b52088163b42", "user", "USER" },
                    { "1d1e3dc2-8b05-4d5c-bb2e-757be34153e0", "1d1e3dc2-8b05-4d5c-bb2e-757be34153e0", "reviewer", "REVIEWER" },
                    { "ee335a58-4c0c-481e-9d35-f65e98177375", "ee335a58-4c0c-481e-9d35-f65e98177375", "admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Active", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "ObstacleId", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "609e2f47-1d3e-4c0d-833f-472ab0bc80e6", 0, true, "c90c12cb-72b8-422c-9f2f-b143d6d14f7b", "user@gorm.no", false, "Bob", "Smith", false, null, "USER@GORM.NO", "USER@GORM.NO", null, "AQAAAAIAAYagAAAAEARHW+BtWbUAyx62fNfw3NtcuxKynm7SQOy92coLRJ32F1b5O5Z1szIyhNzZ+TU53Q==", null, false, "392bff9a-fa37-4484-9883-06b6d54111de", false, "user@gorm.no" },
                    { "6155a463-dd5f-4b4e-84e0-eaf342405f26", 0, true, "c9470ef7-7ee3-4ee2-8903-0f9994208a67", "reviewer@gorm.no", false, "Jane", "Doe", false, null, "REVIEWER@GORM.NO", "REVIEWER@GORM.NO", null, "AQAAAAIAAYagAAAAENkjFINx4Dz6ZuzMKAJ2aQQp6sKNle9+MfMgHXYNNbtFaUoFQNM0Q7zyrb41qOVvXA==", null, false, "966e0daf-2a52-4573-a3a7-ebc9f764bbc5", false, "reviewer@gorm.no" },
                    { "f8daf892-95fa-43b3-bb10-bccb8658636f", 0, true, "5f96dd80-7b33-468d-837b-f1dabc23edeb", "admin@gorm.no", false, "John", "Doe", false, null, "ADMIN@GORM.NO", "ADMIN@GORM.NO", null, "AQAAAAIAAYagAAAAEHCAS5pGrGzIMWD4ChFmDDV9Kr7QsKi2MzA9h9RdCvHdZrpEpyr8vmc99AumvXtIBw==", null, false, "b4059e46-eced-4613-8c55-283daf05fa3c", false, "admin@gorm.no" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "0c4abffe-e542-42df-93ce-b52088163b42", "609e2f47-1d3e-4c0d-833f-472ab0bc80e6" },
                    { "1d1e3dc2-8b05-4d5c-bb2e-757be34153e0", "6155a463-dd5f-4b4e-84e0-eaf342405f26" },
                    { "ee335a58-4c0c-481e-9d35-f65e98177375", "f8daf892-95fa-43b3-bb10-bccb8658636f" }
                });
        }
    }
}
