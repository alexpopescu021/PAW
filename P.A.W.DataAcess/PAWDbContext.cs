using Microsoft.EntityFrameworkCore;
using PAW.Model;
using System;

namespace PAW.DataAcess
{
    public class PAWDbContext : DbContext
    {

        public PAWDbContext(DbContextOptions<PAWDbContext> options): base(options)
        {

        }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }

        public DbSet<Wishlist> Wishlist { get; set; }

        public DbSet<Cart> Carts { get; set; }
        public DbSet<History> Histories { get; set; }
    }
}
