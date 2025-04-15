
using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Models
{
    public class StockChange
    {
        [Required]
        public int StockId { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "StockId pozitif bir değer olmalıdır.")]
        public int Miktar { get; set; }
    }
}
