using Microsoft.EntityFrameworkCore;
using Examen_Practico.Models; 

namespace Examen_Practico.Data 
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

      
        public DbSet<User> Users { get; set; }
    }
}