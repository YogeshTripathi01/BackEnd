using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.DataAccessLayer.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "carts",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "carts",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
