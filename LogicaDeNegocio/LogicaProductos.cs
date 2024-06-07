using AccesoDatos;
using AccesoDatos.Repositorios;
using AccesoModelos;
using AccesoModelos.CustomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio
{
    public class LogicaProductos
    {
        private readonly RestauranteDbContext _context;

        public LogicaProductos(RestauranteDbContext context)
        {
            _context = context;
        }

        public List<ProductoCustom> ObtenerProductos()
        {
            ProductoRepository repoProductos = new ProductoRepository(_context);
            return repoProductos.ObtenerListaDeProductos();
        }        
        
        public void CrearUnProducto(CrearProducto data_producto)
        {

            ProductoRepository repoProductos = new ProductoRepository(_context);
            IngredienteRepository repoIngredientes = new IngredienteRepository(_context);
            Producto producto = new Producto();

                var categoria = _context.Categoria.Find(data_producto.IdCategoria);

                producto.Nombre_producto = data_producto.Nombre_producto;
                producto.Precio = data_producto.Precio;
                producto.Descripcion = data_producto.Descripcion;
                producto.Categoria = categoria;
                var id_producto = repoProductos.CrearUnProducto(producto);


            List<Ingrediente> lista_ingredientes = new List<Ingrediente>();

            foreach (var n in data_producto.Ingredientes)
            {
                var item = repoIngredientes.BuscarIngredientePorId(n);
                lista_ingredientes.Add(item);
            }

            repoProductos.CrearUnProductoNN(id_producto, lista_ingredientes);
            _context.SaveChanges();
        }
    }
}
