using AccesoDatos;
using AccesoModelos;
using AccesoModelos.CustomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Repositorios
{
    public class IngredienteRepository
    {
        private readonly RestauranteDbContext _context;

        public IngredienteRepository(RestauranteDbContext context)
        {
            _context = context;
        }        
        public List<IngredienteCustom> ObtenerListaDeIngredientes()
        {
            using (_context)
            {
                List<IngredienteCustom> lista_ingredientes = new List<IngredienteCustom>();
                lista_ingredientes = _context.Ingrediente.Select(p => new IngredienteCustom
                {
                    Id = p.Id,
                    Nombre = p.Nombre,
                    Precio = p.Precio,
                    Stock = p.Stock
                }).ToList();
                return lista_ingredientes;
            }
        }

        public void CrearUnIngrediente(Ingrediente value)
        {
            Ingrediente ingrediente = new Ingrediente();
            using (_context)
            {
                ingrediente.Nombre = value.Nombre;
                ingrediente.Precio = value.Precio;
                ingrediente.Stock = value.Stock;
                ingrediente.Disponibilidad = value.Disponibilidad;

                _context.Add(ingrediente);
                _context.SaveChanges();
            }
        }
    }
}
