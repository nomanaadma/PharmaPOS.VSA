using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PharmaPOS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddMedicinesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "gender",
                table: "customers",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.CreateTable(
                name: "medicines",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    company = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    generic = table.Column<string>(type: "text", nullable: false),
                    medicine_group = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    category = table.Column<int>(type: "integer", nullable: false),
                    storebox = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    minlevel = table.Column<decimal>(type: "numeric", nullable: true),
                    reorderlevel = table.Column<decimal>(type: "numeric", nullable: true),
                    unit = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    unitpacking = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    note = table.Column<string>(type: "text", nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicines", x => x.id);
                    table.ForeignKey(
                        name: "FK_medicines_medicine_categories_category",
                        column: x => x.category,
                        principalTable: "medicine_categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_medicines_category",
                table: "medicines",
                column: "category");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "medicines");

            migrationBuilder.AlterColumn<string>(
                name: "gender",
                table: "customers",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20,
                oldNullable: true);
        }
    }
}
