using Microsoft.EntityFrameworkCore.Migrations;

namespace PRS.Migrations
{
    public partial class initMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Request_User_UserId",
                table: "Request");

            migrationBuilder.DropForeignKey(
                name: "FK_Requestline_Product_ProductsId",
                table: "Requestline");

            migrationBuilder.DropForeignKey(
                name: "FK_Requestline_Request_RequestsId",
                table: "Requestline");

            migrationBuilder.DropIndex(
                name: "IX_Requestline_ProductsId",
                table: "Requestline");

            migrationBuilder.DropIndex(
                name: "IX_Requestline_RequestsId",
                table: "Requestline");

            migrationBuilder.DropIndex(
                name: "IX_Request_UserId",
                table: "Request");

            migrationBuilder.DropColumn(
                name: "ProductsId",
                table: "Requestline");

            migrationBuilder.DropColumn(
                name: "RequestsId",
                table: "Requestline");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Requestline",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RequestId",
                table: "Requestline",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Requestline_ProductId",
                table: "Requestline",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Requestline_RequestId",
                table: "Requestline",
                column: "RequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requestline_Product_ProductId",
                table: "Requestline",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requestline_Request_RequestId",
                table: "Requestline",
                column: "RequestId",
                principalTable: "Request",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requestline_Product_ProductId",
                table: "Requestline");

            migrationBuilder.DropForeignKey(
                name: "FK_Requestline_Request_RequestId",
                table: "Requestline");

            migrationBuilder.DropIndex(
                name: "IX_Requestline_ProductId",
                table: "Requestline");

            migrationBuilder.DropIndex(
                name: "IX_Requestline_RequestId",
                table: "Requestline");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Requestline");

            migrationBuilder.DropColumn(
                name: "RequestId",
                table: "Requestline");

            migrationBuilder.AddColumn<int>(
                name: "ProductsId",
                table: "Requestline",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RequestsId",
                table: "Requestline",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Requestline_ProductsId",
                table: "Requestline",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_Requestline_RequestsId",
                table: "Requestline",
                column: "RequestsId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Requestline_Product_ProductsId",
                table: "Requestline",
                column: "ProductsId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requestline_Request_RequestsId",
                table: "Requestline",
                column: "RequestsId",
                principalTable: "Request",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
