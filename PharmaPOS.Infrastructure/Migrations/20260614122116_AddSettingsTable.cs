using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PharmaPOS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSettingsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "settings",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    logo = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    logo_icon = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    lg_background = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    favicon = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    legal_name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    mail = table.Column<string>(type: "character varying(254)", maxLength: 254, nullable: false),
                    phone = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    city = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    country = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    address_line1 = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    address_line2 = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    postal = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_settings", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "settings");
        }
    }
}
