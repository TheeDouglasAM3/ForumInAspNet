using Microsoft.EntityFrameworkCore.Migrations;

namespace ForumAspNetCore3._1.Data.Migrations
{
    public partial class alternamecontentfromcommenttabletocontenttext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "Comment");

            migrationBuilder.AddColumn<string>(
                name: "ContentText",
                table: "Comment",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentText",
                table: "Comment");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Comment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
