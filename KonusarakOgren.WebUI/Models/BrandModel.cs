using Core.Entities.Concrete;

namespace KonusarakOgren.WebUI.Models
{
    public class BrandModel:Entity
    {
        public string? Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
