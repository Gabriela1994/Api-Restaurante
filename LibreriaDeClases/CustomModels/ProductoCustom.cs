using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoModelos.CustomModels
{
    public class ProductoCustom
    {
        public int Id { get; set; }
        public string Nombre_producto { get; set; }
        public int IdCategoria { get; set; }
        public string Nombre_categoria { get; set; }
        public double Precio { get; set; }
        public List<IngredientePorProducto> Ingredientes { get; set; }
        public string Descripcion { get; set; }
    }    
    public class CrearProducto
    {
        public int Id { get; set; }
        public string Nombre_producto { get; set; }
        public int IdCategoria { get; set; }
        public double Precio { get; set; }
        public List<int> Ingredientes { get; set; }
        public string Descripcion { get; set; }
    }
}
