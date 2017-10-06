using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VF_API.Migrations
{
    public partial class addenglish : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Revenue",
                newName: "NameVI");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ProductionCapacity",
                newName: "NameVI");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "CompanySize",
                newName: "NameVI");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "CharterCapital",
                newName: "NameVI");

            migrationBuilder.AddColumn<string>(
                name: "NameEN",
                table: "Revenue",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameEN",
                table: "ProductionCapacity",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameEN",
                table: "CompanySize",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameEN",
                table: "CharterCapital",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameEN",
                table: "Revenue");

            migrationBuilder.DropColumn(
                name: "NameEN",
                table: "ProductionCapacity");

            migrationBuilder.DropColumn(
                name: "NameEN",
                table: "CompanySize");

            migrationBuilder.DropColumn(
                name: "NameEN",
                table: "CharterCapital");

            migrationBuilder.RenameColumn(
                name: "NameVI",
                table: "Revenue",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "NameVI",
                table: "ProductionCapacity",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "NameVI",
                table: "CompanySize",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "NameVI",
                table: "CharterCapital",
                newName: "Name");
        }
    }
}
