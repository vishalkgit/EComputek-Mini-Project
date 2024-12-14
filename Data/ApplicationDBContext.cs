using EComputek.Models;
using Microsoft.EntityFrameworkCore;

namespace EComputek.Data
{
    public class ApplicationDBContext:DbContext
    {

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext>op):base(op) 
        {
            
        }


        public DbSet<Category> Categories { get; set; }

        public DbSet<Registeration> Registrations { get; set; }

        public DbSet<Product> Products { get; set; }

    }
}
