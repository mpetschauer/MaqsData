using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaqsData.Migrations
{
    public partial class addinventoryentries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EntryType",
                table: "InventoryEntries",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EntryType",
                table: "InventoryEntries");
        }
    }
}
