using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudApi.Migrations
{
    /// <inheritdoc />
    public partial class OnetoMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Username_Users_UserId",
                table: "Username");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Username",
                table: "Username");

            migrationBuilder.RenameTable(
                name: "Username",
                newName: "Usernames");

            migrationBuilder.RenameIndex(
                name: "IX_Username_UserId",
                table: "Usernames",
                newName: "IX_Usernames_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usernames",
                table: "Usernames",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usernames_Users_UserId",
                table: "Usernames",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usernames_Users_UserId",
                table: "Usernames");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usernames",
                table: "Usernames");

            migrationBuilder.RenameTable(
                name: "Usernames",
                newName: "Username");

            migrationBuilder.RenameIndex(
                name: "IX_Usernames_UserId",
                table: "Username",
                newName: "IX_Username_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Username",
                table: "Username",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Username_Users_UserId",
                table: "Username",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
