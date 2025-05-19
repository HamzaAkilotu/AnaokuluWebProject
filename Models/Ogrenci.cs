using System;

namespace AnaOkuluYS.Models
{
    public class Ogrenci
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string VeliAdi { get; set; }
        public string VeliTelefon { get; set; }
        public string VeliEmail { get; set; }
        public DateTime KayitTarihi { get; set; }
        public bool Aktif { get; set; }
    }
} 