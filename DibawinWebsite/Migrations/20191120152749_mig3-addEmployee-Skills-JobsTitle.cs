using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DibawinWebsite.Migrations
{
    public partial class mig3addEmployeeSkillsJobsTitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    LatinTitle = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false, defaultValue: true),
                    RegDateTime = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    DefinedByUserId = table.Column<string>(nullable: true),
                    ModifiedByUsers = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    Skills = table.Column<string>(nullable: true),
                    JobTitles = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_AspNetUsers_DefinedByUserId",
                        column: x => x.DefinedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employee_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JobsTitle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    LatinTitle = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false, defaultValue: true),
                    RegDateTime = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    DefinedByUserId = table.Column<string>(nullable: true),
                    ModifiedByUsers = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobsTitle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobsTitle_AspNetUsers_DefinedByUserId",
                        column: x => x.DefinedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    LatinTitle = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false, defaultValue: true),
                    RegDateTime = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    DefinedByUserId = table.Column<string>(nullable: true),
                    ModifiedByUsers = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skills_AspNetUsers_DefinedByUserId",
                        column: x => x.DefinedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DefinedByUserId",
                table: "Employee",
                column: "DefinedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_UserId",
                table: "Employee",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_JobsTitle_DefinedByUserId",
                table: "JobsTitle",
                column: "DefinedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_DefinedByUserId",
                table: "Skills",
                column: "DefinedByUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "JobsTitle");

            migrationBuilder.DropTable(
                name: "Skills");
        }
    }
}
