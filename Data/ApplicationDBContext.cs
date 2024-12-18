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

        public DbSet<Registeration> Registerations { get; set; }

        public DbSet<Product> Products { get; set; }


        public DbSet<Cart> Carts { get; set; }

    }
}
