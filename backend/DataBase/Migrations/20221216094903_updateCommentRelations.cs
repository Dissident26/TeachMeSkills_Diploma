using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBase.Migrations
{
    /// <inheritdoc />
    public partial class updateCommentRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments_RepliedCommentId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_RepliedCommentId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "RepliedCommentId",
                table: "Comments");

            migrationBuilder.CreateTable(
                name: "RepliedComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentId = table.Column<int>(type: "int", nullable: false),
                    RepliedCommentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepliedComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RepliedComments_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RepliedComments_CommentId",
                table: "RepliedComments",
                column: "CommentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RepliedComments");

            migrationBuilder.AddColumn<int>(
                name: "RepliedCommentId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_RepliedCommentId",
                table: "Comments",
                column: "RepliedCommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments_RepliedCommentId",
                table: "Comments",
                column: "RepliedCommentId",
                principalTable: "Comments",
                principalColumn: "Id");
        }
    }
}
