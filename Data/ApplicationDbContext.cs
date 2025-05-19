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

        public DbSet<Ogrenci> Ogrenciler { get; set; }
        public DbSet<Ogretmen> Ogretmenler { get; set; }
        public DbSet<Etkinlik> Etkinlikler { get; set; }
        public DbSet<EtkinlikKatilim> EtkinlikKatilimlar { get; set; }
        public DbSet<GelisimRaporu> GelisimRaporlari { get; set; }
        public DbSet<Menu> Menuler { get; set; }
        public DbSet<Duyuru> Duyurular { get; set; }
        public DbSet<Blog> BlogYazilari { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Etkinlik - Öğretmen ilişkisi
            modelBuilder.Entity<Etkinlik>()
                .HasOne(e => e.Ogretmen)
                .WithMany(o => o.Etkinlikler)
                .HasForeignKey(e => e.OgretmenId)
                .OnDelete(DeleteBehavior.Restrict);

            // Etkinlik Katılım ilişkileri
            modelBuilder.Entity<EtkinlikKatilim>()
                .HasOne(ek => ek.Etkinlik)
                .WithMany(e => e.Katilimlar)
                .HasForeignKey(ek => ek.EtkinlikId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<EtkinlikKatilim>()
                .HasOne(ek => ek.Ogrenci)
                .WithMany()
                .HasForeignKey(ek => ek.OgrenciId)
                .OnDelete(DeleteBehavior.Restrict);

            // Gelişim Raporu - Öğrenci ilişkisi
            modelBuilder.Entity<GelisimRaporu>()
                .HasOne(gr => gr.Ogrenci)
                .WithMany()
                .HasForeignKey(gr => gr.OgrenciId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
} 