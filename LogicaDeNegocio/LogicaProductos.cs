using AccesoDatos;
using AccesoDatos.Repositorios;
using AccesoModelos.CustomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio
{
    public class LogicaProductos
    {
        private readonly RestauranteDbContext _context;

        public LogicaProductos(RestauranteDbContext context)
        {
            _context = context;
        }

        public List<ProductoCustom> ObtenerProductos()
        {
            ProductoRepository repoProductos = new ProductoRepository(_context);
            return repoProductos.ObtenerListaDeProductos();
        }

    }
}
