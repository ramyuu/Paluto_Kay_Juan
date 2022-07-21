using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Paluto_Kay_Juan.Migrations
{
    public partial class UserOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CustomerContact = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    PaymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainDishOrder = table.Column<string>(type: "nvarchar(max)", maxLength: 99999, nullable: false),
                    AppetizersOrder = table.Column<string>(type: "nvarchar(max)", maxLength: 99999, nullable: false),
                    DessertOrder = table.Column<string>(type: "nvarchar(max)", maxLength: 99999, nullable: false),
                    DrinksOrder = table.Column<string>(type: "nvarchar(max)", maxLength: 99999, nullable: false),
                    VenueLocation = table.Column<string>(type: "nvarchar(100)",maxLength: 100, nullable: false),
                    CateringDate = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderDate = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
