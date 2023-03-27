using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamesPlatform.Data.Migrations
{
    /// <inheritdoc />
    public partial class CasinoResult : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CasinoResults",
                columns: table => new
                {
                    ResultID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserChoice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComputerChoice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Result = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Win = table.Column<bool>(type: "bit", nullable: false),
                    AmountWon = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateResultPlaced = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CasinoResults", x => x.ResultID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CasinoResults");
        }
    }
}
