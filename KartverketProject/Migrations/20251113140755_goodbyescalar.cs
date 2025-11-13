using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KartverketProject.Migrations
{
    /// <inheritdoc />
    public partial class goodbyescalar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "33333333-3333-3333-3333-333333333333",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e5e07206-72bf-4568-a39a-897e58d7ac86", "AQAAAAIAAYagAAAAEDpDJKhmvgtYpwFQbhJD4K+Jit/1bH1wqP2W4DCvrRI8ffU/XcAO+DGYUo+5uXRGRg==", "50d5c722-e497-423a-8c43-0aa85a4be41a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "44444444-4444-4444-4444-444444444444",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "27e03749-dff2-47a1-ad4b-1b6ef05810c5", "AQAAAAIAAYagAAAAEC/84zP5N102WFh0Ar0KGqvYLp+SaJqMFG/OEFgh+xv3ojg/GexJEdCg+25UDUUZ4g==", "518451ca-f75d-47fe-92a8-acc38073a128" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "66666666-6666-6666-6666-666666666666",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ca9789fb-d082-4ac4-bf82-1eaa694a435e", "AQAAAAIAAYagAAAAEJCP5HAUg46jnqzdEtcJgih+9QuJhaZegptZFWDdOIQ6JLYmHOv/fv/EvRXe/09Lxw==", "74ebdf66-d6cf-4195-ba1d-a56cfd390d3d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "77777777-7777-7777-7777-777777777777",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5279765a-bd2e-4bf0-889b-7bc0f07cbeec", "AQAAAAIAAYagAAAAEGu9nMdlVc8R74+lu3tH+1gnqBcqJXP6S5hTJ31CnP2df7SpENpJZVVefZOO1lJq0A==", "1c85716f-6f01-42a8-8d91-acbfd1d9f1cf" });
        }
    }
}
