using Microsoft.AspNetCore.Mvc.Rendering;

namespace PresentationLayer.Models
{
    public class KisiViewModel
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string FirmaAdi { get; set; }
        public string Telefon { get; set; }
        public string Eposta { get; set; }
        public string Adres { get; set; }
        public List<int> SecilenTurler { get; set; } = new List<int>();

        public List<SelectListItem> TumTurler { get; set; }
    }
}
