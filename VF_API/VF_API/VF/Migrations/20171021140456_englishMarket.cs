using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VF_API.Migrations
{
    public partial class englishMarket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Market",
                newName: "NameVI");

            migrationBuilder.AddColumn<string>(
                name: "NameEN",
                table: "Market",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameEN",
                table: "Market");

            migrationBuilder.RenameColumn(
                name: "NameVI",
                table: "Market",
                newName: "Name");
        }
    }
}
