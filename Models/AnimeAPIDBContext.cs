using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using AnimeAPI.Models;
namespace AnimeAPI.Models
{
    public class AnimeAPIDBContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public AnimeAPIDBContext(DbContextOptions<AnimeAPIDBContext>options, IConfiguration configuration):base(options)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionsString = Configuration.GetConnectionString("Anime");
            options.UseMySql(connectionsString, ServerVersion.AutoDetect(connectionsString));
        }
        public DbSet<info> info { get; set; } = null!;
        public DbSet<Theme> theme { get; set; } = null!;

    }
}