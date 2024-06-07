using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AccesoModelos
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        [JsonIgnore]
        public List<Producto> Productos { get; set; }
    }
}
