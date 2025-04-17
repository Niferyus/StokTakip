using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete.Class
{
    public enum IslemTuru
    {
        Satis,
        Alis
    }
    public class Hareketler
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int KisiId { get; set; }
        public int DepoId { get; set; }
        public int UrunId { get; set; }
        public int Miktar { get; set; }
        public int BirimFiyat { get; set; }
        public int ToplamFiyat { get; set; }
        public DateTime Tarih { get; set; } = DateTime.Now;
        public IslemTuru IslemTuru { get; set; }
        public Kisiler Kisi { get; set; }
        public Depo Depo { get; set; }
        public Urunler Urun { get; set; }
    }
}
