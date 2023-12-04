using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrackMoney.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedballanceToUsersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Ballance",
                table: "Users",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ballance",
                table: "Users");
        }
    }
}
