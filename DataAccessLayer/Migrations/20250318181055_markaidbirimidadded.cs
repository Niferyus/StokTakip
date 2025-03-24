using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class markaidbirimidadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Birim",
                table: "Urunler");

            migrationBuilder.DropColumn(
                name: "Marka",
                table: "Urunler");

            migrationBuilder.AddColumn<int>(
                name: "BirimId",
                table: "Urunler",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MarkaId",
                table: "Urunler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Birim",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Urunler_BirimId",
                table: "Urunler",
                column: "BirimId");

            migrationBuilder.CreateIndex(
                name: "IX_Urunler_MarkaId",
                table: "Urunler",
                column: "MarkaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Urunler_Birim_BirimId",
                table: "Urunler",
                column: "BirimId",
                principalTable: "Birim",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Urunler_Marka_MarkaId",
                table: "Urunler",
                column: "MarkaId",
                principalTable: "Marka",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Urunler_Birim_BirimId",
                table: "Urunler");

            migrationBuilder.DropForeignKey(
                name: "FK_Urunler_Marka_MarkaId",
                table: "Urunler");

            migrationBuilder.DropIndex(
                name: "IX_Urunler_BirimId",
                table: "Urunler");

            migrationBuilder.DropIndex(
                name: "IX_Urunler_MarkaId",
                table: "Urunler");

            migrationBuilder.DropColumn(
                name: "BirimId",
                table: "Urunler");

            migrationBuilder.DropColumn(
                name: "MarkaId",
                table: "Urunler");

            migrationBuilder.AddColumn<string>(
                name: "Birim",
                table: "Urunler",
                type: "varchar(20)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Marka",
                table: "Urunler",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Birim",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }
    }
}
