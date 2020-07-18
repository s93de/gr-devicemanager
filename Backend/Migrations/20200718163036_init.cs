using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace Backend.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Machines",
                columns: table => new
                {
                    machineId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    id = table.Column<int>(nullable: false),
                    name = table.Column<string>(nullable: false),
                    deviceTypeId = table.Column<string>(nullable: false),
                    failsafe = table.Column<bool>(nullable: false),
                    tempMin = table.Column<int>(nullable: false),
                    tempMax = table.Column<int>(nullable: false),
                    installationPosition = table.Column<string>(nullable: false),
                    insertInto19InchCabinet = table.Column<bool>(nullable: false),
                    motionEnable = table.Column<bool>(nullable: false),
                    siplusCatalog = table.Column<bool>(nullable: false),
                    simaticCatalog = table.Column<bool>(nullable: false),
                    rotationAxisNumber = table.Column<int>(nullable: false),
                    positionAxisNumber = table.Column<int>(nullable: false),
                    terminalElement = table.Column<bool>(nullable: true),
                    advancedEnvironmentalConditions = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machines", x => x.machineId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Machines");
        }
    }
}
