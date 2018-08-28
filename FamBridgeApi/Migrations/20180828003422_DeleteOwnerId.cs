using Microsoft.EntityFrameworkCore.Migrations;

namespace FamBridgeApi.Migrations
{
    public partial class DeleteOwnerId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Cases");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Cases",
                nullable: true);
        }
    }
}
