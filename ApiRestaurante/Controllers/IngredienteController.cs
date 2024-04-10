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
        [Route("api/ingredientes/create")]
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
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: IngredienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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
