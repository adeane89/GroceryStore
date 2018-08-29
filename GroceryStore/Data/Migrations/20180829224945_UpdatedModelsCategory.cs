using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GroceryStore.Data.Migrations
{
    public partial class UpdatedModelsCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroceryProductCartID",
                table: "GroceryProduct",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GroceryProductCart",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroceryProductCart", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GroceryCartProducts",
                columns: table => new
                {
                    GroceryCartProductID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GroceryProductCartID = table.Column<int>(nullable: true),
                    GroceryProductsModelID = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroceryCartProducts", x => x.GroceryCartProductID);
                    table.ForeignKey(
                        name: "FK_GroceryCartProducts_GroceryProductCart_GroceryProductCartID",
                        column: x => x.GroceryProductCartID,
                        principalTable: "GroceryProductCart",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GroceryCartProducts_GroceryProduct_GroceryProductsModelID",
                        column: x => x.GroceryProductsModelID,
                        principalTable: "GroceryProduct",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroceryProduct_GroceryProductCartID",
                table: "GroceryProduct",
                column: "GroceryProductCartID");

            migrationBuilder.CreateIndex(
                name: "IX_GroceryCartProducts_GroceryProductCartID",
                table: "GroceryCartProducts",
                column: "GroceryProductCartID");

            migrationBuilder.CreateIndex(
                name: "IX_GroceryCartProducts_GroceryProductsModelID",
                table: "GroceryCartProducts",
                column: "GroceryProductsModelID");

            migrationBuilder.AddForeignKey(
                name: "FK_GroceryProduct_GroceryProductCart_GroceryProductCartID",
                table: "GroceryProduct",
                column: "GroceryProductCartID",
                principalTable: "GroceryProductCart",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroceryProduct_GroceryProductCart_GroceryProductCartID",
                table: "GroceryProduct");

            migrationBuilder.DropTable(
                name: "GroceryCartProducts");

            migrationBuilder.DropTable(
                name: "GroceryProductCart");

            migrationBuilder.DropIndex(
                name: "IX_GroceryProduct_GroceryProductCartID",
                table: "GroceryProduct");

            migrationBuilder.DropColumn(
                name: "GroceryProductCartID",
                table: "GroceryProduct");
        }
    }
}
