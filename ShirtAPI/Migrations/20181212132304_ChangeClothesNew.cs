using Microsoft.EntityFrameworkCore.Migrations;

namespace ShirtAPI.Migrations
{
    public partial class ChangeClothesNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clothes_Type_TypeId1",
                table: "Clothes");

            migrationBuilder.DropForeignKey(
                name: "FK_Clothes_Type_TypeIdId",
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

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Clothes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Clothes_TypeId",
                table: "Clothes",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clothes_Type_TypeId",
                table: "Clothes",
                column: "TypeId",
                principalTable: "Type",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clothes_Type_TypeId",
                table: "Clothes");

            migrationBuilder.DropIndex(
                name: "IX_Clothes_TypeId",
                table: "Clothes");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Clothes");

            migrationBuilder.AddColumn<int>(
                name: "TypeId1",
                table: "Clothes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TypeIdId",
                table: "Clothes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clothes_TypeId1",
                table: "Clothes",
                column: "TypeId1");

            migrationBuilder.CreateIndex(
                name: "IX_Clothes_TypeIdId",
                table: "Clothes",
                column: "TypeIdId");

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
    }
}
