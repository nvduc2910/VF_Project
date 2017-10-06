using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VF_API.Migrations
{
    public partial class addroleId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_ScopeBusiness_ScopeBusinessIdId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_ScopeBusinessIdId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ScopeBusinessIdId",
                table: "User");

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "User",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ScopeBusinessId",
                table: "User",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ScopeBusinessId",
                table: "User");

            migrationBuilder.AddColumn<int>(
                name: "ScopeBusinessIdId",
                table: "User",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_ScopeBusinessIdId",
                table: "User",
                column: "ScopeBusinessIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_ScopeBusiness_ScopeBusinessIdId",
                table: "User",
                column: "ScopeBusinessIdId",
                principalTable: "ScopeBusiness",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
