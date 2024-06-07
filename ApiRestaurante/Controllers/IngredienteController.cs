using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AccesoModelos;
using LogicaDeNegocio;
using AccesoDatos;
using Microsoft.EntityFrameworkCore;
using AccesoDatos.Repositorios;
using AccesoModelos.CustomModels;
using static AccesoModelos.CustomModels.IngredienteCustom;

namespace ApiRestaurante.Controllers
{
    public class IngredienteController : Controller
    {
        private readonly RestauranteDbContext _context;

        public IngredienteController(RestauranteDbContext context)
        {
            _context = context;
        }

        // GET: IngredienteController
        [HttpGet]
        [Route("api/ingredientes/lista")]
        public List<ListarIngredientes> Index()
        {
            LogicaIngredientes ingredientes = new LogicaIngredientes(_context);
            return ingredientes.ObtenerIngredientes();
        }     

        // GET: IngredienteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: IngredienteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IngredienteController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [Route("api/ingredientes/crear")]
        public void Create([FromBody] IngredienteCustom data_ingrediente)
        {
            
                LogicaIngredientes ingredientes = new LogicaIngredientes(_context);
                ingredientes.CrearUnIngrediente(data_ingrediente);                
            
        }

        // GET: IngredienteController/Edit/5
        [HttpGet]
        [Route("api/ingredientes/buscar-id")]
        public Ingrediente Edit(int id)
        {
            LogicaIngredientes ingredientes = new LogicaIngredientes(_context);
            return ingredientes.ObtenerIngredientePorId(id);
        }

        // POST: IngredienteController/Edit/5
        [HttpPut]
        [Route("api/ingredientes/editar/{id?}")]
        //[ValidateAntiForgeryToken]
        public void Edit([FromBody] IngredienteCustom data_ingrediente)
        {
            try
            {
                int idIngrediente = data_ingrediente.Id;
                LogicaIngredientes ingredientes = new LogicaIngredientes(_context);
                ingredientes.EditarUnIngrediente(idIngrediente, data_ingrediente);
            }
            catch
            {
                Response.StatusCode = 404;
            }
        }

        // GET: IngredienteController/Delete/5
        [HttpDelete]
        [Route("api/ingredientes/eliminar/{id?}")]
        public void Delete(int id)
        {
            LogicaIngredientes ingredientes = new LogicaIngredientes(_context);
            ingredientes.EliminarUnIngrediente(id);
        }

        // POST: IngredienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        [Route("api/ingredientes/lista-faltantes")]
        public List<Ingrediente> ListaIngredientesFaltantes()
        {
            IngredienteRepository ingredientes = new IngredienteRepository(_context);
            return ingredientes.ListaIngredientesFaltantes();
            
        }        
        [HttpGet]
        [Route("api/ingredientes/lista-poco-stock")]
        public List<Ingrediente> ListaIngredientesConPocoStock()
        {
            IngredienteRepository ingredientes = new IngredienteRepository(_context);
            return ingredientes.ListaIngredienteConPocoStock();
            
        }        
        
        [HttpGet]
        [Route("api/ingredientes/ingredientes-por-producto/{id?}")]
        public List<IngredientePorProducto> IngredientesPorProducto(int id)
        {
            IngredienteRepository ingredientes = new IngredienteRepository(_context);
            return ingredientes.ListaDeIngredientesPorHamburguesa(id);            
        }
    }
}
