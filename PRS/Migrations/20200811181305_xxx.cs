using Microsoft.EntityFrameworkCore.Migrations;

namespace PRS.Migrations
{
    public partial class xxx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Request_UserId",
                table: "Request",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Request_User_UserId",
                table: "Request",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Request_User_UserId",
                table: "Request");

            migrationBuilder.DropIndex(
                name: "IX_Request_UserId",
                table: "Request");
        }
    }
}
