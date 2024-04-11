using AccesoModelos.CustomModels;
using AccesoModelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Repositorios
{
    public class ProductoRepository
    {
        private readonly RestauranteDbContext _context;

        public ProductoRepository(RestauranteDbContext context)
        {
            _context = context;
        }
        public List<ProductoCustom> ObtenerListaDeProductos()
        {
            List<ProductoCustom> lista_productos = new List<ProductoCustom>();
            using (_context)
            {
                lista_productos = (from p in _context.Producto
                                   join c in _context.Categoria
                                   on p.Categoria.Id equals c.Id
                                   select new ProductoCustom
                                   {
                                       Id= p.Id,
                                       Nombre_producto = p.Nombre_producto,
                                       IdCategoria = c.Id,
                                       Nombre_categoria = c.Nombre,
                                       Precio = p.Precio,
                                       Descripcion = p.Descripcion,
                                       Ingredientes = p.Ingredientes.ToList(),
                                   }).ToList();
            }
            return lista_productos;
        }

        public void CrearUnProducto(Producto value)
        {
            Producto producto = new Producto();

            using (_context)
            {
                producto.Nombre_producto = value.Nombre_producto;
                producto.Categoria = value.Categoria;
            }
        }
        public Producto BuscarProductoPorId(int idProducto)
        {
            Producto producto = new Producto();
            producto = _context.Producto.Find(idProducto);
            return producto;
        }
        public void EditarUnProducto(int idProducto, Producto value)
        {
            using (_context)
            {

            }
        }


        public void EliminarProducto(int idProducto)
        {
            Producto producto = BuscarProductoPorId(idProducto);

            using (_context)
            {

            }
        }
    }
}