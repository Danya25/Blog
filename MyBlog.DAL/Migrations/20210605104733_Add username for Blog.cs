using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBlog.DAL.Migrations
{
    public partial class AddusernameforBlog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username",
                table: "Blogs");
        }
    }
}
