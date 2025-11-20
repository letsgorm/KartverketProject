using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KartverketProject.Migrations
{
    /// <inheritdoc />
    public partial class dock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "33333333-3333-3333-3333-333333333333",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "34ce3a63-2ce5-4101-84e3-bd01ef4c7872", "AQAAAAIAAYagAAAAEKBlcAigQT5ypzHfMe3foM86Eq+fU2ontrpTMugqFTGXT1E4A04YhzepvJwrAhD02A==", "b803a417-0360-48bb-9d49-2c1fe7eefb6c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "44444444-4444-4444-4444-444444444444",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5df379ca-bfd3-4ec1-8af7-7f242d600f35", "AQAAAAIAAYagAAAAEAFchVJ1eRFQQq505RMx5PLYcmbXnds8FymPIJNXC4X/HmNU1D/VFlLzlN5SwBufpg==", "3cdcdbe3-0400-467c-91a1-089ba1fe36c3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "66666666-6666-6666-6666-666666666666",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "27adc1db-fa88-4a67-a180-f1aa42891ebe", "AQAAAAIAAYagAAAAENHifNRZIBhBP86VLpaOmRtPfyYnzw5NbHiv/qHSH1tOMzVuLSzQHdMS6b347pP2bQ==", "42f21312-3ff4-48df-9c76-4a3fe9178505" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "77777777-7777-7777-7777-777777777777",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "74f7fe91-a02d-4bfc-9ec5-fdfea5945b27", "AQAAAAIAAYagAAAAELhBJyD+uyw/iEfuK5mm6I0nsqmZBNghKjps+j9IUHjno8at8NZspGPKPRrbYb0hKw==", "9cfa8c4d-03c8-46ed-b046-3065e5956f79" });
        }
    }
}
