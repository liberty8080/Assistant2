using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assistant2.Migrations
{
    public partial class TableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_magic_subscribe",
                table: "magic_subscribe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_chanify_channel",
                table: "chanify_channel");

            migrationBuilder.RenameTable(
                name: "magic_subscribe",
                newName: "MagicSubscribes");

            migrationBuilder.RenameTable(
                name: "chanify_channel",
                newName: "ChanifyChannels");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MagicSubscribes",
                table: "MagicSubscribes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChanifyChannels",
                table: "ChanifyChannels",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MagicSubscribes",
                table: "MagicSubscribes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChanifyChannels",
                table: "ChanifyChannels");

            migrationBuilder.RenameTable(
                name: "MagicSubscribes",
                newName: "magic_subscribe");

            migrationBuilder.RenameTable(
                name: "ChanifyChannels",
                newName: "chanify_channel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_magic_subscribe",
                table: "magic_subscribe",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_chanify_channel",
                table: "chanify_channel",
                column: "Id");
        }
    }
}
