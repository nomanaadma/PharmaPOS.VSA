using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PharmaPOS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddBillAndBillItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "medicine_bill",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    customer_id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    email = table.Column<string>(type: "character varying(254)", maxLength: 254, nullable: true),
                    mobile = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    method = table.Column<int>(type: "integer", nullable: false),
                    bill_date = table.Column<DateTime>(type: "date", nullable: false),
                    subtotal = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    tax = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    discount_value = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    amount = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    note = table.Column<string>(type: "text", nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicine_bill", x => x.id);
                    table.ForeignKey(
                        name: "FK_medicine_bill_customers_customer_id",
                        column: x => x.customer_id,
                        principalTable: "customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_medicine_bill_payment_method_method",
                        column: x => x.method,
                        principalTable: "payment_method",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "bill_items",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    bill_id = table.Column<int>(type: "integer", nullable: false),
                    medicine_id = table.Column<int>(type: "integer", nullable: false),
                    batch = table.Column<int>(type: "integer", nullable: false),
                    qty = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    saleprice = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    gross = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    discounttype = table.Column<int>(type: "integer", nullable: false),
                    discount = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    discountvalue = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    tax = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    taxprice = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    price = table.Column<decimal>(type: "numeric(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bill_items", x => x.id);
                    table.ForeignKey(
                        name: "FK_bill_items_medicine_batch_batch",
                        column: x => x.batch,
                        principalTable: "medicine_batch",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bill_items_medicine_bill_bill_id",
                        column: x => x.bill_id,
                        principalTable: "medicine_bill",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bill_items_medicines_medicine_id",
                        column: x => x.medicine_id,
                        principalTable: "medicines",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bill_items_batch",
                table: "bill_items",
                column: "batch");

            migrationBuilder.CreateIndex(
                name: "IX_bill_items_bill_id",
                table: "bill_items",
                column: "bill_id");

            migrationBuilder.CreateIndex(
                name: "IX_bill_items_medicine_id",
                table: "bill_items",
                column: "medicine_id");

            migrationBuilder.CreateIndex(
                name: "IX_medicine_bill_customer_id",
                table: "medicine_bill",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_medicine_bill_method",
                table: "medicine_bill",
                column: "method");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bill_items");

            migrationBuilder.DropTable(
                name: "medicine_bill");
        }
    }
}
