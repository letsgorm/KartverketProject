using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KartverketProject.Migrations
{
    /// <inheritdoc />
    public partial class nla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "33333333-3333-3333-3333-333333333333",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "58242bbf-33c2-4866-8615-9a68c9cb82ca", "AQAAAAIAAYagAAAAEC085K4mHiggk4FxMu+1/vNDmV9UxaDZHC8jPS5SJXFLpt6nqP3MAtGVbuOMds6n6w==", "0d108309-e2dc-4bf2-b6b3-f17c588d8b15" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "44444444-4444-4444-4444-444444444444",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d57d1b89-34b5-48da-a649-68100f959a1c", "AQAAAAIAAYagAAAAEIqG8jAKbqtqth4oJLsntpu4jcqvtq97zRei5e4e9TnOOwbebsKrTs+9rJP7Ire29A==", "493a2cb2-ed9e-41a9-baa8-a01d214a9d98" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "66666666-6666-6666-6666-666666666666",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "79e5b6db-d1ec-4d82-b50f-a6fdb38eccf7", "AQAAAAIAAYagAAAAECLF9o/1WcidBe6PJNts62sKs2GN9Ak1XmOcR7/eoUNjS82Zk0s345T6sXbybYTIZA==", "564a9c81-8dab-4a2d-b500-413949449299" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "77777777-7777-7777-7777-777777777777",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bc70051f-0eaa-4bee-97af-525676c2626d", "AQAAAAIAAYagAAAAEHUCFIEfjgTmiEXLxEvRcYogJbcFg+Z3zK66t1lWWc6t2ZZqHFklm6peFzInyqo4mg==", "aa0cddfd-ad6e-4292-9eea-5d36d9f98098" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
