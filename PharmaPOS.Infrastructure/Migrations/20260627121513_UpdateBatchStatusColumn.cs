using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PharmaPOS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBatchStatusColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "status",
                table: "medicine_batch",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "status",
                table: "medicine_batch",
                type: "integer",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(bool),
                oldType: "boolean");
        }
    }
}
