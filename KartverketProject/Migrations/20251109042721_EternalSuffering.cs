using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KartverketProject.Migrations
{
    /// <inheritdoc />
    public partial class EternalSuffering : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8b2b3f97-7331-411f-9b17-0baf993a3673", "c326a3b1-4953-44fe-b546-4975748ee478" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bd0d9b4c-46ea-4227-8c34-4088d0daaac7", "e27279e6-066a-492b-8176-c0ae303d4c4a" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d807e9ed-4819-4ff8-abd4-f2320e13ece9", "e6c65987-6881-4ce6-86c5-557075a7ef01" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8b2b3f97-7331-411f-9b17-0baf993a3673");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd0d9b4c-46ea-4227-8c34-4088d0daaac7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d807e9ed-4819-4ff8-abd4-f2320e13ece9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c326a3b1-4953-44fe-b546-4975748ee478");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e27279e6-066a-492b-8176-c0ae303d4c4a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e6c65987-6881-4ce6-86c5-557075a7ef01");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "8b2b3f97-7331-411f-9b17-0baf993a3673", "8b2b3f97-7331-411f-9b17-0baf993a3673", "admin", "ADMIN" },
                    { "bd0d9b4c-46ea-4227-8c34-4088d0daaac7", "bd0d9b4c-46ea-4227-8c34-4088d0daaac7", "user", "USER" },
                    { "d807e9ed-4819-4ff8-abd4-f2320e13ece9", "d807e9ed-4819-4ff8-abd4-f2320e13ece9", "reviewer", "REVIEWER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Active", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "c326a3b1-4953-44fe-b546-4975748ee478", 0, true, "1c612576-5c2f-4bd3-9144-e2adedb435c5", "admin@gorm.no", false, "John", "Doe", false, null, "ADMIN@GORM.NO", "ADMIN", "AQAAAAIAAYagAAAAEC/m9CX6/C/sAtQ1MB96w/mCfmJKl94YFHUDXO+0Qo5y2Nbw3cchSR5jlwnBSlfsbA==", null, false, "d72cc8a4-609c-4361-994f-5ae1890c1e34", false, "admin" },
                    { "e27279e6-066a-492b-8176-c0ae303d4c4a", 0, true, "3aad8c20-feaa-48c2-8031-57622a02a682", "user@gorm.no", false, "Bob", "Smith", false, null, "USER@GORM.NO", "USER", "AQAAAAIAAYagAAAAEKdaDLDKOb13XtTY8qqLquAQFOjCfjkzwFdrdAjZEwYvb/ARyIUjbkgCafaXXrGvIQ==", null, false, "bebad0c0-09f0-4ab4-9e93-df4d51e2060e", false, "user" },
                    { "e6c65987-6881-4ce6-86c5-557075a7ef01", 0, true, "8ef63ed4-0489-4ab2-9116-95a53a86953d", "reviewer@gorm.no", false, "Jane", "Doe", false, null, "REVIEWER@GORM.NO", "REVIEWER", "AQAAAAIAAYagAAAAEPMynmI6HKtcKkHPk26+3qFIUAr8ODsg9MYKouIE+hhvbeiIZT52yy0Tno6V3ZyFtw==", null, false, "8674e706-bd7c-4f73-b117-ccc4df64c93c", false, "reviewer" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "8b2b3f97-7331-411f-9b17-0baf993a3673", "c326a3b1-4953-44fe-b546-4975748ee478" },
                    { "bd0d9b4c-46ea-4227-8c34-4088d0daaac7", "e27279e6-066a-492b-8176-c0ae303d4c4a" },
                    { "d807e9ed-4819-4ff8-abd4-f2320e13ece9", "e6c65987-6881-4ce6-86c5-557075a7ef01" }
                });
        }
    }
}
