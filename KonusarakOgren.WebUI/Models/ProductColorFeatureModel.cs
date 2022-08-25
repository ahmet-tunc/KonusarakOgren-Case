using Core.Entities.Concrete;

namespace KonusarakOgren.WebUI.Models
{
    public class ProductColorFeatureModel:Entity
    {
        public string? PrimaryColor { get; set; }
        public string? SecondaryColor { get; set; }
    }
}