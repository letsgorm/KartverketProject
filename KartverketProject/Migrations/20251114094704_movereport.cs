using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KartverketProject.Migrations
{
    /// <inheritdoc />
    public partial class movereport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ObstacleStatus",
                table: "Obstacle");

            migrationBuilder.AddColumn<string>(
                name: "ReportStatus",
                table: "Report",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "33333333-3333-3333-3333-333333333333",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "34ce3a63-2ce5-4101-84e3-bd01ef4c7872", "AQAAAAIAAYagAAAAEKBlcAigQT5ypzHfMe3foM86Eq+fU2ontrpTMugqFTGXT1E4A04YhzepvJwrAhD02A==", "b803a417-0360-48bb-9d49-2c1fe7eefb6c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "44444444-4444-4444-4444-444444444444",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5df379ca-bfd3-4ec1-8af7-7f242d600f35", "AQAAAAIAAYagAAAAEAFchVJ1eRFQQq505RMx5PLYcmbXnds8FymPIJNXC4X/HmNU1D/VFlLzlN5SwBufpg==", "3cdcdbe3-0400-467c-91a1-089ba1fe36c3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "66666666-6666-6666-6666-666666666666",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "27adc1db-fa88-4a67-a180-f1aa42891ebe", "AQAAAAIAAYagAAAAENHifNRZIBhBP86VLpaOmRtPfyYnzw5NbHiv/qHSH1tOMzVuLSzQHdMS6b347pP2bQ==", "42f21312-3ff4-48df-9c76-4a3fe9178505" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "77777777-7777-7777-7777-777777777777",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "74f7fe91-a02d-4bfc-9ec5-fdfea5945b27", "AQAAAAIAAYagAAAAELhBJyD+uyw/iEfuK5mm6I0nsqmZBNghKjps+j9IUHjno8at8NZspGPKPRrbYb0hKw==", "9cfa8c4d-03c8-46ed-b046-3065e5956f79" });

            migrationBuilder.UpdateData(
                table: "Report",
                keyColumn: "ReportId",
                keyValue: 1,
                column: "ReportStatus",
                value: "Pending");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReportStatus",
                table: "Report");

            migrationBuilder.AddColumn<string>(
                name: "ObstacleStatus",
                table: "Obstacle",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "33333333-3333-3333-3333-333333333333",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cc7fbede-31d0-474b-b8f3-0bfb31a807e4", "AQAAAAIAAYagAAAAEBb4iX0rOIYhdTmeoi76OSWfok/m+tYGD5gTadgrK73Ae3IghmIzjSa1AAk83eITKg==", "4c20adca-7f45-4b05-bdac-6d560f1f5083" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "44444444-4444-4444-4444-444444444444",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ff0b99c0-451d-4426-b30e-aeffa15787ab", "AQAAAAIAAYagAAAAEDUFKQLPOX0oiH1FsfyH/g7Zty6VgdOAEfG9kEcQWQIbyQrKsbsJEV4/mixLgXdLWg==", "72f1a5e5-b9a1-4dc2-8e2d-590bb07c382b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "66666666-6666-6666-6666-666666666666",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "10a8cae9-7ffc-42a6-9ab9-9d0e57c223a8", "AQAAAAIAAYagAAAAEASfXlIIIVqKjMwhHNJAuA5PngiMI5dVRnFu7Oiswvpn4osIOPiavFyjCGjCd2aGRw==", "0254f54f-1847-4dfa-bbe8-ea3c37821a6f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "77777777-7777-7777-7777-777777777777",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a9e686d0-1231-4dc1-8209-3f6bfec37de1", "AQAAAAIAAYagAAAAEOAWHe61cIIEsiqRDPFPiiE8iI2nphVu2SL7K2odDKg8ePYXHpEmNq7ez44N3ko+Zw==", "ee9eb05f-52ca-4bd8-a5a0-19e8f031de28" });

            migrationBuilder.UpdateData(
                table: "Obstacle",
                keyColumn: "ObstacleId",
                keyValue: 1,
                column: "ObstacleStatus",
                value: "Pending");
        }
    }
}
