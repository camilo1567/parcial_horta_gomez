using Microsoft.EntityFrameworkCore;
using parcial_Horta_Gomez.Models;

namespace parcial_Horta_Gomez.Data
{
    public class RostrosFelicesContext : DbContext
    {
        public RostrosFelicesContext(DbContextOptions options) : base(options) 
        { 
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Cliente> Clientes { get; set;}
    }
}
