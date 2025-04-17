using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class addedhareketler : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "Hareketler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KisiId = table.Column<int>(type: "int", nullable: false),
                    DepoId = table.Column<int>(type: "int", nullable: false),
                    UrunId = table.Column<int>(type: "int", nullable: false),
                    Miktar = table.Column<int>(type: "int", nullable: false),
                    BirimFiyat = table.Column<int>(type: "int", nullable: false),
                    ToplamFiyat = table.Column<int>(type: "int", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IslemTuru = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hareketler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hareketler_Depo_DepoId",
                        column: x => x.DepoId,
                        principalTable: "Depo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hareketler_Kisiler_KisiId",
                        column: x => x.KisiId,
                        principalTable: "Kisiler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hareketler_Urunler_UrunId",
                        column: x => x.UrunId,
                        principalTable: "Urunler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

           

            migrationBuilder.CreateIndex(
                name: "IX_Hareketler_DepoId",
                table: "Hareketler",
                column: "DepoId");

            migrationBuilder.CreateIndex(
                name: "IX_Hareketler_KisiId",
                table: "Hareketler",
                column: "KisiId");

            migrationBuilder.CreateIndex(
                name: "IX_Hareketler_UrunId",
                table: "Hareketler",
                column: "UrunId");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Islemler_Toptancilar_ToptanciID",
                table: "Islemler");

            migrationBuilder.DropTable(
                name: "Hareketler");

            migrationBuilder.DropTable(
                name: "Toptancilar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kisiler",
                table: "Kisiler");

            migrationBuilder.DropColumn(
                name: "IslemTuru",
                table: "Islemler");

            migrationBuilder.AddColumn<int>(
                name: "ToptanciID",
                table: "Kisiler",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Adet",
                table: "Kisiler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SatisFiyati",
                table: "Kisiler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ToptanciAdi",
                table: "Kisiler",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UrunId",
                table: "Kisiler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Satis",
                table: "Islemler",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kisiler",
                table: "Kisiler",
                column: "ToptanciID");

            migrationBuilder.CreateIndex(
                name: "IX_Kisiler_UrunId",
                table: "Kisiler",
                column: "UrunId");

            migrationBuilder.AddForeignKey(
                name: "FK_Islemler_Kisiler_ToptanciID",
                table: "Islemler",
                column: "ToptanciID",
                principalTable: "Kisiler",
                principalColumn: "ToptanciID");

            migrationBuilder.AddForeignKey(
                name: "FK_Kisiler_Urunler_UrunId",
                table: "Kisiler",
                column: "UrunId",
                principalTable: "Urunler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
