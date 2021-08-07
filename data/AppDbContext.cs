using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tarefa.Models;

namespace Tarefa.data
{
    public class AppDbContext :IdentityDbContext<Client>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public AppDbContext()
        {
            
        }

        public DbSet<Product> Products { get; set; }
    }
}