using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class sehiridilceidaddedddepotable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ilce",
                table: "Depo");

            migrationBuilder.DropColumn(
                name: "Sehir",
                table: "Depo");

            migrationBuilder.AddColumn<int>(
                name: "IlceId",
                table: "Depo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SehirId",
                table: "Depo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Depo_IlceId",
                table: "Depo",
                column: "IlceId");

            migrationBuilder.CreateIndex(
                name: "IX_Depo_SehirId",
                table: "Depo",
                column: "SehirId");

            migrationBuilder.AddForeignKey(
                name: "FK_Depo_Yerlesim_IlceId",
                table: "Depo",
                column: "IlceId",
                principalTable: "Yerlesim",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Depo_Yerlesim_SehirId",
                table: "Depo",
                column: "SehirId",
                principalTable: "Yerlesim",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Depo_Yerlesim_IlceId",
                table: "Depo");

            migrationBuilder.DropForeignKey(
                name: "FK_Depo_Yerlesim_SehirId",
                table: "Depo");

            migrationBuilder.DropIndex(
                name: "IX_Depo_IlceId",
                table: "Depo");

            migrationBuilder.DropIndex(
                name: "IX_Depo_SehirId",
                table: "Depo");

            migrationBuilder.DropColumn(
                name: "IlceId",
                table: "Depo");

            migrationBuilder.DropColumn(
                name: "SehirId",
                table: "Depo");

            migrationBuilder.AddColumn<string>(
                name: "Ilce",
                table: "Depo",
                type: "varchar(30)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Sehir",
                table: "Depo",
                type: "varchar(30)",
                nullable: false,
                defaultValue: "");
        }
    }
}
