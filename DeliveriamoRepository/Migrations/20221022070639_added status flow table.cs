using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeliveriamoRepository.Migrations
{
    public partial class addedstatusflowtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StatusFlow",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    NextStatusId = table.Column<int>(type: "int", nullable: true),
                    CanceledStatusId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusFlow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatusFlow_Status_CanceledStatusId",
                        column: x => x.CanceledStatusId,
                        principalTable: "Status",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StatusFlow_Status_NextStatusId",
                        column: x => x.NextStatusId,
                        principalTable: "Status",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StatusFlow_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_StatusFlow_CanceledStatusId",
                table: "StatusFlow",
                column: "CanceledStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_StatusFlow_NextStatusId",
                table: "StatusFlow",
                column: "NextStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_StatusFlow_StatusId",
                table: "StatusFlow",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StatusFlow");
        }
    }
}
