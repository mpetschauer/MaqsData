using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaqsData.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "NeckalaceTotalValue",
                table: "Inventorys",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "entryDate",
                table: "Inventorys",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "entryDate",
                table: "Inventorys");

            migrationBuilder.AlterColumn<int>(
                name: "NeckalaceTotalValue",
                table: "Inventorys",
                type: "int",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);
        }
    }
}
