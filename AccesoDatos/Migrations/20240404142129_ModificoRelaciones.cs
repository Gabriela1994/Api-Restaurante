using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccesoDatos.Migrations
{
    public partial class ModificoRelaciones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingrediente_Producto_ProductoId",
                table: "Ingrediente");

            migrationBuilder.DropIndex(
                name: "IX_Ingrediente_ProductoId",
                table: "Ingrediente");

            migrationBuilder.DropColumn(
                name: "ProductoId",
                table: "Ingrediente");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "ProductoId",
                table: "Ingrediente",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ingrediente_ProductoId",
                table: "Ingrediente",
                column: "ProductoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingrediente_Producto_ProductoId",
                table: "Ingrediente",
                column: "ProductoId",
                principalTable: "Producto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
