using System;
using System.ComponentModel.DataAnnotations;

namespace AnaOkuluYS.Models
{
    public class Blog
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Baslik { get; set; }

        [Required]
        public string Icerik { get; set; }

        [Required]
        public DateTime YayinTarihi { get; set; }

        [Required]
        [MaxLength(100)]
        public string Yazar { get; set; }

        public string? ResimUrl { get; set; }

        [Required]
        public bool Aktif { get; set; } = true;

        [Required]
        [MaxLength(50)]
        public string Kategori { get; set; }

        public string? Etiketler { get; set; }
    }
} 