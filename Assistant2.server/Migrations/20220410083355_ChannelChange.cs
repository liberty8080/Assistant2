using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assistant2.Migrations
{
    public partial class ChannelChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Port",
                table: "chanify_channel");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "chanify_channel",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "chanify_channel");

            migrationBuilder.AddColumn<int>(
                name: "Port",
                table: "chanify_channel",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
