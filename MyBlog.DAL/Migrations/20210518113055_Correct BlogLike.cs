using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBlog.DAL.Migrations
{
    public partial class CorrectBlogLike : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BlogLikes",
                table: "BlogLikes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "BlogLikes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlogLikes",
                table: "BlogLikes",
                columns: new[] { "BlogId", "UserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_BlogLikes_Blogs_BlogId",
                table: "BlogLikes",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogLikes_Blogs_BlogId",
                table: "BlogLikes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BlogLikes",
                table: "BlogLikes");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "BlogLikes",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlogLikes",
                table: "BlogLikes",
                column: "Id");
        }
    }
}
