using Microsoft.EntityFrameworkCore.Migrations;

namespace CulinarySite.Dal.Migrations
{
    public partial class ChangedClassStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VideoUrl",
                table: "Episodes",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VideoUrl",
                table: "Episodes");
        }
    }
}
