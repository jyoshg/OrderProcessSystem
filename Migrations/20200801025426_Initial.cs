using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderProcessSystem.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderCategory",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderCategory", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    ItemID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.ItemID);
                    table.ForeignKey(
                        name: "FK_OrderItem_OrderCategory_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "OrderCategory",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<string>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    ProductItemID = table.Column<int>(nullable: true),
                    accountId = table.Column<int>(nullable: false),
                    accountName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Order_OrderItem_ProductItemID",
                        column: x => x.ProductItemID,
                        principalTable: "OrderItem",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_ProductItemID",
                table: "Order",
                column: "ProductItemID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_CategoryID",
                table: "OrderItem",
                column: "CategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "OrderCategory");
        }
    }
}
