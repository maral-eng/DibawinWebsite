using Microsoft.EntityFrameworkCore.Migrations;

namespace DibawinWebsite.Migrations
{
    public partial class mig4fixProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Technologies",
                table: "Projects",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Technologies",
                table: "Projects");
        }
    }
}
