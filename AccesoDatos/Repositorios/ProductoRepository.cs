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
            IngredienteRepository repoIngredientes = new IngredienteRepository(_context);
            using (_context)
            {
                {
                    lista_productos = (from p in _context.Producto
                                       join c in _context.Categoria on p.Categoria.Id equals c.Id
                                       select new ProductoCustom
                                       {
                                           Id = p.Id,
                                           Nombre_producto = p.Nombre_producto,
                                           IdCategoria = p.Categoria.Id,
                                           Nombre_categoria = c.Nombre,
                                           Precio = p.Precio,
                                           Descripcion = p.Descripcion,
                                           Ingredientes = repoIngredientes.ListaDeIngredientesPorHamburguesa(p.Id)
                                       }).ToList();
                }
            }
            return lista_productos;
        }

        public int CrearUnProducto(Producto value_producto)
        {
            Producto producto = new Producto();
            IngredienteProducto ingredientes = new IngredienteProducto();

                producto.Nombre_producto = value_producto.Nombre_producto;
                producto.Precio = value_producto.Precio;
                producto.Descripcion = value_producto.Descripcion;
                producto.Categoria = value_producto.Categoria;
                _context.Add(producto);
                _context.SaveChanges();
            return producto.Id;
        }        
        public void CrearUnProductoNN(int idProducto, int idIngrediente)
        {
            IngredienteProducto producto = new IngredienteProducto();

            using (_context)
            {
                producto.IdProducto = idProducto;
                producto.IdIngrediente = idIngrediente;
                _context.Add(producto);
                _context.SaveChanges();
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