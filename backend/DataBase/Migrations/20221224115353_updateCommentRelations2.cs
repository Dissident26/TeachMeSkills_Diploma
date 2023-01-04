using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBase.Migrations
{
    /// <inheritdoc />
    public partial class updateCommentRelations2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RepliedComments_Comments_CommentId",
                table: "RepliedComments");

            migrationBuilder.CreateIndex(
                name: "IX_RepliedComments_RepliedCommentId",
                table: "RepliedComments",
                column: "RepliedCommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_RepliedComments_Comments_CommentId",
                table: "RepliedComments",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RepliedComments_Comments_RepliedCommentId",
                table: "RepliedComments",
                column: "RepliedCommentId",
                principalTable: "Comments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RepliedComments_Comments_CommentId",
                table: "RepliedComments");

            migrationBuilder.DropForeignKey(
                name: "FK_RepliedComments_Comments_RepliedCommentId",
                table: "RepliedComments");

            migrationBuilder.DropIndex(
                name: "IX_RepliedComments_RepliedCommentId",
                table: "RepliedComments");

            migrationBuilder.AddForeignKey(
                name: "FK_RepliedComments_Comments_CommentId",
                table: "RepliedComments",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id");
        }
    }
}
