using System.ComponentModel.DataAnnotations;

namespace KonusarakOgren.WebUI.Models
{
    public class LoginViewModel
    {
        [Display(Name ="E-Mail")]
        [Required(ErrorMessage = "Email alanının girilmesi zorunludur")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Parola")]
        [Required(ErrorMessage = "Password alanının girilmesi zorunludur")]
        [DataType(DataType.Password)]
        [MinLength(4,ErrorMessage = "Parola uzunluğu en az 4 karakter olmalıdır")]
        public string Password { get; set; }
    }
}
