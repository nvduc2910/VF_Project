using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace VF_API.Migrations
{
    public partial class profile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "User",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Profile",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    ApplicationUserId = table.Column<int>(nullable: false),
                    ApplicationUserId1 = table.Column<int>(nullable: true),
                    CompanyDesciption = table.Column<string>(nullable: true),
                    CompanyName = table.Column<string>(nullable: true),
                    CustomerName = table.Column<string>(nullable: true),
                    EmailContact = table.Column<string>(nullable: true),
                    FoundedYear = table.Column<int>(nullable: false),
                    PhoneNumberContact = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    ProductDescription = table.Column<string>(nullable: true),
                    ProductRequirement = table.Column<string>(nullable: true),
                    RoleId = table.Column<int>(nullable: false),
                    TotalProductNeeded = table.Column<int>(nullable: false),
                    Vision = table.Column<string>(nullable: true),
                    WebSite = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profile_User_ApplicationUserId1",
                        column: x => x.ApplicationUserId1,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProfileScopeBusiness",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProfileId = table.Column<int>(nullable: false),
                    ScopeBusinessId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileScopeBusiness", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfileScopeBusiness_Profile_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfileScopeBusiness_ScopeBusiness_ScopeBusinessId",
                        column: x => x.ScopeBusinessId,
                        principalTable: "ScopeBusiness",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Profile_ApplicationUserId1",
                table: "Profile",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileScopeBusiness_ProfileId",
                table: "ProfileScopeBusiness",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileScopeBusiness_ScopeBusinessId",
                table: "ProfileScopeBusiness",
                column: "ScopeBusinessId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfileScopeBusiness");

            migrationBuilder.DropTable(
                name: "Profile");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "User");
        }
    }
}
