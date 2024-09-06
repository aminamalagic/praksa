using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreatee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UsersGenders_UserGenderId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UsersTypes_UserTypeId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserGenderId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserTypeId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserGenderId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserTypeId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "User_gender_id",
                table: "Users",
                newName: "user_gender_id");

            migrationBuilder.AlterColumn<int>(
                name: "user_gender_id",
                table: "Users",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "User_gender_id",
                table: "Users",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Users_user_gender_id",
                table: "Users",
                column: "user_gender_id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_User_type_id",
                table: "Users",
                column: "User_type_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UsersGenders_user_gender_id",
                table: "Users",
                column: "user_gender_id",
                principalTable: "UsersGenders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UsersTypes_User_type_id",
                table: "Users",
                column: "User_type_id",
                principalTable: "UsersTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UsersGenders_user_gender_id",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UsersTypes_User_type_id",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_user_gender_id",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_User_type_id",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "User_gender_id",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "user_gender_id",
                table: "Users",
                newName: "User_gender_id");

            migrationBuilder.AlterColumn<long>(
                name: "User_gender_id",
                table: "Users",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "UserGenderId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UserTypeId",
                table: "Users",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserGenderId",
                table: "Users",
                column: "UserGenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserTypeId",
                table: "Users",
                column: "UserTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UsersGenders_UserGenderId",
                table: "Users",
                column: "UserGenderId",
                principalTable: "UsersGenders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UsersTypes_UserTypeId",
                table: "Users",
                column: "UserTypeId",
                principalTable: "UsersTypes",
                principalColumn: "Id");
        }
    }
}
