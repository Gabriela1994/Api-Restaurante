using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccesoDatos.Migrations
{
    public partial class CambioNombreDeTablaIngredienteXProducto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredienteProducto_Ingrediente_IdIngrediente",
                table: "IngredienteProducto");

            migrationBuilder.DropForeignKey(
                name: "FK_IngredienteProducto_Producto_IdProducto",
                table: "IngredienteProducto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IngredienteProducto",
                table: "IngredienteProducto");

            migrationBuilder.RenameTable(
                name: "IngredienteProducto",
                newName: "IngredienteXProducto");

            migrationBuilder.RenameIndex(
                name: "IX_IngredienteProducto_IdProducto",
                table: "IngredienteXProducto",
                newName: "IX_IngredienteXProducto_IdProducto");

            migrationBuilder.RenameIndex(
                name: "IX_IngredienteProducto_IdIngrediente",
                table: "IngredienteXProducto",
                newName: "IX_IngredienteXProducto_IdIngrediente");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngredienteXProducto",
                table: "IngredienteXProducto",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredienteXProducto_Ingrediente_IdIngrediente",
                table: "IngredienteXProducto",
                column: "IdIngrediente",
                principalTable: "Ingrediente",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredienteXProducto_Producto_IdProducto",
                table: "IngredienteXProducto",
                column: "IdProducto",
                principalTable: "Producto",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredienteXProducto_Ingrediente_IdIngrediente",
                table: "IngredienteXProducto");

            migrationBuilder.DropForeignKey(
                name: "FK_IngredienteXProducto_Producto_IdProducto",
                table: "IngredienteXProducto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IngredienteXProducto",
                table: "IngredienteXProducto");

            migrationBuilder.RenameTable(
                name: "IngredienteXProducto",
                newName: "IngredienteProducto");

            migrationBuilder.RenameIndex(
                name: "IX_IngredienteXProducto_IdProducto",
                table: "IngredienteProducto",
                newName: "IX_IngredienteProducto_IdProducto");

            migrationBuilder.RenameIndex(
                name: "IX_IngredienteXProducto_IdIngrediente",
                table: "IngredienteProducto",
                newName: "IX_IngredienteProducto_IdIngrediente");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngredienteProducto",
                table: "IngredienteProducto",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredienteProducto_Ingrediente_IdIngrediente",
                table: "IngredienteProducto",
                column: "IdIngrediente",
                principalTable: "Ingrediente",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredienteProducto_Producto_IdProducto",
                table: "IngredienteProducto",
                column: "IdProducto",
                principalTable: "Producto",
                principalColumn: "Id");
        }
    }
}
