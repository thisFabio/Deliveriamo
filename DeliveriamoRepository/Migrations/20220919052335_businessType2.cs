using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeliveriamoRepository.Migrations
{
    public partial class businessType2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_User_BusinessTypeId",
                table: "User",
                column: "BusinessTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_BusinessType_BusinessTypeId",
                table: "User",
                column: "BusinessTypeId",
                principalTable: "BusinessType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_BusinessType_BusinessTypeId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_BusinessTypeId",
                table: "User");
        }
    }
}
