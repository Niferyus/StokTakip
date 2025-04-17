using EntityLayer.Concrete.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete.Dtos
{
    public class KisilerDto
    {
        public int Id { get; set; }
        [Required]
        public string Ad { get; set; }

        public string Soyad { get; set; }
        public string FirmaAdi { get; set; }

        [MaxLength(20)]
        public string Telefon { get; set; }

        [MaxLength(100)]
        public string Eposta { get; set; }

        [MaxLength(250)]
        public string Adres { get; set; }

        [Required]
        public KisiTuru Tur { get; set; }

        public DateTime KayitTarihi { get; set; } = DateTime.Now;
    }
}
