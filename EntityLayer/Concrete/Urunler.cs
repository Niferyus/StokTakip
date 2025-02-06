using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Urunler : EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage ="Marka alanı boş geçilemez")]
        public string Marka { get; set; }
        [Required(ErrorMessage ="İsim alanı boş geçilemez")]
        public string Adi { get; set; }
        [StringLength(13,ErrorMessage ="Barkod 13 haneli olmalıdır")]
        public string BarkodNo { get; set; }
        [StringLength(50,ErrorMessage ="En fazla 50 karakter olmalı")]
        public string Aciklama { get; set; }
        public string? Birim { get; set; }
        //[DataType(DataType.Currency)]
        [Required(ErrorMessage ="Alış fiyatı alanı boş geçilemez")]
        public decimal AlisFiyat { get; set; }
        //[DataType(DataType.Currency)]
        [Required(ErrorMessage ="Satış Fiyatı alanı boş geçilemez")]
        public decimal SatisFiyat { get; set; }
        [Required(ErrorMessage ="Stok miktarı alanı boş geçilemez")]
        public int Stok { get; set; }
        public ICollection<Islemler> Islemler { get; set; }

        public ICollection<Toptancilar> Toptancilar { get; set; }

        public ICollection<CartItem> cartitem { get; set; }
    }
}
