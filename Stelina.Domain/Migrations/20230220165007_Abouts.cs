using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stelina.Domain.Migrations
{
    public partial class Abouts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AboutCompany",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BoldText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FreeDeliveryText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoneyGuaranteeText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OnlineSupportText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutCompany", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutCompany");
        }
    }
}
