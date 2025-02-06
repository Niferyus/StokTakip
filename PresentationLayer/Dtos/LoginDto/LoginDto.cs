using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Dtos.LoginDto
{
    public class LoginDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Kullanıcı Adını giriniz")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Şifreyi giriniz")]
        public string Password { get; set; }
    }
}

