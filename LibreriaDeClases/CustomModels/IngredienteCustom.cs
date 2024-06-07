using NSwag.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AccesoModelos.CustomModels
{
    public class IngredienteCustom
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public int Stock { get; set; }

        public IngredienteCustom(string nombre, double precio, int stock)
        {
            Nombre = nombre;
            Precio = precio;
            Stock = stock;
        }
        public IngredienteCustom()
        {

        }
    }

        public class ListarIngredientes : IngredienteCustom
        {
            public string Disponibilidad { get; set; }

            public ListarIngredientes(int id, string nombre, double precio, int stock)
            {
                {
                    Id = id;
                    Nombre = nombre;
                    Precio = precio;
                    Stock = stock;
                    Disponibilidad = Stock != 0 ? "Disponible" : "No disponible";
                }
            }
        }


    public class IngredientePorProducto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public IngredientePorProducto()
        {

        }
    }
}
