using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryApp.Migrations
{
    public partial class products : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "catergories",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_catergories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    ID = table.Column<string>(type: "text", nullable: false),
                    barcode = table.Column<string>(type: "text", nullable: true),
                    productName = table.Column<string>(type: "text", nullable: true),
                    productImage = table.Column<string>(type: "text", nullable: true),
                    catergoryID = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.ID);
                    table.ForeignKey(
                        name: "FK_products_catergories_catergoryID",
                        column: x => x.catergoryID,
                        principalTable: "catergories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "storeProducts",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    sellingPrice = table.Column<double>(type: "double precision", nullable: false),
                    stockPrice = table.Column<double>(type: "double precision", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    storeID = table.Column<string>(type: "text", nullable: true),
                    productID = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_storeProducts", x => x.id);
                    table.ForeignKey(
                        name: "FK_storeProducts_products_productID",
                        column: x => x.productID,
                        principalTable: "products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_storeProducts_stores_storeID",
                        column: x => x.storeID,
                        principalTable: "stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_products_catergoryID",
                table: "products",
                column: "catergoryID");

            migrationBuilder.CreateIndex(
                name: "IX_storeProducts_productID",
                table: "storeProducts",
                column: "productID");

            migrationBuilder.CreateIndex(
                name: "IX_storeProducts_storeID",
                table: "storeProducts",
                column: "storeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "storeProducts");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "catergories");
        }
    }
}
