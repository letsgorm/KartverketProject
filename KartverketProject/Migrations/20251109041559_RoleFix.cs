using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KartverketProject.Migrations
{
    /// <inheritdoc />
    public partial class RoleFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "89578426-a858-4b61-bad1-1d732e38e6d1", "0bc5e074-efff-4996-a268-fd2a69f8bba5" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5cf4e46d-19d6-4f70-ac4a-b64be1df8473", "799673c2-7bcc-4d11-ad1f-b8688dd76b8d" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2575cf3e-3c0b-49c3-9320-86cfed7e8cde", "8ea604ed-9171-41f0-b120-355587373608" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2575cf3e-3c0b-49c3-9320-86cfed7e8cde");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5cf4e46d-19d6-4f70-ac4a-b64be1df8473");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "89578426-a858-4b61-bad1-1d732e38e6d1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0bc5e074-efff-4996-a268-fd2a69f8bba5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "799673c2-7bcc-4d11-ad1f-b8688dd76b8d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8ea604ed-9171-41f0-b120-355587373608");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "2575cf3e-3c0b-49c3-9320-86cfed7e8cde", "2575cf3e-3c0b-49c3-9320-86cfed7e8cde", "reviewer", "REVIEWER" },
                    { "5cf4e46d-19d6-4f70-ac4a-b64be1df8473", "5cf4e46d-19d6-4f70-ac4a-b64be1df8473", "admin", "ADMIN" },
                    { "89578426-a858-4b61-bad1-1d732e38e6d1", "89578426-a858-4b61-bad1-1d732e38e6d1", "user", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Active", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0bc5e074-efff-4996-a268-fd2a69f8bba5", 0, true, "4761dda5-c378-4834-99fc-85ca4ee55d3e", "user@gorm.no", false, "Bob", "Smith", false, null, "USER@GORM.NO", "USER@GORM.NO", "AQAAAAIAAYagAAAAELLV+mpQQTif/n3teGoqPO5ZTVJbmfvGb5gU9xsFiN7PywPU/VjYyShUzZKgqslQcQ==", null, false, "aced0b06-0a25-46ce-a771-961b5135261c", false, "user@gorm.no" },
                    { "799673c2-7bcc-4d11-ad1f-b8688dd76b8d", 0, true, "9e1a9bd6-793f-4fc3-ab70-052051729ca8", "admin@gorm.no", false, "John", "Doe", false, null, "ADMIN@GORM.NO", "ADMIN@GORM.NO", "AQAAAAIAAYagAAAAENoAqm4Grb7ufYUw4ZAWL+4M2w6fKHcKozu01+ehDeA7S2cdt0lwX5g5Y7u6oPrqfA==", null, false, "9e5e0b5b-36f9-4116-832c-772a22837378", false, "admin@gorm.no" },
                    { "8ea604ed-9171-41f0-b120-355587373608", 0, true, "ee3b8df7-35b8-4466-8c5a-dc71624de307", "reviewer@gorm.no", false, "Jane", "Doe", false, null, "REVIEWER@GORM.NO", "REVIEWER@GORM.NO", "AQAAAAIAAYagAAAAEGEYPjTHD0MR5OXBSp2bo7JKqPjyTdPc7RfLwbDCw/hyWUAZBZgNEDgR4N/vjLE/Vw==", null, false, "c84b73e3-3450-40fc-acf1-e5a57a174317", false, "reviewer@gorm.no" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "89578426-a858-4b61-bad1-1d732e38e6d1", "0bc5e074-efff-4996-a268-fd2a69f8bba5" },
                    { "5cf4e46d-19d6-4f70-ac4a-b64be1df8473", "799673c2-7bcc-4d11-ad1f-b8688dd76b8d" },
                    { "2575cf3e-3c0b-49c3-9320-86cfed7e8cde", "8ea604ed-9171-41f0-b120-355587373608" }
                });
        }
    }
}
