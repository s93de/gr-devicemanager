using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class FixColidtype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "id",
                table: "Machines",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "Machines",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
