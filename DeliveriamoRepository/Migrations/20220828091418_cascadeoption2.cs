using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeliveriamoRepository.Migrations
{
    public partial class cascadeoption2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProduct_User_UserId",
                table: "UserProduct");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProduct_User_UserId",
                table: "UserProduct",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProduct_User_UserId",
                table: "UserProduct");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProduct_User_UserId",
                table: "UserProduct",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
