using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeliveriamoRepository.Migrations
{
    public partial class fixedUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShopKeeperType");

            migrationBuilder.DropColumn(
                name: "BusinessTypeName",
                table: "User");

            migrationBuilder.AddColumn<int>(
                name: "BusinessTypeId",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BusinessTypeId",
                table: "User");

            migrationBuilder.AddColumn<string>(
                name: "BusinessTypeName",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ShopKeeperType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopKeeperType", x => x.Id);
                });
        }
    }
}
