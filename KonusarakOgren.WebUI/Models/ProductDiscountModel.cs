using Core.Entities.Concrete;

namespace KonusarakOgren.WebUI.Models
{
    public  class ProductDiscountModel:Entity
    {
        public int ProductFeatureId { get; set; }
        public decimal DiscountPercentage { get; set; }
    }
}
