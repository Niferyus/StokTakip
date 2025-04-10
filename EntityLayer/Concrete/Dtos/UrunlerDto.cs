using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace EntityLayer.Concrete.Dtos
{
    public class UrunlerDto
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Marka alanı boş geçilemez")]
        public string MarkaAdi { get; set; }
        [Required(ErrorMessage = "İsim alanı boş geçilemez")]
        [StringLength(20, ErrorMessage = "İsim en fazla 50 karakter olabilir")]
        public string Adi { get; set; }
        [Required(ErrorMessage = "Barkod alanı boş geçilemez")]
        [StringLength(maximumLength: 13, ErrorMessage = "Barkod 13 haneli olmalıdır", MinimumLength = 13)]
        public string BarkodNo { get; set; }
        [StringLength(maximumLength: 100, ErrorMessage = "En fazla 100 karakter olmalı")]
        public string Aciklama { get; set; }
        public string BirimAdi { get; set; }
        [DataType(DataType.Currency, ErrorMessage = "Veri tipini doğru girin")]
        [Range(0, double.MaxValue, ErrorMessage = "Alış fiyatı negatif olamaz!")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
        [Required(ErrorMessage = "Alış fiyatı alanı boş geçilemez")]
        public decimal AlisFiyat { get; set; }
        [DataType(DataType.Currency, ErrorMessage = "Veri tipini doğru girin")]
        [Range(0, double.MaxValue, ErrorMessage = "Satış fiyatı negatif olamaz!")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
        [Required(ErrorMessage = "Alış fiyatı alanı boş geçilemez")]
        public decimal SatisFiyat { get; set; }
        [Required(ErrorMessage = "Stok miktarı alanı boş geçilemez")]
        [Range(0, double.MaxValue, ErrorMessage = "Satış fiyatı negatif olamaz!")]
        public int Stok { get; set; }
        public DateTime Tarih { get; set; }
        [Required(ErrorMessage = "Kritik stok miktarı alanı boş geçilemez")]
        public int KritikStokMiktarı { get; set; }
        [Required(ErrorMessage = "Eksik stok miktarı alanı boş geçilemez")]
        public int EksikStokMiktarı { get; set; }
        [Required(ErrorMessage = "Depo alanı boş geçilemez")]
        public string DepoAdi { get; set; }
        public string DepoVerileri { get; set; }
    }
}
