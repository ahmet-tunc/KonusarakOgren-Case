using Core.Entities.Concrete;

namespace KonusarakOgren.WebUI.Models
{
    public class BasketItemModel : Entity
    {
        public int ProductId { get; set; }
        public ProductModel Product { get; set; }

        public int ProductFeatureId { get; set; }
        public ProductFeatureModel ProductFeature { get; set; }

        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}
