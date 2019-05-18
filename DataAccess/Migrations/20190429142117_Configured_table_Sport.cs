using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class Configured_table_Sport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Sports",
                table: "Sports");

            migrationBuilder.RenameTable(
                name: "Sports",
                newName: "BaseEntity");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "BaseEntity",
                maxLength: 32,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "BaseEntity",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BaseEntity",
                table: "BaseEntity",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BaseEntity",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "BaseEntity");

            migrationBuilder.RenameTable(
                name: "BaseEntity",
                newName: "Sports");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Sports",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 32);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sports",
                table: "Sports",
                column: "Id");
        }
    }
}
