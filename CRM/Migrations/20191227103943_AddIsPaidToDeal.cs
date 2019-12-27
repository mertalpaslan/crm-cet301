using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM.Migrations
{
    public partial class AddIsPaidToDeal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_paid",
                table: "Deals",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_paid",
                table: "Deals");
        }
    }
}
