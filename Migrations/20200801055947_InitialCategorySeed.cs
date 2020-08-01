using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderProcessSystem.Migrations
{
    public partial class InitialCategorySeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "OrderCategory",
                columns: new[] { "CategoryID", "CategoryName", "Description" },
                values: new object[] { 1, "Fruits", "Fresh Fruits" });

            migrationBuilder.InsertData(
                table: "OrderCategory",
                columns: new[] { "CategoryID", "CategoryName", "Description" },
                values: new object[] { 2, "Vegetables", "Fresh Vegetables" });

            migrationBuilder.InsertData(
                table: "OrderCategory",
                columns: new[] { "CategoryID", "CategoryName", "Description" },
                values: new object[] { 3, "Flowers", "Fresh Flowers" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderCategory",
                keyColumn: "CategoryID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderCategory",
                keyColumn: "CategoryID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderCategory",
                keyColumn: "CategoryID",
                keyValue: 3);
        }
    }
}
