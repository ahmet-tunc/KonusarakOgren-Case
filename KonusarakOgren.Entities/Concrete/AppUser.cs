using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace KonusarakOgren.Entities.Concrete
{
    public class AppUser:IdentityUser
    {
        public int? BrandId { get; set; }
        public Brand? Brand { get; set; }
    }
}
