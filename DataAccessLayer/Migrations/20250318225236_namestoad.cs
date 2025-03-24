using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class namestoad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Marka",
                newName: "Ad");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Birim",
                newName: "Ad");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ad",
                table: "Marka",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Ad",
                table: "Birim",
                newName: "Name");
        }
    }
}
