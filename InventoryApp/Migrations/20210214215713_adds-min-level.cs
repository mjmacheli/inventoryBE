using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryApp.Migrations
{
    public partial class addsminlevel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "minLevel",
                table: "storeProducts",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "minLevel",
                table: "storeProducts");
        }
    }
}
