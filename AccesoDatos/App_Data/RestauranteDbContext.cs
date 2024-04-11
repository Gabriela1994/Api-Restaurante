using AccesoModelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class RestauranteDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>()
            .HasMany(p => p.Ingredientes)
            .WithMany(p => p.Productos)
            .UsingEntity<IngredienteProducto>(
                r => r.HasOne<Ingrediente>().WithMany().HasForeignKey(p=> p.IdIngrediente).OnDelete(DeleteBehavior.NoAction),
                l => l.HasOne<Producto>().WithMany().HasForeignKey(p => p.IdProducto).OnDelete(DeleteBehavior.NoAction)
        );

        }

        public RestauranteDbContext(DbContextOptions<RestauranteDbContext> options) : base(options)
        {

        }

        //public DbSet<NombreTabla> nombre getset;
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Empleado> Empleado { get; set; }
        public DbSet<Ingrediente> Ingrediente { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<IngredienteProducto> IngredienteXProducto { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
    }
}
