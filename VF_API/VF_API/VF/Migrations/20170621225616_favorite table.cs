using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VF_API.Migrations
{
    public partial class favoritetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteProduct_User_ApplicationUserId",
                table: "FavoriteProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteProduct_Product_ProductId",
                table: "FavoriteProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FavoriteProduct",
                table: "FavoriteProduct");

            migrationBuilder.RenameTable(
                name: "FavoriteProduct",
                newName: "FavoritesProduct");

            migrationBuilder.RenameIndex(
                name: "IX_FavoriteProduct_ProductId",
                table: "FavoritesProduct",
                newName: "IX_FavoritesProduct_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_FavoriteProduct_ApplicationUserId",
                table: "FavoritesProduct",
                newName: "IX_FavoritesProduct_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FavoritesProduct",
                table: "FavoritesProduct",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FavoritesProduct_User_ApplicationUserId",
                table: "FavoritesProduct",
                column: "ApplicationUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FavoritesProduct_Product_ProductId",
                table: "FavoritesProduct",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavoritesProduct_User_ApplicationUserId",
                table: "FavoritesProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoritesProduct_Product_ProductId",
                table: "FavoritesProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FavoritesProduct",
                table: "FavoritesProduct");

            migrationBuilder.RenameTable(
                name: "FavoritesProduct",
                newName: "FavoriteProduct");

            migrationBuilder.RenameIndex(
                name: "IX_FavoritesProduct_ProductId",
                table: "FavoriteProduct",
                newName: "IX_FavoriteProduct_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_FavoritesProduct_ApplicationUserId",
                table: "FavoriteProduct",
                newName: "IX_FavoriteProduct_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FavoriteProduct",
                table: "FavoriteProduct",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteProduct_User_ApplicationUserId",
                table: "FavoriteProduct",
                column: "ApplicationUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteProduct_Product_ProductId",
                table: "FavoriteProduct",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
