using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GroceryStore.Data.Migrations
{
    public partial class FixingGPMProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_GroceryProductCart_ApplicationUserID",
                table: "GroceryProductCart");

            migrationBuilder.AddColumn<int>(
                name: "GroceryProductCartID",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_GroceryProductCart_ApplicationUserID",
                table: "GroceryProductCart",
                column: "ApplicationUserID",
                unique: true,
                filter: "[ApplicationUserID] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_GroceryProductCart_ApplicationUserID",
                table: "GroceryProductCart");

            migrationBuilder.DropColumn(
                name: "GroceryProductCartID",
                table: "AspNetUsers");

            migrationBuilder.CreateIndex(
                name: "IX_GroceryProductCart_ApplicationUserID",
                table: "GroceryProductCart",
                column: "ApplicationUserID");
        }
    }
}
