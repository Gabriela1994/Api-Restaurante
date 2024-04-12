using AccesoModelos.CustomModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AccesoDatos.Repositorios;
using static AccesoModelos.CustomModels.ProductoCustom;
using AccesoDatos;
using LogicaDeNegocio;

namespace ApiRestaurante.Controllers
{
    public class ProductoController : Controller
    {
        private readonly RestauranteDbContext _context;

        public ProductoController(RestauranteDbContext context)
        {
            _context = context;
        }
        // GET: ProductoController
        [HttpGet]
        [Route("api/productos/lista")]

        public List<ProductoCustom> Index()
        {
            LogicaProductos log_producto = new LogicaProductos(_context);
            return log_producto.ObtenerProductos();
        }

        // GET: ProductoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductoController/Create
        [HttpPost]
        [Route("api/productos/create")]
        //[ValidateAntiForgeryToken]
        public void Create(CrearProducto data_producto)
        {
            try
            {
                LogicaProductos log_producto = new LogicaProductos(_context);
                log_producto.CrearUnProducto(data_producto, data_producto.Idingredientes);
            }
            catch
            {
                Response.StatusCode = 404;
            }
        }

        // GET: ProductoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductoController/Edit/5
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

        // GET: ProductoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductoController/Delete/5
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
