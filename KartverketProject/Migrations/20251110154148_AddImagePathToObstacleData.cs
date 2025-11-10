using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KartverketProject.Migrations
{
    /// <inheritdoc />
    public partial class AddImagePathToObstacleData : Migration
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

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Obstacle",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "33333333-3333-3333-3333-333333333333",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c023cdb5-2279-479c-a0d5-62c5e0dc1e03", "AQAAAAIAAYagAAAAEBvIuG+qYr9jZRXlmJ50iD6LGR5i3Ef6z4o4LZoHvg0VH5rebdg9eq5EIPh9FPvAyg==", "cd75d281-3afd-42d4-82f3-fccb4601ae2c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "44444444-4444-4444-4444-444444444444",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b6f75e0f-e936-4cc9-a116-7275a068d6a2", "AQAAAAIAAYagAAAAEAhIl4jTlJlzyiCwM7GIeZSh13ScnHRgFIzNcmGC7NtiHkHpY4qnYd+xOVGk4Ut/9Q==", "20cfd151-0d66-4d60-9ae7-b2a48005c7ff" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "66666666-6666-6666-6666-666666666666",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "461bf45e-bfa1-422a-9dfb-fc964b11f902", "AQAAAAIAAYagAAAAEBzru9tZmH7CBvf6PnYm4i2q98tofb//ps5swjl8+wtgTaCwnd36vNkOJFpPO1ROkg==", "a1985b82-a18c-4ffb-808e-8276aa65d89f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "77777777-7777-7777-7777-777777777777",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ab61d9e8-2bb1-4f59-8f37-0bcf8d5fbe3d", "AQAAAAIAAYagAAAAEObGbTCoGYxbkxmFCqSWzuXsI1kWcd0id0H8JQpQ4jBdRwZUOqkI+ic7RCckd4BKmA==", "e66abac2-d902-4e5c-ae38-c848d7a12cd7" });

            migrationBuilder.UpdateData(
                table: "Obstacle",
                keyColumn: "ObstacleId",
                keyValue: 1,
                column: "ImagePath",
                value: null);

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

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Obstacle");

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
