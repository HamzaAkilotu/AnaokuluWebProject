using System;

namespace AnaOkuluYS.Models
{
    public class Etkinlik
    {
        public int Id { get; set; }
        public string Baslik { get; set; } = string.Empty;
        public string Aciklama { get; set; } = string.Empty;
        public DateTime Tarih { get; set; }
        public string Konum { get; set; } = string.Empty;
        public bool Aktif { get; set; }
        // Sadece tanıtım amaçlı alanlar kaldı
    }
} 