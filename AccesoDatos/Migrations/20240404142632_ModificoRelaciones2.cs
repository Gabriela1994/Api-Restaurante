using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccesoDatos.Migrations
{
    public partial class ModificoRelaciones2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producto_Ingrediente_IngredientesId",
                table: "Producto");

            migrationBuilder.DropIndex(
                name: "IX_Producto_IngredientesId",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "IngredientesId",
                table: "Producto");

            migrationBuilder.CreateTable(
                name: "IngredienteProducto",
                columns: table => new
                {
                    IngredientesId = table.Column<int>(type: "int", nullable: false),
                    ProductosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredienteProducto", x => new { x.IngredientesId, x.ProductosId });
                    table.ForeignKey(
                        name: "FK_IngredienteProducto_Ingrediente_IngredientesId",
                        column: x => x.IngredientesId,
                        principalTable: "Ingrediente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredienteProducto_Producto_ProductosId",
                        column: x => x.ProductosId,
                        principalTable: "Producto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngredienteProducto_ProductosId",
                table: "IngredienteProducto",
                column: "ProductosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredienteProducto");

            migrationBuilder.AddColumn<int>(
                name: "IngredientesId",
                table: "Producto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Producto_IngredientesId",
                table: "Producto",
                column: "IngredientesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_Ingrediente_IngredientesId",
                table: "Producto",
                column: "IngredientesId",
                principalTable: "Ingrediente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
