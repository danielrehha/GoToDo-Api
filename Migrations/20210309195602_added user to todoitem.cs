using Microsoft.EntityFrameworkCore.Migrations;

namespace gotodo_api.Migrations
{
    public partial class addedusertotodoitem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_todoItems_UserId",
                table: "todoItems",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_todoItems_users_UserId",
                table: "todoItems",
                column: "UserId",
                principalTable: "users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_todoItems_users_UserId",
                table: "todoItems");

            migrationBuilder.DropIndex(
                name: "IX_todoItems_UserId",
                table: "todoItems");
        }
    }
}
