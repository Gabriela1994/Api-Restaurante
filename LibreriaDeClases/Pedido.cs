using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoModelos
{
    public class Pedido
    {
        //public int Id { get; set; }
        public int Numero_orden { get; set; }
        public DateTime Fecha_salida { get; set; }
        public TimeSpan Hora { get; set; }
        public string TipoServicio { get; set; } //Para llevar | para retirar | para comer en el local
        public string Observaciones { get; set; }
        public string Estado { get; set; } //entregado //en preparacion // cancelado
        public Cliente Cliente { get; set; }
        public Empleado Empleado { get; set; }
        public List<Producto> Productos { get; set; }

        public Pedido(int numero_orden, DateTime fecha_salida, TimeSpan hora, string tipo_servicio, string observaciones, Cliente cliente, Empleado empleado, string estado, List<Producto> productos )
        {
            Numero_orden = numero_orden;
            Fecha_salida = fecha_salida;
            Hora = hora;
            TipoServicio = tipo_servicio;
            Observaciones = observaciones;
            Cliente = cliente;
            Empleado = empleado;
            Estado = estado;
            Productos = productos;
        }
    }
}
