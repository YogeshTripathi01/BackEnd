using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.DataAccessLayer.Migrations
{
    public partial class updateCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Product_Image",
                table: "carts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Product_Image",
                table: "carts");
        }
    }
}
