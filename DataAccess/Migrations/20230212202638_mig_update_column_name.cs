using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class mig_update_column_name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "User",
                table: "Comments",
                newName: "CommentUser");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Comments",
                newName: "CommentContent");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CommentUser",
                table: "Comments",
                newName: "User");

            migrationBuilder.RenameColumn(
                name: "CommentContent",
                table: "Comments",
                newName: "Content");
        }
    }
}
