using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KartverketProject.Migrations
{
    /// <inheritdoc />
    public partial class brute : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "33333333-3333-3333-3333-333333333333",
                columns: new[] { "ConcurrencyStamp", "LockoutEnabled", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bde21a69-2565-469c-84f8-b01d50ce4a9d", true, "AQAAAAIAAYagAAAAEL0/QJhEPrObd2r0yA/WjKBgi4egK7WZg6NL4EdhzpfU5vwwr/Ap/ZRILQAfeE7bhQ==", "c918132e-1286-4ed3-b249-4609353a1be2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "44444444-4444-4444-4444-444444444444",
                columns: new[] { "ConcurrencyStamp", "LockoutEnabled", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c2be85f4-9a3c-4d86-9bac-ca615b836400", true, "AQAAAAIAAYagAAAAELhXm1sS9wSNpl28QVfsisHb2TNPDKxSsm3+LGYiPdwyixROh48uS0WtPQ7JbRsmuQ==", "fff7319c-2395-48f3-9dee-ef594c419c05" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "66666666-6666-6666-6666-666666666666",
                columns: new[] { "ConcurrencyStamp", "LockoutEnabled", "PasswordHash", "SecurityStamp" },
                values: new object[] { "520065de-dbbe-43e7-ad45-0e5551522606", true, "AQAAAAIAAYagAAAAEIfzbY+3Imgkkbxmt+SNM+5Vdrp8Uzxp7MdpLX4PR0BQjqgQkeVQKLxCGpIjHPOR3A==", "96090509-a632-4a71-a1ec-c815c4683e9b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "77777777-7777-7777-7777-777777777777",
                columns: new[] { "ConcurrencyStamp", "LockoutEnabled", "PasswordHash", "SecurityStamp" },
                values: new object[] { "07b458bf-96d5-4398-a9b0-3ae69fb0a763", true, "AQAAAAIAAYagAAAAEL8qxlIR9vwIsiw1FORISXYRblfRA8JA3oezZtkDZOCrZFDii4ux2oPI4ZdvmGDlnw==", "dfbbac8b-db49-4242-b26b-fe90bc484bde" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "33333333-3333-3333-3333-333333333333",
                columns: new[] { "ConcurrencyStamp", "LockoutEnabled", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b6b254d3-a819-4c90-8eef-f0c3754d9257", false, "AQAAAAIAAYagAAAAEJOtLRm2hnIYTBXC6XXYw/x4uIhrxUENBy27BmsT7tY8nHYVoF1qUnxzWGVRjjYgeg==", "9a6c088b-fda8-410f-8801-1c9182a4d9d3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "44444444-4444-4444-4444-444444444444",
                columns: new[] { "ConcurrencyStamp", "LockoutEnabled", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6e26e724-262d-4a98-9062-df175ba3e9f6", false, "AQAAAAIAAYagAAAAED8duSKaXIBxK7LKjz/c/A1lJmslPdQhoEfgWlfrISEM/9osEhiJFPJKJgIuqFG6Tw==", "c642e253-aa37-40cb-a564-228e770453e0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "66666666-6666-6666-6666-666666666666",
                columns: new[] { "ConcurrencyStamp", "LockoutEnabled", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5c63f0c4-6877-4d2e-8763-15691eeaa4a0", false, "AQAAAAIAAYagAAAAEKUOLjASjvUPw0IezFWCgzXckUwvJ6b4GXhW2L8h6XwI5uGI1D183WirR6fpO2BJiA==", "5eb8e1f0-c4b2-4018-a2fe-2f52675533bf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "77777777-7777-7777-7777-777777777777",
                columns: new[] { "ConcurrencyStamp", "LockoutEnabled", "PasswordHash", "SecurityStamp" },
                values: new object[] { "839d60e2-dd6c-4836-b3a5-4b3df7dc20c0", false, "AQAAAAIAAYagAAAAEDUeGDPqcT8gR8VFIeKirLq6GJ/XpsYJj3m66ZKqpfuiUDyW35TgRyzTfhyN7mEvxg==", "5863db1f-38f8-4ce6-80a0-2975c8359292" });
        }
    }
}
