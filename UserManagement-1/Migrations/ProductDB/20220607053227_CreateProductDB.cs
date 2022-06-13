using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement_1.Migrations.ProductDB
{
    public partial class CreateProductDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    ProdId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProdDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProdImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProdCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProdPrice = table.Column<float>(type: "real", nullable: false),
                    ProdDiscount = table.Column<float>(type: "real", nullable: false),
                    ProdStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SellerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.ProdId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "product");
        }
    }
}
