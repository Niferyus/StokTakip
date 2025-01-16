using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class CartItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int CartID { get; set; }

        public int UrunID { get; set; }

        public int Adet { get; set; }

        public decimal Fiyat { get; set; }

        [ForeignKey("CartID")]
        public Cart cart { get; set; }

        [ForeignKey("UrunID")]
        public Urunler Urun { get; set; }
    }
}
