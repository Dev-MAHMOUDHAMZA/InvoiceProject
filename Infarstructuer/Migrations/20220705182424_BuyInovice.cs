using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infarstructuer.Migrations
{
    public partial class BuyInovice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BuyInovices",
                columns: table => new
                {
                    BuyInvoice = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    afterDiscount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BaranchId = table.Column<int>(type: "int", nullable: false),
                    CurrentState = table.Column<int>(type: "int", nullable: false),
                    CreateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyInovices", x => x.BuyInvoice);
                    table.ForeignKey(
                        name: "FK_BuyInovices_Baranches_BaranchId",
                        column: x => x.BaranchId,
                        principalTable: "Baranches",
                        principalColumn: "BaranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuyInovices_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "BuyInvoiceItems",
                columns: table => new
                {
                    BuyInvoiceItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quntity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BuyInoviceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyInvoiceItems", x => x.BuyInvoiceItemId);
                    table.ForeignKey(
                        name: "FK_BuyInvoiceItems_BuyInovices_BuyInoviceId",
                        column: x => x.BuyInoviceId,
                        principalTable: "BuyInovices",
                        principalColumn: "BuyInvoice",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuyInvoiceItems_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_BuyInvoiceItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuyInovices_BaranchId",
                table: "BuyInovices",
                column: "BaranchId");

            migrationBuilder.CreateIndex(
                name: "IX_BuyInovices_SupplierId",
                table: "BuyInovices",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_BuyInvoiceItems_BuyInoviceId",
                table: "BuyInvoiceItems",
                column: "BuyInoviceId");

            migrationBuilder.CreateIndex(
                name: "IX_BuyInvoiceItems_CategoryId",
                table: "BuyInvoiceItems",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BuyInvoiceItems_ProductId",
                table: "BuyInvoiceItems",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuyInvoiceItems");

            migrationBuilder.DropTable(
                name: "BuyInovices");
        }
    }
}
