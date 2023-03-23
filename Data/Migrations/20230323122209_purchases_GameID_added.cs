using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamesPlatform.Data.Migrations
{
    /// <inheritdoc />
    public partial class purchasesGameIDadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GameID",
                table: "Purchases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_GameID",
                table: "Purchases",
                column: "GameID");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Games_GameID",
                table: "Purchases",
                column: "GameID",
                principalTable: "Games",
                principalColumn: "GameID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Games_GameID",
                table: "Purchases");

            migrationBuilder.DropIndex(
                name: "IX_Purchases_GameID",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "GameID",
                table: "Purchases");
        }
    }
}
