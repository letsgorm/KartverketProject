using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KartverketProject.Migrations
{
    /// <inheritdoc />
    public partial class FixGuid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "23c2e4b5-df62-43fc-831b-22136ed83684", "1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8d436dab-628d-4da2-82b5-53863f0f558c", "2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "08425d60-cadd-4254-9acd-388f9feee44a", "3" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "08425d60-cadd-4254-9acd-388f9feee44a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "23c2e4b5-df62-43fc-831b-22136ed83684");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8d436dab-628d-4da2-82b5-53863f0f558c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "08425d60-cadd-4254-9acd-388f9feee44a", "08425d60-cadd-4254-9acd-388f9feee44a", "user", "USER" },
                    { "23c2e4b5-df62-43fc-831b-22136ed83684", "23c2e4b5-df62-43fc-831b-22136ed83684", "admin", "ADMIN" },
                    { "8d436dab-628d-4da2-82b5-53863f0f558c", "8d436dab-628d-4da2-82b5-53863f0f558c", "reviewer", "REVIEWER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Active", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, true, "942e219f-4101-492f-95d2-8f084328b738", "admin@gorm.no", false, "John", "Doe", false, null, "ADMIN@GORM.NO", "ADMIN@GORM.NO", "AQAAAAIAAYagAAAAEHK7hSrjSnhCZKkl3M0Tea9qdf8GVAndMmbZlQnicqBiHfxKh2mxnU4R4ltm+MKYaQ==", null, false, "c3b0301a-46e1-43fd-a04f-1e8c97a19d45", false, "admin@gorm.no" },
                    { "2", 0, true, "eb8bf9cb-3ed6-4c2d-a656-1562aa367979", "reviewer@gorm.no", false, "Jane", "Doe", false, null, "REVIEWER@GORM.NO", "REVIEWER@GORM.NO", "AQAAAAIAAYagAAAAEK9ILQmBAb4ZOEAFYMQg6nmfPaAVE3O725Eb9URw62DLvz/ND3lqvzJ2e4j362ILRg==", null, false, "2b338268-17e0-4c1c-a35f-1e8ad481fde8", false, "reviewer@gorm.no" },
                    { "3", 0, true, "f161c33e-6498-4918-8049-366b25e9aab9", "user@gorm.no", false, "Bob", "Smith", false, null, "USER@GORM.NO", "USER@GORM.NO", "AQAAAAIAAYagAAAAEKiswwW+cJP2KJq3WR1DkakwOv1O4FHttB64f+/J9cJ18SGZXblGqHkTeN3Pdb1NyA==", null, false, "aae48ad0-4baa-4ac1-9278-f158ca25db18", false, "user@gorm.no" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "23c2e4b5-df62-43fc-831b-22136ed83684", "1" },
                    { "8d436dab-628d-4da2-82b5-53863f0f558c", "2" },
                    { "08425d60-cadd-4254-9acd-388f9feee44a", "3" }
                });
        }
    }
}
