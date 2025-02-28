using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using FilmDB.DAL.Models;

namespace FilmDB.DAL
{
    public class FilmDBContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public FilmDBContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<Sender> Sender { get; set; }
        public DbSet<Gesehen> Gesehen { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = _configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseNpgsql(connectionString);
            }
        }
    }
} 