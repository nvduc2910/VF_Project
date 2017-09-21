using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace VF_API.Migrations
{
    public partial class addconverstationagain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Converstation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LastDate = table.Column<DateTime>(nullable: false),
                    LastMessage = table.Column<string>(nullable: true),
                    RecevierId = table.Column<int>(nullable: false),
                    SenderId = table.Column<int>(nullable: false),
                    TotalMessage = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Converstation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Converstation_User_RecevierId",
                        column: x => x.RecevierId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Converstation_User_SenderId",
                        column: x => x.SenderId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Converstation_RecevierId",
                table: "Converstation",
                column: "RecevierId");

            migrationBuilder.CreateIndex(
                name: "IX_Converstation_SenderId",
                table: "Converstation",
                column: "SenderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Converstation");
        }
    }
}
