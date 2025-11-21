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
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "33333333-3333-3333-3333-333333333333",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "df763dc0-9ede-4ab7-a44c-a825b76bc05a", "AQAAAAIAAYagAAAAEKBIKjj4HK0ImTRDSOVHcCtovnv+1F+1LLK9OxCwubsafQWRlz05tzcm3a5Ggq5ejQ==", "34eee811-dfa3-42a4-8a9f-3d2e2c67144b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "44444444-4444-4444-4444-444444444444",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "162cd054-eebd-4c7e-b669-50eb1f3390cb", "AQAAAAIAAYagAAAAEHnpqxpsL5HQkqcxrEq5nlZ3nA4qeoWlVb+hRdEXMpFQxUAckwXP4HQoHKNgJaMprA==", "6ebe07fa-7865-4ac4-be85-6e583e74c104" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "66666666-6666-6666-6666-666666666666",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e2142608-01fa-4540-9335-ab996c47094c", "AQAAAAIAAYagAAAAEBrDnAcQN8IyHe5kls5vqaGk2+vMHy4RGLjbGcQDlzcmzueb/Y+ow6bp8THsSw6eyg==", "02e5531d-ee1a-43dd-b78c-83f94e6cdc0c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "77777777-7777-7777-7777-777777777777",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "faf21f24-2912-41c0-8db6-0972f3b7f7eb", "AQAAAAIAAYagAAAAEHlBHbs0BHdE09COCa+lmB2WftaoSIEF/YRi7A7Bu9LSXgC6V5jc5HM5gblDMu1H6g==", "3016093f-2264-42ba-979f-f8a61c122e8a" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "33333333-3333-3333-3333-333333333333",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "76e12416-fd3f-4ad8-95e6-7d4f75624c31", "AQAAAAIAAYagAAAAELi0/UTtx+AcWk42m1TvnYFor66vgErWR1AR6XJDnSGVAitYJB+xuN2mkb65333QpA==", "5b023941-31d5-42f6-b96b-8fec3dcac0ff" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "44444444-4444-4444-4444-444444444444",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a9eb8ad6-55a0-4aa7-bd99-8eede627ef8e", "AQAAAAIAAYagAAAAEIlFNs3nmKkbMRkR4pUvy+Hau0ya7Ic+kdlXmYhhsKOHglYy1BZALeRkz2FMdD0Fhw==", "17fe1f72-fa44-41a4-8d60-e9f21e1d76ba" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "66666666-6666-6666-6666-666666666666",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fdf68500-d299-446b-9bcb-344c0247e5bf", "AQAAAAIAAYagAAAAEN5m1RpWpJSfK9AIgpOoxoszFwKo9AkiFy2qnqg6d78htY2oguOWrCcfhpNV2y6i9g==", "220c0c51-fc1f-4546-a07a-ebf07dfbbd37" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "77777777-7777-7777-7777-777777777777",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "31b7a2dd-fd02-4556-a39f-a446ee18e3d4", "AQAAAAIAAYagAAAAEOdMtxegM7qYafntUH5ULsitTDQkN4lFQBPXQvo8vTV+isNmGmPLHwXvVLlCn3MoiA==", "a90c4167-17a0-436d-99bb-0281164753b4" });
        }
    }
}
