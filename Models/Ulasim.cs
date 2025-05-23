using System.ComponentModel.DataAnnotations;
using System;

namespace AnaOkuluYS.Models
{
    public class Ulasim
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Baslik { get; set; } = string.Empty;
        [Required]
        public string Aciklama { get; set; } = string.Empty;
        public string? GorselUrl { get; set; }
        public DateTime GuncellemeTarihi { get; set; }
    }
} 