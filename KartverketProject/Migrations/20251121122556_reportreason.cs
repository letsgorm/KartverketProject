using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KartverketProject.Migrations
{
    /// <inheritdoc />
    public partial class reportreason : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "33333333-3333-3333-3333-333333333333",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b7c06b91-ada6-4848-845d-96e932345830", "AQAAAAIAAYagAAAAEPFeHpe9TlsbwzFyAyij1xO3wmk1qtOpCwqypMCp+Y0TEhYrmajJfK0CumfCS8dIjA==", "d42fc8cc-dc22-48b2-9cc3-4214cb4091da" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "44444444-4444-4444-4444-444444444444",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "52226cc8-452f-4e0b-966f-0ebb8aecf430", "AQAAAAIAAYagAAAAEMlco0RNGOiW7h3PGb2KREt2oh2gFOTTRLtrZC7PA+W8iPJj7Rtb83pKjJWd2oY39w==", "871c8d27-d850-41c0-86b0-f9854bf6f379" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "66666666-6666-6666-6666-666666666666",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "923fd5b6-fcd1-4ff9-806f-cbd52fc91580", "AQAAAAIAAYagAAAAEN8n8O+HFtM32LDZxKKE0Yu8qxszsGDMfZDEQmoRl2zpOmyu+eQ+KCiDs8DdzbcK3Q==", "ffba73b2-9e12-4618-a347-aff54c1ffe6e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "77777777-7777-7777-7777-777777777777",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6915312d-112f-4693-9a7d-a8178edaec60", "AQAAAAIAAYagAAAAEB/CifWxPjkb07ovuE9U6h8k0omhUwWQ0Nhw8pZinPuS1Pu/gSSwbgwVRjJQfQTwJg==", "608266c6-e00b-4eb6-99af-abeb44aac9bc" });
        }
    }
}
