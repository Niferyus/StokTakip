using EntityLayer.Concrete.Enums;

namespace EntityLayer.Class
{
    public class ProductFilter
    {
        public string? Marka { get; set; }
        public string? Adi { get; set; }
        public string? Barkod { get; set; }
        public StokMiktar? StokMiktar { get; set; }
        public string? BaslangicTarihi { get; set; }
        public string? BitisTarihi { get; set; }
    }
}
