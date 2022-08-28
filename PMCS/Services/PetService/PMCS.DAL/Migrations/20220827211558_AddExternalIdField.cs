using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PMCS.DAL.Migrations
{
    public partial class AddExternalIdField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Owners",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Owners");
        }
    }
}
