using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GroceryStore.Data.Migrations
{
    public partial class AddingName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "GroceryCartProducts",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "GroceryCartProducts",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "GroceryCartProducts");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "GroceryCartProducts");
        }
    }
}
