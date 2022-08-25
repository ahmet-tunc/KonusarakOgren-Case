using Core.Entities.Concrete;

namespace KonusarakOgren.Entities.Concrete
{
    public class BasketItem : Entity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int ProductFeatureId { get; set; }
        public ProductFeature ProductFeature { get; set; }

        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}
