using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Toptancilar
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ToptanciID { get; set; }
        public string ToptanciAdi { get; set; }
        public int UrunID { get; set; }
        public int Adet { get; set; }
        public int SatisFiyati { get; set; }
        public Urunler Urun { get; set; }
    }
}
