using Core.Entities.Concrete;
using System.ComponentModel.DataAnnotations;

namespace KonusarakOgren.WebUI.Models
{
    public class RoleViewModel
    {
        public string Id { get; set; }
        [Display(Name = "Rol ismi")]
        [Required(ErrorMessage = "Role ismi gereklidir")]
        public string Name { get; set; }

    }
}