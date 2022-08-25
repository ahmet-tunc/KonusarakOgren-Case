using Core.Entities.Concrete;

namespace KonusarakOgren.Entities.Concrete
{
    public  class ProductDiscount:Entity
    {
        public int ProductFeatureId { get; set; }
        public decimal DiscountPercentage { get; set; }
    }
}
