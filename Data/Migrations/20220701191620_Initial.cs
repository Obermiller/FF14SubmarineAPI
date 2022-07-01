using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rank = table.Column<int>(type: "int", nullable: false),
                    Components = table.Column<int>(type: "int", nullable: false),
                    Surveillance = table.Column<int>(type: "int", nullable: false),
                    Retrieval = table.Column<int>(type: "int", nullable: false),
                    Speed = table.Column<int>(type: "int", nullable: false),
                    Range = table.Column<int>(type: "int", nullable: false),
                    Favor = table.Column<int>(type: "int", nullable: false),
                    Materials = table.Column<int>(type: "int", nullable: false),
                    Desynthesizable = table.Column<bool>(type: "bit", nullable: false),
                    ShopSellingPrice = table.Column<int>(type: "int", nullable: false),
                    SellingPrice = table.Column<int>(type: "int", nullable: false),
                    MarketboardProhibited = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Submarines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rank = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Submarines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Submarine_Part",
                columns: table => new
                {
                    SubmarineId = table.Column<int>(type: "int", nullable: false),
                    PartId = table.Column<int>(type: "int", nullable: false),
                    Dye = table.Column<int>(type: "int", nullable: false),
                    Condition = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Submarine_Part", x => new { x.SubmarineId, x.PartId });
                    table.ForeignKey(
                        name: "FK_Submarine_Part_Parts_PartId",
                        column: x => x.PartId,
                        principalTable: "Parts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Submarine_Part_Submarines_SubmarineId",
                        column: x => x.SubmarineId,
                        principalTable: "Submarines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "Components", "Description", "Desynthesizable", "Favor", "MarketboardProhibited", "Materials", "Name", "Range", "Rank", "Retrieval", "SellingPrice", "ShopSellingPrice", "Speed", "Surveillance", "Type" },
                values: new object[,]
                {
                    { 1, 5, "Comprising the center of a shark-class submersible, this ovoid hull is multi-walled to stabilize and maintain pressure within so that the vessel's crew does not succumb to the crushing weight of the waters it navigates. Several sturdy rudder fins serve to increase maneuverability.", false, 20, true, 1, "Shark-class Pressure Hull", 40, 1, 30, 16, 0, 20, -10, 1 },
                    { 2, 5, "Comprising the rear end of a shark-class submersible, this stern contains the unique independent engine which propels the craft.", false, 15, true, 1, "Shark-class Stern", 30, 1, 20, 16, 0, 60, -30, 2 },
                    { 3, 5, "Comprising the front end of a shark-class submersible, this bow has been reinforced to double as a battering ram for subduing unruly sea creatures.", false, 15, true, 1, "Shark-class Bow", -20, 1, 40, 16, 0, 10, 50, 3 },
                    { 4, 5, "Comprising the top of a shark-class submersible, the bridge houses all of the equipment necessary for the vessel's crew to navigate the unplumbed depths of the Ruby Sea and beyond.", false, 20, true, 1, "Shark-class Bridge", 20, 1, 20, 16, 0, 20, 20, 4 }
                });

            migrationBuilder.InsertData(
                table: "Submarines",
                columns: new[] { "Id", "Name", "Rank" },
                values: new object[] { 1, "Base Sub", 1 });

            migrationBuilder.InsertData(
                table: "Submarine_Part",
                columns: new[] { "PartId", "SubmarineId", "Condition", "Dye" },
                values: new object[,]
                {
                    { 1, 1, 100, 2 },
                    { 2, 1, 100, 2 },
                    { 3, 1, 100, 2 },
                    { 4, 1, 100, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Submarine_Part_PartId",
                table: "Submarine_Part",
                column: "PartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Submarine_Part");

            migrationBuilder.DropTable(
                name: "Parts");

            migrationBuilder.DropTable(
                name: "Submarines");
        }
    }
}
