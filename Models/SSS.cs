using System;
using System.ComponentModel.DataAnnotations;

namespace AnaOkuluYS.Models
{
    public class SSS
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Soru { get; set; } = string.Empty;
        [Required]
        [MaxLength(1000)]
        public string Cevap { get; set; } = string.Empty;
        public DateTime GuncellemeTarihi { get; set; }
    }
} 