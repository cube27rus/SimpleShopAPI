using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShirtAPI.Migrations
{
    public partial class ChangeClothes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Clothes");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Clothes",
                newName: "CategoryId");

            migrationBuilder.AddColumn<int>(
                name: "TypeId1",
                table: "Clothes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TypeIdId",
                table: "Clothes",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Type",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clothes_CategoryId",
                table: "Clothes",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Clothes_TypeId1",
                table: "Clothes",
                column: "TypeId1");

            migrationBuilder.CreateIndex(
                name: "IX_Clothes_TypeIdId",
                table: "Clothes",
                column: "TypeIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clothes_Category_CategoryId",
                table: "Clothes",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clothes_Type_TypeId1",
                table: "Clothes",
                column: "TypeId1",
                principalTable: "Type",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clothes_Type_TypeIdId",
                table: "Clothes",
                column: "TypeIdId",
                principalTable: "Type",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clothes_Category_CategoryId",
                table: "Clothes");

            migrationBuilder.DropForeignKey(
                name: "FK_Clothes_Type_TypeId1",
                table: "Clothes");

            migrationBuilder.DropForeignKey(
                name: "FK_Clothes_Type_TypeIdId",
                table: "Clothes");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Type");

            migrationBuilder.DropIndex(
                name: "IX_Clothes_CategoryId",
                table: "Clothes");

            migrationBuilder.DropIndex(
                name: "IX_Clothes_TypeId1",
                table: "Clothes");

            migrationBuilder.DropIndex(
                name: "IX_Clothes_TypeIdId",
                table: "Clothes");

            migrationBuilder.DropColumn(
                name: "TypeId1",
                table: "Clothes");

            migrationBuilder.DropColumn(
                name: "TypeIdId",
                table: "Clothes");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Clothes",
                newName: "Type");

            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "Clothes",
                nullable: false,
                defaultValue: 0);
        }
    }
}
