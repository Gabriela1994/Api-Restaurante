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
        public List<Ingrediente> Ingredientes { get; set; }
        public string Descripcion { get; set; }
    }
}
