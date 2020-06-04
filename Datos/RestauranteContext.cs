using Entity;
using Microsoft.EntityFrameworkCore;

namespace Datos
{
    public class RestauranteContext : DbContext
    {
        public RestauranteContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Restaurante> Restaurantes { get; set; }
        public DbSet<Dueño> Dueños {get; set;}
	}
}
