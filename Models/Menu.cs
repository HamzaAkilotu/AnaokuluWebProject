using System;
using System.ComponentModel.DataAnnotations;

namespace AnaOkuluYS.Models
{
    public class Menu
    {
        public int Id { get; set; }

        [Required]
        public DateTime Tarih { get; set; }

        [Required]
        [MaxLength(100)]
        public string SabahKahvaltisi { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string OgleYemegi { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string IkindiKahvaltisi { get; set; } = string.Empty;

        public string Notlar { get; set; } = string.Empty;

        [Required]
        public bool Aktif { get; set; } = true;
    }
} 