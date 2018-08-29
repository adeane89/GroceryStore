using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GroceryStore.Data.Migrations
{
    public partial class FixingFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroceryCartProducts_GroceryProduct_GroceryProductsModelID",
                table: "GroceryCartProducts");

            migrationBuilder.DropIndex(
                name: "IX_GroceryCartProducts_GroceryProductsModelID",
                table: "GroceryCartProducts");

            migrationBuilder.RenameColumn(
                name: "GroceryProductsModelID",
                table: "GroceryCartProducts",
                newName: "GroceryProductID");

            migrationBuilder.AddColumn<int>(
                name: "GroceryProductsID",
                table: "GroceryCartProducts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GroceryCartProducts_GroceryProductsID",
                table: "GroceryCartProducts",
                column: "GroceryProductsID");

            migrationBuilder.AddForeignKey(
                name: "FK_GroceryCartProducts_GroceryProduct_GroceryProductsID",
                table: "GroceryCartProducts",
                column: "GroceryProductsID",
                principalTable: "GroceryProduct",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroceryCartProducts_GroceryProduct_GroceryProductsID",
                table: "GroceryCartProducts");

            migrationBuilder.DropIndex(
                name: "IX_GroceryCartProducts_GroceryProductsID",
                table: "GroceryCartProducts");

            migrationBuilder.DropColumn(
                name: "GroceryProductsID",
                table: "GroceryCartProducts");

            migrationBuilder.RenameColumn(
                name: "GroceryProductID",
                table: "GroceryCartProducts",
                newName: "GroceryProductsModelID");

            migrationBuilder.CreateIndex(
                name: "IX_GroceryCartProducts_GroceryProductsModelID",
                table: "GroceryCartProducts",
                column: "GroceryProductsModelID");

            migrationBuilder.AddForeignKey(
                name: "FK_GroceryCartProducts_GroceryProduct_GroceryProductsModelID",
                table: "GroceryCartProducts",
                column: "GroceryProductsModelID",
                principalTable: "GroceryProduct",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
