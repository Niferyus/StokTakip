using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class MusteriUrunDto
    {
        public int UrunId { get; set; }
        public string UrunAdi { get; set; }

        public int UrunFiyati { get; set; }

        public int UrunStok { get; set; }
    }
}
