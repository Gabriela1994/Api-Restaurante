using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoModelos
{
    public class Cliente : Persona
    {
        [Key]
        public int Id { get; set; }
        public Cliente(string nombre, string apellido, int dni) 
        { 
            Nombre = nombre;
            Apellido = apellido;
            Dni = dni;
        }

    }
}
