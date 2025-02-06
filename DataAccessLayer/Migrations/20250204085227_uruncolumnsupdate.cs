using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class uruncolumnsupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UrunStok",
                table: "Urunler",
                newName: "Stok");

            migrationBuilder.RenameColumn(
                name: "UrunSatisFiyat",
                table: "Urunler",
                newName: "SatisFiyat");

            migrationBuilder.RenameColumn(
                name: "UrunAlisFiyat",
                table: "Urunler",
                newName: "AlisFiyat");

            migrationBuilder.RenameColumn(
                name: "UrunAdi",
                table: "Urunler",
                newName: "Adi");

            migrationBuilder.RenameColumn(
                name: "UrunAciklama",
                table: "Urunler",
                newName: "Aciklama");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Stok",
                table: "Urunler",
                newName: "UrunStok");

            migrationBuilder.RenameColumn(
                name: "SatisFiyat",
                table: "Urunler",
                newName: "UrunSatisFiyat");

            migrationBuilder.RenameColumn(
                name: "AlisFiyat",
                table: "Urunler",
                newName: "UrunAlisFiyat");

            migrationBuilder.RenameColumn(
                name: "Adi",
                table: "Urunler",
                newName: "UrunAdi");

            migrationBuilder.RenameColumn(
                name: "Aciklama",
                table: "Urunler",
                newName: "UrunAciklama");
        }
    }
}
