using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stelina.Domain.Migrations
{
    public partial class ProductRates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Rate",
                table: "Products",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.CreateTable(
                name: "ProductRates",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: false),
                    Rate = table.Column<byte>(type: "tinyint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedUserId = table.Column<int>(type: "int", nullable: true),
                    DeletedByUserId = table.Column<int>(type: "int", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductRates", x => new { x.ProductId, x.CreatedByUserId });
                    table.ForeignKey(
                        name: "FK_ProductRates_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductRates_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "Membership",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductRates_Users_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "Membership",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductRates_CreatedByUserId",
                table: "ProductRates",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductRates_DeletedByUserId",
                table: "ProductRates",
                column: "DeletedByUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductRates");

            migrationBuilder.AlterColumn<decimal>(
                name: "Rate",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
