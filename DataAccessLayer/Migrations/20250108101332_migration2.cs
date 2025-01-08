using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class migration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Islemler_Musteriler_MusteriID",
                table: "Islemler");

            migrationBuilder.AlterColumn<int>(
                name: "MusteriID",
                table: "Islemler",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ToptanciID",
                table: "Islemler",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Islemler_ToptanciID",
                table: "Islemler",
                column: "ToptanciID");

            migrationBuilder.AddForeignKey(
                name: "FK_Islemler_Musteriler_MusteriID",
                table: "Islemler",
                column: "MusteriID",
                principalTable: "Musteriler",
                principalColumn: "MusteriID");

            migrationBuilder.AddForeignKey(
                name: "FK_Islemler_Toptancilar_ToptanciID",
                table: "Islemler",
                column: "ToptanciID",
                principalTable: "Toptancilar",
                principalColumn: "ToptanciID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Islemler_Musteriler_MusteriID",
                table: "Islemler");

            migrationBuilder.DropForeignKey(
                name: "FK_Islemler_Toptancilar_ToptanciID",
                table: "Islemler");

            migrationBuilder.DropIndex(
                name: "IX_Islemler_ToptanciID",
                table: "Islemler");

            migrationBuilder.DropColumn(
                name: "ToptanciID",
                table: "Islemler");

            migrationBuilder.AlterColumn<int>(
                name: "MusteriID",
                table: "Islemler",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Islemler_Musteriler_MusteriID",
                table: "Islemler",
                column: "MusteriID",
                principalTable: "Musteriler",
                principalColumn: "MusteriID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
