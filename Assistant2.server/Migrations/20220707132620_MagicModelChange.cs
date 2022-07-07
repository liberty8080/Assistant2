using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assistant2.Migrations
{
    public partial class MagicModelChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BandwidthLeft",
                table: "MagicSubscribes");

            migrationBuilder.RenameColumn(
                name: "ExpirationTime",
                table: "MagicSubscribes",
                newName: "RocketRegex");

            migrationBuilder.RenameColumn(
                name: "Data",
                table: "MagicSubscribes",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RocketRegex",
                table: "MagicSubscribes",
                newName: "ExpirationTime");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "MagicSubscribes",
                newName: "Data");

            migrationBuilder.AddColumn<string>(
                name: "BandwidthLeft",
                table: "MagicSubscribes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
