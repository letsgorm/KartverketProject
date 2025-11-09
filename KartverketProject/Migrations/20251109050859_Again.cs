using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KartverketProject.Migrations
{
    /// <inheritdoc />
    public partial class Again : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b72eec54-55d3-468d-94d0-5023a0af7469", "4351701f-2d09-4d3c-998e-d7a4ce750882" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4f45df02-beed-417f-b31f-70986edfd3c2", "8835e129-c1aa-48b0-8a01-8743e016119f" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c544ddbc-6361-40d9-bb5f-78a2cfc02a58", "e0e945e9-25c4-42b2-bf70-2dd107f1ac10" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4f45df02-beed-417f-b31f-70986edfd3c2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b72eec54-55d3-468d-94d0-5023a0af7469");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c544ddbc-6361-40d9-bb5f-78a2cfc02a58");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4351701f-2d09-4d3c-998e-d7a4ce750882");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8835e129-c1aa-48b0-8a01-8743e016119f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e0e945e9-25c4-42b2-bf70-2dd107f1ac10");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "125598d6-2d34-4ead-9f4e-3e3d96b3e385", "125598d6-2d34-4ead-9f4e-3e3d96b3e385", "reviewer", "REVIEWER" },
                    { "850fbe7f-5c70-4e45-a290-02a7817b2fe7", "850fbe7f-5c70-4e45-a290-02a7817b2fe7", "user", "USER" },
                    { "f895355f-4ddb-4a37-8dc0-de9ee7369adb", "f895355f-4ddb-4a37-8dc0-de9ee7369adb", "admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Active", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "06973bec-c1da-4966-ab99-097087f1f52a", 0, true, "969b9d88-a33f-4b16-8b8a-2361b12b6ba6", "reviewer@gorm.no", false, "Jane", "Doe", false, null, "REVIEWER@GORM.NO", "REVIEWER@GORM.NO", "AQAAAAIAAYagAAAAENZ10VCqLnd/rZgt/pOr1RbdHcwQOR4WxO4QURtXO8p2O08oVLRhBLp2jTBC7LowQQ==", null, false, "cb5b4cb1-6a56-4714-a614-bc3c0727a99d", false, "reviewer@gorm.no" },
                    { "14055a74-98b2-4266-bdaf-a507e715d2c5", 0, true, "bfd51045-e683-4756-9a2b-160a19066d75", "user@gorm.no", false, "Bob", "Smith", false, null, "USER@GORM.NO", "USER@GORM.NO", "AQAAAAIAAYagAAAAEGsCIOhDdhkvlIqyyhiRYxZKOOIPdsLrlpIbDBoYbg/XLy1LaQfF3iMseEB78zwwMA==", null, false, "c5779abc-f804-40fe-8112-d2ebb4ea85c8", false, "user@gorm.no" },
                    { "c3178c80-2c9b-4c3a-a18c-19ecdda97962", 0, true, "ffc75c36-8569-4fd8-a09f-d92c3c7cb0a3", "admin@gorm.no", false, "John", "Doe", false, null, "ADMIN@GORM.NO", "ADMIN@GORM.NO", "AQAAAAIAAYagAAAAEOnuN5J7fOkScxJbmZyhYjEAG3QvEw2bTMaBRjhLAyJN7pnhHdm0dHmTmbAMcFjZMg==", null, false, "8c2029d4-87d8-4b3c-be58-e661a0cf906b", false, "admin@gorm.no" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "125598d6-2d34-4ead-9f4e-3e3d96b3e385", "06973bec-c1da-4966-ab99-097087f1f52a" },
                    { "850fbe7f-5c70-4e45-a290-02a7817b2fe7", "14055a74-98b2-4266-bdaf-a507e715d2c5" },
                    { "f895355f-4ddb-4a37-8dc0-de9ee7369adb", "c3178c80-2c9b-4c3a-a18c-19ecdda97962" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "125598d6-2d34-4ead-9f4e-3e3d96b3e385", "06973bec-c1da-4966-ab99-097087f1f52a" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "850fbe7f-5c70-4e45-a290-02a7817b2fe7", "14055a74-98b2-4266-bdaf-a507e715d2c5" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f895355f-4ddb-4a37-8dc0-de9ee7369adb", "c3178c80-2c9b-4c3a-a18c-19ecdda97962" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "125598d6-2d34-4ead-9f4e-3e3d96b3e385");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "850fbe7f-5c70-4e45-a290-02a7817b2fe7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f895355f-4ddb-4a37-8dc0-de9ee7369adb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "06973bec-c1da-4966-ab99-097087f1f52a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "14055a74-98b2-4266-bdaf-a507e715d2c5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c3178c80-2c9b-4c3a-a18c-19ecdda97962");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4f45df02-beed-417f-b31f-70986edfd3c2", "4f45df02-beed-417f-b31f-70986edfd3c2", "reviewer", "REVIEWER" },
                    { "b72eec54-55d3-468d-94d0-5023a0af7469", "b72eec54-55d3-468d-94d0-5023a0af7469", "user", "USER" },
                    { "c544ddbc-6361-40d9-bb5f-78a2cfc02a58", "c544ddbc-6361-40d9-bb5f-78a2cfc02a58", "admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Active", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "4351701f-2d09-4d3c-998e-d7a4ce750882", 0, true, "e42047d3-71ed-4892-b621-a691543137ac", "user@gorm.no", false, "Bob", "Smith", false, null, "USER@GORM.NO", "USER@GORM.NO", "AQAAAAIAAYagAAAAEOW8BL+lsvX6kePKy71HoR8ZFOjL9HaT6GVdqCcAQmMKKHQaEW4Q0DDSREfnc7kAQg==", null, false, "607d5606-82fd-4852-ae64-3ee3d134ce5d", false, "user@gorm.no" },
                    { "8835e129-c1aa-48b0-8a01-8743e016119f", 0, true, "bf1bee17-a880-4049-8e7a-2e91133b6eee", "reviewer@gorm.no", false, "Jane", "Doe", false, null, "REVIEWER@GORM.NO", "REVIEWER@GORM.NO", "AQAAAAIAAYagAAAAELVGTI+YKlXBbaTZYRYERfVlki089Hueh78THsDGswHba1Kpe5vMPU0IEh9aVG9cQA==", null, false, "cd68f17e-e75c-4490-aead-9052e15cbcb5", false, "reviewer@gorm.no" },
                    { "e0e945e9-25c4-42b2-bf70-2dd107f1ac10", 0, true, "827dc74a-d7de-4c5e-ae58-fe50b373a964", "admin@gorm.no", false, "John", "Doe", false, null, "ADMIN@GORM.NO", "ADMIN@GORM.NO", "AQAAAAIAAYagAAAAEGOax5+IVIDQDRK923nHd/ktAjpMEaL6iL8DYlON+6gMJ0ESCC71aVmfB6rlCnh5uQ==", null, false, "9f830e97-ce45-4771-9b68-110e648eb9a1", false, "admin@gorm.no" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "b72eec54-55d3-468d-94d0-5023a0af7469", "4351701f-2d09-4d3c-998e-d7a4ce750882" },
                    { "4f45df02-beed-417f-b31f-70986edfd3c2", "8835e129-c1aa-48b0-8a01-8743e016119f" },
                    { "c544ddbc-6361-40d9-bb5f-78a2cfc02a58", "e0e945e9-25c4-42b2-bf70-2dd107f1ac10" }
                });
        }
    }
}
