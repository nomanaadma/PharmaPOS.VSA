using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PharmaPOS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePaymentMethodStatusToBoolean : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "payment_method");

            migrationBuilder.AddColumn<bool>(
                name: "status",
                table: "payment_method",
                type: "boolean",
                nullable: false,
                defaultValue: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "payment_method");

            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "payment_method",
                type: "integer",
                nullable: false,
                defaultValue: 1);
        }
    }
}
