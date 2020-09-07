using Microsoft.EntityFrameworkCore.Migrations;

namespace DaryaVaria.Web.Data.Migrations
{
    public partial class UpdateTabelLaporanProduk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "LaporanProduk",
                nullable: true,
                defaultValue: "Open");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "LaporanProduk");
        }
    }
}
