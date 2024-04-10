using AccesoDatos;
using AccesoModelos;
using AccesoModelos.CustomModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AccesoModelos.CustomModels.IngredienteCustom;

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
                lista_ingredientes = _context.Ingrediente.Select(p => new IngredienteCustom(p.Id, p.Nombre, p.Precio, p.Stock)).ToList();
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
        public void EditarUnIngrediente(int idIngrediente, IngredienteCustom value)
        {
            Ingrediente ingrediente = new Ingrediente();

            using (_context)
            {
                ingrediente = _context.Ingrediente.Find(idIngrediente);

                ingrediente.Nombre = value.Nombre;
                ingrediente.Precio = value.Precio;
                ingrediente.Stock = value.Stock;

                _context.Entry(ingrediente).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }

        public Ingrediente BuscarIngredientePorId(int idIngrediente)
        {
            Ingrediente ingrediente = new Ingrediente();

            using (_context)
            {
                ingrediente = _context.Ingrediente.Find(idIngrediente);
                return ingrediente;
            }
            return ingrediente;
        }
    }
}
