using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccesoDatos.Migrations
{
    public partial class ModificoRelaciones4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredienteProducto_Ingrediente_IngredientesId",
                table: "IngredienteProducto");

            migrationBuilder.DropForeignKey(
                name: "FK_IngredienteProducto_Producto_ProductosId",
                table: "IngredienteProducto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IngredienteProducto",
                table: "IngredienteProducto");

            migrationBuilder.RenameColumn(
                name: "ProductosId",
                table: "IngredienteProducto",
                newName: "IdProducto");

            migrationBuilder.RenameColumn(
                name: "IngredientesId",
                table: "IngredienteProducto",
                newName: "IdIngrediente");

            migrationBuilder.RenameIndex(
                name: "IX_IngredienteProducto_ProductosId",
                table: "IngredienteProducto",
                newName: "IX_IngredienteProducto_IdProducto");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "IngredienteProducto",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngredienteProducto",
                table: "IngredienteProducto",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_IngredienteProducto_IdIngrediente",
                table: "IngredienteProducto",
                column: "IdIngrediente");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_IngredienteProducto_IdIngrediente",
                table: "IngredienteProducto");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "IngredienteProducto");

            migrationBuilder.RenameColumn(
                name: "IdProducto",
                table: "IngredienteProducto",
                newName: "ProductosId");

            migrationBuilder.RenameColumn(
                name: "IdIngrediente",
                table: "IngredienteProducto",
                newName: "IngredientesId");

            migrationBuilder.RenameIndex(
                name: "IX_IngredienteProducto_IdProducto",
                table: "IngredienteProducto",
                newName: "IX_IngredienteProducto_ProductosId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngredienteProducto",
                table: "IngredienteProducto",
                columns: new[] { "IngredientesId", "ProductosId" });

            migrationBuilder.AddForeignKey(
                name: "FK_IngredienteProducto_Ingrediente_IngredientesId",
                table: "IngredienteProducto",
                column: "IngredientesId",
                principalTable: "Ingrediente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IngredienteProducto_Producto_ProductosId",
                table: "IngredienteProducto",
                column: "ProductosId",
                principalTable: "Producto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
