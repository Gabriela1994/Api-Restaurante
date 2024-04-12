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
        
        public void CrearUnProducto(CrearProducto value, int idIngrediente)
        {

            ProductoRepository repoProductos = new ProductoRepository(_context);
            IngredienteRepository repoIngredientes = new IngredienteRepository(_context);
            Producto producto = new Producto();

                var categoria = _context.Categoria.Find(value.IdCategoria);

                producto.Nombre_producto = value.Nombre_producto;
                producto.Precio = value.Precio;
                producto.Descripcion = value.Descripcion;
                producto.Categoria = categoria;
                var producto_final = repoProductos.CrearUnProducto(producto);

                var obj_producto = repoProductos.BuscarProductoPorId(producto_final);
                int idRecuperado = obj_producto.Id;

                var obj_ingrediente = repoIngredientes.BuscarIngredientePorId(idIngrediente);
                int id_ingrediente = obj_ingrediente.Id;

                repoProductos.CrearUnProductoNN(idRecuperado, id_ingrediente);
        }
    }
}
