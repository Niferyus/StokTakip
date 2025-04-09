using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class uniquenameurunozellikleri : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Urunler_BirimId",
                table: "Urunler");

            migrationBuilder.DropIndex(
                name: "IX_Urunler_MarkaId",
                table: "Urunler");

            migrationBuilder.DropIndex(
                name: "IX_Urunler_DepoId",
                table: "Urunler");

            migrationBuilder.DropForeignKey(
                name: "FK_Urunler_Depo_DepoId",
                table: "Urunler");

            migrationBuilder.DropColumn(
                name: "BirimId",
                table: "Urunler");

            migrationBuilder.DropColumn(
                name: "MarkaId",
                table: "Urunler");

            migrationBuilder.DropColumn(
                name: "DepoId",
                table: "Urunler");

            migrationBuilder.AlterColumn<string>(
                name: "Ad",
                table: "UrunOzellikleri",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "UrunOzellikId",
                table: "Urunler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UrunOzellikleri_Ad",
                table: "UrunOzellikleri",
                column: "Ad",
                unique: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Urunler_UrunOzellikleri_UrunOzellikId",
                table: "Urunler");

            migrationBuilder.DropIndex(
                name: "IX_UrunOzellikleri_Ad",
                table: "UrunOzellikleri");

            migrationBuilder.DropIndex(
                name: "IX_Urunler_UrunOzellikId",
                table: "Urunler");

            migrationBuilder.DropColumn(
                name: "UrunOzellikId",
                table: "Urunler");

            migrationBuilder.AlterColumn<string>(
                name: "Ad",
                table: "UrunOzellikleri",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

        }
    }
}
