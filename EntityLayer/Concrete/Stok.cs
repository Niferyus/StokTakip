using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Stok
    {
        public int Id { get; set; }
        public int UrunId { get; set; }
        public Urunler Urun { get; set; }
        public int StokMiktari { get; set; }
        public int DepoId { get; set; }
        public Depo Depo { get; set; }
    }
}
