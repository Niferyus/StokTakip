using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete.Dtos
{
    public class DepoDto
    {
        public int Id { get; set; }
        [StringLength(50, ErrorMessage = "İsim en fazla 50 karakter olabilir")]
        [Required(ErrorMessage = "Depo adı girmeniz gerekmektedir")]
        public string Ad { get; set; }
        [Required(ErrorMessage = "Şehir seçmeniz gerekmektedir")]
        public string Sehir { get; set; }
        [Required(ErrorMessage = "İlçe seçmeniz gerekmektedir")]
        public string Ilce { get; set; }
        [StringLength(50, ErrorMessage = "Adres en fazla 50 karakter olabilir")]
        [Required(ErrorMessage = "Adres bilgisi girmeniz gerekmektedir")]
        public string Adres { get; set; }
        [EmailAddress(ErrorMessage = "Geçerli bir mail adresi giriniz")]
        [Required(ErrorMessage = "Lütfen Mail Giriniz")]
        [MinLength(5, ErrorMessage = "E-posta en az 5 karakter olmalıdır.")]
        [MaxLength(255, ErrorMessage = "E-posta en fazla 255 karakter olabilir.")]
        public string Mail { get; set; }
        [StringLength(20, ErrorMessage = "Adres en fazla 20 karakter olabilir")]
        [Required(ErrorMessage = "Lütfen Yetkili Giriniz")]
        public string Yetkili { get; set; }
        [StringLength(255, ErrorMessage = "Açıklama en fazla 255 karakter olabilir")]
        [Required(ErrorMessage = "Lütfen Acıklama Giriniz")]
        public string Aciklama { get; set; }
    }
}
