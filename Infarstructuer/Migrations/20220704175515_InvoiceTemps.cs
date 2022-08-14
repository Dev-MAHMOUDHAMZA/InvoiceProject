using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infarstructuer.Migrations
{
    public partial class InvoiceTemps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InvoiceTemps",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quntity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BaranchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceTemps", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "FK_InvoiceTemps_Baranches_BaranchId",
                        column: x => x.BaranchId,
                        principalTable: "Baranches",
                        principalColumn: "BaranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceTemps_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_InvoiceTemps_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceTemps_BaranchId",
                table: "InvoiceTemps",
                column: "BaranchId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceTemps_CategoryId",
                table: "InvoiceTemps",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceTemps_ProductId",
                table: "InvoiceTemps",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceTemps");
        }
    }
}
