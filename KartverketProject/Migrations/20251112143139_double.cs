using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KartverketProject.Migrations
{
    /// <inheritdoc />
    public partial class @double : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "33333333-3333-3333-3333-333333333333",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "13080ddf-63a2-4adf-b8cb-9b2b6ce4bf42", "AQAAAAIAAYagAAAAEM00J+TaciHm6eAYWuR9gUO0BFAF9RIXISWinnnHuiXDaJw3D6+bf3YHw0jeA4V9Pw==", "2232d3f7-31eb-4763-9a0c-2f69f0e77cf8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "44444444-4444-4444-4444-444444444444",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bd71adcf-81fa-445f-9a6e-9d6bec41e665", "AQAAAAIAAYagAAAAEOCGbOdVdZpuHYG3XNmdx/LF8UX91vePEvXip0SkTga0ODWDdO+mm6HhocS1nbZ5Wg==", "aa3f6911-1963-487e-99c9-ce6f23fec221" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "66666666-6666-6666-6666-666666666666",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ddd4e06b-cd42-454c-86a2-00a142545875", "AQAAAAIAAYagAAAAEN/LIgXO6u57TpTinH06mqh71Slbapp3lkuYS9Jp/O1ugiB/uV5UuHuyrmCpJv7VIg==", "276ded96-cd95-49e2-a811-7e3fcbf93ed7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "77777777-7777-7777-7777-777777777777",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3bec16fb-ba59-4fcb-af00-49afd780fa45", "AQAAAAIAAYagAAAAEHe3aC3kAKm/egLa9P94t09TcSniZU5HeykdcaWtSFmD87fJHOtKfIIMh5r7gKNkjg==", "9a35f83c-b862-4e4e-ba69-01ae480122f7" });
        }
    }
}
