using AccesoModelos;
using AccesoModelos.CustomModels;
using Microsoft.EntityFrameworkCore;

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
        public List<IngredientePorProducto> ListaDeIngredientesPorHamburguesa(int id)
        {
            List<IngredientePorProducto> lista_ingrediente = new List<IngredientePorProducto>();

            lista_ingrediente = (from prod in _context.IngredienteXProducto
                                 join i in _context.Ingrediente on prod.IdIngrediente equals i.Id
                                 where prod.IdProducto == id
                                 select new IngredientePorProducto { Id = i.Id, Nombre = i.Nombre }).ToList();

            return lista_ingrediente;
        }

        public List<Ingrediente> ListaIngredientesFaltantes()
        {
            List<Ingrediente> ingredientes_faltantes = new List<Ingrediente>();

            ingredientes_faltantes = _context.Ingrediente.Select(i => i)
                .Where(i => i.Stock == 0)
                .ToList();

            return ingredientes_faltantes;
        }        
        public List<Ingrediente> ListaIngredienteConPocoStock()
        {
            List<Ingrediente> ingredientes_faltantes = new List<Ingrediente>();

            ingredientes_faltantes = _context.Ingrediente.Select(i => i)
                .Where(i => i.Stock > 1 && i.Stock < 50)
                .ToList();

            return ingredientes_faltantes;
        }
    }
}
