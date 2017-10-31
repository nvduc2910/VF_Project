using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace VF_API.Migrations
{
    public partial class addfocusinsry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FocusIndustry",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NameEN = table.Column<string>(nullable: true),
                    NameVI = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FocusIndustry", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProfileFocusIndustry",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FocusIndustryId = table.Column<int>(nullable: false),
                    ProfileId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileFocusIndustry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfileFocusIndustry_FocusIndustry_FocusIndustryId",
                        column: x => x.FocusIndustryId,
                        principalTable: "FocusIndustry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfileFocusIndustry_Profile_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProfileFocusIndustry_FocusIndustryId",
                table: "ProfileFocusIndustry",
                column: "FocusIndustryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileFocusIndustry_ProfileId",
                table: "ProfileFocusIndustry",
                column: "ProfileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfileFocusIndustry");

            migrationBuilder.DropTable(
                name: "FocusIndustry");
        }
    }
}
