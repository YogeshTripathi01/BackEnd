using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.DataAccessLayer.Migrations
{
    public partial class cartupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Total",
                table: "carts",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Total",
                table: "carts");
        }
    }
}
