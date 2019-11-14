using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DibawinWebsite.Migrations
{
    public partial class mig1projectsclientsfeature : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    LatinTitle = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    RegDateTime = table.Column<DateTime>(nullable: false),
                    DefinedByUserId = table.Column<string>(nullable: true),
                    ModifiedByUsers = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    ClientCode = table.Column<string>(nullable: true),
                    ManagerFullName = table.Column<string>(nullable: true),
                    IsRealPersonality = table.Column<bool>(nullable: false),
                    Logo = table.Column<byte[]>(nullable: true),
                    LogoTiny = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_AspNetUsers_DefinedByUserId",
                        column: x => x.DefinedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clients_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    LatinTitle = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    RegDateTime = table.Column<DateTime>(nullable: false),
                    DefinedByUserId = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    Image = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientAddress",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<bool>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    RegDateTime = table.Column<DateTime>(nullable: false),
                    DefinedByUserId = table.Column<string>(nullable: true),
                    ModifiedByUsers = table.Column<string>(nullable: true),
                    ClientId = table.Column<int>(nullable: false),
                    CityId = table.Column<int>(nullable: true),
                    ProvinceId = table.Column<int>(nullable: true),
                    CountryId = table.Column<int>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Telephone = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Fax = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    Coordinates = table.Column<string>(nullable: true),
                    SocialMediaLinks = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientAddress_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientAddress_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientAddress_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientAddress_AspNetUsers_DefinedByUserId",
                        column: x => x.DefinedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientAddress_Province_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Province",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
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
                    ProjectManagerFullName = table.Column<string>(nullable: true),
                    ProjectManagerId = table.Column<string>(nullable: true),
                    Collaborators = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false, defaultValue: false),
                    CategoryId = table.Column<int>(nullable: false),
                    ClientId = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Start = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projects_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Projects_AspNetUsers_DefinedByUserId",
                        column: x => x.DefinedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Projects_AspNetUsers_ProjectManagerId",
                        column: x => x.ProjectManagerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectsFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProjectId = table.Column<int>(nullable: false),
                    FeatureId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectsFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectsFeatures_Features_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectsFeatures_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectsImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    LatinTitle = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    RegDateTime = table.Column<DateTime>(nullable: false),
                    DefinedByUserId = table.Column<string>(nullable: true),
                    ProjectId = table.Column<int>(nullable: false),
                    BigImage = table.Column<byte[]>(nullable: true),
                    BigImagePath = table.Column<string>(nullable: true),
                    Image = table.Column<byte[]>(nullable: true),
                    ImagePath = table.Column<string>(nullable: true),
                    ImageThumbnail = table.Column<byte[]>(nullable: true),
                    ImageThumbnailPath = table.Column<string>(nullable: true),
                    ImageTinyThumbnail = table.Column<byte[]>(nullable: true),
                    ImageTinyThumbnailPath = table.Column<string>(nullable: true),
                    VolumeSize = table.Column<string>(nullable: true),
                    DimensionSize = table.Column<string>(nullable: true),
                    GrayScale = table.Column<bool>(nullable: false),
                    Compressed = table.Column<bool>(nullable: false),
                    IsMainImage = table.Column<bool>(nullable: false),
                    ImageFormat = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectsImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectsImages_AspNetUsers_DefinedByUserId",
                        column: x => x.DefinedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectsImages_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientAddress_CityId",
                table: "ClientAddress",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientAddress_ClientId",
                table: "ClientAddress",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientAddress_CountryId",
                table: "ClientAddress",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientAddress_DefinedByUserId",
                table: "ClientAddress",
                column: "DefinedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientAddress_ProvinceId",
                table: "ClientAddress",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_DefinedByUserId",
                table: "Clients",
                column: "DefinedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_UserId",
                table: "Clients",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CategoryId",
                table: "Projects",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ClientId",
                table: "Projects",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_DefinedByUserId",
                table: "Projects",
                column: "DefinedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectManagerId",
                table: "Projects",
                column: "ProjectManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectsFeatures_FeatureId",
                table: "ProjectsFeatures",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectsFeatures_ProjectId",
                table: "ProjectsFeatures",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectsImages_DefinedByUserId",
                table: "ProjectsImages",
                column: "DefinedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectsImages_ProjectId",
                table: "ProjectsImages",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientAddress");

            migrationBuilder.DropTable(
                name: "ProjectsFeatures");

            migrationBuilder.DropTable(
                name: "ProjectsImages");

            migrationBuilder.DropTable(
                name: "Features");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
