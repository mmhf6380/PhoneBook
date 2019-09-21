using Microsoft.EntityFrameworkCore.Migrations;

namespace Phonebook.DAL.EF.Migrations
{
    public partial class Email_isNot_Uinicode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "People",
                unicode: false,
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "People",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 200);
        }
    }
}
