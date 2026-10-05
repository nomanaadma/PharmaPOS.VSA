using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PharmaPOS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPurchaseTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "medicine_purchase",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    supplier = table.Column<int>(type: "integer", nullable: false),
                    date = table.Column<DateTime>(type: "date", nullable: false),
                    total = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    tax = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    discount_value = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    amount = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    note = table.Column<string>(type: "text", nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicine_purchase", x => x.id);
                    table.ForeignKey(
                        name: "FK_medicine_purchase_suppliers_supplier",
                        column: x => x.supplier,
                        principalTable: "suppliers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "medicine_batch",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    batch = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    expiry = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    pqty = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    qty = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    saleprice = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    purchaseprice = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    gross = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    discounttype = table.Column<int>(type: "integer", nullable: false),
                    discount = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    discountvalue = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    tax = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    taxprice = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    price = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    sold = table.Column<decimal>(type: "numeric(10,2)", nullable: false, defaultValue: 0m),
                    medicine_id = table.Column<int>(type: "integer", nullable: false),
                    purchase_id = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicine_batch", x => x.id);
                    table.ForeignKey(
                        name: "FK_medicine_batch_medicine_purchase_purchase_id",
                        column: x => x.purchase_id,
                        principalTable: "medicine_purchase",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_medicine_batch_medicines_medicine_id",
                        column: x => x.medicine_id,
                        principalTable: "medicines",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_medicine_batch_medicine_id",
                table: "medicine_batch",
                column: "medicine_id");

            migrationBuilder.CreateIndex(
                name: "IX_medicine_batch_purchase_id",
                table: "medicine_batch",
                column: "purchase_id");

            migrationBuilder.CreateIndex(
                name: "IX_medicine_purchase_supplier",
                table: "medicine_purchase",
                column: "supplier");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "medicine_batch");

            migrationBuilder.DropTable(
                name: "medicine_purchase");
        }
    }
}
