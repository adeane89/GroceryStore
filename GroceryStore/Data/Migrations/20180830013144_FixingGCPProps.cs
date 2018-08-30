using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GroceryStore.Data.Migrations
{
    public partial class FixingGCPProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GroceryCartProducts",
                table: "GroceryCartProducts");

            migrationBuilder.AlterColumn<int>(
                name: "GroceryCartProductID",
                table: "GroceryCartProducts",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "GroceryCartProducts",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroceryCartProducts",
                table: "GroceryCartProducts",
                column: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GroceryCartProducts",
                table: "GroceryCartProducts");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "GroceryCartProducts");

            migrationBuilder.AlterColumn<int>(
                name: "GroceryCartProductID",
                table: "GroceryCartProducts",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroceryCartProducts",
                table: "GroceryCartProducts",
                column: "GroceryCartProductID");
        }
    }
}
