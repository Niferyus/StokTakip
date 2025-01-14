using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Dtos.RegisterDto
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "Ad alanı gereklidir")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyad alanı gereklidir")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Kullanıcı adı alanı gereklidir")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Mail alanı gereklidir")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Şifre alanı gereklidir")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).+$",
        ErrorMessage = "Şifre en az bir büyük harf, bir küçük harf, bir rakam ve bir özel karakter içermelidir.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre tekrar alanı gereklidir")]
        [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor")]
        public string ConfirmPassword { get; set; }
    }
}
