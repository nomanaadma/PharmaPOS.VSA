using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PharmaPOS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TotalToSubTotalInPurchase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "total",
                table: "medicine_purchase",
                newName: "sub_total");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "sub_total",
                table: "medicine_purchase",
                newName: "total");
        }
    }
}
