using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class salamm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckOuts_Products_ProductId",
                table: "CheckOuts");

            migrationBuilder.DropIndex(
                name: "IX_CheckOuts_ProductId",
                table: "CheckOuts");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "CheckOuts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "CheckOuts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CheckOuts_ProductId",
                table: "CheckOuts",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckOuts_Products_ProductId",
                table: "CheckOuts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
