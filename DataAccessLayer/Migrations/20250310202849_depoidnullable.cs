using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class depoidnullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Urunler_Depo_DepoId",
                table: "Urunler");

            migrationBuilder.AlterColumn<int>(
                name: "DepoId",
                table: "Urunler",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Urunler_Depo_DepoId",
                table: "Urunler",
                column: "DepoId",
                principalTable: "Depo",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Urunler_Depo_DepoId",
                table: "Urunler");

            migrationBuilder.AlterColumn<int>(
                name: "DepoId",
                table: "Urunler",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Urunler_Depo_DepoId",
                table: "Urunler",
                column: "DepoId",
                principalTable: "Depo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
