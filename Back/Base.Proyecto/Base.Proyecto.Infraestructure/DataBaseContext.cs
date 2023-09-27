using Microsoft.EntityFrameworkCore;
using Base.Proyecto.Infraestructure.Models;

namespace Base.Proyecto.Infraestructure
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<AppUsers> Users { get; set; }
        public DbSet<Person> Person { get; set; }

    }
}