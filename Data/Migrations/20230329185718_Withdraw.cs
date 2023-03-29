using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamesPlatform.Data.Migrations
{
    /// <inheritdoc />
    public partial class Withdraw : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Withdraws",
                columns: table => new
                {
                    WithdrawID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WalletID = table.Column<int>(type: "int", nullable: false),
                    AmountTransfered = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PayPalEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PayPalBatchID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WithdrawDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Withdraws", x => x.WithdrawID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Withdraws");
        }
    }
}
