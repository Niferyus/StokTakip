using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete.Class
{
    
    public class Islemler
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IslemlerID { get; set; }
        public int? MusteriID { get; set; }
        public int? ToptanciID { get; set; }
        public int UrunId { get; set; }
        public int Adet { get; set; }
        public decimal ToplamFiyat { get; set; }
        public DateTime Tarih { get; set; }
        public IslemTuru IslemTuru { get; set; }
        [ForeignKey("UrunId")]
        public Urunler Urun { get; set; }

        [ForeignKey("MusteriID")]
        public Musteriler Musteri { get; set; }

        [ForeignKey("ToptanciID")]
        public Toptancilar Toptanci { get; set; }
    }
}
