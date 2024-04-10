using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoModelos.CustomModels
{
    public class IngredienteCustom
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public int Stock { get; set; }

        public IngredienteCustom(int id, string nombre, double precio, int stock) 
        {
            Id = id;
            Nombre = nombre;
            Precio = precio;
            Stock = stock;
        }        
        public IngredienteCustom() 
        {

        }
    }
}
