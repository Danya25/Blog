using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBlog.DAL.Migrations
{
    public partial class CorrectBlogLikev2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_BlogLikes_UserId",
                table: "BlogLikes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogLikes_Users_UserId",
                table: "BlogLikes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogLikes_Users_UserId",
                table: "BlogLikes");

            migrationBuilder.DropIndex(
                name: "IX_BlogLikes_UserId",
                table: "BlogLikes");
        }
    }
}
