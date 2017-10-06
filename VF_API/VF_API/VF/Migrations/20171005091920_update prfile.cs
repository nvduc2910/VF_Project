using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace VF_API.Migrations
{
    public partial class updateprfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CharterCapitalId",
                table: "Profile",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompanySizeId",
                table: "Profile",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Lat",
                table: "Profile",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Lng",
                table: "Profile",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "MarketId",
                table: "Profile",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductionCapacityId",
                table: "Profile",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RevenueId",
                table: "Profile",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TypicalProduct",
                table: "Profile",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CharterCapital",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharterCapital", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanySize",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanySize", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Market",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Market", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductionCapacity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionCapacity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Revenue",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Revenue", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Profile_CharterCapitalId",
                table: "Profile",
                column: "CharterCapitalId");

            migrationBuilder.CreateIndex(
                name: "IX_Profile_CompanySizeId",
                table: "Profile",
                column: "CompanySizeId");

            migrationBuilder.CreateIndex(
                name: "IX_Profile_MarketId",
                table: "Profile",
                column: "MarketId");

            migrationBuilder.CreateIndex(
                name: "IX_Profile_ProductionCapacityId",
                table: "Profile",
                column: "ProductionCapacityId");

            migrationBuilder.CreateIndex(
                name: "IX_Profile_RevenueId",
                table: "Profile",
                column: "RevenueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Profile_CharterCapital_CharterCapitalId",
                table: "Profile",
                column: "CharterCapitalId",
                principalTable: "CharterCapital",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Profile_CompanySize_CompanySizeId",
                table: "Profile",
                column: "CompanySizeId",
                principalTable: "CompanySize",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Profile_Market_MarketId",
                table: "Profile",
                column: "MarketId",
                principalTable: "Market",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Profile_ProductionCapacity_ProductionCapacityId",
                table: "Profile",
                column: "ProductionCapacityId",
                principalTable: "ProductionCapacity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Profile_Revenue_RevenueId",
                table: "Profile",
                column: "RevenueId",
                principalTable: "Revenue",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profile_CharterCapital_CharterCapitalId",
                table: "Profile");

            migrationBuilder.DropForeignKey(
                name: "FK_Profile_CompanySize_CompanySizeId",
                table: "Profile");

            migrationBuilder.DropForeignKey(
                name: "FK_Profile_Market_MarketId",
                table: "Profile");

            migrationBuilder.DropForeignKey(
                name: "FK_Profile_ProductionCapacity_ProductionCapacityId",
                table: "Profile");

            migrationBuilder.DropForeignKey(
                name: "FK_Profile_Revenue_RevenueId",
                table: "Profile");

            migrationBuilder.DropTable(
                name: "CharterCapital");

            migrationBuilder.DropTable(
                name: "CompanySize");

            migrationBuilder.DropTable(
                name: "Market");

            migrationBuilder.DropTable(
                name: "ProductionCapacity");

            migrationBuilder.DropTable(
                name: "Revenue");

            migrationBuilder.DropIndex(
                name: "IX_Profile_CharterCapitalId",
                table: "Profile");

            migrationBuilder.DropIndex(
                name: "IX_Profile_CompanySizeId",
                table: "Profile");

            migrationBuilder.DropIndex(
                name: "IX_Profile_MarketId",
                table: "Profile");

            migrationBuilder.DropIndex(
                name: "IX_Profile_ProductionCapacityId",
                table: "Profile");

            migrationBuilder.DropIndex(
                name: "IX_Profile_RevenueId",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "CharterCapitalId",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "CompanySizeId",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "Lat",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "Lng",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "MarketId",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "ProductionCapacityId",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "RevenueId",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "TypicalProduct",
                table: "Profile");
        }
    }
}
