using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete
{
    public class IslemlerDto
    {
        public int IslemlerId { get; set; }
        public string UrunAdi { get; set; }
        public string MusteriAdi { get; set; }
        public string ToptanciAdi { get; set; }
        public int Adet { get; set; }
        public decimal ToplamFiyat { get; set; }
        public DateTime Tarih { get; set; }
        public bool SatisTipi { get; set; }
    }
}
