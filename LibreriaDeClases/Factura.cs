using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoModelos
{
    public class Factura
    {
        public DateTime Fecha { get; set; }
        public double Total { get; set; }
        public string TipoDePago { get; set; } //Efectivo | debito | credito

        public Factura(DateTime fecha, double total, string tipo_pago)
        {
            Fecha = fecha;
            TipoDePago = tipo_pago;
            Total = total;
        }
    }
}
