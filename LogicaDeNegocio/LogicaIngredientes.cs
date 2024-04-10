using AccesoDatos;
using AccesoDatos.Repositorios;
using AccesoModelos;
using AccesoModelos.CustomModels;

namespace LogicaDeNegocio
{
    public class LogicaIngredientes
    {
        private readonly RestauranteDbContext _context;

        public LogicaIngredientes(RestauranteDbContext context)
        {
            _context = context;
        }

        public List<IngredienteCustom> GetIngredientes()
        {
            IngredienteRepository repoIngrediente = new IngredienteRepository(_context);
            return repoIngrediente.ObtenerListaDeIngredientes();
        }        
        
        public void CrearUnIngrediente(IngredienteCustom data_ingrediente)
        {
            IngredienteRepository repoIngrediente = new IngredienteRepository(_context);
            Ingrediente ingrediente = new Ingrediente();

            ingrediente.Nombre = data_ingrediente.Nombre;
            ingrediente.Precio = data_ingrediente.Precio;
            ingrediente.Stock = data_ingrediente.Stock;
            ingrediente.Disponibilidad = (ingrediente.Stock != 0 ? true : false);            
            
            repoIngrediente.CrearUnIngrediente(ingrediente);
        }

        public Ingrediente ObtenerIngredientePorId(int id)
        {
            IngredienteRepository repoIngrediente = new IngredienteRepository(_context);
            return repoIngrediente.BuscarIngredientePorId(id);

        }        
        public void EditarUnIngrediente(int idIngrediente, IngredienteCustom data_ingrediente)
        {
            IngredienteRepository repoIngrediente = new IngredienteRepository(_context);
            IngredienteCustom ingrediente = new IngredienteCustom();

            ingrediente.Nombre = data_ingrediente.Nombre;
            ingrediente.Precio = data_ingrediente.Precio;
            ingrediente.Stock = data_ingrediente.Stock;

            repoIngrediente.EditarUnIngrediente(idIngrediente, ingrediente);
        }
    }
}