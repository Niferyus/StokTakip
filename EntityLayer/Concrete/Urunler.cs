using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Urunler
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UrunID { get; set; }

        public string UrunAdi { get; set; }

        public int UrunFiyat { get; set; }

        public int UrunStok { get; set; }

        public ICollection<Islemler> Islemler { get; set; }

        public ICollection<Toptancilar> Toptancilar { get; set; }
    }
}
