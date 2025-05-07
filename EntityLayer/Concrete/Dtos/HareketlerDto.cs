using EntityLayer.Concrete.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete.Dtos
{
    public class HareketlerDto
    {
        public int Id { get; set; }
        public string KisiAdi { get; set; }
        public string DepoAdi { get; set; }
        public string UrunAdi { get; set; }
        public int Miktar { get; set; }
        public int BirimFiyat { get; set; }
        public int ToplamFiyat { get; set; }
        public DateTime Tarih { get; set; } = DateTime.Now;
        public IslemTuru IslemTuru { get; set; }
    }
}
