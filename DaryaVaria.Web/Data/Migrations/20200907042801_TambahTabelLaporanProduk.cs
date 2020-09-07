using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DaryaVaria.Web.Data.Migrations
{
    public partial class TambahTabelLaporanProduk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LaporanProduk",
                columns: table => new
                {
                    IdProduk = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamaProduk = table.Column<string>(nullable: true),
                    TanggalProduksi = table.Column<DateTime>(nullable: false),
                    TanggalKadaluarsa = table.Column<DateTime>(nullable: false),
                    TanggalKonsumsi = table.Column<DateTime>(nullable: false),
                    CaraPemakaian = table.Column<string>(maxLength: 500, nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaporanProduk", x => x.IdProduk);
                    table.ForeignKey(
                        name: "FK_LaporanProduk_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LaporanProduk_UserId",
                table: "LaporanProduk",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LaporanProduk");
        }
    }
}
