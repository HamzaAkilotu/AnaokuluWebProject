using System;
using System.ComponentModel.DataAnnotations;

namespace AnaOkuluYS.Models
{
    public class Duyuru
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Baslik { get; set; } = string.Empty;

        [Required]
        public string Icerik { get; set; } = string.Empty;

        [Required]
        public DateTime YayinTarihi { get; set; }

        public DateTime? SonGecerlilikTarihi { get; set; }

        public bool Aktif { get; set; } = true;

        public string? ResimUrl { get; set; }
    }
} 