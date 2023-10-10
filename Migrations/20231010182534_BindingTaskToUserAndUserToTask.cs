using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskSystem.Migrations
{
    /// <inheritdoc />
    public partial class BindingTaskToUserAndUserToTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tasks_UserId",
                table: "Tasks");

            migrationBuilder.AddColumn<int>(
                name: "UserModelId",
                table: "Tasks",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UserId",
                table: "Tasks",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UserModelId",
                table: "Tasks",
                column: "UserModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Users_UserModelId",
                table: "Tasks",
                column: "UserModelId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Users_UserModelId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_UserId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_UserModelId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "UserModelId",
                table: "Tasks");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UserId",
                table: "Tasks",
                column: "UserId");
        }
    }
}
