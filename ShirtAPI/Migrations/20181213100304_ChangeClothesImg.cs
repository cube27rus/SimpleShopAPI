using Microsoft.EntityFrameworkCore.Migrations;

namespace ShirtAPI.Migrations
{
    public partial class ChangeClothesImg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Img",
                table: "Clothes");

            migrationBuilder.AddColumn<int>(
                name: "ClothesId",
                table: "Images",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Images_ClothesId",
                table: "Images",
                column: "ClothesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Clothes_ClothesId",
                table: "Images",
                column: "ClothesId",
                principalTable: "Clothes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Clothes_ClothesId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_ClothesId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "ClothesId",
                table: "Images");

            migrationBuilder.AddColumn<string>(
                name: "Img",
                table: "Clothes",
                nullable: true);
        }
    }
}
