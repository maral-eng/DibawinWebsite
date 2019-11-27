using Microsoft.EntityFrameworkCore.Migrations;

namespace DibawinWebsite.Migrations
{
    public partial class mig3fillTablesSkillsANDJobsTitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "JobsTitle",
                columns: new[] { "Id", "Comment", "DefinedByUserId", "LatinTitle", "ModifiedByUsers", "Title" },
                values: new object[] { 1, null, null, "Back-End developer", null, "برنامه نویس بک اند" });

            migrationBuilder.InsertData(
                table: "JobsTitle",
                columns: new[] { "Id", "Comment", "DefinedByUserId", "LatinTitle", "ModifiedByUsers", "Title" },
                values: new object[] { 2, null, null, "Front-End developer", null, "برنامه نویس فرانت اند" });

            migrationBuilder.InsertData(
                table: "JobsTitle",
                columns: new[] { "Id", "Comment", "DefinedByUserId", "LatinTitle", "ModifiedByUsers", "Title" },
                values: new object[] { 3, null, null, "Full-Stack developer", null, "برنامه نویس فول استک" });

            migrationBuilder.InsertData(
                table: "JobsTitle",
                columns: new[] { "Id", "Comment", "DefinedByUserId", "LatinTitle", "ModifiedByUsers", "Title" },
                values: new object[] { 4, null, null, "System Support", null, "پشتیبان نرم افزار" });

            migrationBuilder.InsertData(
                table: "JobsTitle",
                columns: new[] { "Id", "Comment", "DefinedByUserId", "LatinTitle", "ModifiedByUsers", "Title" },
                values: new object[] { 5, null, null, "Software Engineer", null, "مهندس نرم افزار" });

            migrationBuilder.InsertData(
                table: "JobsTitle",
                columns: new[] { "Id", "Comment", "DefinedByUserId", "LatinTitle", "ModifiedByUsers", "Title" },
                values: new object[] { 6, null, null, "Senior developer", null, "برنامه نویس ارشد" });

            migrationBuilder.InsertData(
                table: "JobsTitle",
                columns: new[] { "Id", "Comment", "DefinedByUserId", "LatinTitle", "ModifiedByUsers", "Title" },
                values: new object[] { 7, null, null, "Junior developer", null, "برنامه نویس مبتدی" });

            migrationBuilder.InsertData(
                table: "JobsTitle",
                columns: new[] { "Id", "Comment", "DefinedByUserId", "LatinTitle", "ModifiedByUsers", "Title" },
                values: new object[] { 8, null, null, "Mid-Level developer", null, "برنامه نویس میان سطح" });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "DefinedByUserId", "LatinTitle", "ModifiedByUsers", "Title" },
                values: new object[] { 11, null, "UX", null, "UX" });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "DefinedByUserId", "LatinTitle", "ModifiedByUsers", "Title" },
                values: new object[] { 10, null, "UI", null, "UI" });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "DefinedByUserId", "LatinTitle", "ModifiedByUsers", "Title" },
                values: new object[] { 9, null, "Angular", null, "Angular" });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "DefinedByUserId", "LatinTitle", "ModifiedByUsers", "Title" },
                values: new object[] { 8, null, "React Js", null, "React Js" });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "DefinedByUserId", "LatinTitle", "ModifiedByUsers", "Title" },
                values: new object[] { 7, null, "MVC", null, "MVC" });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "DefinedByUserId", "LatinTitle", "ModifiedByUsers", "Title" },
                values: new object[] { 3, null, "HTML5", null, "HTML5" });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "DefinedByUserId", "LatinTitle", "ModifiedByUsers", "Title" },
                values: new object[] { 5, null, "JavaScript", null, "JavaScript" });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "DefinedByUserId", "LatinTitle", "ModifiedByUsers", "Title" },
                values: new object[] { 4, null, "CSS3", null, "CSS3" });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "DefinedByUserId", "LatinTitle", "ModifiedByUsers", "Title" },
                values: new object[] { 12, null, "MS SQL Server", null, "MS SQL Server" });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "DefinedByUserId", "LatinTitle", "ModifiedByUsers", "Title" },
                values: new object[] { 2, null, "C#", null, "C#" });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "DefinedByUserId", "LatinTitle", "ModifiedByUsers", "Title" },
                values: new object[] { 1, null, "ASP.Net Core", null, "ASP.Net Core" });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "DefinedByUserId", "LatinTitle", "ModifiedByUsers", "Title" },
                values: new object[] { 6, null, "JQuery", null, "JQuery" });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "DefinedByUserId", "LatinTitle", "ModifiedByUsers", "Title" },
                values: new object[] { 13, null, "Python", null, "Python" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "JobsTitle",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "JobsTitle",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "JobsTitle",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "JobsTitle",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "JobsTitle",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "JobsTitle",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "JobsTitle",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "JobsTitle",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 13);
        }
    }
}
