using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AccesoModelos
{
    public class Ingrediente
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public int Stock { get; set; }

        public string Disponibilidad { get; set; }

        [JsonIgnore]
        public List<Producto> Productos { get; set; }

        public Ingrediente(string nombre, double precio, int stock, string disponibilidad)
        {
            Nombre = nombre;
            Precio = precio;
            Stock = stock;
            Disponibilidad = disponibilidad;
        }        
        public Ingrediente()
        {

        }

        public Ingrediente(string nombre)
        {
            Nombre = nombre;
        }

        public override string ToString()
        {
            return $"Nombre: {Nombre}, Precio: {Precio}, Stock: {Stock}, Disponibilidad: {Disponibilidad}";
        }
    }
}
