using System.ComponentModel.DataAnnotations;

namespace AccesoModelos
{
    public abstract class Persona
    {
        [Key]
        public  int Id { get; }
        public  string Nombre { get; set; }
        public  string Apellido { get; set; }
        public int Dni { get; set; }
        public DateTime Fecha_nacimineto { get; set; }
        public string Genero { get; set; }

        public int CalcularEdad(DateTime fecha_nacimiento)
        {
                DateTime fechaActual = DateTime.Today;

                int edad = fechaActual.Year - fecha_nacimiento.Year;

                // Restar un año si la fecha actual es anterior al día de nacimiento en el mismo año
                if (fechaActual < fecha_nacimiento.AddYears(edad))
                {
                    edad--;
                }

                return edad;
        }
    }
}