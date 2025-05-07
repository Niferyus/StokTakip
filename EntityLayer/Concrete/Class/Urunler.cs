using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EntityLayer.Concrete.Class
{
    [Index(nameof(BarkodNo), IsUnique = true)]
    public class Urunler : EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string Adi { get; set; }
        [Column(TypeName = "varchar(13)")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string BarkodNo { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Aciklama { get; set; } = "aciklama";     
        public decimal AlisFiyat { get; set; } = decimal.Zero;
        public decimal SatisFiyat { get; set; } = decimal.Zero;
        public int KritikStokMiktarı { get; set; } = 0;
        public int EksikStokMiktarı { get; set; } = 0;
        public int Stok { get; set; } = 0;
        public int MarkaId { get; set; } = 4;
        public UrunOzellikleri Marka { get; set; }
        public int BirimId { get; set; } = 6;
        public UrunOzellikleri Birim { get; set; }
        public ICollection<Hareketler> Hareketler { get; set; }
        public ICollection<Toptancilar> Toptancilar { get; set; }
        public ICollection<CartItem> cartitem { get; set; }
        public ICollection<Stok> Stoklar { get; set; }
    }
}
