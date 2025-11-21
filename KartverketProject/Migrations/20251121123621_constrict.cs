using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KartverketProject.Migrations
{
    /// <inheritdoc />
    public partial class constrict : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ReportReason",
                table: "Report",
                type: "varchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ReportReason",
                table: "Report",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "33333333-3333-3333-3333-333333333333",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c6316a11-7814-4b69-bf8a-6e88763d98a7", "AQAAAAIAAYagAAAAEImA3n2g/oZ+jCRMH6RtvswOGgufcSwavk/ojoQcNbxJTWW/IEpsrostNbRDtgZBgA==", "89eab33c-4ca7-4823-bd92-f9044243829b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "44444444-4444-4444-4444-444444444444",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "14a7d060-8753-4fb6-8096-5537d16ba0c9", "AQAAAAIAAYagAAAAEF8ajPfu0AE35DqA+b5rfKzdt+3f53NDSK4CC1JKpt/BT4h3GnekO4DoOmDDBwliXA==", "592a9b98-0855-4772-b53a-b43153057140" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "66666666-6666-6666-6666-666666666666",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bd1fb486-0351-44b7-84e6-6d5b82a6036e", "AQAAAAIAAYagAAAAEIocgTN1Noy5lHH8FNQT7yCBlo3/ksNYwG1eB+OfbxDxzANOgwPcKTfT/eEELWujDw==", "a71926c7-896a-4da3-9aea-6084522a4d87" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "77777777-7777-7777-7777-777777777777",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5070f500-c114-4d73-83b1-48baf59b8c71", "AQAAAAIAAYagAAAAEB6+35Lf4p03qc4AKAeYL+2j2czlRn2ps4YP+0TNqfT9+0CFeeI45DFwAN2bB4OnFw==", "7dc48e35-0f8a-4178-861e-4d56c50d7a74" });
        }
    }
}
