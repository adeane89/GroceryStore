using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GroceryStore.Data.Migrations
{
    public partial class UpdatedModelsCartProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroceryProduct_GroceryProductCart_GroceryProductCartID",
                table: "GroceryProduct");

            migrationBuilder.DropIndex(
                name: "IX_GroceryProduct_GroceryProductCartID",
                table: "GroceryProduct");

            migrationBuilder.DropColumn(
                name: "GroceryProductCartID",
                table: "GroceryProduct");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserID",
                table: "GroceryProductCart",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "GroceryProductCart",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateLastModified",
                table: "GroceryProductCart",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GroceryProductsID",
                table: "GroceryProductCart",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "GroceryCartProducts",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateLastModified",
                table: "GroceryCartProducts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GroceryProductCart_ApplicationUserID",
                table: "GroceryProductCart",
                column: "ApplicationUserID");

            migrationBuilder.CreateIndex(
                name: "IX_GroceryProductCart_GroceryProductsID",
                table: "GroceryProductCart",
                column: "GroceryProductsID");

            migrationBuilder.AddForeignKey(
                name: "FK_GroceryProductCart_AspNetUsers_ApplicationUserID",
                table: "GroceryProductCart",
                column: "ApplicationUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GroceryProductCart_GroceryProduct_GroceryProductsID",
                table: "GroceryProductCart",
                column: "GroceryProductsID",
                principalTable: "GroceryProduct",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroceryProductCart_AspNetUsers_ApplicationUserID",
                table: "GroceryProductCart");

            migrationBuilder.DropForeignKey(
                name: "FK_GroceryProductCart_GroceryProduct_GroceryProductsID",
                table: "GroceryProductCart");

            migrationBuilder.DropIndex(
                name: "IX_GroceryProductCart_ApplicationUserID",
                table: "GroceryProductCart");

            migrationBuilder.DropIndex(
                name: "IX_GroceryProductCart_GroceryProductsID",
                table: "GroceryProductCart");

            migrationBuilder.DropColumn(
                name: "ApplicationUserID",
                table: "GroceryProductCart");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "GroceryProductCart");

            migrationBuilder.DropColumn(
                name: "DateLastModified",
                table: "GroceryProductCart");

            migrationBuilder.DropColumn(
                name: "GroceryProductsID",
                table: "GroceryProductCart");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "GroceryCartProducts");

            migrationBuilder.DropColumn(
                name: "DateLastModified",
                table: "GroceryCartProducts");

            migrationBuilder.AddColumn<int>(
                name: "GroceryProductCartID",
                table: "GroceryProduct",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GroceryProduct_GroceryProductCartID",
                table: "GroceryProduct",
                column: "GroceryProductCartID");

            migrationBuilder.AddForeignKey(
                name: "FK_GroceryProduct_GroceryProductCart_GroceryProductCartID",
                table: "GroceryProduct",
                column: "GroceryProductCartID",
                principalTable: "GroceryProductCart",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
