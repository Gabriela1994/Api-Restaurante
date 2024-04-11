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
        public List<ListarIngredientes> ObtenerListaDeIngredientes()
        {
            using (_context)
            {
                List<ListarIngredientes> lista_ingredientes = new List<ListarIngredientes>();
                lista_ingredientes = _context.Ingrediente.Select(p => new ListarIngredientes(p.Id, p.Nombre, p.Precio, p.Stock)).ToList();
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
        public Ingrediente BuscarIngredientePorId(int idIngrediente)
        {
            Ingrediente ingrediente = new Ingrediente();
            ingrediente = _context.Ingrediente.Find(idIngrediente);
            return ingrediente;
        }
        public void EditarUnIngrediente(int idIngrediente, Ingrediente value)
        {
            Ingrediente ingrediente = new Ingrediente();

            using (_context)
            {
                ingrediente = BuscarIngredientePorId(idIngrediente);

                ingrediente.Nombre = value.Nombre;
                ingrediente.Precio = value.Precio;
                ingrediente.Stock = value.Stock;
                ingrediente.Disponibilidad = value.Disponibilidad;

                _context.Entry(ingrediente).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }


        public void EliminarIngrediente(int IdIngrediente)
        {
            Ingrediente ingrediente = BuscarIngredientePorId(IdIngrediente);

            using (_context)
            {
                _context.Ingrediente.Remove(ingrediente);
                _context.SaveChanges();
            }
        }        
        public List<IngredienteCustom> ListaDeIngredientesPorHamburguesa(int id)
        {
            List<IngredienteCustom> lista_ingrediente = new List<IngredienteCustom>();

            lista_ingrediente = (from prod in _context.IngredienteXProducto
                                 join i in _context.Ingrediente on prod.IdIngrediente equals i.Id
                                 where prod.IdProducto == id
                                 select new IngredienteCustom
                                 {
                                     Id = i.Id,
                                     Nombre = i.Nombre,
                                     Precio = i.Precio,
                                     Stock = i.Stock
                                 }).ToList();

            return lista_ingrediente;
        }
    }
}
