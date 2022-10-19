using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeliveriamoRepository.Migrations
{
    public partial class fixOrderStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderStatus",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "LastUpdate",
                table: "OrderStatus",
                newName: "StatusTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StatusTime",
                table: "OrderStatus",
                newName: "LastUpdate");

            migrationBuilder.AddColumn<string>(
                name: "OrderStatus",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
