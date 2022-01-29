using Microsoft.EntityFrameworkCore.Migrations;

namespace Raducu_Alexandru_Gabriel_Proiect.Migrations
{
    public partial class LocationChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocationID",
                table: "Event",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Event_LocationID",
                table: "Event",
                column: "LocationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Location_LocationID",
                table: "Event",
                column: "LocationID",
                principalTable: "Location",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_Location_LocationID",
                table: "Event");

            migrationBuilder.DropIndex(
                name: "IX_Event_LocationID",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "LocationID",
                table: "Event");
        }
    }
}
