using System;
using System.ComponentModel.DataAnnotations;

namespace AnaOkuluYS.Models
{
    public class Galeri
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Başlık alanı zorunludur.")]
        public string Baslik { get; set; } = string.Empty;

        public string? Aciklama { get; set; }

        [Required(ErrorMessage = "Resim yolu zorunludur.")]
        public string ResimYolu { get; set; } = string.Empty;

        public DateTime YuklemeTarihi { get; set; } = DateTime.Now;

        public bool AktifMi { get; set; } = true;
    }
} 