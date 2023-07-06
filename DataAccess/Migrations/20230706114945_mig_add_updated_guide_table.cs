using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class mig_add_updated_guide_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Destinations_GuideId",
                table: "Destinations");

            migrationBuilder.CreateIndex(
                name: "IX_Destinations_GuideId",
                table: "Destinations",
                column: "GuideId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Destinations_GuideId",
                table: "Destinations");

            migrationBuilder.CreateIndex(
                name: "IX_Destinations_GuideId",
                table: "Destinations",
                column: "GuideId",
                unique: true,
                filter: "[GuideId] IS NOT NULL");
        }
    }
}
