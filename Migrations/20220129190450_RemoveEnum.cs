using Microsoft.EntityFrameworkCore.Migrations;

namespace Raducu_Alexandru_Gabriel_Proiect.Migrations
{
    public partial class RemoveEnum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EventStatus",
                table: "Event",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "EventStatus",
                table: "Event",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
