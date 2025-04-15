using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete.Class
{
    [Flags]
    public enum KisiTuru
    {
        Musteri = 1,
        Toptanci = 2,
    }
    public class Kisiler
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Ad { get; set; }

        [MaxLength(100)]
        public string Soyad { get; set; }

        [MaxLength(200)]
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
