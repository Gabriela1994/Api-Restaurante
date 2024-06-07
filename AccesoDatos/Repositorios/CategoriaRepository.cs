using AccesoModelos;
using AccesoModelos.CustomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Repositorios
{
    public class CategoriaRepository
    {
        private readonly RestauranteDbContext _context;

        public CategoriaRepository(RestauranteDbContext context)
        {
            _context = context;
        }

        public List<Categoria> ObtenerListaDeCategorias()
        {
            using (_context)
            {
                List<Categoria> lista_categoria = new List<Categoria>();
                lista_categoria = _context.Categoria.ToList();
                return lista_categoria;
            }
        }
    }
}
