using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace VF_API.Migrations
{
    public partial class addProductPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Profile",
                newName: "PriceId");

            migrationBuilder.AddColumn<int>(
                name: "ProductPriceId",
                table: "Profile",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProductPrice",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NameEN = table.Column<int>(nullable: false),
                    NameVI = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPrice", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Profile_ProductPriceId",
                table: "Profile",
                column: "ProductPriceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Profile_ProductPrice_ProductPriceId",
                table: "Profile",
                column: "ProductPriceId",
                principalTable: "ProductPrice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profile_ProductPrice_ProductPriceId",
                table: "Profile");

            migrationBuilder.DropTable(
                name: "ProductPrice");

            migrationBuilder.DropIndex(
                name: "IX_Profile_ProductPriceId",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "ProductPriceId",
                table: "Profile");

            migrationBuilder.RenameColumn(
                name: "PriceId",
                table: "Profile",
                newName: "Price");
        }
    }
}
