using API_REST_To_Do.Models;
using Microsoft.EntityFrameworkCore;

namespace API_REST_To_Do.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Tarea> Tareas => Set<Tarea>();
    }
}
