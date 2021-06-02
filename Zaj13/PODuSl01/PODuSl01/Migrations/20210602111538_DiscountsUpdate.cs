using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PODuSl01.Migrations
{
    public partial class DiscountsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Discounts_brands_BrandId",
                table: "Discounts");

            migrationBuilder.AlterColumn<int>(
                name: "BrandId",
                table: "Discounts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Discounts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateFrom",
                table: "Discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTo",
                table: "Discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "DicountProcent",
                table: "Discounts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Discounts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_CategoryId",
                table: "Discounts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_ProductId",
                table: "Discounts",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Discounts_brands_BrandId",
                table: "Discounts",
                column: "BrandId",
                principalSchema: "production",
                principalTable: "brands",
                principalColumn: "brand_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Discounts_categories_CategoryId",
                table: "Discounts",
                column: "CategoryId",
                principalSchema: "production",
                principalTable: "categories",
                principalColumn: "category_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Discounts_products_ProductId",
                table: "Discounts",
                column: "ProductId",
                principalSchema: "production",
                principalTable: "products",
                principalColumn: "product_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Discounts_brands_BrandId",
                table: "Discounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Discounts_categories_CategoryId",
                table: "Discounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Discounts_products_ProductId",
                table: "Discounts");

            migrationBuilder.DropIndex(
                name: "IX_Discounts_CategoryId",
                table: "Discounts");

            migrationBuilder.DropIndex(
                name: "IX_Discounts_ProductId",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "DateFrom",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "DateTo",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "DicountProcent",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Discounts");

            migrationBuilder.AlterColumn<int>(
                name: "BrandId",
                table: "Discounts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Discounts_brands_BrandId",
                table: "Discounts",
                column: "BrandId",
                principalSchema: "production",
                principalTable: "brands",
                principalColumn: "brand_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
