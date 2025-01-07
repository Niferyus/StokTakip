using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Islemler
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IslemlerID { get; set; }
        public int MusteriID { get; set; }
        public int UrunID { get; set; }
        public int Adet { get; set; }
        public int ToplamFiyat { get; set; }
        public DateOnly Tarih { get; set; }
        public bool Satis { get; set; }
        public Urunler Urun { get; set; }
        public Musteriler Musteri { get; set; }
    }
}
