using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class addedstoktable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stok",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrunId = table.Column<int>(type: "int", nullable: false),
                    StokMiktari = table.Column<int>(type: "int", nullable: false),
                    DepoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stok", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stok_Depo_DepoId",
                        column: x => x.DepoId,
                        principalTable: "Depo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stok_Urunler_UrunId",
                        column: x => x.UrunId,
                        principalTable: "Urunler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stok_DepoId",
                table: "Stok",
                column: "DepoId");

            migrationBuilder.CreateIndex(
                name: "IX_Stok_UrunId",
                table: "Stok",
                column: "UrunId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stok");
        }
    }
}
