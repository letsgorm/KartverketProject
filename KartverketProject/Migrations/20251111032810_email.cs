using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KartverketProject.Migrations
{
    /// <inheritdoc />
    public partial class email : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ReportReasonSeen",
                table: "Report",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "33333333-3333-3333-3333-333333333333",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4a1bfb38-011a-4d77-879f-c71a5d68da15", "AQAAAAIAAYagAAAAEPAh2TVeCkVyZfDU8uiZ9RDnhb5DuFSaj+SKAvJCmD4L/JpjyKw18c+/Ukg01wE1TA==", "5de66905-b432-42d7-a5c0-1b23e6fd7a98" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "44444444-4444-4444-4444-444444444444",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "97ee33ff-00cd-44af-b1c5-897cb9438b47", "AQAAAAIAAYagAAAAEOJjv8/oDv7e1arJ7CfO+I0h+IYbBw8OvUuB0ixvtC8rvhfBwB1K2m0vzFl0KFXanA==", "8743bcf4-a18a-41c6-a514-446d369c428a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "66666666-6666-6666-6666-666666666666",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e1c18b55-22fc-4ecc-ad55-549f33b0bb24", "AQAAAAIAAYagAAAAEHQ3+7ZUN9AiJ3IZX4p6HMifI63exx6KuhNBHe39dCIcAmvaeYw1F+dX2fWLDNHD1w==", "7e67abf9-aaab-400c-8e3b-e3d99a69fc68" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "77777777-7777-7777-7777-777777777777",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7a7d1d0c-3ad6-48d6-bc73-df23b8feac10", "AQAAAAIAAYagAAAAENAPOUw6ipDpNfZ81j6l5ejlCppOC3vH4T3cwESbPU4Jz719f33z6W7ZeQ3Rzl2/Qw==", "1e4ed8c4-ff6d-4a98-9c0b-d6e272701589" });

            migrationBuilder.UpdateData(
                table: "Report",
                keyColumn: "ReportId",
                keyValue: 1,
                column: "ReportReasonSeen",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReportReasonSeen",
                table: "Report");

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
        }
    }
}
