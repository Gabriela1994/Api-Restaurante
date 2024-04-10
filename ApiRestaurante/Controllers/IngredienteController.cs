using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AccesoModelos;
using LogicaDeNegocio;
using AccesoDatos;
using Microsoft.EntityFrameworkCore;
using AccesoDatos.Repositorios;
using AccesoModelos.CustomModels;

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
        public List<IngredienteCustom> Index()
        {
            LogicaIngredientes ingredientes = new LogicaIngredientes(_context);
            return ingredientes.GetIngredientes();
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
        public void Create(IngredienteCustom data_ingrediente)
        {
            try
            {
                LogicaIngredientes ingredientes = new LogicaIngredientes(_context);
                ingredientes.CrearUnIngrediente(data_ingrediente);                
            }
            catch
            {
                Response.StatusCode = 404;
            }
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
        [HttpPost]
        [Route("api/ingredientes/editar")]
        //[ValidateAntiForgeryToken]
        public void Edit(IngredienteCustom data_ingrediente)
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
        public ActionResult Delete(int id)
        {
            return View();
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
    }
}
