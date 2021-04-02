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
    }
}
