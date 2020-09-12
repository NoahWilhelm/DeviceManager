using Microsoft.EntityFrameworkCore.Migrations;

namespace DeviceManager.Core.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    Entry_Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Id = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    DeviceTypeId = table.Column<string>(nullable: true),
                    Failsafe = table.Column<bool>(nullable: false),
                    TempMin = table.Column<int>(nullable: false),
                    TempMax = table.Column<int>(nullable: false),
                    InstallationPosition = table.Column<string>(nullable: true),
                    InsertInto19InchCabinet = table.Column<bool>(nullable: false),
                    MotionEnable = table.Column<bool>(nullable: false),
                    SiplusCatalog = table.Column<bool>(nullable: false),
                    SimaticCatalog = table.Column<bool>(nullable: false),
                    RotationAxisNumber = table.Column<int>(nullable: false),
                    positionAxisNumber = table.Column<int>(nullable: false),
                    AdvancedEnvironmentalConditions = table.Column<bool>(nullable: false),
                    TerminalElement = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.Entry_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Devices");
        }
    }
}
