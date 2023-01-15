using Microsoft.EntityFrameworkCore.Migrations;

namespace Stelina.Domain.Migrations
{
    public partial class BlogPostLikes_CreatedByUserIdNullableCancelled : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPostLikes_Users_CreatedByUserId",
                table: "BlogPostLikes");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedByUserId",
                table: "BlogPostLikes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPostLikes_Users_CreatedByUserId",
                table: "BlogPostLikes",
                column: "CreatedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPostLikes_Users_CreatedByUserId",
                table: "BlogPostLikes");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedByUserId",
                table: "BlogPostLikes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPostLikes_Users_CreatedByUserId",
                table: "BlogPostLikes",
                column: "CreatedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
