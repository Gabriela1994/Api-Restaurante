using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoModelos
{
    public class Usuario : Persona
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int IdRol { get; set; } //duda

        public Usuario(string usuario, string clave)
        {
            Username = usuario;
            Password = clave;
        }
    }
}
