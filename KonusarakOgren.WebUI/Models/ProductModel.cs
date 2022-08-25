using Core.Entities.Concrete;
using KonusarakOgren.Entities.Concrete;

namespace KonusarakOgren.WebUI.Models
{
    public class ProductModel : Entity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public int BrandId { get; set; }
        public BrandModel Brand { get; set; }

        public List<ProductFeatureModel> ProductFeatures { get; set; }
    }
}
