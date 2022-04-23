using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assistant2.Migrations
{
    public partial class MagicSubChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AutoUpdate",
                table: "magic_subscribe");

            migrationBuilder.DropColumn(
                name: "UpdateInterval",
                table: "magic_subscribe");

            migrationBuilder.RenameColumn(
                name: "Site",
                table: "magic_subscribe",
                newName: "Cron");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cron",
                table: "magic_subscribe",
                newName: "Site");

            migrationBuilder.AddColumn<bool>(
                name: "AutoUpdate",
                table: "magic_subscribe",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "UpdateInterval",
                table: "magic_subscribe",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
