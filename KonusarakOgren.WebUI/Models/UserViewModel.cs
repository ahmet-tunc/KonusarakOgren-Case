using System.ComponentModel.DataAnnotations;

namespace KonusarakOgren.WebUI.Models
{
    public class UserViewModel
    {
        [Display(Name ="Kullanıcı Adı")]
        public string UserName { get; set; }

        [Display(Name = "Telefon Numarası")]
        public string PhoneNumber { get; set; }

        [Display(Name = "E-Mail")]
        [EmailAddress(ErrorMessage = "E-Mail adresiniz doğru formatta değil")]
        public string Email { get; set; }

        [Display(Name = "Parola")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
