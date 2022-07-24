using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeliveriamoRepository.Migrations
{
    public partial class fixeduser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Dob", "Enabled", "Firstname", "Gender", "Lastname", "Password", "RoleId", "Username" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null, null, 0, null });
        }
    }
}
