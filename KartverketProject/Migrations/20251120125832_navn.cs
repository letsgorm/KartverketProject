using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KartverketProject.Migrations
{
    /// <inheritdoc />
    public partial class navn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "33333333-3333-3333-3333-333333333333",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e6101ddd-8f24-48f8-89b7-0f942f064780", "AQAAAAIAAYagAAAAEMueFBGqXVAT03LZuRzdDcUGRE/6GJSYbQVAC+vI+O7mvCNmGvwEJc7DR4S1mbNhzw==", "97212e76-c36c-4360-a1ec-2f79ca64b9ad" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "44444444-4444-4444-4444-444444444444",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7a598196-e38b-4ddd-a9e8-6d33fb340b86", "AQAAAAIAAYagAAAAEI+BzruMhWl7oOOQC6eEA3WvV6s28l31eUndhx3JRHvQJ9b25NQKGaZpC6fR9ledvw==", "e0f1c3c2-1843-4f7f-909e-341b90395a4a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "66666666-6666-6666-6666-666666666666",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f0145da6-3106-41a8-87bb-e48a5ac17cda", "AQAAAAIAAYagAAAAEBiXNpOnjV4qE89ZBjzj/i517vqUri5LCmHlujxpEj66p8fsh9WI74JqLP9IKm9+Eg==", "946bee6c-4203-4666-990b-52e95a0f6dc2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "77777777-7777-7777-7777-777777777777",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "65883e46-07ad-4856-aa8f-f7db5d7c2d40", "AQAAAAIAAYagAAAAEPjZbubVH5S9VZo81St66O44qeqO88X+tS4gWSb8WNMC9vk3XCpyGKk1obqdG+hBtA==", "06ccf939-fe24-427c-90cf-30087e59aadd" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "33333333-3333-3333-3333-333333333333",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "71a84b1a-071f-46d1-9819-4d6d3f1f8871", "AQAAAAIAAYagAAAAEA6Nyhcx7jZ0/gwMdDpi+mDRfiPlwFaC+q6SGszN0CcedpKQ8ycCEUVr//bb6mzVIg==", "313a1e0a-a737-4b84-a146-d0a7970ac77b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "44444444-4444-4444-4444-444444444444",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "034c957e-524e-4b6a-8059-2f4764279bd5", "AQAAAAIAAYagAAAAEAwrgcdotQiqX5FR2jEcQzSxr/pjgzZ7kKd8axlCtSnxOEQzycN/r+/mLtrvAxerCA==", "03bed05e-3056-4ba5-8e30-28313ee24abb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "66666666-6666-6666-6666-666666666666",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "43b6ae9b-0924-4574-a5ae-55a7761e6c80", "AQAAAAIAAYagAAAAEJLLTFuoYGGxzvAKG0LI3qtMnYfMgpyAwyqoOK5baFV0qGzWgnbISHTKaeFwhCTgJg==", "0d4074d3-8f2e-4bb4-a88c-c4f81312d48a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "77777777-7777-7777-7777-777777777777",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "87d5ce93-c5ea-4d83-ba53-2e8ee504abee", "AQAAAAIAAYagAAAAEAVlI4wgoJ/R8qhBpmzHD5zgK1c35XxnQyP07Wi7Cs/FcZRYWcA40JQgHMyqRwB1Sw==", "561a458b-429f-45e1-b192-8a943b08ce3e" });
        }
    }
}
