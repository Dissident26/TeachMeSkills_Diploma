using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBase.Migrations
{
    /// <inheritdoc />
    public partial class changeAuthFieldsNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RegistrationDate",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_RepliedComments_CommentId",
                table: "RepliedComments");

            migrationBuilder.DropIndex(
                name: "IX_AuthorisedUsers_Email",
                table: "AuthorisedUsers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "AuthorisedUsers",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RepliedComments_CommentId_RepliedCommentId",
                table: "RepliedComments",
                columns: new[] { "CommentId", "RepliedCommentId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AuthorisedUsers_Name",
                table: "AuthorisedUsers",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RepliedComments_CommentId_RepliedCommentId",
                table: "RepliedComments");

            migrationBuilder.DropIndex(
                name: "IX_AuthorisedUsers_Name",
                table: "AuthorisedUsers");

            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "AuthorisedUsers",
                newName: "Email");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RegistrationDate",
                table: "Users",
                column: "RegistrationDate",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RepliedComments_CommentId",
                table: "RepliedComments",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorisedUsers_Email",
                table: "AuthorisedUsers",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");
        }
    }
}
