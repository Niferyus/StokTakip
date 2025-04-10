using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete.Class
{
    public class Musteriler
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MusteriID { get; set; }
        [Required(ErrorMessage = "Müşteri adı zorunludur.")]
        public string MusteriAdi { get; set; }

        [Required(ErrorMessage = "Müşteri soyadı zorunludur.")]
        public string MusteriSoyadi { get; set; }

        public ICollection<Islemler> Islemler { get; set; }
    }
}
