using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Paluto_Kay_Juan.Migrations
{
    public partial class addImageUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FoodImgUrl",
                table: "Menus",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FoodImgUrl",
                table: "Menus");
        }
    }
}
