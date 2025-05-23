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

        public DbSet<EtkinlikTakvimi> EtkinlikTakvimi { get; set; }
        public DbSet<Galeri> Galeri { get; set; }
        public DbSet<Iletisim> Iletisim { get; set; }
        public DbSet<Duyuru> Duyurular { get; set; }
        public DbSet<Menu> Menuler { get; set; }
        public DbSet<Oneri> Oneriler { get; set; }
        public DbSet<SSS> SSS { get; set; }
        public DbSet<Ulasim> Ulasim { get; set; }
        public DbSet<VizyonMisyon> VizyonMisyon { get; set; }
        public DbSet<Etkinlik> Etkinlikler { get; set; }
        // Ekstra: Galeri, SSS, Ulasim, Iletisim, VizyonMisyon modelleri eklenecek

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Sadece kalan modellerin ilişkileri burada tanımlanacak (gerekirse)
        }
    }
} 