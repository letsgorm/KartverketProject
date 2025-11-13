using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KartverketProject.Migrations
{
    /// <inheritdoc />
    public partial class comments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "33333333-3333-3333-3333-333333333333",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3a693d1b-2958-4207-9f88-e21008285760", "AQAAAAIAAYagAAAAEEgdQv5Z2RqwbEIOuuCbzIfCn5LDM4/9Q0vj7M8/Yjwx8pg8rwZhy62We7qkpdANWA==", "aade2c21-4c15-4760-95b9-47c0238e9577" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "44444444-4444-4444-4444-444444444444",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "43d67763-13da-44e0-a71f-adda5bbe9984", "AQAAAAIAAYagAAAAEEdLrofrB+e2kMwuI8X8C9OVPyZsA01lgRSnTLlHjJFm/Dwd1zoojYTRFLPSupecmA==", "4687acc0-a5fe-4ae6-8e0a-1cccd8dd6be3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "66666666-6666-6666-6666-666666666666",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d6710dcc-c2ce-4c1f-832d-e561a3f807ab", "AQAAAAIAAYagAAAAEBH4enqVOBhQ8u5ujQCu/Yil3Jk1wepP4z+iL+RxSWVHFlVYeOzwMbLOmA2RDJoEvw==", "c6ec9649-2c30-4b0a-9a10-dc0c5e1b7c14" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "77777777-7777-7777-7777-777777777777",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eb328612-423a-44c4-89a5-c86ccc399fe9", "AQAAAAIAAYagAAAAEOWixDid+aZoQVwAFBbbjWQ898EsR8KpJxzne9ULrR7U349oNpggoFPJCqpQEnd8Ew==", "12cd0c91-0184-442c-b93e-f4d7a44cf83b" });
        }
    }
}
