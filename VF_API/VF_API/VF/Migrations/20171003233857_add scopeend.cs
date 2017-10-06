using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VF_API.Migrations
{
    public partial class addscopeend : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ScopeBusiness",
                newName: "NameVI");

            migrationBuilder.AddColumn<string>(
                name: "NameEN",
                table: "ScopeBusiness",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameEN",
                table: "ScopeBusiness");

            migrationBuilder.RenameColumn(
                name: "NameVI",
                table: "ScopeBusiness",
                newName: "Name");
        }
    }
}
