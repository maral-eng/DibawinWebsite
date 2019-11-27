using Microsoft.EntityFrameworkCore.Migrations;

namespace DibawinWebsite.Migrations
{
    public partial class mig5fixProjectaddPriceField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Projects",
                type: "Money",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Projects");
        }
    }
}
