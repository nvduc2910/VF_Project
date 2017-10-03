using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VF_API.Migrations
{
    public partial class updateprofile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AboutMe",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Job",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Languages",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lat",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocationName",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Long",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Paymeninfo",
                table: "User",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AboutMe",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Job",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Languages",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Lat",
                table: "User");

            migrationBuilder.DropColumn(
                name: "LocationName",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Long",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Paymeninfo",
                table: "User");
        }
    }
}
