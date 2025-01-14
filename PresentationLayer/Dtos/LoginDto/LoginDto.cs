using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Dtos.LoginDto
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Kullanıcı Adını giriniz")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Şifreyi giriniz")]
        public string Password { get; set; }
    }
}

