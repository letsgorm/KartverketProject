using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KartverketProject.Migrations
{
    /// <inheritdoc />
    public partial class ImagePath : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                values: new object[] { "b5ed6a2f-c10d-4e78-9815-8982d9c09c55", "AQAAAAIAAYagAAAAEMl5DkDQUuS6KnWY1KU5/2j5al3seMB9Yc6MrlXNU5ANTLA+VQ1y9XlUv5BzOrBjRw==", "679da0d8-8f29-4eb5-9443-6a77e249f631" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "44444444-4444-4444-4444-444444444444",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9c5a481d-6bbb-4dce-82a9-54969836287a", "AQAAAAIAAYagAAAAEMjA2hGvKQfjJzZaGapzn+YChX77+w6llre8pYqGnLDzdPe6yVnFzn+u8WOucKHPfA==", "aae656e7-b681-40bb-bd8f-0b00b2a2012f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "66666666-6666-6666-6666-666666666666",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f051c73b-0ce9-4b18-babb-e0073c7931b7", "AQAAAAIAAYagAAAAEAnXg9VqxAJEZhs+DqIHXpL270m06kV/tFVjS9ViDuGaRKd7iaojVvqJF8LVqCjBLQ==", "96f8e74c-5ca2-4add-99c1-a4b984f25608" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "77777777-7777-7777-7777-777777777777",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5b1b1913-1352-4d56-b51f-04d61a6471b8", "AQAAAAIAAYagAAAAENGVIKVcf77zqeTIvxYXYHIHAyQCw/Noze0ZXjZzx+wf+bLI6cN/4A9dbhu3CHHAYQ==", "f5c041fb-18d8-4f98-af99-970686052745" });

            migrationBuilder.UpdateData(
                table: "Obstacle",
                keyColumn: "ObstacleId",
                keyValue: 1,
                column: "ImagePath",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Obstacle");

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
