using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KartverketProject.Migrations
{
    /// <inheritdoc />
    public partial class testing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "33333333-3333-3333-3333-333333333333",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ec97eb68-d3b4-4593-9117-d2b9ccbe7a69", "AQAAAAIAAYagAAAAEIEHFcobse0q8AxB58FF1qz5PxeV7z7DjxYKR1L1Esm43p36oV92J5uSBPFflFif9A==", "c9a5dab6-e916-40b1-b4ec-028c51e47f90" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "44444444-4444-4444-4444-444444444444",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "97e5b8f1-466c-40e1-a709-a397ff271d1a", "AQAAAAIAAYagAAAAEP0F2Z7xOT5XDp9rZSGyghBvgb8ILDhil6saq0TBScyws0A12nJeghvKn3mGxVdggw==", "d1705f09-e406-4095-820d-528e42d80dcc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "66666666-6666-6666-6666-666666666666",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eeb85f4f-f07c-4b66-af30-9cd6df1c8ebf", "AQAAAAIAAYagAAAAEBYM8xaBiUIjLXh4xhPZ9cGnEVP6Z93BvC6hyOPGwZ4F4hJjCWE0MqkTs1oQJZM+Qw==", "6c244b53-5f1d-4878-baff-a7c913e992f5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "77777777-7777-7777-7777-777777777777",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "73c5c72f-f15a-4654-b4c6-565a079f271f", "AQAAAAIAAYagAAAAEN0vIoMx+uYoRCWr/mV0m0yXqen4CVCy1Zx+CMQciRvtKUcVIz0Igv4vzsBrJfpCMA==", "85a41f66-41e8-4d67-930b-1590db8bafc1" });
        }
    }
}
