using Microsoft.EntityFrameworkCore;
using AnaOkuluYS.Models;

namespace AnaOkuluYS.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Galeri> Galeri { get; set; }
        public DbSet<Duyuru> Duyurular { get; set; }
        public DbSet<Menu> Menuler { get; set; }
        public DbSet<Etkinlik> Etkinlikler { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Sadece kalan modellerin ilişkileri burada tanımlanacak (gerekirse)
        }
    }
} 