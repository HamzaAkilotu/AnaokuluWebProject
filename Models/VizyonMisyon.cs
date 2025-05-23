using System.ComponentModel.DataAnnotations;
using System;

namespace AnaOkuluYS.Models
{
    public class VizyonMisyon
    {
        public int Id { get; set; }
        [Required]
        public string Vizyon { get; set; } = string.Empty;
        [Required]
        public string Misyon { get; set; } = string.Empty;
        public string? Ekstra { get; set; }
        public DateTime GuncellemeTarihi { get; set; }
    }
} 