using Microsoft.EntityFrameworkCore.Migrations;

namespace Stelina.Domain.Migrations
{
    public partial class BlogPost_IsLiked_LikeCount_Deleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_BlogPosts_BlogPostId",
                schema: "Membership",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_BlogPostId",
                schema: "Membership",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BlogPostId",
                schema: "Membership",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LikeCount",
                table: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "isLiked",
                table: "BlogPosts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BlogPostId",
                schema: "Membership",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LikeCount",
                table: "BlogPosts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "isLiked",
                table: "BlogPosts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Users_BlogPostId",
                schema: "Membership",
                table: "Users",
                column: "BlogPostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_BlogPosts_BlogPostId",
                schema: "Membership",
                table: "Users",
                column: "BlogPostId",
                principalTable: "BlogPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
