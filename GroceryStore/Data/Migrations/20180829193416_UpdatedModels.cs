using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GroceryStore.Data.Migrations
{
    public partial class UpdatedModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GroceryProducts",
                table: "GroceryProducts");

            migrationBuilder.RenameTable(
                name: "GroceryProducts",
                newName: "GroceryProduct");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "GroceryProduct",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroceryProduct",
                table: "GroceryProduct",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_GroceryProduct_Name",
                table: "GroceryProduct",
                column: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_GroceryProduct_Categories_Name",
                table: "GroceryProduct",
                column: "Name",
                principalTable: "Categories",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroceryProduct_Categories_Name",
                table: "GroceryProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroceryProduct",
                table: "GroceryProduct");

            migrationBuilder.DropIndex(
                name: "IX_GroceryProduct_Name",
                table: "GroceryProduct");

            migrationBuilder.RenameTable(
                name: "GroceryProduct",
                newName: "GroceryProducts");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "GroceryProducts",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroceryProducts",
                table: "GroceryProducts",
                column: "ID");
        }
    }
}
