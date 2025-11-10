using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KartverketProject.Migrations
{
    /// <inheritdoc />
    public partial class reason : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReportReason",
                table: "Report",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "33333333-3333-3333-3333-333333333333",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "173706c5-e926-4ac9-a25b-e0a3e2592f3f", "AQAAAAIAAYagAAAAEGd9HWyfu0PAxooXo2kS/ahxI30wUs/zYlytezF1SeTXtOVwU9Y9BySo+7tbXny22A==", "a613b538-9378-433f-8220-059b025f20b2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "44444444-4444-4444-4444-444444444444",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "69f88824-1dd8-4956-bbc6-e8876191d382", "AQAAAAIAAYagAAAAEPlwzx5XQp9IDHgnIiBHgqUk76vgBQqkBORFN+CU2AOhsgcHaCdAhw6VC9sI29CNJg==", "85a6bf58-0bcb-4242-ba6f-5e8abe042a59" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "66666666-6666-6666-6666-666666666666",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ea90fac5-4a26-497a-963c-3b73205b83ba", "AQAAAAIAAYagAAAAEFEPOO9Yd6DXr0yhHv5/kTgxF4sbjhrrSwrsiJtebJEcBGOjKBK7EKWE0LNX5om18Q==", "514be756-950d-439f-8563-f2d3e316efab" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "77777777-7777-7777-7777-777777777777",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8bcbaee4-e3aa-4528-9520-d2665715d637", "AQAAAAIAAYagAAAAEPkfSCJZfL2PnaTRYxglHKV78N/w+55NOBOCqIaQGBGES76x14ANkQmoGh8V1H6y/g==", "2445d66a-2482-4333-99da-7b9c793b81dc" });

            migrationBuilder.UpdateData(
                table: "Report",
                keyColumn: "ReportId",
                keyValue: 1,
                column: "ReportReason",
                value: "This is the reason.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReportReason",
                table: "Report");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "33333333-3333-3333-3333-333333333333",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dfd4580e-6f30-41d9-b5b3-6f781f965624", "AQAAAAIAAYagAAAAEF/0bgDE04DfemwTjDL4WazaN8Zpie8Q4u/i3L1X8Z+we8fpZj5/p481HXqTAkVK/A==", "0e323b92-fd79-483f-a0ed-8df4a1a1940a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "44444444-4444-4444-4444-444444444444",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6135a361-e97b-437a-a396-3c5449f4680c", "AQAAAAIAAYagAAAAEKauiXMRdO9VceAduiXvlfM2Whi5Vu9Tz1hjzmSMfBJju0K1SkUTh0qtO1ypXuP/+Q==", "2439cc62-50cf-4608-87da-cbc828f2cf81" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "66666666-6666-6666-6666-666666666666",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "96792f40-7d1b-46b0-826c-51b7f890c574", "AQAAAAIAAYagAAAAEA2Yq3NkB6y9QttFdHT+I2aTdM3XygogKxMyFyzeYVTPR2PCf7InefWEM6PktUj04A==", "d8e59a4a-ae59-44c8-bb8e-df419aedf212" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "77777777-7777-7777-7777-777777777777",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b6ab1c8d-fc31-4643-ae21-7b6291f75718", "AQAAAAIAAYagAAAAED5Eq9NvkYrohKiMNZmb2JagmFhSzu/JfdXCuCjr/QVHG3GxNau/XoImzQ10b761JQ==", "b2bc54b2-2c7d-420f-805d-bed44e75629c" });
        }
    }
}
