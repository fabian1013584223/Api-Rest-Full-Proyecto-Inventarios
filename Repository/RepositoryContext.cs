using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new CategoriaConfiguration());
       
            //modelBuilder.ApplyConfiguration(new DetalleFacturaProveedorConfiguration());
            //modelBuilder.ApplyConfiguration(new DetalleFacturaClienteConfiguration());
       
            modelBuilder.ApplyConfiguration(new FacturaProveedorConfiguration());
            //modelBuilder.ApplyConfiguration(new FacturaConfiguration());
            modelBuilder.ApplyConfiguration(new PrecioConfiguration());
            //modelBuilder.ApplyConfiguration(new MetodoPagoConfiguration());
            modelBuilder.ApplyConfiguration(new ProductoConfiguration());
            modelBuilder.ApplyConfiguration(new ProveedorConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new StockConfiguration());

        }

       
        public DbSet<Categoria>? Categorias { get; set; }
       
        public DbSet<FacturaProveedor>? FacturasCompras { get; set; }
        public DbSet<FacturaCliente>? FacturasVentas { get; set; }
        public DbSet<DetalleFacturaCliente>? DetallesFacturaVentas { get; set; }

        public DbSet<DetalleFacturaProveedor>? DetallesFacturaProveedores { get; set; }

        public DbSet<Precios>? HistoricosPrecios { get; set; }
        public DbSet<MetodoPago>? MetodoPagos { get; set; }
       
        public DbSet<Producto>? Productos { get; set; }
        public DbSet<Proveedor>? Proveedores { get; set; }
        public DbSet<Usuario>? Usuarios { get; set; }
        public DbSet<Usuario>? Stocks { get; set; }
    }
}