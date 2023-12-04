using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrackMoney.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRelationshipsBetweenCurrencyAndTransactions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Expenses",
                table: "Currencies");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Expenses",
                table: "Currencies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
