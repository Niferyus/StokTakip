using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class addedkisiler : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            //migrationBuilder.DropIndex(
            //    name: "IX_Musteriler_DepoId",
            //    table: "Urunler");

            migrationBuilder.DropForeignKey(
                name: "FK_Islemler_Musteriler_MusteriID",
                table: "Islemler");
            
            migrationBuilder.DropForeignKey(
                name: "FK_Islemler_Kisiler_ToptanciID",
                table: "Islemler");

            migrationBuilder.DropTable(
                name: "Musteriler");

            migrationBuilder.DropForeignKey(
                name: "FK_Kisiler_Urunler_UrunId",
                table: "Kisiler");

            migrationBuilder.DropIndex(
                name: "IX_Kisiler_UrunId",
                table: "Kisiler");

            migrationBuilder.DropTable(
                name: "Kisiler");

            migrationBuilder.CreateTable(
                name: "Kisiler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FirmaAdi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Eposta = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Tur = table.Column<int>(type: "int", nullable: false),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kisiler", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kisiler");
        }
    }
}
