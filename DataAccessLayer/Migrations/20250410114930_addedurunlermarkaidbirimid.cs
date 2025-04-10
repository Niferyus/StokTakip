using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class addedurunlermarkaidbirimid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Urunler_UrunOzellikleri_UrunOzellikId",
                table: "Urunler");

            migrationBuilder.DropIndex(
                name: "IX_Urunler_UrunOzellikId",
                table: "Urunler");

            migrationBuilder.DropColumn(
                name: "UrunOzellikId",
                table: "Urunler");

            migrationBuilder.AddColumn<int>(
                name: "MarkaId",
                table: "Urunler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BirimId",
                table: "Urunler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Urunler_BirimId",
                table: "Urunler",
                column: "BirimId");

            migrationBuilder.CreateIndex(
                name: "IX_Urunler_MarkaId",
                table: "Urunler",
                column: "MarkaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Urunler_UrunOzellikleri_BirimId",
                table: "Urunler",
                column: "BirimId",
                principalTable: "UrunOzellikleri",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Urunler_UrunOzellikleri_MarkaId",
                table: "Urunler",
                column: "MarkaId",
                principalTable: "UrunOzellikleri",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Urunler_UrunOzellikleri_BirimId",
                table: "Urunler");

            migrationBuilder.DropForeignKey(
                name: "FK_Urunler_UrunOzellikleri_MarkaId",
                table: "Urunler");

            migrationBuilder.DropIndex(
                name: "IX_Urunler_BirimId",
                table: "Urunler");

            migrationBuilder.DropIndex(
                name: "IX_Urunler_MarkaId",
                table: "Urunler");

            migrationBuilder.AlterColumn<int>(
                name: "BirimId",
                table: "Urunler",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "UrunOzellikId",
                table: "Urunler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Urunler_UrunOzellikId",
                table: "Urunler",
                column: "UrunOzellikId");

            migrationBuilder.AddForeignKey(
                name: "FK_Urunler_UrunOzellikleri_UrunOzellikId",
                table: "Urunler",
                column: "UrunOzellikId",
                principalTable: "UrunOzellikleri",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
