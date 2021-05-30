using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductID",
                table: "Offer",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Advertisements",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advertisements", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Offer_ProductID",
                table: "Offer",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_Offer_Product_ProductID",
                table: "Offer",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offer_Product_ProductID",
                table: "Offer");

            migrationBuilder.DropTable(
                name: "Advertisements");

            migrationBuilder.DropIndex(
                name: "IX_Offer_ProductID",
                table: "Offer");

            migrationBuilder.DropColumn(
                name: "ProductID",
                table: "Offer");
        }
    }
}
