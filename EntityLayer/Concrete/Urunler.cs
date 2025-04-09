 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EntityLayer.Concrete
{
    [Index(nameof(BarkodNo), IsUnique = true)]
    public class Urunler : EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int MarkaId { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string Adi { get; set; }
        [Column(TypeName = "varchar(13)")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string BarkodNo { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Aciklama { get; set; }
        public int? BirimId { get; set; }
        public decimal AlisFiyat { get; set; }
        public decimal SatisFiyat { get; set; }
        public int KritikStokMiktarı { get; set; }
        public int EksikStokMiktarı { get; set; }
        public int Stok { get; set; }
        public int UrunOzellikId { get; set; }
        [ForeignKey("UrunOzellikId")]
        public UrunOzellikleri urunOzellikleri { get; set; }
        public ICollection<Islemler> Islemler { get; set; }
        public ICollection<Toptancilar> Toptancilar { get; set; }
        public ICollection<CartItem> cartitem { get; set; }
        public ICollection<Stok> Stoklar { get; set; }
    }
}
