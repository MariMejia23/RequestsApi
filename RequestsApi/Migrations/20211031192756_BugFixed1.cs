using Microsoft.EntityFrameworkCore.Migrations;

namespace RequestsApi.Migrations
{
    public partial class BugFixed1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Request_Status_StatusId1",
                table: "Request");

            migrationBuilder.DropIndex(
                name: "IX_Request_StatusId1",
                table: "Request");

            migrationBuilder.DropColumn(
                name: "StatusId1",
                table: "Request");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusId1",
                table: "Request",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Request_StatusId1",
                table: "Request",
                column: "StatusId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Request_Status_StatusId1",
                table: "Request",
                column: "StatusId1",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
