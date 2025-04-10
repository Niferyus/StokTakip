using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete.Dtos
{
    public class ToptancilarDto
    {
        public int ToptanciID { get; set; }
        public string ToptanciAdi { get; set; }
        public string UrunAdi { get; set; }
        public int Adet { get; set; }
        public int SatisFiyati { get; set; }
    }
}
