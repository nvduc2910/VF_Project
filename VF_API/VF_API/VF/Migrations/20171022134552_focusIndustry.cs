using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace VF_API.Migrations
{
    public partial class focusIndustry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FocusIndustryId",
                table: "Profile",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleteProfile",
                table: "User",
                nullable: false,
                defaultValue: false);

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

            migrationBuilder.CreateIndex(
                name: "IX_Profile_FocusIndustryId",
                table: "Profile",
                column: "FocusIndustryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Profile_FocusIndustry_FocusIndustryId",
                table: "Profile",
                column: "FocusIndustryId",
                principalTable: "FocusIndustry",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profile_FocusIndustry_FocusIndustryId",
                table: "Profile");

            migrationBuilder.DropTable(
                name: "FocusIndustry");

            migrationBuilder.DropIndex(
                name: "IX_Profile_FocusIndustryId",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "FocusIndustryId",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "IsCompleteProfile",
                table: "User");
        }
    }
}
