using System;
using System.ComponentModel.DataAnnotations;

namespace AnaOkuluYS.Models
{
    public class Oneri
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string VeliAdi { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string VeliEmail { get; set; } = string.Empty;

        [Required]
        [MaxLength(500)]
        public string Mesaj { get; set; } = string.Empty;

        public DateTime Tarih { get; set; } = DateTime.Now;

        public bool Okundu { get; set; }
    }
} 