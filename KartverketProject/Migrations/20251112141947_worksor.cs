using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KartverketProject.Migrations
{
    /// <inheritdoc />
    public partial class worksor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SharedWithUserId",
                table: "ReportShare",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ReportShare",
                keyColumn: "SharedWithUserId",
                keyValue: null,
                column: "SharedWithUserId",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "SharedWithUserId",
                table: "ReportShare",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

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
    }
}
