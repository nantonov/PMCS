using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Schedule.Infrastructure.Migrations
{
    public partial class AddIsTriggeredField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsTriggered",
                table: "Reminders",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsTriggered",
                table: "Reminders");
        }
    }
}
