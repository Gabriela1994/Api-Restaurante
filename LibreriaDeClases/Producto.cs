using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoModelos
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre_producto { get; set; }
        public Categoria Categoria { get; set; }
        public double Precio { get; set; }
        public List<Ingrediente> Ingredientes { get; set; }
        public string Descripcion { get; set; }

        public Producto()
        {

        }

        public override string ToString()
        {
            string ingredientesString = string.Join("\n", Ingredientes.Select(p => p.Nombre));
            return $"Nombre: {Nombre_producto}\nCategoria: {Categoria}\nPrecio: {Precio}\nDescripción: {Descripcion}\n \nIngredientes: \n{ingredientesString}";
        }
    }
}
