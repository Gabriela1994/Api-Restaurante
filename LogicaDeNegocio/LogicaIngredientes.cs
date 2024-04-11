using AccesoDatos;
using AccesoDatos.Repositorios;
using AccesoModelos;
using AccesoModelos.CustomModels;
using static AccesoModelos.CustomModels.IngredienteCustom;

namespace LogicaDeNegocio
{
    public class LogicaIngredientes
    {
        private readonly RestauranteDbContext _context;

        public LogicaIngredientes(RestauranteDbContext context)
        {
            _context = context;
        }

        public List<ListarIngredientes> ObtenerIngredientes()
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
            Ingrediente ingrediente = new Ingrediente();

            ingrediente.Nombre = data_ingrediente.Nombre;
            ingrediente.Precio = data_ingrediente.Precio;
            ingrediente.Stock = data_ingrediente.Stock;
            ingrediente.Disponibilidad = (ingrediente.Stock != 0 ? true : false);

            repoIngrediente.EditarUnIngrediente(idIngrediente, ingrediente);
        }        
        public void EliminarUnIngrediente(int idIngrediente)
        {
            IngredienteRepository repoIngrediente = new IngredienteRepository(_context);
            repoIngrediente.EliminarIngrediente(idIngrediente);
        }
    }
}